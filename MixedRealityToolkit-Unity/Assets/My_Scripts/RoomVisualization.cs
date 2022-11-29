using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.MixedReality.Toolkit.Input;

public class RoomVisualization : MonoBehaviour
{
    public Material currentRoomMat;
    public Material originalMat;
    [HideInInspector]
    public int room;

    private bool shouldChangeMat;
    private MeshRenderer meshRenderer;
    private FurnitureMenu menu;
    private HistoryManager manager;
    

    void Start() {
        meshRenderer = gameObject.GetComponent<MeshRenderer>();
        menu = GameObject.Find("FurnitureMenu").GetComponent<FurnitureMenu>();
        manager = GameObject.Find("HistoryManager").GetComponent<HistoryManager>();
        
        if (manager.currentRoom == room) {
            meshRenderer.material = currentRoomMat;
        }
    }

    public void VisualizationOnFocusBegin() {
        if (manager.currentRoom == room) {
            return;
        }
        shouldChangeMat = true;
        StartCoroutine(TriggerOnHover());
    }

    public void VisualizationOnFocusEnd() {
        shouldChangeMat = false;
        StopCoroutine(TriggerOnHover());
        if (manager.currentRoom != room) {
            meshRenderer.material.SetColor("_Color", new Color(1f, 1f, 1f, 1f));
        }
    }

    IEnumerator TriggerOnHover() {
        for (int i = 0; i < 10; i++) {
            if (!shouldChangeMat) {
                yield break;
            }
            Color old = meshRenderer.material.color;
            meshRenderer.material.SetColor("_Color", new Color(old.r, old.g - 0.05f, old.b - 0.05f, old.a));
            yield return new WaitForSeconds(0.1f);
        }
        menu.LoadTheRoom(manager.history.data.rooms[room], true, room);
       
        for (int i = 0; i < manager.visualization.transform.childCount; i++) { // reset all rooms' mat to default
            manager.visualization.transform.GetChild(i).gameObject.GetComponent<RoomVisualization>().SetToDefaultMat();
        }
        meshRenderer.material = currentRoomMat;
    }

    public void SetToDefaultMat() {
        meshRenderer.material = originalMat;
    }
}
