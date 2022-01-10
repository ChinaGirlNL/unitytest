using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Book : HeldObject
{
    public TextMeshProUGUI UIText;
    public RawImage UIImage;
    public Button UIButton;
    public GameObject UI;

    public string text_contents;
    public Texture image_contents;

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
