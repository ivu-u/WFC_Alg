using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using System.Linq;

public class HelperFunctions : MonoBehaviour 
{
    //not collapsed - -1
    //wall - 1
    //void - 2
    //ground - 3
    //entrance - 4
    //exit - 5
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
                    sb.Append(' ');				   
                }
                else
                {
                    switch(matrix[i,j].possibilities.First())
                    {
                        case "wallTile":
                            sb.Append(1);
                            sb.Append(", ");
                            break;
                        case "voidTile":
                            sb.Append(2);
                            sb.Append(", ");
                            break;
                        case "groundTile":
                            sb.Append(3);
                            sb.Append(", ");
                            break;
                        case "entranceTile":
                            sb.Append(4);
                            sb.Append(", ");
                            break;
                        case "exitTile":
                            sb.Append(5);
                            sb.Append(", ");
                            break;
                    }
                }
            }
            sb.AppendLine();
        }
        Debug.Log(sb.ToString());
    }
}