using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public float rotation_speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.J))
        {
            transform.Rotate(Vector3.down * Time.deltaTime * rotation_speed);
        }
        if (Input.GetKey(KeyCode.L))
        {
            transform.Rotate(Vector3.up * Time.deltaTime * rotation_speed);
        }
    }
}