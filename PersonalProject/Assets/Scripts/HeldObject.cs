using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeldObject : MonoBehaviour
{
    public bool isBeingHeld;

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
        if (isBeingHeld == false)
        {
            return;
        }
        objectRb.position = player.transform.position + offset;
    }
    
    public void enableHold()
    {
        player.GetComponent<PlayerController>().heldObject = gameObject;
        player.GetComponent<PlayerController>().heldObjectScript = this;
        isBeingHeld = true;
        objectRb.position = player.transform.position + offset;
        objectRb.useGravity = false;
        onHold();
    }

    public void disableHold()
    {
        isBeingHeld = false;
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
