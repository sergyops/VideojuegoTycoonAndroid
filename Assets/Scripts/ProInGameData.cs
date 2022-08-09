using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProInGameData : MonoBehaviour
{
    public GameObject gameobjectpro;

    public Property terreno, oficina;
    public Property property;

    public int id, idcountry, level, actualworkers, actualclients, actualorders, nprofits, plusworkers, actualmaxclients, actualmaxorders;

    void Update()
    {

        switch (level)
        {
            case 0:
                property = terreno;
                actualworkers = terreno.workers;
                actualmaxclients = terreno.clientsmax;
                actualmaxorders = terreno.ordersmax;
                break;
            case 1:
                property = oficina;
                actualmaxclients = oficina.clientsmax;
                actualmaxorders = oficina.ordersmax;

                actualmaxclients = actualworkers * 2;
                actualmaxorders = actualmaxclients * 2;
                break;
        }
        actualworkers = property.workers + plusworkers;
    }
}
