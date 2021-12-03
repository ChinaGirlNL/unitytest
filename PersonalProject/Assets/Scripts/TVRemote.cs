using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class TVRemote : HeldObject
{
    public GameManager gameManagerScript;

    public GameObject UI;

    public List<VideoClip> videos;
    public VideoPlayer TV;

    public string sequence;
    public string correctSequence = "8146";

    public float keyCooldown = 0.1f;
    private float lastTime;

    public override void onHold()
    {
        UI.SetActive(true);
    }

    public override void onRelease()
    {
        UI.SetActive(false);
    }

    public void OnGUI()
    {
        Event e = Event.current;

        if (e.isKey && isBeingHeld && Time.time - lastTime > keyCooldown)
        {
            lastTime = Time.time;
            if (e.keyCode >= KeyCode.Keypad0 && e.keyCode <= KeyCode.Keypad9)
            {
                int x = e.keyCode - KeyCode.Keypad0;
                TV.clip = videos[x];
                sequence += x;

                if (sequence.Length > correctSequence.Length)
                {
                    sequence = sequence.Remove(0, 1);
                }
                if (sequence == correctSequence)
                {
                    gameManagerScript.openDoor(3);
                }
            }
        }
    }
}
