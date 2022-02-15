using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    // take the compelted room matrix
    // start in the middle and iterate through to check for ground tiles
    // once a ground tile is found spawn the player

    public void spawnPlayer(NewNode[,] roomMatrix)
    {

    }

    //https://www.geeksforgeeks.org/print-given-matrix-reverse-spiral-form/
    // Function that print matrix in reverse spiral form.
    public static void ReversespiralPrint(int row, int col, NewNode[,] roomMatrix)
    {
        // Large array to initialize it
        // with elements of matrix
        NewNode[] temp = new NewNode[100];

        /* k - starting row index
        l - starting column index*/
        int i, k = 0, l = 0;

        // Counter for single dimension array
        //in which elements will be stored
        int z = 0;

        // Total elements in matrix
        int size = row * col;

        while (k < row && l < col)
        {
            // Variable to store value of matrix.
            NewNode val;

            /* Print the first row from the remaining
            rows */
            for (i = l; i < col; ++i)
            {

                val = roomMatrix[k, i];
                temp[z] = val;
                ++z;
            }
            k++;

            /* Print the last column from the remaining
            columns */
            for (i = k; i < row; ++i)
            {

                val = roomMatrix[i, col - 1];
                temp[z] = val;
                ++z;
            }
            col--;

            /* Print the last row from the remaining
            rows */
            if (k < row)
            {
                for (i = col - 1; i >= l; --i)
                {

                    val = roomMatrix[row - 1, i];
                    temp[z] = val;
                    ++z;
                }
                row--;
            }

            /* Print the first column from the remaining
            columns */
            if (l < col)
            {
                for (i = row - 1; i >= k; --i)
                {

                    val = roomMatrix[i, l];
                    temp[z] = val;
                    ++z;
                }
                l++;
            }
        }

        // check if this tile is ground
        // if so spawn the player
        for (int x = size - 1; x >= 0; --x)
        {
            if (temp[x].label == "groundTile")
            {
                // call spawn player function
                return;
            }
        }
    }
}
