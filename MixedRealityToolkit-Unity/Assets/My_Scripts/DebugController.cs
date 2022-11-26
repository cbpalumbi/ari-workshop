using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugController : MonoBehaviour
{

    [HideInInspector]
    public FurnitureMenu menu;
    public HistoryManager manager;

    void Start()
    {
        menu = GameObject.FindWithTag("FurnitureMenu").GetComponent<FurnitureMenu>();
        if (menu == null) {
            Debug.LogError("Could not find furniture menu in scene");
        }
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.J)) {
            menu.SpawnCouch();
        } else if (Input.GetKeyUp(KeyCode.K)) {
            menu.SpawnChair();
        } else if (Input.GetKeyUp(KeyCode.L)) {
            menu.SpawnLamp();
        } else if (Input.GetKeyUp("0")) {
            manager.CurrentRoom = 0;
            menu.LoadTheRoom(manager.history.data.rooms[0]);
        } else if (Input.GetKeyUp("1")) {
            manager.CurrentRoom = 1;
            menu.LoadTheRoom(manager.history.data.rooms[1]);
        } else if (Input.GetKeyUp("2")) {
            manager.CurrentRoom = 2;
            menu.LoadTheRoom(manager.history.data.rooms[2]);
        } else if (Input.GetKeyUp("3")) {
            manager.CurrentRoom = 3;
            menu.LoadTheRoom(manager.history.data.rooms[3]);
        } else if (Input.GetKeyUp("4")) {
            manager.CurrentRoom = 4;
            menu.LoadTheRoom(manager.history.data.rooms[4]);
        } else if (Input.GetKeyUp("5")) {
            manager.CurrentRoom = 5;
            menu.LoadTheRoom(manager.history.data.rooms[5]);
        } else if (Input.GetKeyUp("6")) {
            manager.CurrentRoom = 6;
            menu.LoadTheRoom(manager.history.data.rooms[6]);
        } else if (Input.GetKeyUp("7")) {
            manager.CurrentRoom = 7;
            menu.LoadTheRoom(manager.history.data.rooms[7]);
        }
        
    }
}
