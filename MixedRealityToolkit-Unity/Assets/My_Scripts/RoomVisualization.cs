using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.MixedReality.Toolkit.Input;

public class RoomVisualization : MonoBehaviour
{
    public Material mat;
    private bool shouldChangeMat;
    private MeshRenderer meshRenderer;

    void Start() {
        meshRenderer = gameObject.GetComponent<MeshRenderer>();
    }

    public void VisualizationOnFocusBegin() {
        shouldChangeMat = true;
        Debug.Log("hover started");
        StartCoroutine(TriggerOnHover());
    }

    public void VisualizationOnFocusEnd() {
        Debug.Log("hover ended");
        shouldChangeMat = false;
        StopCoroutine(TriggerOnHover());
        meshRenderer.material.SetColor("_Color", new Color(1f, 1f, 1f, 1f));

    }

    IEnumerator TriggerOnHover() {
        for (int i = 0; i < 10; i++) {
            if (!shouldChangeMat) {
                yield break;
            }
            Color old = meshRenderer.material.color;
            Debug.Log("updating color");
            meshRenderer.material.SetColor("_Color", new Color(old.r, old.g - 0.05f, old.b - 0.05f, old.a));
            yield return new WaitForSeconds(0.1f);
        }
    }
}
