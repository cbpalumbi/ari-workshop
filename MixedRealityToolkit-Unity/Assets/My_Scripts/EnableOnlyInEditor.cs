using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableOnlyInEditor : MonoBehaviour
{
    void Awake() {
#if !UNITY_EDITOR
        gameObject.SetActive(false);
#endif
    }
}
