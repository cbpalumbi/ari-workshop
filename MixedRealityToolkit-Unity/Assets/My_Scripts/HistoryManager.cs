using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HistoryManager : MonoBehaviour
{
    [HideInInspector]
    History history;
    [HideInInspector]
    public int currentRoom = 0; // should only go 0 to 7
    [HideInInspector]
    public int lowestUnusedRoom = 1;
    public FurnitureMenu menu;
    public TextMeshProUGUI debugRoomText;

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

    void Start() {
        // load existing history if possible
        HistoryData dataFromFiles = SaveLoad.LoadHistorySaveDataOnStartup();
        if (dataFromFiles == null) {
            Debug.Log("no history to load from files on startup");
            history = new History();
        } else {
            Debug.Log("yes history to load from files on startup");
            history = new History(dataFromFiles);
            currentRoom = dataFromFiles.currentRoom;
            foreach(FurnitureData f in history.data.rooms[dataFromFiles.currentRoom].furniture) {
                menu.SetUpLoadedFurniture(f);
            }
            UpdateRoomText();
        }
    }

    public void UpdateRoomText() {
        debugRoomText.text = currentRoom.ToString();
    }
        
}
