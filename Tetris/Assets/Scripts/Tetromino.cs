using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Tetromino : MonoBehaviour
{
    private float previousTime;
    public float fallTime = 0.8f;
   
    // Update is called once per frame
    void Update()
    {
        float tempTime = fallTime;

       if (Input.GetKeyUp(KeyCode.LeftArrow))
       {
            transform.position += Vector3.left;
       }

       if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            transform.position += Vector3.right;
        }
        

       if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            tempTime = tempTime/10;
        }
       if (Time.time - previousTime > tempTime)
        {
            transform.position += Vector3.down;
            previousTime = Time.time;
        }
    }
}
