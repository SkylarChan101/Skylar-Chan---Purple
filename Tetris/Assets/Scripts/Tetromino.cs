using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Tetromino : MonoBehaviour
{
    private float previousTime;
    public float fallTime = 0.8f;
    public static int width = 10;
    public static int height = 20;
    public int x;
    public int y;
    public bool ValidMove()
    {
        foreach (Transform child in transform)
        {
            int x = Mathf.RoundToInt(child.transform.position.x);
            int y = Mathf.RoundToInt(child.transform.position.y);

            if (x < 0 || y < 0 )
            {
                return (false);
            }

            if (x >= 0 || y >= 0)
            {
                return (false);
            }
        }
        return (true);
    }

    // Update is called once per frame
    void Update()
    {
        float tempTime = fallTime;


        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            transform.position += Vector3.left;
            if (!ValidMove())
            {

            }
        }

        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            transform.position += Vector3.right;
        }


        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            tempTime = tempTime / 10;
        }
        if (Time.time - previousTime > tempTime)
        {
            transform.position += Vector3.down;
            previousTime = Time.time;
        }
    }

}
