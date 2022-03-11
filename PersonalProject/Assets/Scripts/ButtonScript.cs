using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    public GameObject door;
    public bool mustBeHeld;
    public bool isActivated;
    private GameManager gameManagerScript;

    public string sequence;
    private float buttonDownTime;
    public float longHoldTime;

    public string correctSequence = ".-..";


    // Start is called before the first frame update
    void Start()
    {
        isActivated = false;
        gameManagerScript = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if ((other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Object")) && !isActivated)
        {
            gameManagerScript.openDoor(1);
            transform.Translate(Vector3.down * (GetComponent<BoxCollider>().size.y / 4));
            isActivated = true;

            buttonDownTime = Time.time;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if ((other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Object")) && isActivated)
        {
            gameManagerScript.closeDoor();
            transform.Translate(Vector3.up * (GetComponent<BoxCollider>().size.y / 4));
            isActivated = false;

            float heldTime = Time.time - buttonDownTime;
            if (heldTime <= longHoldTime)
            {
                sequence += ".";
            }
            else
            {
                sequence += "-";
            }
            if (sequence.Length > correctSequence.Length)
            {
                sequence = sequence.Remove(0, 1);
            }
            if (sequence == correctSequence)
            {
                gameManagerScript.openDoor(2);
            }
        }
    }
}
