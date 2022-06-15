using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    int i = 4;
    int posX = -30;
    int posY = 3;
    // Start is called before the first frame update
    void Start()
    {
        while (i > 0)
        {
            Instantiate(enemyPrefab, new Vector2(posX, posY), Quaternion.identity);
            i--;
            posX += 25;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
