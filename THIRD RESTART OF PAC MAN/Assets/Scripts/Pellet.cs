using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pellet : MonoBehaviour
{
    protected virtual void Eat()
    {
        gameObject.SetActive(false);
    }
}

