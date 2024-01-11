using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Tetromino : MonoBehaviour
{
    private float previousTime;
    public float fallTime = 0.8f;
    public static int width = 10;
    public static int height = 20;
    public Vector3 rotationPoint;
    //public int x;
    //public int y;
    public bool ValidMove()
    {
        // this code is used to stop the tetrominoes from falling out of the map
        foreach (Transform child in transform)
        {
            int x = Mathf.RoundToInt(child.transform.position.x);
            int y = Mathf.RoundToInt(child.transform.position.y);

            if (x < 0 || y < 0 )
            {
                return (false);
            }

            if (x >= width || y >= height)
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

        // rotates the tetrominoes
        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            Vector3 convertedPoint = transform.TransformPoint(rotationPoint);
            transform.RotateAround(convertedPoint, Vector3.forward, 90);
            
            if (!ValidMove()) 
            {
                transform.RotateAround(convertedPoint, Vector3.forward, -90);
            }
        }

        // The code below allows the tetrominos to move left and right and move down faster.
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            transform.position += Vector3.left;
            if (!ValidMove())
            {
                transform.position += Vector3.right;
            }
        }

        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            transform.position += Vector3.right;
            //this code also stops the tetrominoes from falling out of the map
            if (!ValidMove())
            {
                transform.position += Vector3.left;
            }
            
        }
         

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            tempTime = tempTime / 10;
        }
        if (Time.time - previousTime > tempTime)
        {
            transform.position += Vector3.down;
            previousTime = Time.time;

            if (!ValidMove())
            {
                transform.position += Vector3.up;
            }
        }
        
    }

   

}
