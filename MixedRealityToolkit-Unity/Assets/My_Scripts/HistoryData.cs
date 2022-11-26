using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class HistoryData
{
    public RoomData[] rooms;
    public int currentRoom;
    public int lowestUnusedRoom;

    public HistoryData() {
        rooms = new RoomData[8];
        currentRoom = 0;
    }

    public HistoryData(HistoryManager manager) {
        rooms = new RoomData[8];
        currentRoom = manager.currentRoom;
        lowestUnusedRoom = manager.lowestUnusedRoom;
        
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
