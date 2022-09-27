using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStomp : MonoBehaviour
{
    public int damge;

    private Rigidbody2D rb2d;
    public float bounceForce;
    public float slimeBounceForce;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = transform.parent.GetComponent<Rigidbody2D>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Hitbox")
        {
            if (col.transform.parent.gameObject.tag == "Slime") {
                col.transform.parent.gameObject.GetComponent<SlimeController>().TakeDamage(damge);
                rb2d.AddForce(transform.up * slimeBounceForce, ForceMode2D.Impulse);
            }
        }
    }
}
