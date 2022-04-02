using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    Rigidbody2D rb;
    Animator anim;
    SpriteRenderer sp;
    CircleCollider2D col;

    public GameObject dieEffect;

    [Header("Move")]
    public float speed;
    public float jumpForce;
    public float jumpFactor;

    [Header("PhysicsCheck")]
    public float checkRadius;
    public LayerMask platform;
    public GameObject groundCheck;

    float moveH;
    bool isGround;
    bool isJump;
    bool playerIsDead;

    void Start()
    {
        
        col = GetComponent<CircleCollider2D>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sp = GetComponent<SpriteRenderer>();        

    }

    void Update()
    {
        GameManager.GameOver(playerIsDead);
        
        isGround = Physics2D.OverlapCircle(groundCheck.transform.position, checkRadius, platform);

        if (rb.velocity.y < 0 || !isGround&&!isJump)
        {
            anim.SetBool("fall", true);
        }
        else
        {
            anim.SetBool("fall", false);
        }
        anim.SetFloat("speed", Mathf.Abs(rb.velocity.x));
        anim.SetBool("jump", isJump);

        moveH = Input.GetAxis("Horizontal") * speed;
        rb.velocity = new Vector2(moveH, rb.velocity.y);

        Jump();
        Flip();
    }

    void Flip()
    {
        if (moveH > 0)
        {
            sp.flipX = false;
        }
       else if (moveH < 0)
        {
            sp.flipX = true;
        }
    }


    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space)&&isGround)
        {
            isJump = true;
            AudioManager.PlayJumpAudio();
            rb.velocity += Vector2.up * jumpForce;
        }
        if (rb.velocity.y < 0)
        {
            isJump = false;       
            rb.velocity += Vector2.up * Physics2D.gravity.y * jumpFactor * Time.deltaTime;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("fan"))
        {
            AudioManager.PlayJumpAudio();
            rb.velocity += Vector2.up * jumpForce;
            if (rb.velocity.y < 0)
            {
                rb.velocity += Vector2.up * Physics2D.gravity.y * jumpFactor * Time.deltaTime;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("spike")) 
        {
            playerIsDead = true;
            AudioManager.PlayDeathAudio();
            Instantiate(dieEffect, transform.position, Quaternion.identity);
            col.enabled = false;
            sp.color = new Color(1, 1, 1, 0);
             
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.transform.position, checkRadius);
    }

}
