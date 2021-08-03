using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public GameObject door;
    public bool mustBeHeld;
    public bool isActivated;

    // Start is called before the first frame update
    void Start()
    {
        isActivated = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && !isActivated)
        {
            door.SetActive(false);
            transform.Translate(Vector3.down * (GetComponent<BoxCollider>().size.y / 2));
            isActivated = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && mustBeHeld && isActivated)
        {
            door.SetActive(true);
            transform.Translate(Vector3.up * (GetComponent<BoxCollider>().size.y / 2));
            isActivated = false;
        }
    }
}
