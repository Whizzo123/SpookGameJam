using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    int towerCost;
    int towerRate;
    int towerDamage;
    int towerRange;
    string towerEffect;// = { "Slow", "Vulnerability", "None" };
    string towerProjectile;// = { "Direct", "Splash" };

    // Start is called before the first frame update
    void Start()
    {
        if(this.gameObject.tag == "Fist Of Justice")
        {
            towerCost = 5;
            towerRate = 10;
            towerDamage = 5;
            towerRange = 5;
            towerEffect = "None";
            towerProjectile = "Direct";
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
