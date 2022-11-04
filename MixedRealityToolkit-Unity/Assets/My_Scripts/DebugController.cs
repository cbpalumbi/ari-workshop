using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugController : MonoBehaviour
{

    public FurnitureMenu menu;

    void Start()
    {
        menu = GameObject.FindWithTag("FurnitureMenu").GetComponent<FurnitureMenu>();
        if (menu == null) {
            Debug.LogError("Could not find furniture menu in scene");
        }
    }

    void Update()
    {
        if (Input.GetKeyUp("1")) {
            menu.SpawnCouch();
        } else if (Input.GetKeyUp("2")) {
            menu.SpawnChair();
        } else if (Input.GetKeyUp("3")) {
            menu.SpawnLamp();
        }
    }
}
