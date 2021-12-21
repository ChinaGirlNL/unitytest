using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseScreenScript : MonoBehaviour
{
    public GameObject UI;
    public Image progressBar;
    public static PauseScreenScript instance;

    PauseScreenScript()
    {
        instance = this;
    }

    public void resume()
    {
        UI.SetActive(false);
        if (GameManager.instance.currentLevel == 5)
        {
            GameManager.instance.closeDoor();
        }
        GameObject.Find("Player").GetComponent<PlayerController>().blockMovements = false;
    }

    public void open()
    {
        GameManager.instance.openDoor(5);
        GameObject.Find("Player").GetComponent<PlayerController>().blockMovements = false;
    }

    public void openUI()
    {
        UI.SetActive(true);
        progressBar.fillAmount = (float)Progress.current.completionValue / (float) Progress.levelCount;
        GameObject.Find("Player").GetComponent<PlayerController>().blockMovements = true;
    }
}
