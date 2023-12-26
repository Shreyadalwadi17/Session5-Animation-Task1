using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
    private float speed = 10f;
    public Rigidbody2D rb;
    float jumpy = 6f;
    bool jump = false;
    public Animator pa;
    Vector2 Player;
    bool djump = false;
    bool slide = false;
    bool wallwalk = false;
    public float helth = 3;
    public GameObject[] hearts;
    public int life;
    public GameObject bullet;
    public GameObject fruity;
    public int Scoreval = 0;
    public Text score;
    public FixedJoystick joystick;

    public void FixedUpdate()
    {
        Animation();
        P_Jump();
        P_Move();
        P_DoubleJump();
        P_Slide();
        P_Wallwalk();
        JoystickMove();

    }

    private void Update()
    {
        Death();
        Fire();

    }

    public void Animation()
    {

        if (Player.x == 0)
        {
            pa.SetFloat("run", 0);
        }

        if (Player.x > 0 || Player.x < 0)
        {
            pa.SetFloat("run", 1);
        }

    }

    public void P_Move()
    {
        Player = new Vector2(Input.GetAxis("Horizontal"), 0f);
        transform.Translate(Player * speed * Time.deltaTime);
    }

    public void P_Jump()
    {
        if (Input.GetKey(KeyCode.Space) && jump == false)
        {
            jump = true;
            pa.SetBool("jump", true);
            rb.velocity = Vector2.up * jumpy;
        }
    }
    public void P_DoubleJump()
    {
        if (Input.GetKey(KeyCode.RightAlt) && djump == false)
        {
            djump = true;
            pa.SetBool("djump", true);
            rb.velocity = Vector2.up * jumpy;
        }
    }
    public void P_Wallwalk()
    {
        if (Input.GetKey(KeyCode.LeftAlt) && wallwalk == false)
        {
            wallwalk = true;
            pa.SetBool("wallwalk", true);
            rb.velocity = Vector2.up * speed;
        }
    }
    public void P_Slide()
    {
        if (Input.GetKey(KeyCode.RightShift) && slide == false)
        {
            slide = true;
            pa.SetBool("slide", true);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Boxes")
        {
            jump = false;
            djump = false;
            pa.SetBool("jump", false);
            pa.SetBool("djump", false);
            pa.SetBool("slide", false);
            pa.SetBool("wallwalk", false);
        }
        if (collision.gameObject.tag == "opstical")
        {
            jump = false;
            djump = false;
            pa.SetBool("jump", false);
            pa.SetBool("djump", false);

        }
        if (collision.gameObject.tag == "ground")
        {
            jump = false;
            djump = false;
            pa.SetBool("jump", false);
            pa.SetBool("djump", false);

        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "opstical")
        {
            helth -= 1;
            pa.SetTrigger("hit");
            Debug.Log("hit");

            life -= 1;
            Destroy(hearts[life].gameObject);
            Debug.Log("Minus life");

        }
        if (collision.gameObject.tag == "playereat")
        {
            Destroy(collision.gameObject);
            Scoreval += 1;
            score.text = "Score:" + Scoreval;
        }

    }
    public void Fire()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            Instantiate(bullet, transform.position, transform.rotation);
        }
    }

    void Death()
    {
        if (helth == 0)
            Destroy(gameObject, 1);
    }
    public void JoystickMove()
    {
        float verticalDirection = joystick.Vertical;
        float horizontalDirection = joystick.Horizontal;
        Vector2 direction = new Vector2(horizontalDirection, verticalDirection);
        transform.Translate(direction * Time.deltaTime * speed);
    }
    public void jumpbtn()
    {
        if (jump == false)
        {
            jump = true;
            pa.SetBool("jump", true);
            rb.velocity = Vector2.up * jumpy;
        }
    }
    public void Attackbtn()
    {
        Instantiate(bullet, transform.position, transform.rotation);
    }


}

