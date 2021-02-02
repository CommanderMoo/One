using System.Collections;
using UnityEngine;

// when you want to create a class with multiple field you need to include serializable
[System.Serializable]

public class TurretBlueprint : MonoBehaviour
{
    public GameObject prefab;
    public int cost;


    public int GetSellAmount()
    {
        return cost / 2;
    }

}
