using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinEngine : MonoBehaviour
{
    public GameObject coinAnimationDestroy;
    public GameObject coinSpawner;
    // Start is called before the first frame update

    private void Awake()
    {
        coinSpawner = GameObject.Find("CoinSpawner");
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            coinSpawner.GetComponent<CoinSpawner>().score += 10;
            coinSpawner.GetComponent<CoinSpawner>().textScore.text = "Score : " + coinSpawner.GetComponent<CoinSpawner>().score;
            SoundManager.PlaySound("CoinSound");
            DestroyCoin();
        }

    }

    public void DestroyCoin()
    {
        Instantiate(coinAnimationDestroy, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
