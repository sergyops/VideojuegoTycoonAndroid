using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PropertyInfo : MonoBehaviour
{
    public Text nameproperty, lvl, profits;
    public GameObject ingamedata;

    Property property;
    int id, nprofits;

    void Update()
    {

        property = ingamedata.GetComponent<ProInGameData>().property;
        id = ingamedata.GetComponent<ProInGameData>().id;
        nprofits = ingamedata.GetComponent<ProInGameData>().nprofits;

        nameproperty.text = property.nameproperty + " (" + (id + 1) + ")";
        lvl.text = "Nivel: " + property.lvl;
        profits.text = nprofits.ToString();
    }
}
