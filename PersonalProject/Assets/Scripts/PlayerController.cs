using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 25;

    private Rigidbody playerRb;
    private GameObject focalPoint;
    private GameManager gameManagerScript;

    public GameObject heldObject;
    public HeldObject heldObjectScript;
    public bool blockMovements = false;

    public int maxChannels = 10;
    public Texture[] videos;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");
        gameManagerScript = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        Interact();
        TestForUI();
    }
    void MovePlayer()
    {
        if (blockMovements)
        {
            playerRb.velocity = Vector3.zero;
            return;
        }
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
        if (heldObject == null)
        {
            return;
        }

        if (Input.GetKey(KeyCode.E) && !blockMovements)
        {
            heldObjectScript.disableHold();
            heldObject = null;
            heldObjectScript = null;
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Book bookScript = heldObjectScript as Book;
            if (bookScript != null)
            {
                bookScript.ToggleRead();
                blockMovements = !blockMovements;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Finish"))
        {
            gameManagerScript.onComplete();
        }
        if (other.CompareTag("Upper Limit"))
        {
            gameManagerScript.currentLevel = 4;
            gameManagerScript.onComplete();
        }
    }

    private void TestForUI()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseScreenScript.instance.openUI();
        }
    }
}
