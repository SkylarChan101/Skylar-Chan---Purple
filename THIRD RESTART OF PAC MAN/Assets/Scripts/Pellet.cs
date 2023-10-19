using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pellet : MonoBehaviour
{
    protected virtual void Eat()
    {
        gameObject.SetActive(false);
    }

  
    private void OnTriggerEnter2D(Collider2D collision)
    {
           
        if (collision.gameObject.CompareTag("Pacman"))
        {
            Eat();
        }
    }
}

