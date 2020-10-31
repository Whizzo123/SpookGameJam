using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerStats : ScriptableObject
{
    int towerCost;
    int towerRate;
    int towerDamage;
    int towerRange;
    string[] towerEffect = { "Slow", "Vulnerability", "None" };
    string[] towerProjectile = { "Direct", "Splash" };
}
