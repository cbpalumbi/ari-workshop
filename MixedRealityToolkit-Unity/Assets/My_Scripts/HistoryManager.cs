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
        float couchOffset = menu.yPos;
        float chairOffset = menu.yPos2;
        for (int i = 0; i < lowestUnusedRoom; i++) {
            // create plane
            float multiplier = 0.18f;
            Vector3 newPos = visualization.transform.position + (Vector3.forward * i * multiplier);
            GameObject floorPlane = GameObject.Instantiate(roomPrefab, newPos, Quaternion.identity, visualization.transform);

            // spawn mini furniture
            float fScale = 0.08f;
            RoomData room = history.data.rooms[i];
            for (int j = 0; j <  room.furnitureCount; j++) {
                FurnitureData f = room.furniture[j];
                GameObject prefab = f.furnitureType == 0 ? menu.couchPrefab : menu.chairPrefab;
                
                GameObject obj = GameObject.Instantiate(prefab, floorPlane.transform);
                obj.transform.localPosition = new Vector3(f.position[0] * fScale, 0, f.position[2] * fScale);
                obj.transform.rotation = Quaternion.identity;
                obj.transform.Rotate(0, f.rotationY, 0);
                //obj.transform.localScale = new Vector3(f.scale[0] * fScale, f.scale[1] * fScale, f.scale[2] * fScale);
            }
        }
    }
        
}
