using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HistoryManager : MonoBehaviour
{
    [HideInInspector]
    public History history;
    private int currentRoom = 0; // should only go 0 to 7
    [HideInInspector]
    public int lowestUnusedRoom = 1;
    public FurnitureMenu menu;
    public TextMeshProUGUI debugRoomText;
    public GameObject visualization;
    public GameObject roomPrefab;

    public History History
    {
        get
        {
            return history;
        }
        set
        {
            history = value;
        }
    }

    public int CurrentRoom
    {
        get
        {
            return currentRoom;
        }
        set
        {
            currentRoom = value;
            UpdateRoomText();
        }
    }

    void Start() {
        ShowHistory(false);

        // load existing history if possible
        HistoryData dataFromFiles = SaveLoad.LoadHistorySaveDataOnStartup();
        if (dataFromFiles == null) {
            Debug.Log("no history to load from files on startup");
            history = new History();
        } else {
            Debug.Log("yes history to load from files on startup");
            history = new History(dataFromFiles);
            currentRoom = dataFromFiles.currentRoom;
            RoomData room = history.data.rooms[dataFromFiles.currentRoom];
            for (int i = 0; i < room.furnitureCount; i++) {
                menu.SetUpLoadedFurniture(room.furniture[i]);
            }
            UpdateRoomText();
        }
    }

    private void UpdateRoomText() {
        debugRoomText.text = currentRoom.ToString();
    }

    public void ShowHistory(bool show) {
        visualization.SetActive(show);
    }

    public void GenerateHistory() {
        for (int i = 0; i < lowestUnusedRoom; i++) {
            Debug.Log("spawning room viz");
            float multiplier = 0.18f;
            Vector3 newPos = visualization.transform.position + (Vector3.forward * i * multiplier);
            GameObject.Instantiate(roomPrefab, newPos, Quaternion.identity, visualization.transform);
        }
    }
        
}
