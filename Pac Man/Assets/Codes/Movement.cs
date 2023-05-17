using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Movement : MonoBehaviour
{
    public float speed;
    public Vector2 initialDirection;
    public LayerMask obstacleLayer;

    protected Rigidbody2D rb;
    [SerializeField]
    protected Vector2 direction;
    protected Vector2 nextDirection;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        direction = initialDirection;
        nextDirection = Vector2.zero;
    }

    // Update is called once per frame
    void Update()
    {
        if (nextDirection != Vector2.zero)
        {
            SetDirection(nextDirection);
        }
        ChildUpdate();
        
    }
<<<<<<< HEAD
    abstract protected void ChildUpdate();
    private void FixedUpdate()
    {
        Vector2 position = rb.position;
        Vector2 translation = direction * speed * Time.fixedDeltaTime;

        rb.MovePosition(position + translation);
    }

    private bool Occupied(Vector2 newDirection)
    {
        RaycastHit2D hit = Physics2D.BoxCast(transform.position, Vector2.one * 0.75f, 0f, newDirection, 1, 5f, obstacleLayer);
        return hit.collider != null;
    }

    protected void SetDirection(Vector2 newDirection)
    {
        if (!Occupied(newDirection))
        {
            direction = newDirection;
            nextDirection = Vector2.zero;
        }
        else
        {
            nextDirection = newDirection;
        }
=======

    void FixedUpdate()
    {
        Vector2 position = rb.position;
        Vector2 translation = direction * speed * Time.fixedDeltaTime;
        rb.MovePosition(position + translation);
        Debug.Log(translation+translation);
>>>>>>> 082f93b09eac894ed64d106c4c35c63b7a713867
    }
}

