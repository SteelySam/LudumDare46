using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("MoveRight", 1f, .01f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void MoveRight()
    {
        transform.position = new Vector3(transform.position.x + .01f, transform.position.y, transform.position.z);
    }
}
