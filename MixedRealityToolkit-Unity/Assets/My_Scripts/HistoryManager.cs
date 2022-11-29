using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HistoryManager : MonoBehaviour
{
    [HideInInspector]
    public History history;
    [HideInInspector]
    public int currentRoom = 0; // should only go 0 to 7
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
            history = new History();
        } else {
            history = new History(dataFromFiles);
            currentRoom = dataFromFiles.currentRoom;
            lowestUnusedRoom = dataFromFiles.lowestUnusedRoom;
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

    public void ClearHistory(bool hide = true) {
        foreach(Transform child in visualization.transform) { // clears existing furniture
            Object.Destroy(child.gameObject);
        }
        if (hide) {
            ShowHistory(false);
        }
    }

    public void GenerateHistory() {
        for (int i = 0; i < lowestUnusedRoom; i++) {
            // create plane
            float multiplier = 0.3f;
            Vector3 newPos = visualization.transform.position + (Vector3.forward * i * multiplier);
            GameObject floorPlane = GameObject.Instantiate(roomPrefab, newPos, Quaternion.identity, visualization.transform);
            floorPlane.GetComponent<RoomVisualization>().room = i;

            // spawn mini furniture
            RoomData room = history.data.rooms[i];
            for (int j = 0; j <  room.furnitureCount; j++) {
                FurnitureData f = room.furniture[j];
                GameObject prefab = f.furnitureType == 0 ? menu.couchPrefab : menu.chairPrefab;
                
                GameObject obj = GameObject.Instantiate(prefab, floorPlane.transform);
                obj.transform.localPosition = new Vector3(f.position[0], 0, f.position[2]);
                if (f.furnitureType == 1) {
                    obj.transform.localPosition += new Vector3(0, 0.314f, 0);
                }
                obj.transform.rotation = Quaternion.identity;
                obj.transform.Rotate(0, f.rotationY, 0);
                obj.tag = "Untagged"; // makes sure the miniatures aren't saved in the room data
            }
        }
    }
        
}
