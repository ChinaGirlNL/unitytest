using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TVRemote : HeldObject
{
    public GameObject UI;

    public override void onHold()
    {
        UI.SetActive(true);
    }

    public override void onRelease()
    {
        UI.SetActive(false);
    }
}
