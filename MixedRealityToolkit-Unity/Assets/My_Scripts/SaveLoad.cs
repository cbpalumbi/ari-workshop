using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveLoad
{
    public static void SaveRoom() {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Path.Combine(Application.persistentDataPath, "room.txt");

        FileStream stream = new FileStream(path, FileMode.Create);
        RoomData data = new RoomData();

        formatter.Serialize(stream, data);
        stream.Close();
    } 

    public static RoomData LoadRoom() {
        string path = Path.Combine(Application.persistentDataPath, "room.txt");
        if (File.Exists(path)) {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            RoomData data = formatter.Deserialize(stream) as RoomData;
            stream.Close();

            return data;

        } else {
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }

    public static void DeleteSaveFiles() {
        string path = Application.persistentDataPath;

        var folder = Directory.GetFiles(path);
 
        for (int i = 0; i < folder.Length; i++) {
            File.Delete(folder[i]);
        }
    }
}
