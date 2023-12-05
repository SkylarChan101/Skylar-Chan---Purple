using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    public SpriteRenderer smallRenderer;
    public SpriteRenderer bigRenderer;
    private Animator smallAnimator;
    public bool big;
    // Start is called before the first frame update
    public void Start()
    {
        smallAnimator = smallRenderer.gameObject.GetComponent<Animator>();
        big = false;
    }

    public void Hit()
    {
        if (big)
        {
            Shrink();
        }
        else
        {
            Death();
        }
    }

    private void Shrink()
    {
        smallRenderer.enabled = true;
        bigRenderer.enabled = false;

        GetComponent<CapsuleCollider2D>().size = Vector2.one;
        GetComponent<CapsuleCollider2D>().offset = Vector2.zero;

        big = false;
        StartCoroutine("ChangeSize");
    }

    public void Grow()
    {
        if (big)
        {
            return;
        }

        smallRenderer.enabled = false;
        bigRenderer.enabled = true;

        GetComponent<CapsuleCollider2D>().size = new Vector2(1f, 2f);
        GetComponent<CapsuleCollider2D>().offset = new Vector2(0, 0.5f);

        big = true;
        StartCoroutine("ChangeSize");

    }

    private void Death()
    {
        smallAnimator.SetTrigger("Death");

        GetComponent<CapsuleCollider2D>().enabled = false;

        GetComponent<Rigidbody2D>().velocity = Vector2.up * 10;
        GetComponent<PlayerMovement>().enabled = false;
        Destroy(gameObject, 0.5f);
    }

    private IEnumerator ChangeSize()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        Vector3 velocity = rb.velocity;
        GetComponent<PlayerMovement>().enabled = false;
        GetComponent<CapsuleCollider2D>().enabled = false;
        rb.velocity = Vector3.zero;
        rb.isKinematic = true;

        for (int i = 0; i < 8; i++)
        {
            bigRenderer.enabled = !bigRenderer.enabled;
            smallRenderer.enabled = !smallRenderer.enabled;
            yield return new WaitForSeconds(0.25f);
        }

        rb.isKinematic = false;
        rb.velocity = velocity;
        GetComponent<PlayerMovement>().enabled = true;
        GetComponent<CapsuleCollider2D>().enabled = true;
    }
}
