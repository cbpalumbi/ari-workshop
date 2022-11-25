using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HistoryManager : MonoBehaviour
{
    public History history;
    public int currentRoom = 0; // should only go 0 to 7


    void Start() {
        // load existing history if possible 
        // otherwise
        history = new History();
        history.data = new HistoryData();
    }
}
