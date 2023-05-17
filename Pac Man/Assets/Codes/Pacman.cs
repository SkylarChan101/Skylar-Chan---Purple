using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacMan : Movement
{
    protected override void ChildUpdate()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
    }
    
}

