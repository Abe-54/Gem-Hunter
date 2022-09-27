using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeController : MonoBehaviour
{
    [Header("Attributes")]
    [SerializeField] private int attackPower = 10;
    private int direction = -1;
    private bool facingRight = true;
    public int health = 100;
    private int maxHealth = 100;
    [SerializeField] private float maxSpeed;
    [SerializeField] private LayerMask raycastLayerMask;
    [SerializeField] private Vector2 raycastOffset;
    [SerializeField] private float verticalRaycastLength = 2;
    [SerializeField] private float horizontalRaycastLength = 2;


    [Header("References")]
    private RaycastHit2D rightLedgeRaycastHit;
    private RaycastHit2D leftLedgeRaycastHit;
    private RaycastHit2D rightWallRaycastHit;
    private RaycastHit2D leftWallRaycastHit;
    private Rigidbody2D rb2d;
    private SpriteRenderer sprite;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();

        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        rb2d.velocity = new Vector2(direction * maxSpeed, rb2d.velocity.y);

        //Check for right ledge
        rightLedgeRaycastHit = Physics2D.Raycast(new Vector2(transform.position.x + raycastOffset.x, transform.position.y + raycastOffset.y), Vector2.down, verticalRaycastLength, raycastLayerMask);
        Debug.DrawRay(new Vector2(transform.position.x + raycastOffset.x, transform.position.y + raycastOffset.y), Vector2.down * verticalRaycastLength, Color.red);
        if (rightLedgeRaycastHit.collider == null) direction = -1;


        //Check for left ledge
        leftLedgeRaycastHit = Physics2D.Raycast(new Vector2(transform.position.x - raycastOffset.x, transform.position.y + raycastOffset.y), Vector2.down, verticalRaycastLength, raycastLayerMask);
        Debug.DrawRay(new Vector2(transform.position.x - raycastOffset.x, transform.position.y + raycastOffset.y), Vector2.down * verticalRaycastLength, Color.green);
        if (leftLedgeRaycastHit.collider == null) direction = 1;

        //Check for right wall
        rightWallRaycastHit = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y), Vector2.right, horizontalRaycastLength, raycastLayerMask);
        Debug.DrawRay(new Vector2(transform.position.x, transform.position.y), Vector2.right * horizontalRaycastLength, Color.yellow);
        if (rightWallRaycastHit.collider != null) direction = -1;

        //Check for left wall
        leftWallRaycastHit = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y), Vector2.left, horizontalRaycastLength, raycastLayerMask);
        Debug.DrawRay(new Vector2(transform.position.x, transform.position.y), Vector2.left * horizontalRaycastLength, Color.magenta);
        if (leftWallRaycastHit.collider != null) direction = 1;

        if ((direction > 0 && !facingRight) || (direction < 0 && facingRight))
        {
            Flip();
        }

        if (health <= 0)
        {
            //DIE
            gameObject.SetActive(false);
            //TODO: add particle effects
            //TODO: add sound effects
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        transform.rotation = Quaternion.Euler(0, facingRight ? 0 : 180, 0);
    }

    public void TakeDamage(int damageToTake)
    {
        health -= damageToTake;
    }
}
