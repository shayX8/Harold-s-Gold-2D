using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip playerShoot, enemyShoot, coinCollect, enemyDeath, playerJump, playerHit, playerDash;
    static AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        playerShoot = Resources.Load<AudioClip>("PlayerShootSound");
        enemyShoot = Resources.Load<AudioClip>("EnemyShootSound");
        coinCollect = Resources.Load<AudioClip>("CoinSound");
        enemyDeath = Resources.Load<AudioClip>("EnemyDeathSound");
        playerJump = Resources.Load<AudioClip>("JumpSound");
        playerHit = Resources.Load<AudioClip>("PlayerHitSound");
        playerDash = Resources.Load<AudioClip>("PlayerDashSound");

        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void PlaySound(string clip)
    {
        if (clip == "PlayerShootSound")
        {
            audioSource.PlayOneShot(playerShoot);
        }

        else if (clip == "EnemyShootSound")
        {
            audioSource.PlayOneShot(enemyShoot);
        }

        else if (clip == "CoinSound")
        {
            audioSource.PlayOneShot(coinCollect);
        }

        else if (clip == "EnemyDeathSound")
        {
            audioSource.PlayOneShot(enemyDeath);
        }

        else if (clip == "JumpSound")
        {
            audioSource.PlayOneShot(playerJump);
        }

        else if (clip == "PlayerHitSound")
        {
            audioSource.PlayOneShot(playerHit);
        }

        else if (clip == "PlayerDashSound")
        {
            audioSource.PlayOneShot(playerDash);
        }
    }

}
