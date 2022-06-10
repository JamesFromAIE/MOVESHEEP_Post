using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
	public static void SavePlayer(PlayerManager player)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player.savedata"; // SEARCHES FOR A PERSISTENT PATH IN THE OS
        FileStream stream = new FileStream(path, FileMode.Create); // CREATE A STREAM TO HOLD THE PATH

        PlayerData data = new PlayerData(player); // GETS CURRENT PLAYER DATA FROM PLAYERMANAGER

        formatter.Serialize(stream, data); // CONVERTS DATA INTO BINARY WITHIN FILE
        stream.Close(); // CLOSE STREAM TO AVOID LEAKS
    }

    public static void ClearPlayer(PlayerManager player)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player.savedata"; // SEARCHES FOR A PERSISTENT PATH IN THE OS
        FileStream stream = new FileStream(path, FileMode.Create); // CREATE A STREAM TO HOLD THE PATH

        PlayerData data = new PlayerData(player); // GETS CURRENT PLAYER DATA FROM PLAYERMANAGER

        data.ClearData(); // SETS ALL VALUES IN DATA TO ZERO

        formatter.Serialize(stream, data); // CONVERTS DATA INTO BINARY WITHIN FILE
        stream.Close(); // CLOSE STREAM TO AVOID LEAKS
    }

    public static PlayerData LoadPlayer()
    {
        string path = Application.persistentDataPath + "/player.savedata"; // SEARCHES FOR A PERSISTENT PATH IN THE OS
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open); // CREATE A STREAM TO HOLD THE PATH

            PlayerData data = formatter.Deserialize(stream) as PlayerData; // GET STREAM
            stream.Close(); // CLOSE STREAM TO AVOID LEAKS

            return data;
        }
        else
        {
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }


}
