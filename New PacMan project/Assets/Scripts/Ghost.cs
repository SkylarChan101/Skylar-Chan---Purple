using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : Movement
{
    public GameObject body;
    public GameObject eyes;
    public GameObject blue;
    public GameObject white;
    public bool atHome;
    public bool frightened;
    public float homeDuration;
    protected override void ChildUpdate()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Node node = collision.GetComponent<Node>();

        if (node != null)
        {

            
            int index = Random.Range(0, node.availableDirections.Count);



            if (node.availableDirections[index] == -direction)
            {
                index += 1;
            }
            

            index += 1;

            if (index == node.availableDirections.Count)
            {
                index = 0;
            }

            SetDirection(node.availableDirections[index]);

        }

        

    }

     
}
