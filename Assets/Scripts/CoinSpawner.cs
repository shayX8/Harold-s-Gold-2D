using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinSpawner : MonoBehaviour
{

    public GameObject coin;
    public Text textScore;
    public GameObject[] coinArr;

    public int score;

    float randX;
    float randY;
    // Start is called before the first frame update
    void Start()
    {
        coinArr = new GameObject[8];
        score = 0;
        CreateCoins();
        Instantiate(coin, new Vector2(10.35f, -1.8f), Quaternion.identity);
        Instantiate(coin, new Vector2(42.7f, -9.29f), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void CreateCoins()
    {
        for (int i = 0; i < coinArr.Length; i++)
        {
            randX = Random.Range(-60f, 60f);
            randY = Random.Range(2f, 2.7f);
            coinArr[i] = Instantiate(coin, new Vector2(randX, randY), Quaternion.identity);
        }
    }
}
