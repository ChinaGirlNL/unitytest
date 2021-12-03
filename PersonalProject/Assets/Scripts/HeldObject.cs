using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeldObject : MonoBehaviour
{
    //0 means is not being held, 1 means it's moving towards the player, 2 means it's being held
    public int isBeingHeld; //change to private later

    protected GameObject player;
    public Rigidbody objectRb;
    public Vector3 offset = new Vector3(0, -3, 0);
    public int speed = 20;

    public virtual void onHold()
    {

    }

    public virtual void onRelease()
    {

    }

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
        player.GetComponent<PlayerController>().heldObject = gameObject;
        player.GetComponent<PlayerController>().heldObjectScript = this;
        isBeingHeld = 1;
        objectRb.position = player.transform.position + offset;
        objectRb.useGravity = false;
        onHold();
    }

    public void disableHold()
    {
        isBeingHeld = 0;
        objectRb.useGravity = true;
        onRelease();
    }

    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.CompareTag("Player"))
        {
            //Vector3 direction = collision.GetContact(0).normal;
            //if(Mathf.RoundToInt(direction[1]) == -1)
            {
                enableHold();
                
            }
        }
    }
}
