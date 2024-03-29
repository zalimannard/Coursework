using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLoader : MonoBehaviour
{
    public static int[][] GetField(string id)
    {
        if (id.Equals("1"))
        {
            return new int[][]
            {
                new int[] {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                new int[] {0, 0, -1, -1, -3, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 0, 0},
                new int[] {0, -1, -1, -1, -3, -2, 7, -2, 7, -2, 7, -2, 7, -2, -2, 1, 0},
                new int[] {0, -1, -1, -1, -3, -2, -2, -2, -2, -2, -2, -2, -2, -2, -2, 1, 0},
                new int[] {0, -1, -1, -1, -3, -2, -2, -2, -2, -2, -2, -2, -2, -2, -2, 1, 0},
                new int[] {0, -1, -1, -3, -2, -2, -2, -2, -2, -2, -2, -2, -2, 4, -2, 1, 0},
                new int[] {0, -1, -1, 52, -2, -2, -2, 3, -2, 2, 2, 2, -2, -1, -2, 1, 0},
                new int[] {0, -3, 50, -2, -2, -2, -2, 6, 1, -0, -0, -0, 1, -2, -2, 1, 0},
                new int[] {0, 1, -2, -2, -2, -2, -2, 6, -2, 2, 2, -0, 1, -2, -2, 1, 0},
                new int[] {0, 1, -2, -2, -2, -2, -2, 6, -2, -2, -2, 2, -2, -2, -4, 1, 0},
                new int[] {0, 1, -2, -2, -2, -2, -2, 6, -2, -2, -2, -2, -4, -4, -4, 1, 0},
                new int[] {0, 1, -2, 99, -2, -2, -2, 6, -3, 52, 52, -4, -3, -3, -4, 1, 0},
                new int[] {0, 1, -2, -2, -2, -2, -2, -4, 51, 50, -3, -3, 51, -3, -3, 1, 0},
                new int[] {0, 1, -2, 52, 3, -2, -2, -3, -3, -3, -3, 50, -3, -3, 51, 1, 0},
                new int[] {0, 1, 50, 50, -2, -2, -3, -3, -3, -3, 50, -3, -3, -3, -3, 1, 0},
                new int[] {0, 0, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 0, 0},
                new int[] {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}
            };
        }
        else if (id.Equals("2"))
        {
          //   З
          // Ю   С
          //   В
            return new int[][]
            {
                new int[] {0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0},
                new int[] {0,  -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1,  0},
                new int[] {0,  -1, 52, 99, -3, -3, -3, -3, -3, -3, -3, -3, -3, -3, -3, -3, -1,  0},
                new int[] {0,  -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -3, -1,  0},
                new int[] {0,  -1, -1, -1, -1, -1, 52, 3, 51, 51, 51, 51, 52, -1, -1, -3, -1,  0},
                new int[] {0,  -1, -1, 3, 51, 51, 51, 51, -1, -1, 52, -1, 3, -1, -1, -3, -1,  0},
                new int[] {0,  -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -3, -1,  0},
                new int[] {0,  -1, -1, -3, -3, -3, -3, -3, -3, -3, -3, -3, -3, -1, -1, -3, -1,  0},
                new int[] {0,  -1, -1, -3, -1, -1, -1, -1, -1, -1, -1, -1, -3, -1, -1, -3, -1,  0},
                new int[] {0,  -1, -1, -3, -1, -1, -1, -1, -1, -1, -1, -1, -3, -1, -1, -3, -1,  0},
                new int[] {0,  -1, -1, -3, -1, -1, -1, -3, -3, -3, -3, -3, -3, -1, -1, -3, -1,  0},
                new int[] {0,  -1, -1, -3, -1, -1, -1, 4, 7, 7, 7, 7, -3, -1, -1, -3, -1,  0},
                new int[] {0,  -1, -1, -3, -1, -1, -1, -3, -3, -3, -3, -3, -3, -1, -1, -3, -1,  0},
                new int[] {0,  -1, -1, -3, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -3, -1,  0},
                new int[] {0,  -1, -1, -3, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -3, -1,  0},
                new int[] {0,  -1, -1, -3, -3, -3, -3, -3, -3, -3, -3, -3, -3, -3, -3, -3, -1,  0},
                new int[] {0,  -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1,  0},
                new int[] {0,  -1, 50, -1, 50, -1, 50, -1, 50, -1, 50, -1, 50, -1, 50, -1, -1,  0},
                new int[] {0,  -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1,  0},
                new int[] {0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0}
            };
        }
        else if (id.Equals("3"))
        {
            return new int[][]
            {
                new int[] {0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0},
                new int[]{0,  51, 51, 51, 51, 51, 51, 51, 51, -3, 51, 51, 51, 51, 51, 51, 51, 51, 51, 51, 51, -3, -3, -3, -3, -3,  0},
                new int[]{0,  51, 51, 51, 51, 51, 51, 51, -3, -3, 51, 51, 51, 51, 51, 51, 51, 51, 51, 51, 51, 52, 51, 51, -3, -3,  0},
                new int[]{0,  51, 52, 99, 52, 52, -3, 51, 51, 51, 51, -3, -1, -1, 50, -3, -3, 4, -3, -1, -3, -3, 4, 52, 50, -3,  0},
                new int[]{0,  51, 51, -3, 52, 50, 50, 50, -1, -3, -1, -3, -1, -3, 50, 50, 50, 50, -3, -1, -1, -3, -3, -3, 50, 50,  0},
                new int[]{0,  51, 51, -3, 50, 50, -1, -3, -3, -3, -3, 4, -3, -3, 50, 50, -3, -3, -3, -3, -3, -1, -1, -3, 50, 50,  0},
                new int[]{0,  51, 51, -3, -3, -1, -1, -3, 50, -1, -3, -1, -1, -3, -1, 50, -3, 50, 51, -1, -3, -3, -1, -3, 50, 50,  0},
                new int[]{0,  51, 51, 51, -3, -3, -3, -3, 50, -1, -3, -1, -3, -3, -3, -1, -3, 51, 51, -3, -3, -3, -3, -3, 50, 51,  0},
                new int[]{0,  -3, 50, 51, 51, 51, 51, 51, 50, -1, -3, -1, -1, -1, -1, -1, 4, 51, 51, -1, -3, 50, 50, 50, 50, 51,  0},
                new int[]{0,  -3, -3, 50, -3, -3, -3, -3, -3, -3, -3, -1, -3, -3, -3, -1, -3, 51, 50, -1, -3, -3, -3, 50, -3, 51,  0},
                new int[]{0,  -3, -3, 52, -3, -1, -3, -1, -3, -3, -3, -3, -3, -1, -3, -3, -3, -1, -1, -3, -3, 52, -3, 51, -3, 51,  0},
                new int[]{0,  -3, 52, 50, 50, 50, 50, 50, -1, -1, 50, 50, 51, 51, 51, 51, 51, 50, 50, 50, 50, 51, 51, -3, -3, 51,  0},
                new int[]{0,  51, 51, 51, 51, 51, 51, 51, 51, 51, 51, 51, 51, 51, 51, 51, 51, 51, 50, 51, 51, 51, 51, 51, 51, 51,  0},
                new int[] {0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0}
            };
        }
        else
        {
            return new int[][]
            {
                new int[]{-1, -1, -1},
                new int[]{-1, 99, -1},
                new int[]{-1, -1, -1},
            };
        }
    }
}


// new int[] {0, -1, -1, -3, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 0},
// new int[] {-1, -1, -1, -3, -2, 7, -2, 7, -2, 7, -2, 7, -2, -2, 1},
// new int[] {-1, -1, -1, -3, -2, -2, -2, -2, -2, -2, -2, -2, -2, -2, 1},
// new int[] {-1, -1, -1, -3, -2, -2, -2, -2, -2, -2, -2, -2, -2, -2, 1},
// new int[] {-1, -1, -3, -2, -2, -2, -2, -2, -2, -2, -2, -2, 4, -2, 1},
// new int[] {-1, -1, 52, -2, -2, -2, 3, -2, 2, 2, 2, -2, -1, -2, 1},
// new int[] {-3, 50, -2, -2, -2, -2, 6, 1, -0, -0, -0, 1, -2, -2, 1},
// new int[] {1, -2, -2, -2, -2, -2, 6, -2, 2, 2, -0, 1, -2, -2, 1},
// new int[] {1, -2, -2, -2, -2, -2, 6, -2, -2, -2, 2, -2, -2, -4, 1},
// new int[] {1, -2, -2, -2, -2, -2, 6, -2, -2, -2, -2, -4, -4, -4, 1},
// new int[] {1, -2, 99, -2, -2, -2, 6, -3, 52, 52, -4, -3, -3, -4, 1},
// new int[] {1, -2, -2, -2, -2, -2, -4, 51, 50, -3, -3, 51, -3, -3, 1},
// new int[] {1, -2, 52, 3, -2, -2, -3, -3, -3, -3, 50, -3, -3, 51, 1},
// new int[] {1, 50, 50, -2, -2, -3, -3, -3, -3, 50, -3, -3, -3, -3, 1},
// new int[] {0, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 0}
    
// new int[] {-1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1},
// new int[] {-1, 52, 99, -3, -3, -3, -3, -3, -3, -3, -3, -3, -3, -3, -3, -1},
// new int[] {-1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -3, -1},
// new int[] {-1, -1, -1, -1, -1, 52, 3, 51, 51, 51, 51, 52, -1, -1, -3, -1},
// new int[] {-1, -1, 3, 51, 51, 51, 51, -1, -1, 52, -1, 3, -1, -1, -3, -1},
// new int[] {-1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -3, -1},
// new int[] {-1, -1, -3, -3, -3, -3, -3, -3, -3, -3, -3, -3, -1, -1, -3, -1},
// new int[] {-1, -1, -3, -1, -1, -1, -1, -1, -1, -1, -1, -3, -1, -1, -3, -1},
// new int[] {-1, -1, -3, -1, -1, -1, -1, -1, -1, -1, -1, -3, -1, -1, -3, -1},
// new int[] {-1, -1, -3, -1, -1, -1, -3, -3, -3, -3, -3, -3, -1, -1, -3, -1},
// new int[] {-1, -1, -3, -1, -1, -1, 4, 7, 7, 7, 7, -3, -1, -1, -3, -1},
// new int[] {-1, -1, -3, -1, -1, -1, -3, -3, -3, -3, -3, -3, -1, -1, -3, -1},
// new int[] {-1, -1, -3, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -3, -1},
// new int[] {-1, -1, -3, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -3, -1},
// new int[] {-1, -1, -3, -3, -3, -3, -3, -3, -3, -3, -3, -3, -3, -3, -3, -1},
// new int[] {-1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1},
// new int[] {-1, 50, -1, 50, -1, 50, -1, 50, -1, 50, -1, 50, -1, 50, -1, -1},
// new int[] {-1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1}

// new int[]{51, 51, 51, 51, 51, 51, 51, 51, -3, 51, 51, 51, 51, 51, 51, 51, 51, 51, 51, 51, -3, -3, -3, -3, -3},
// new int[]{51, 51, 51, 51, 51, 51, 51, -3, -3, 51, 51, 51, 51, 51, 51, 51, 51, 51, 51, 51, 52, 51, 51, -3, -3},
// new int[]{51, 52, 99, 52, 52, -3, 51, 51, 51, 51, -3, -1, -1, 50, -3, -3, 4, -3, -1, -3, -3, 4, 52, 50, -3},
// new int[]{51, 51, -3, 52, 50, 50, 50, -1, -3, -1, -3, -1, -3, 50, 50, 50, 50, -3, -1, -1, -3, -3, -3, 50, 50},
// new int[]{51, 51, -3, 50, 50, -1, -3, -3, -3, -3, 4, -3, -3, 50, 50, -3, -3, -3, -3, -3, -1, -1, -3, 50, 50},
// new int[]{51, 51, -3, -3, -1, -1, -3, 50, -1, -3, -1, -1, -3, -1, 50, -3, 50, 51, -1, -3, -3, -1, -3, 50, 50},
// new int[]{51, 51, 51, -3, -3, -3, -3, 50, -1, -3, -1, -3, -3, -3, -1, -3, 51, 51, -3, -3, -3, -3, -3, 50, 51},
// new int[]{-3, 50, 51, 51, 51, 51, 51, 50, -1, -3, -1, -1, -1, -1, -1, 4, 51, 51, -1, -3, 50, 50, 50, 50, 51},
// new int[]{-3, -3, 50, -3, -3, -3, -3, -3, -3, -3, -1, -3, -3, -3, -1, -3, 51, 50, -1, -3, -3, -3, 50, -3, 51},
// new int[]{-3, -3, 52, -3, -1, -3, -1, -3, -3, -3, -3, -3, -1, -3, -3, -3, -1, -1, -3, -3, 52, -3, 51, -3, 51},
// new int[]{-3, 52, 50, 50, 50, 50, 50, -1, -1, 50, 50, 51, 51, 51, 51, 51, 50, 50, 50, 50, 51, 51, -3, -3, 51},
// new int[]{51, 51, 51, 51, 51, 51, 51, 51, 51, 51, 51, 51, 51, 51, 51, 51, 51, 50, 51, 51, 51, 51, 51, 51, 51}