using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class HistoryData
{
    public RoomData[] rooms;

    public HistoryData() {
        rooms = new RoomData[8];
    }

    public HistoryData(HistoryManager manager) {
        rooms = new RoomData[8];
        
        History h = manager.History;
        if (h == null) {
            Debug.LogError("Existing history not found");
            return;
        }

        // take in old history data, copy over every room
        for (int i = 0; i < 8; i++) {
            rooms[i] = h.data.rooms[i];
        }

        // modify only the room you're in 
        rooms[manager.currentRoom] = new RoomData();

    }
}
