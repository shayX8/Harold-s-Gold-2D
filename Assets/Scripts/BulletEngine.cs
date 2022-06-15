using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEngine : MonoBehaviour
{

    float bulletSpeed;
    public GameObject player;
    bool shootDir = true;
    public GameObject bulletExplosion;
    // Start is called before the first frame update
    void Start()
    {
        bulletSpeed = 15f;
        player = GameObject.Find("Player");
        if (player.transform.localScale.x == 4)
        {
            //true means right
            shootDir = true;
        }
        else if (player.transform.localScale.x == -4)
        {
            //false means left
            shootDir = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (shootDir)
        {
            ShootBulletRight();
        }
        else if (!shootDir)
        {
            ShootBulletLeft();
        }
    }

    void ShootBulletRight()
    {
        transform.Translate(bulletSpeed * Time.deltaTime, 0, 0);
    }
    void ShootBulletLeft()
{
        transform.localScale = new Vector2(-2f, transform.localScale.y);
        transform.Translate(-bulletSpeed * Time.deltaTime, 0, 0);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "EnemyBullet")
        {
            other.gameObject.GetComponent<EnemyBullet>().DestroyBullet();
            DestroyBullet();
        }
        if (other.gameObject.tag == "Enemy")
        {
            other.gameObject.GetComponent<EnemyEngine>().TakeDamage();
            DestroyBullet();
        }

        if (other.gameObject.tag == "Ground" || other.gameObject.tag == "Wall")
        {
            DestroyBullet();
        }
    }


    void DestroyBullet()
    {
        Instantiate(bulletExplosion, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
