using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 25;

    private Rigidbody playerRb;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        Interact();
    }
    void MovePlayer()
    {
        float horizontalAxis = Input.GetAxis("Horizontal");
        float verticalAxis = Input.GetAxis("Vertical");

        playerRb.velocity = transform.right * speed * horizontalAxis + transform.forward * speed * verticalAxis;

        if (Input.GetKey(KeyCode.Space))
        {
            playerRb.velocity = Vector3.up * speed;
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            playerRb.velocity = Vector3.down * speed;
        }
    }

    void Interact()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            //Interact with the scene
            Debug.Log("Clicked (" + Time.time + ")");
        }
    }
}
