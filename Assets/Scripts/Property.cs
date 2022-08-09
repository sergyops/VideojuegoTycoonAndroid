using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Property", menuName = "Scriptable Objects/Property")]
public class Property : ScriptableObject
{
    public string nameproperty;
    public Sprite image;
    public int lvl, nextlevelprice, workers, workersmax, clientsmax, ordersmax, cost;

}
