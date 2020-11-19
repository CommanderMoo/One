using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{

    public static BuildManager instance;

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Build Manager");
            return;
        }
        instance = this;
    }

    public GameObject standardTurretPrefab;
    public GameObject anotherTurretPrefab;

    /*
    void Start()
    {
        turretBuild = standardTurretPrefab;
    }
    */

    private GameObject turretBuild;

    public GameObject GetTurretToBuild()
    {
        return turretBuild;
    }

    public void SetTurretToBuild( GameObject turret)
    {
        turretBuild = turret;
    }



}
