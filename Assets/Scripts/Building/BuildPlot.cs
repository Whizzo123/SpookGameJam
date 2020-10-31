using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildPlot : MonoBehaviour
{

    public Material materialToSwitchToWhenSelected;
    public Material materialToSwitchToWhenBlocked;
    public Material defaultMaterial;
    public GameObject buildPosition;
    public GameObject builtGO;
    private bool blocked;
    public bool PlotBlocked
    {
        get
        {
            return blocked;
        }
        set
        {
            blocked = value;
            if(value)
            {
                GetComponent<MeshRenderer>().material = materialToSwitchToWhenBlocked;
            }
            else
            {
                GetComponent<MeshRenderer>().material = defaultMaterial;
            }
        }
    }
    public string builtGOPrefabName;
    public BuildPlot twinBuildPlot;



    public void ClickedOn()
    {
        if (PlotBlocked == false)
            GetComponent<MeshRenderer>().material = materialToSwitchToWhenSelected;
    }

    public void ClickedOff()
    {
        if(PlotBlocked == false)
            GetComponent<MeshRenderer>().material = defaultMaterial;
    }



    public void BuildOn(GameObject towerGO)
    {
        builtGOPrefabName = towerGO.name;
        builtGO = (GameObject)Instantiate(towerGO, buildPosition.transform.position, Quaternion.identity);
        if(twinBuildPlot != null)
            twinBuildPlot.PlotBlocked = true;
    }

    public void RemoveTower()
    {
        if (builtGO != null)
        {
            if(twinBuildPlot != null)
                twinBuildPlot.PlotBlocked = false;
            Destroy(builtGO);
            builtGO = null;
        }
        
    }
}
