using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BuildManager : MonoBehaviour
{

    public GameObject chosenTowerGOToBuild;
    public BuildPlot plotChosenToBuildOn;


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            int layerMask = 1 << 8;
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
            {
                Debug.DrawRay(ray.origin, ray.direction * hit.distance, Color.yellow);
                if(hit.collider.gameObject.GetComponent<BuildPlot>())
                {
                    Debug.Log("Hit plot");
                    if (plotChosenToBuildOn != null)
                        plotChosenToBuildOn.ClickedOff();
                    plotChosenToBuildOn = hit.collider.gameObject.GetComponent<BuildPlot>();
                    plotChosenToBuildOn.ClickedOn();
                }
               
            }
            else if (plotChosenToBuildOn != null)
            {
                plotChosenToBuildOn.ClickedOff();
            }

        }
    }

}
