using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.MixedReality.Toolkit.Input;

public class RoomVisualization : MonoBehaviour
{
    public void OnTouchStarted(HandTrackingInputEventData eventData)
    {
        
        Debug.Log($"Touch started");
    }
    public void OnTouchCompleted(HandTrackingInputEventData eventData) {}
}
