using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraMovment : MonoBehaviour
{
    bool isRight;
    float speed;
    // Start is called before the first frame update
    void Start()
    {
        isRight = true;
        speed = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (isRight)

        {
            transform.Translate(speed*Time.deltaTime, 0, 0);
            if (transform.position.x > 2.5f)
                isRight = false;
        }
        else
        {
            transform.Translate(-speed * Time.deltaTime, 0, 0);
            if (transform.position.x < -2.5f)
                isRight = true;
        }
    }
}
