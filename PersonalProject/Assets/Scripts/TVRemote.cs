using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TVRemote : MonoBehaviour
{
    GameObject UI;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void toggleRemote()
    {
        if (UI.activeInHierarchy)
        {
            UI.SetActive(false);
        }
        else
        {
            UI.SetActive(true);
        }
    }

    public void button()
    {
        
    }
}
