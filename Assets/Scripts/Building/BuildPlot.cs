using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildPlot : MonoBehaviour
{

    public Material materialToSwitchToWhenSelected;
    public Material defaultMaterial;
    public GameObject buildPosition;
    public GameObject builtGO;
    public bool blocked;




    public void ClickedOn()
    {
        GetComponent<MeshRenderer>().material = materialToSwitchToWhenSelected;
    }

    public void ClickedOff()
    {
        GetComponent<MeshRenderer>().material = defaultMaterial;
    }



    public void BuildOn(GameObject towerGO)
    {
        builtGO = (GameObject)Instantiate(towerGO, buildPosition.transform.position, Quaternion.identity);
    }

    public void RemoveTower()
    {
        if (builtGO != null)
        {
            Destroy(builtGO);
            builtGO = null;
        }
    }
}
