using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine;


public static class SaveLoad
{
    public static Progress savedGame;
    public static void Save() //Reads current game progress from the current game
    {
        savedGame = Progress.current;
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/savedGames.gd");
        bf.Serialize(file, savedGame);
        file.Close();
    }
    public static void Load() //Reads previous game progress from a file
    {
        if (File.Exists(Application.persistentDataPath + "/savedGames.gd"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/savedGames.gd", FileMode.Open);
            savedGame = (Progress)bf.Deserialize(file);
            file.Close();
            Progress.current = savedGame;
        }
    }
}
