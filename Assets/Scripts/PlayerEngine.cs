using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerEngine : MonoBehaviour
{
    public int numOfEnemies;
    public int playerLife;
    public Text scoreText;
    public Text lifeText;
    float speed,extraSpeed, dashTime,startDashTime, xPos, shootTime, startShootTime;
    bool isFloor, isAlive, isDash;
    public string winText;

    Vector2 playerScale;
    Rigidbody2D rb;
    public GameObject shoot;
    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        numOfEnemies = 4;
        isDash = false;
        isFloor = true;
        isAlive = true;
        winText = "Score : 100";

        speed = 6; 
        extraSpeed = 12;
        startDashTime = 0.1f;
        dashTime = 0;
        xPos = 0;
        playerLife = 1;
        lifeText.text = "Life : " + (playerLife + 1).ToString();


        startShootTime = 1f;
        shootTime = 0;

        playerScale = transform.lossyScale;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //give the player option to move if he alive
        if (isAlive)
        {

            //Movement of the player to the sides
            xPos = Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime;
            if (xPos > 0)
            {
                if (playerScale.x < 0) // right
                {
                    playerScale.x = -playerScale.x;
                }
                transform.localScale = playerScale;
                transform.Translate(speed * Time.deltaTime, 0, 0);


                //animation
                anim.SetBool("IsRun", true);
                anim.SetBool("IsJump", false);
                anim.SetBool("IsDash", false);
                anim.SetBool("IsHit", false);
                anim.SetBool("IsShoot", false);
            }
            else if (xPos < 0) // left
            {
                if (playerScale.x > 0)
                {
                    playerScale.x = -playerScale.x;
                }
                transform.localScale = playerScale;
                transform.Translate(-speed * Time.deltaTime, 0, 0);

                //animation
                anim.SetBool("IsRun", true);
                anim.SetBool("IsJump", false);
                anim.SetBool("IsDash", false);
                anim.SetBool("IsHit", false);
                anim.SetBool("IsShoot", false);
            }
            else // idle
            {
                //animation
                anim.SetBool("IsRun", false);
                anim.SetBool("IsJump", false);
                anim.SetBool("IsDash", false);
                anim.SetBool("IsHit", false);
                anim.SetBool("IsShoot", false);
            }

            //Jumping, making sure to check if the player is grounded
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow) && isFloor)
            {
                rb.AddForce(new Vector2(0, 800));
                SoundManager.PlaySound("JumpSound");
                isFloor = false;
                //animation
                anim.SetBool("IsRun", false);
                anim.SetBool("IsJump", true);
                anim.SetBool("IsHit", false);
                anim.SetBool("IsShoot", false);
            }

            //shoot
            if (Input.GetKeyDown(KeyCode.Space))
            {
                
                if (shootTime <= 0)
                {
                    Instantiate(shoot, transform.position, shoot.transform.rotation);
                    SoundManager.PlaySound("PlayerShootSound");

                    //animation
                    anim.SetBool("IsShoot", true);
                    anim.SetBool("IsRun", false);
                    anim.SetBool("IsDash", false);
                    anim.SetBool("IsHit", false);
                    shootTime = startShootTime;
                }
            }
            shootTime -= Time.deltaTime;

            //Dashing + Dash timer
            if (Input.GetKeyDown(KeyCode.LeftShift) && !isDash && isFloor)
            {
                //animation
                anim.SetBool("IsRun", false);
                anim.SetBool("IsDash", true);
                anim.SetBool("IsHit", false);
                anim.SetBool("IsShoot", false);

                dashTime = startDashTime;
                speed += extraSpeed;
                SoundManager.PlaySound("PlayerDashSound");
                isDash = true;
            }
            else if (dashTime <= 0 && isDash)
            {
                isDash = false;
                speed -= extraSpeed;
                if (xPos != 0) //animation
                {
                    //get the player to run after dash
                    anim.SetBool("IsRun", true);
                    anim.SetBool("IsDash", false);
                    anim.SetBool("IsHit", false);
                    anim.SetBool("IsShoot", false);
                }
                else
                {
                    //get the player to idle after dash
                    anim.SetBool("IsRun", false);
                    anim.SetBool("IsDash", false);
                    anim.SetBool("IsHit", false);
                    anim.SetBool("IsShoot", false);
                }
            }
            else
            {
                dashTime -= Time.deltaTime;
            }

            //Win Condition
            if (numOfEnemies <= 0 && scoreText.text == winText)
            {
                SceneManager.LoadScene(2);
            }



        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Ground")
        {
            isFloor = true;
        }

        if (other.gameObject.tag == "Enemy")
        {
            TakeDamage();
        }
    }


    public void DestroyPlayer()
    {
        Destroy(gameObject, 2);
    }

    public void TakeDamage()
    {
        //player dead
        if (playerLife == 0)
        {
            anim.SetTrigger("Dead");
            isAlive = false;
            SceneManager.LoadScene(1);
            Destroy(gameObject);
        }
        else
        {
            anim.SetBool("IsHit", true);
            playerLife--;
            SoundManager.PlaySound("PlayerHitSound");
            lifeText.text = "Life : " + (playerLife + 1).ToString();
        }
    }
}
