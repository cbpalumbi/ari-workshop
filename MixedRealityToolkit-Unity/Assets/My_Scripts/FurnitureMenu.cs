using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FurnitureMenu : MonoBehaviour
{
    public GameObject couchPrefab;
    public GameObject chairPrefab;
    public GameObject lampPrefab;
    public float xPlacementOffset;
    public float zPlacementOffset;
    public Transform parent;

    private float yPos = -1.534f; // TODO: change this to grab y coord of floor plane
    private float yPos2 = -1.242923f;
    private float yPos3 = -1.566f;
    
    public void SpawnCouch() { 
        Vector3 pos = new Vector3(gameObject.transform.position.x + xPlacementOffset, yPos, gameObject.transform.position.z + zPlacementOffset);
        GameObject.Instantiate(couchPrefab, pos, Quaternion.identity, parent);
    }

    public void SpawnChair() { 
        Vector3 pos = new Vector3(gameObject.transform.position.x + xPlacementOffset, yPos2, gameObject.transform.position.z + zPlacementOffset);
        GameObject.Instantiate(chairPrefab, pos, Quaternion.identity, parent);
    }

    public void SpawnLamp() { 
        Vector3 pos = new Vector3(gameObject.transform.position.x + xPlacementOffset, yPos3, gameObject.transform.position.z + zPlacementOffset);
        GameObject.Instantiate(lampPrefab, pos, Quaternion.identity, parent);
    }

    private void LoadTheRoom(RoomData room) {
        foreach(Transform child in parent) { // clears existing furniture
            Object.Destroy(child.gameObject);
        }
        foreach(FurnitureData f in room.furniture) {
            SetUpLoadedFurniture(f);
        }
    }

    public void DeleteSaveFilesOnClick() {
        SaveLoad.DeleteSaveFiles();
    }

    public void SaveRoomVariantOnClick() {
        SaveLoad.SaveRoomVariant();
    }

    public void SaveHistoryOnClick() {
        SaveLoad.SaveRoom();
        SaveLoad.SaveHistory();
    }

    public void LoadHistoryOnClick() {
        HistoryData data = SaveLoad.LoadHistory();
        LoadTheRoom(data.rooms[0]); // just loading room you're in for now 
    }

    private void SetUpLoadedFurniture(FurnitureData f) {
        
        GameObject prefab;
        float yOffSet = 0.0f;
        switch(f.furnitureType) {
            case 0:
                prefab = couchPrefab;
                yOffSet = yPos;
            break;
            case 1:
                prefab = chairPrefab;
                yOffSet = yPos2;
            break;
            case 2:
                prefab = lampPrefab;
                yOffSet = yPos3;
            break;
            default:
                prefab = null;
                Debug.LogError("Could not read furniture type from saved data");
            break;
        }

        GameObject obj = GameObject.Instantiate(prefab, parent);
        obj.transform.position = new Vector3(f.position[0], yOffSet, f.position[2]);
        obj.transform.rotation = Quaternion.identity;
        obj.transform.Rotate(0, f.rotationY, 0);
        obj.transform.localScale = new Vector3(f.scale[0], f.scale[1], f.scale[2]);
    }
}
