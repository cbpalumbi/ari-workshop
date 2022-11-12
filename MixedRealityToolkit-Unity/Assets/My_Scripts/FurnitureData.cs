using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class FurnitureData
{
    public float[] position;
    public float rotationY;
    public float[] scale;
    public int furnitureType;

    public FurnitureData(Furniture f) {
        position = new float[3];
        position[0] = f.gameObject.transform.position.x;
        position[1] = f.gameObject.transform.position.x;
        position[2] = f.gameObject.transform.position.x;

        rotationY = f.gameObject.transform.eulerAngles.y;

        scale = new float[3];
        scale[0] = f.gameObject.transform.localScale.x;
        scale[1] = f.gameObject.transform.localScale.y;
        scale[2] = f.gameObject.transform.localScale.z;

        furnitureType = (int)f.type;

    }

}
