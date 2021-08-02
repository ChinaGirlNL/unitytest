using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed;
    private float xBound;
    private float topYBound;
    private float bottomYBound;
    private float zBound;

    private Rigidbody playerRb;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        speed = 10;
        xBound = 25;
        topYBound = 50;
        bottomYBound = 0;
        zBound = 25;
    }

    // Update is called once per frame
    void Update()
    {   
        {
            float horizontalAxis = Input.GetAxis("Horizontal");
            float verticalAxis = Input.GetAxis("Vertical");

            transform.Translate(horizontalAxis * speed * Vector3.right * Time.deltaTime);
            transform.Translate(verticalAxis * speed * Vector3.forward * Time.deltaTime);
            if (transform.position.x < -xBound || transform.position.x > xBound || transform.position.z < -zBound || transform
                .position.z > zBound)
            {
                transform.Translate(-horizontalAxis * speed * Vector3.right * Time.deltaTime);
                transform.Translate(-verticalAxis * speed * Vector3.forward * Time.deltaTime);
            }
        }

        if (Input.GetKey(KeyCode.Space))
        {
            transform.Translate(speed * Vector3.up * Time.deltaTime);
            if (transform.position.y > topYBound)
            {
                transform.Translate(-speed * Vector3.up * Time.deltaTime);
            }
        }
        else if (Input.GetKey(KeyCode.LeftShift))
        {
            transform.Translate(speed * Vector3.down * Time.deltaTime);
            if (transform.position.y < bottomYBound)
            {
                transform.Translate(-speed * Vector3.down * Time.deltaTime);
            }
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            //Interact with the scene
            Debug.Log("Clicked (" + Time.time + ")");
        }
    }
}
