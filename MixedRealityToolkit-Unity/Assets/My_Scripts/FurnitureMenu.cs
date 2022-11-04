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
}
