using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Progress
{
    public static Progress current;
    public static int levelCount = 5;
    public List<bool> hasCompletedLevel = new List<bool>();
    public int completionValue = 0;
    
    public Progress()
    {
        for (int i = 0; i < levelCount; i++)
        {
            hasCompletedLevel.Add(false);
        }
    }
}
