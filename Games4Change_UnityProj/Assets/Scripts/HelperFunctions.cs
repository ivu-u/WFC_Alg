using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using System.Linq;
using TMPro;

public class HelperFunctions : MonoBehaviour 
{
    //info panel
    public GameObject panel;
    public TextMeshProUGUI labelText;
    public TextMeshProUGUI positionText;
    public TextMeshProUGUI possibilitiesText;
    public TextMeshProUGUI allowedLeftText;
    public TextMeshProUGUI allowedRightText;
    public TextMeshProUGUI allowedUpText;
    public TextMeshProUGUI allowedDownText;

    //not collapsed - -1
    //wall - 0
    //void - 1
    //ground - 2
    //entrance - 3
    //exit - 4
    // dumps the information of the current room matrix to the console
    public void dumpMatrix(NewNode[,] matrix)
    {
        StringBuilder sb = new StringBuilder();
        for(int i=0; i < matrix.GetLength(1); i++)
        {
            for(int j=0; j < matrix.GetLength(0); j++)
            {
                if (!matrix[i,j].isCollapsed)
                {
                    sb.Append(-1);
                    sb.Append(",");				   
                }
                else
                {
                    switch(matrix[i,j].possibilities.First())
                    {
                        case "wallTile":
                            sb.Append(0);
                            sb.Append(",");
                            break;
                        case "voidTile":
                            sb.Append(1);
                            sb.Append(",");
                            break;
                        case "groundTile":
                            sb.Append(2);
                            sb.Append(",");
                            break;
                        case "entranceTile":
                            sb.Append(3);
                            sb.Append(",");
                            break;
                        case "exitTile":
                            sb.Append(4);
                            sb.Append(",");
                            break;
                    }
                }
            }
            sb.AppendLine();
        }
        Debug.Log(sb.ToString());
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);
            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
            // Casts the ray and get the first game object hit
            if (hit.collider.gameObject.GetComponent<Identify>() != null) {
                Debug.Log("Run");
                GameObject item = hit.collider.gameObject;
                Display(item);
            }
        }
    }

    void Display(GameObject get)
    {
        NewNode n = this.GetComponent<NewWFC>().roomMatrix[get.GetComponent<Identify>().posY, get.GetComponent<Identify>().posX];
        panel.SetActive(true);
        labelText.text = n.label;
        positionText.text = "(" + n.positionY + ", " + n.positionX + ")";

        possibilitiesText.text = "";
        foreach (string s in n.possibilities)
        {
            possibilitiesText.text += s + "\n\r";
        }

        allowedUpText.text = "";
        foreach (string s in n.allowedAboveThisNode)
        {
            allowedUpText.text += s + "\n\r";
        }

        allowedDownText.text = "";
        foreach (string s in n.allowedBelowThisNode)
        {
            allowedDownText.text += s + "\n\r";
        }

        allowedRightText.text = "";
        foreach (string s in n.allowedRightThisNode)
        {
            allowedRightText.text += s + "\n\r";
        }

        allowedLeftText.text = "";
        foreach (string s in n.allowedLeftThisNode)
        {
            allowedLeftText.text += s + "\n\r";
        }
    }

    public void CloseWindow ()
    {
        panel.SetActive(false);
    }

    public void KeepGen ()
    {
        this.GetComponent<NewWFC>().canGo = true;
    }
}