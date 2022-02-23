using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceGround : MonoBehaviour
{
    NewWFC wfc;
    int yPos;
    int xPos;
    // Start is called before the first frame update
    void Start()
    {
        wfc = GameObject.FindGameObjectWithTag("Dictionary").GetComponent<NewWFC>();
        xPos = (int)this.transform.position.x;
        yPos = (int)this.transform.position.y;
        if(yPos + 1 < wfc.roomDimension && wfc.roomMatrix[yPos + 1,xPos].label == "groundTile")
        {
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 180);
        } else if (yPos - 1 >= 0 && wfc.roomMatrix[yPos - 1, xPos].label == "groundTile")
        {
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 0);
        }
        else if(xPos + 1 < wfc.roomDimension && wfc.roomMatrix[yPos, xPos + 1].label == "groundTile")
        {
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 90);
        }
        else if(xPos - 1 >= 0 && wfc.roomMatrix[yPos, xPos - 1].label == "groundTile")
        {
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 270);
        } 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
