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

    public GameObject buildEffect;
    public GameObject sellEffect;

    private TurretBlueprint turretToBuild;
    private Node selectedNode;

    //public NodeUI nodeUI;

    // this is a property (it can only get things)
    public bool CanBuild { get { return turretToBuild != null; } }
    public bool HasMoney { get { return Player.Money >= turretToBuild.cost; } }

    /// <summary>
     public GameObject standardTurretPrefab;
     public GameObject waterTurretPrefab;
     public GameObject airTurretPrefab;
     public GameObject earthTurretPrefab;
    /// </summary>


    /*
    public void SelectNode(Node node)
    {
        if (selectedNode == node)
        {
            DeselectNode();
            return;
        }

        selectNode = node;
        turretToBuild = null;

        nodeUI.SetTarget(node);
    }

    public void DeselectNode()
    {
        selectNode = null;
        nodeUI.Hide();
    }

    public void SelectTurretToBuild (TurretBlueprint turret)
    {
        turretToBuild = turret;
        DeselectNode();
    }

    public TurretBlueprint GetTurretToBuild()
    {
        return turretToBuild;
    }
    */


    public void BuildTurretOn (Node node)
    {
        if (Player.Money < turretToBuild.cost)
        {
            Debug.Log("Need more monies"); return;
        }

        GameObject turret = (GameObject)Instantiate(turretToBuild.prefab, node.GetBuildPosition(), Quaternion.identity);
        node.turret = turret;

        Player.Money -= turretToBuild.cost;
        Debug.Log("MOney: " + Player.Money);


    }

    public void SelectTurretToBuild(TurretBlueprint turret)
    {
        turretToBuild = turret;
    }



}
