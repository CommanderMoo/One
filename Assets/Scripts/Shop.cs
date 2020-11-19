using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    BuildManager buildManager;

    void Start()
    {
        buildManager = BuildManager.instance;    
    }

    public void PurchaseStandardTurret()
    {
        Debug.Log("Turret Landing");
        buildManager.SetTurretToBuild(buildManager.standardTurretPrefab);
    }

    public void PurchaseATurret()
    {
        Debug.Log("Another Turret");
        buildManager.SetTurretToBuild(buildManager.anotherTurretPrefab);
    }
}
