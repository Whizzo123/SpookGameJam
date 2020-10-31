using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BuildManager : MonoBehaviour
{

    public GameObject chosenTowerGOToBuild;
    public BuildPlot plotChosen;
    public Dictionary<string, GameObject> towerPrefabRegistry;

    void Start()
    {
        towerPrefabRegistry = new Dictionary<string, GameObject>();
        LoadTowerPrefabsFromFolder();
    }

    private void LoadTowerPrefabsFromFolder()
    {
        GameObject[] towers = Resources.LoadAll<GameObject>("Prefabs");
        for (int i = 0; i < towers.Length; i++)
        {
            towerPrefabRegistry[towers[i].name] = towers[i];
        }
    }

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
                    if (plotChosen != null)
                        plotChosen.ClickedOff();
                    plotChosen = hit.collider.gameObject.GetComponent<BuildPlot>();
                    plotChosen.ClickedOn();
                }
               
            }
            else if (plotChosen != null && !MouseIsOverUI())
            {
                plotChosen.ClickedOff();
                plotChosen = null;
            }

        }
    }

    public void SetTowerToBuild(string towerName)
    {
        if (plotChosen != null)
        {
            if (plotChosen.blocked == false && plotChosen.builtGO == null)
            {
                plotChosen.BuildOn(towerPrefabRegistry[towerName]);
            }
            plotChosen.ClickedOff();
        }

        plotChosen = null;
    }

    public void RemoveTowerOnPlot()
    {
        if (plotChosen != null)
        {
            plotChosen.RemoveTower();
            plotChosen.ClickedOff();
        }
        plotChosen = null;
    }

    private bool MouseIsOverUI()
    {
        PointerEventData eventData = new PointerEventData(EventSystem.current);
        eventData.position = Input.mousePosition;
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, results);
        return results.Count > 0;
    }
}
