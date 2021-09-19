using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeldObject : MonoBehaviour
{
    //0 means is not being held, 1 means it's moving towards the player, 2 means it's being held
    public int isBeingHeld; //change to private later

    private GameObject player;
    private Rigidbody objectRb;
    public Vector3 offset;
    public int speed;

    // Start is called before the first frame update
    void Start()
    {
        objectRb = gameObject.GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (isBeingHeld == 0)
        {
            return;
        }
        objectRb.position = player.transform.position + offset;
    }
    
    public void enableHold()
    {
        isBeingHeld = 1;
        objectRb.position = player.transform.position + offset;
        objectRb.useGravity = false;
    }

    public void disableHold()
    {
        isBeingHeld = 0;
        objectRb.useGravity = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.CompareTag("Player"))
        {
            Vector3 direction = collision.GetContact(0).normal;
            Debug.Log(direction);
            if(Mathf.RoundToInt(direction[1]) == -1)
            {
                enableHold();
                player.GetComponent<PlayerController>().heldObject = this;
            }
        }
    }
}
