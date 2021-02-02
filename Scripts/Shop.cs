using UnityEngine;

public class Shop : MonoBehaviour
{
    public TurretBlueprint standardTurret;
    public TurretBlueprint waterTurret;
    public TurretBlueprint airTurret;
    public TurretBlueprint earthTurret;

    BuildManager buildManager;

    void Start()
    {
        buildManager = BuildManager.instance;
    }

    public void SelectStandardTurret()
    {
        Debug.Log("Turret Landing");
        buildManager.SelectTurretToBuild(standardTurret);
    }

    public void SelectWaterTurret()
    {
        Debug.Log("Another Turret");
        buildManager.SelectTurretToBuild(waterTurret);
    }

    public void SelectAirTurret()
    {
        Debug.Log("Another Turret");
        buildManager.SelectTurretToBuild(airTurret);
    }

    public void SelectEarthTurret()
    {
        Debug.Log("Another Turret");
        buildManager.SelectTurretToBuild(earthTurret);
    }
}
