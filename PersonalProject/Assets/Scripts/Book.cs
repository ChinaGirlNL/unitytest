using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Book : MonoBehaviour
{
    public TextMeshProUGUI UIText;
    public RawImage UIImage;
    public Button UIButton;
    public GameObject UI;

    public string text_contents;
    public Texture image_contents;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReadBook()
    {
        UIText.text = text_contents;
        UIImage.texture = image_contents;

        UI.SetActive(true);
    }

    public void CloseBook()
    {
        UI.SetActive(false);
    }

    public void ToggleRead()
    {
        if(UI.activeInHierarchy)
        {
            CloseBook();
        }
        else
        {
            ReadBook();
        }
    }
}
