using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject door;
    private int currentLevel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ResetEscaperoom()
    {
        Scene escaperoom = SceneManager.GetActiveScene();
        SceneManager.LoadScene(escaperoom.name);
    }

    public void openDoor(int levelCondition)
    {
        currentLevel = levelCondition;
        door.SetActive(false);
    }

    public void closeDoor(int levelCondition)
    {
        if (currentLevel == levelCondition)
        {
            door.SetActive(true);
        }
    }
}
