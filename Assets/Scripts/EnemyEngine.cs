using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyEngine : MonoBehaviour
{
    public int enemyHealth;
    public float shootingDistance = 10;
    public float stoppingDistance = 10;
    public float retreatDistance = 5;

    private float timeBtwShots;
    public float startTimeBtwShots;

    public GameObject player;
    public GameObject bullet;
    public GameObject enemyExplosion;
    float speed = 3f;
    // Start is called before the first frame update
    void Start()
    {
        enemyHealth = 1;
        player = GameObject.Find("Player");
        //face the Player
        if (player.transform.position.x > transform.position.x)
        {
            transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
        }

        startTimeBtwShots = 3f;
        timeBtwShots = startTimeBtwShots;
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            //looking towards the player
            if (player.transform.position.x > transform.position.x)
            {
                transform.localScale = new Vector2(4f, transform.localScale.y);
            }
            else if (player.transform.position.x < transform.position.x)
            {
                transform.localScale = new Vector2(-4f, transform.localScale.y);
            }

            //Calculating Moving Towards Player Distance
            if (Vector2.Distance(transform.position, player.transform.position) > stoppingDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
            }
            //Calculating Stopping Distance
            else if (Vector2.Distance(transform.position, player.transform.position) < stoppingDistance && Vector2.Distance(transform.position, player.transform.position) > retreatDistance)
            {
                transform.position = transform.position;
            }
            //Calculating Retreat Distance
            else if (Vector2.Distance(transform.position, player.transform.position) < retreatDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, player.transform.position, -speed * Time.deltaTime);
            }

            //Calculating Time Between Shots (3 seconds)
            if (timeBtwShots <= 0 && Vector2.Distance(transform.position, player.transform.position) <= shootingDistance)
            {
                ShootBullet();
                timeBtwShots = startTimeBtwShots;
            }
            else
            {
                timeBtwShots -= Time.deltaTime;
            }
        }

    }

    public void TakeDamage()
    {
        //Reducing the number of enemies by 1
        if (enemyHealth <= 0)
        {
            player.GetComponent<PlayerEngine>().numOfEnemies--;
            DestroyEnemy();
        }
        else if (enemyHealth > 0)
        {
            enemyHealth--;
        }
    }

    void ShootBullet()
    {
        Instantiate(bullet, transform.position, Quaternion.identity);
        SoundManager.PlaySound("EnemyShootSound");
    }

    public void DestroyEnemy()
    {
        Instantiate(enemyExplosion, transform.position, Quaternion.identity);
        SoundManager.PlaySound("EnemyDeathSound");
        Destroy(gameObject);
    }
}
