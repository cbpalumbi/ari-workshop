using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class RoomData
{
    public FurnitureData[] furniture;

    public RoomData() {
        furniture = new FurnitureData[40];
        GameObject[] furniturePieces = GameObject.FindGameObjectsWithTag("Furniture");
        int counter = 0;
        foreach (GameObject obj in furniturePieces) {
            Furniture script = obj.GetComponent<Furniture>();
            furniture[counter] = new FurnitureData(script);
            Debug.Log("saving furniture item at pos " + script.gameObject.transform.position);
            counter++;
        }
    }
}
