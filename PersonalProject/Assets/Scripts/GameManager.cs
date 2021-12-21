using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject door;
    public int currentLevel;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        SaveLoad.Load();
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

    public void closeDoor()
    {
        door.SetActive(true);
    }

    public void onComplete()
    {
        if (!Progress.current.hasCompletedLevel[currentLevel - 1])
        {
            Progress.current.completionValue++;
            Progress.current.hasCompletedLevel[currentLevel - 1] = true;
        }
        ResetEscaperoom();
    }

    public void OnDestroy()
    {
        SaveLoad.Save();
    }
}
