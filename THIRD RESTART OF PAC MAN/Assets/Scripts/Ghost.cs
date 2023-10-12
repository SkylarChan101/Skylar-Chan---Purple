using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Ghost : Movement
{
    public GameObject body;
    public GameObject eyes;
    public GameObject blue;
    public GameObject white;
    public bool frightened;
    public float homeDuration;
    public bool atHome;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Node node = collision.GetComponent<Node>();

        if (node != null)
        {
            int index = Random.Range(0, node.availableDirections.Count);

            if (node.availableDirections[index] == direction)
            {
                index += 1;

                if (index == node.availableDirections.Count)
                {
                    index = 0;
                }
            }
            SetDirection(node.availableDirections[index]);

        }
    }

    protected override void ChildUpdate()
    {
        
    }

    private void Update()
    {
        
    }

    private void Awake()
    {
        body.SetActive(true);
        eyes.SetActive(true);
        blue.SetActive(false);
        white.SetActive(false);
        frightened = false;
        Invoke("LeaveHome", homeDuration);
    }

    private void LeaveHome()
    {
        transform.position = new Vector3(-34, -10.9f, -1f);
        direction = new Vector2(-1, 0);
        atHome = false;
        frightened = false;
        body.SetActive(true);
        eyes.SetActive(true);
        blue.SetActive(false);
        white.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (atHome && collision.gameObject.layer == LayerMask.NameToLayer("Obstacle"))
        {
            SetDirection(-direction);
        }
    }
}
