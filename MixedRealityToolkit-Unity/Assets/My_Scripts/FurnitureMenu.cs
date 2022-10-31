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
    private float yPos = -1.534f; // TODO: change this to grab y coord of floor plane
    
    public void SpawnCouch() { 
        Vector3 pos = new Vector3(gameObject.transform.position.x + xPlacementOffset, yPos, gameObject.transform.position.z + zPlacementOffset);
        GameObject.Instantiate(couchPrefab, pos, Quaternion.identity);
    }
}
