using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    public float speed;
    public float jumpForce;
    public bool isJumping;
    public bool doubleJump;

    private bool isBlowing;
    private Rigidbody2D rgb;
    private Animator anim;
    private bool flip;

    void Start()
    {
        rgb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        Move();
        Jump();
        AntiGravity();
    }

    public void Move()
    {
        //Vector3 movement = new Vector3(Input.GetAxis("Horizontal"),0f,0f);
        //transform.position += movement * Time.deltaTime * speed;

        float movement = Input.GetAxis("Horizontal");
        rgb.velocity = new Vector2(movement*speed,rgb.velocity.y);
        
        if (movement > 0f)
        {
            anim.SetBool("walk", true);
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
        }

        else if (movement < 0f)
        {
            anim.SetBool("walk", true);
            transform.eulerAngles = new Vector3(0f, 180f, 0f);
        }

        else
        {
            anim.SetBool("walk", false);
        }
    }

    public void Jump()
    {
        if (Input.GetButtonDown("Jump") && !isBlowing)
        {
            if (!isJumping)
            {
                rgb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
                doubleJump = true;
                anim.SetBool("jump", true);
            }
            else
            {
                if (doubleJump)
                {
                    rgb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
                    doubleJump = false;
                }
            }
        }
            
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            isJumping = false;
            anim.SetBool("jump", false);
        }

        if (collision.gameObject.tag == "Spike" || collision.gameObject.tag == "Saw")
        {
            GameController.instance.ShowGameOver();
            Destroy(gameObject);
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            isJumping = true;
        }
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 9)
        {
            isBlowing = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 9)
        {
            isBlowing = false;
        }
    }

    void AntiGravity()
    {
        if (Input.GetKeyDown(KeyCode.G) && SceneManager.GetActiveScene().name == "Level6")
        {
            flip = !flip;
            rgb.gravityScale = -rgb.gravityScale;
            gameObject.GetComponent<SpriteRenderer>().flipY = flip;
        }
    }
}
