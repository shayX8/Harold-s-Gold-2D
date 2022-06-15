using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyBullet : MonoBehaviour
{
    public float speed = 3f;
    public GameObject bulletExplosion;

    private Transform player;
    private Vector2 target;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").transform;

        //Taking the last position of the Player
        target = new Vector2(player.position.x, player.position.y);
        
        //Bullet facing the player
        if(player.position.x < transform.position.x)
        {
            transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
        //Destroy if reached destination
        if (transform.position.x == target.x && transform.position.y == target.y)
        {
            DestroyBullet();
        }
    }

    private void OnBecameInvisible()
    {
        DestroyBullet();
    }

    public void DestroyBullet()
    {
        Instantiate(bulletExplosion, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            //Taking damage to the player
            other.gameObject.GetComponent<PlayerEngine>().TakeDamage();
            DestroyBullet();
        }

        if (other.gameObject.tag == "Ground" || other.gameObject.tag == "Wall")
        {
            DestroyBullet();
        }
    }


}
