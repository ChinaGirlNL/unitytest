using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Progress
{
    public static Progress current;
    public static int levelCount;
    public List<bool> hasCompletedLevel = new List<bool>();
    
    public Progress()
    {
        for (int i = 0; i < levelCount; i++)
        {
            hasCompletedLevel.Add(false);
        }
    }
}
