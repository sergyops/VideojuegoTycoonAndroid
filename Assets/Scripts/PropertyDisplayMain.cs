using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PropertyDisplayMain : MonoBehaviour
{
    public Property terreno, oficina;
    public Property property;

    public Text namepropertymain, lvlmain, nextlevelmain, nextlevelpricemain, workersmain, clientsmain, ordersmain, profitsmain, workerspopup;

    public Image image;

    public GameObject actualpro;
    int level;

    public int actualworkers, plusworkers, actualmaxclients, actualmaxorders;

    public InfoCountries infco;

    public void onclick(GameObject pro)
    {
        actualpro = pro;

        level = pro.GetComponent<PropertyInfo>().ingamedata.GetComponent<ProInGameData>().level;

        infco.GetComponent<InfoCountries>().posarrows = pro.GetComponent<PropertyInfo>().ingamedata.GetComponent<ProInGameData>().id;

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
                actualworkers = oficina.workers;
                actualmaxclients = oficina.clientsmax;
                actualmaxorders = oficina.ordersmax;

                actualworkers += plusworkers;
                actualmaxclients = actualworkers*2;
                actualmaxorders += actualmaxclients*2;
                break;
        }

        namepropertymain.text = property.nameproperty + " (" + (pro.GetComponent<PropertyInfo>().ingamedata.GetComponent<ProInGameData>().id +1) + ")";
        image.sprite = property.image;
        lvlmain.text = "Nivel: " + property.lvl;
        nextlevelmain.text = "Nivel: " + (property.lvl + 1).ToString();
        nextlevelpricemain.text = property.nextlevelprice.ToString();

        workersmain.text = pro.GetComponent<PropertyInfo>().ingamedata.GetComponent<ProInGameData>().actualworkers + "/" + property.workersmax;
        clientsmain.text = pro.GetComponent<PropertyInfo>().ingamedata.GetComponent<ProInGameData>().actualclients + "/" + pro.GetComponent<PropertyInfo>().ingamedata.GetComponent<ProInGameData>().actualmaxclients;
        ordersmain.text = pro.GetComponent<PropertyInfo>().ingamedata.GetComponent<ProInGameData>().actualorders + "/" + pro.GetComponent<PropertyInfo>().ingamedata.GetComponent<ProInGameData>().actualmaxorders;
        profitsmain.text = pro.GetComponent<PropertyInfo>().ingamedata.GetComponent<ProInGameData>().nprofits.ToString();

        workerspopup.text = pro.GetComponent<PropertyInfo>().ingamedata.GetComponent<ProInGameData>().plusworkers + "/" + (property.workersmax - (pro.GetComponent<PropertyInfo>().ingamedata.GetComponent<ProInGameData>().actualworkers - pro.GetComponent<PropertyInfo>().ingamedata.GetComponent<ProInGameData>().plusworkers));
    }
    // Start is called before the first frame update
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {

    }
}
