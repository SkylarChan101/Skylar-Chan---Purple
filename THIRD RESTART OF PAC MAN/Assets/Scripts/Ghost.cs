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
        obstacleLayer = 1 << 8;

        transform.position = new Vector3(-34.89f, -11.57f, -1);
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
            print("bouncing");
            SetDirection(-direction);
        }

        if (collision.gameObject.CompareTag("Pacman"))
        {
            if (frightened)
            {
                obstacleLayer = 1 << 0;
                transform.position = new Vector3(-34.87f, -14.3f, -1);
                body.SetActive(false);
                eyes.SetActive(true);
                blue.SetActive(false);
                white.SetActive(false);
                atHome = true;
                CancelInvoke();
                Invoke("LeaveHome", 4f);
            }
            else
            {
                Destroy(collision.gameObject);
            }
        }
    }

    public void Frighten()
    {
        if (!atHome)
        {
            frightened = true;
            body.SetActive(false);
            eyes.SetActive(false);
            blue.SetActive(true);
            white.SetActive(false);
            Invoke("Flash", 4f);
        }
    }

    private void Flash()
    {
        body.SetActive(false);
        eyes.SetActive(false);
        blue.SetActive(false);
        white.SetActive(true);
        Invoke("Reset", 4f);
    }

    private void Reset()
    {
        frightened = false;
        body.SetActive(true);
        eyes.SetActive(true);
        blue.SetActive(false);
        white.SetActive(false);

    }


}
