using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenWrap : MonoBehaviour
{
    private Vector2 screenMin;
    private Vector2 screenMax;
    // Start is called before the first frame update
    void Start()
    {
        screenMin = Camera.main.ScreenToWorldPoint(new Vector2(0, 0));
        screenMax = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
    }

    // Update is called once per frame
    void Update()
    {
        float x = transform.position.x;
        float y = transform.position.y;

        //left side
        if (x > screenMax.x)
        {
            transform.position = new Vector2(screenMin.x, y);
        }
        //right side
        if (x < screenMin.x)
        {
            transform.position = new Vector2(screenMax.x, y);
        }
        //top side
        if (y > screenMax.y)
        {
            transform.position = new Vector2(x, screenMin.y);
        }
        //bottum side
        if (y < screenMin.y)
        {
            transform.position = new Vector2(x, screenMax.y);
        }
    }
}
