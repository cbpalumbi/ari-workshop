using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveLoad
{

    public static HistoryData LoadHistorySaveDataOnStartup() {
        string path = Path.Combine(Application.persistentDataPath, "history.txt");
        if (File.Exists(path)) {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            HistoryData data = formatter.Deserialize(stream) as HistoryData;
            stream.Close();

            return data;

        } else {
            return null;
        }
    }

    public static void SaveHistory() {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Path.Combine(Application.persistentDataPath, "history.txt");

        FileStream stream = new FileStream(path, FileMode.Create);
        HistoryManager manager = GameObject.Find("HistoryManager").GetComponent<HistoryManager>();
        if (manager == null) {
            Debug.LogError("Could not find history manager");
            return;
        }
        HistoryData data = new HistoryData(manager);

        formatter.Serialize(stream, data);
        stream.Close();
    } 

    public static HistoryData LoadHistory() {
        string path = Path.Combine(Application.persistentDataPath, "history.txt");
        if (File.Exists(path)) {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            HistoryData data = formatter.Deserialize(stream) as HistoryData;
            stream.Close();

            return data;

        } else {
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }

    public static void SaveRoom() {
        
        // need to update history data 
        HistoryManager manager = GameObject.Find("HistoryManager").GetComponent<HistoryManager>();
        if (manager == null) {
            Debug.LogError("Could not find history manager");
            return;
        }
        if (manager.History == null) {
            Debug.LogError("Manager.history is null");
            return;
        }
        if (manager.History.data == null) {
            Debug.LogError("Manager.history.data is null");
            return;
        }
        if (manager.History.data.rooms == null) {
            Debug.LogError("Manager.history.data.rooms is null");
            return;
        }
        manager.History.data.rooms[manager.currentRoom] = new RoomData(); 
    } 

    // public static RoomData LoadRoom() {
    //     string path = Path.Combine(Application.persistentDataPath, "room.txt");
    //     if (File.Exists(path)) {
    //         BinaryFormatter formatter = new BinaryFormatter();
    //         FileStream stream = new FileStream(path, FileMode.Open);

    //         RoomData data = formatter.Deserialize(stream) as RoomData;
    //         stream.Close();

    //         return data;

    //     } else {
    //         Debug.LogError("Save file not found in " + path);
    //         return null;
    //     }
    // }

    public static void DeleteSaveFiles() {
        string path = Application.persistentDataPath;

        var folder = Directory.GetFiles(path);
 
        for (int i = 0; i < folder.Length; i++) {
            File.Delete(folder[i]);
        }
    }

    public static void SaveRoomVariant() {
        HistoryManager manager = GameObject.Find("HistoryManager").GetComponent<HistoryManager>();
        if (manager.lowestUnusedRoom < 8) { // max 8 rooms
            manager.CurrentRoom += 1;
        } else {
            Debug.LogError("Trying to save more than 8 rooms");
            return;
        }
        
    }
}
