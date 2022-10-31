using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using OVRInput;
//using UnityEngine.Input;

public class MenuController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.Get(OVRInput.Button.One) || Input.GetKey("N")){
            Debug.Log("A button pressed");
        }
    }
}
