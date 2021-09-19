using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 25;

    private Rigidbody playerRb;
    private GameObject focalPoint;

    public HeldObject heldObject;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");
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

        playerRb.velocity = focalPoint.transform.right * speed * horizontalAxis + focalPoint.transform.forward * speed * verticalAxis;

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
        if (Input.GetKey(KeyCode.E))
        {
            heldObject.disableHold();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Button"))
        {
            Debug.Log("Trigger");
        }
    }
}
