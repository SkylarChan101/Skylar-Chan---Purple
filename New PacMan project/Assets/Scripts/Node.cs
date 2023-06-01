using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public LayerMask obstacleLayer;
    public List<Vector2> availableDirections;
    // Start is called before the first frame update
    void Start()
    {
        availableDirections = new List<Vector2>();

        CheckAvailableDirection(Vector2.up);
        CheckAvailableDirection(Vector2.down);
        CheckAvailableDirection(Vector2.left);
        CheckAvailableDirection(Vector2.right);


        if (availableDirections.Count == 0)
        {
            Debug.Log("No available directions");
        }
    }

    private void CheckAvailableDirection(Vector2 newDirection)
    {
        RaycastHit2D hit = Physics2D.BoxCast(transform.position, Vector2.one * 0.75f, 0f, newDirection, 1f, obstacleLayer);

        Debug.Log(hit.collider.gameObject.name);

        if (hit.collider == null)
        {
            availableDirections.Add(newDirection);
        }
    }
}
