using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovment : MonoBehaviour
{
    public Transform playerTRN;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(playerTRN != null)
        {
            transform.position = new Vector3(playerTRN.transform.position.x, playerTRN.transform.position.y + 2, -10);
        }
        
    }
}
