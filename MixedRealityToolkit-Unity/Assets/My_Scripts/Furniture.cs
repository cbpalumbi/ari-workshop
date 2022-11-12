using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Furniture : MonoBehaviour
{
    public FurnitureType type;
}

public enum FurnitureType {
    Sofa, // 0
    Chair, // 1
    Lamp // 2
}
