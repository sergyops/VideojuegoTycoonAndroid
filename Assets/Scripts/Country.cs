using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Country", menuName = "Scriptable Objects/Country")]
public class Country : ScriptableObject
{
    public string namecountry;
    public int maxproperties;
}
