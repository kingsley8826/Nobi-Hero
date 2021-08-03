using UnityEngine;
using System.Collections;

public class CoinManager : ScriptableObject{

    public static void createX(GameObject star, Vector3 location)
    {
        int[,] map = new int[7, 7] {
            { 1, 0, 0, 0, 0, 0, 1 },
            { 0, 1, 0, 0, 0, 1, 0 },
            { 0, 0, 1, 0, 1, 0, 0 },
            { 0, 0, 0, 1, 0, 0, 0 },
            { 0, 0, 1, 0, 1, 0, 0 },
            { 0, 1, 0, 0, 0, 1, 0 },
            { 1, 0, 0, 0, 0, 0, 1 }
        };
        drawStar(map, star, location);
    }
    public static void createXXX(GameObject star, Vector3 location)
    {
        int[,] map = new int[5, 13] {
            { 1, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 1 },
            { 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0 },
            { 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0 },
            { 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0 },
            { 1, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 1 }
        };
        drawStar(map, star, location);
    }
    public static void createRectangle(GameObject star, Vector3 location)
    {
        int[,] map = new int[5, 8] {
           { 1, 1, 1, 1, 1, 1, 1, 1 },
           { 1, 0, 0, 0, 0, 0, 0, 1 },
           { 1, 0, 1, 1, 1, 1, 0, 1 },
           { 1, 0, 0, 0, 0, 0, 0, 1 },
           { 1, 1, 1, 1, 1, 1, 1, 1 }
        };
        drawStar(map, star, location);
    }

    public static void createTriangle(GameObject star, Vector3 location)
    {
        int[,] map = new int[5, 9] {
            { 0, 0, 0, 0, 1, 0, 0, 0, 0 },
            { 0, 0, 0, 1, 0, 1, 0, 0, 0 },
            { 0, 0, 1, 0, 1, 0, 1, 0, 0 },
            { 0, 1, 0, 1, 0, 1, 0, 1, 0 },
            { 1, 0, 1, 0, 1, 0, 1, 0, 1 }
        };
        drawStar(map, star, location);
    }
    public static void createCircle(GameObject star, Vector3 location)
    {
        int[,] map = new int[7, 7] { 
            { 0, 0, 1, 1, 1, 0, 0 },
            { 0, 1, 0, 0, 0, 1, 0 },
            { 1, 0, 0, 1, 0, 0, 1 },
            { 1, 0, 1, 0, 1, 0, 1 },
            { 1, 0, 0, 1, 0, 0, 1 },
            { 0, 1, 0, 0, 0, 1, 0 },
            { 0, 0, 1, 1, 1, 0, 0 }
        };
        drawStar(map, star, location);
    }
    public static void createHeart(GameObject star, Vector3 location)
    {
        int[,] map = new int[7, 7] {
            { 0, 1, 1, 0, 1, 1, 0 },
            { 1, 0, 0, 1, 0, 0, 1 },
            { 1, 0, 0, 0, 0, 0, 1 },
            { 1, 0, 1, 1, 1, 0, 1 },
            { 0, 1, 0, 1, 0, 1, 0 },
            { 0, 0, 1, 0, 1, 0, 0 },
            { 0, 0, 0, 1, 0, 0, 0 }
        };
        drawStar(map, star, location);
    }

    public static void createHorizontal(GameObject star, Vector3 location)
    {
        int[,] map = new int[2, 6] {
            { 1, 1, 1, 1, 1, 1 },
            { 1, 1, 1, 1, 1, 1 }
        };
        drawStar(map, star, location);
    }
    public static void createCrossLine1(GameObject star, Vector3 location)
    {
        int[,] map = new int[3, 7] {
            { 1, 0, 0, 0, 1, 0, 0},
            { 0, 1, 0, 1, 0, 1, 0},
            { 0, 0, 1, 0, 0, 0, 1}
        };
        drawStar(map, star, location);
    }
    public static void createCrossLine2(GameObject star, Vector3 location)
    {
        int[,] map = new int[3, 7] {
            { 0, 0, 1, 0, 0, 0, 1},
            { 0, 1, 0, 1, 0, 1, 0},
            { 1, 0, 0, 0, 1, 0, 0}
        };
        drawStar(map, star, location);
    }

    public static void createSquare(GameObject star, Vector3 location)
    {
        int[,] map = new int[3, 3] {
            { 1, 1, 1},
            { 1, 1, 1},
            { 1, 1, 1}
        };
        drawStar(map, star, location);
    }
    public static void createMiniCircle(GameObject star, Vector3 location)
    {
        int[,] map = new int[3, 4] {
            { 0, 1, 1, 0 },
            { 1, 1, 1, 1 },
            { 0, 1, 1, 0 },
        };
        drawStar(map, star, location);
    }


    private static void drawStar(int[,] map, GameObject star, Vector3 location)
    {
        float locationX = location.x;
        for (int i = 0; i < map.GetLength(0); i++)
        {
            location.x = locationX;
            for (int j = 0; j < map.GetLength(1); j++)
            {
                if (map[i, j] == 1)
                {
                    Instantiate(star, location, Quaternion.identity);
                }
                location.x += 0.5f;
            }
            location.y -= 0.5f;
        }
    }
}
