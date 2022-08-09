using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class MoneyManager : MonoBehaviour
{
    public Property Terrain, office;

    public Text displaymoney, displayads, displaywebprofits, displayworkers, displayclients, profitssantos, profitsspring, deliverysecondstext;

    public GameObject lvlupbutton, soundlevelup, newsound, web1, web2, web3;

    public InfoCountries countrydata;

    public PropertyDisplayMain dmain;

    List<GameObject> lossantos;
    List<GameObject> springfield;

    int cost, level, individualcost, nclients, id, actualworkers, workers, clients;

    public int money, plusclients, moneywebupgrades, deliveryseconds;//save
    public bool notgiveinicialmoney;//save
    public List<GameObject> webupgrades = new List<GameObject>(3);//save

    float moneytimer = 0.0f;
    float workerstimer = 0.0f;
    float deliverytimer = 0.0f;

    void Money(List<GameObject> country)
    {

        for (int i =0; i < country.Count; i++)
        {
            level = country[i].GetComponent<PropertyInfo>().ingamedata.GetComponent<ProInGameData>().level;

            switch (level)
            {
                case 0:
                    cost += Terrain.cost;
                    individualcost += Terrain.cost;
                    break;
                case 1:
                    cost += office.cost;
                    individualcost += office.cost;
                    break;
            }

            country[i].GetComponent<PropertyInfo>().ingamedata.GetComponent<ProInGameData>().nprofits += individualcost;

            individualcost = 0;
        }
    }

    void ClientsOrders(List<GameObject> country)
    {
        for (int i = 0; i < country.Count; i++)
        {
            level = country[i].GetComponent<PropertyInfo>().ingamedata.GetComponent<ProInGameData>().level;
            int actualorders = country[i].GetComponent<PropertyInfo>().ingamedata.GetComponent<ProInGameData>().actualorders;
            int actualclients = country[i].GetComponent<PropertyInfo>().ingamedata.GetComponent<ProInGameData>().actualclients;

            switch (level)
            {
                case 0:
                    break;
                case 1:
                    nclients = Random.Range(-10,10);

                    if (plusclients > 0)
                    {
                        nclients += 10;
                    }
                    break;
            }

            if ((actualclients + nclients) >= 0)
            {
                country[i].GetComponent<PropertyInfo>().ingamedata.GetComponent<ProInGameData>().actualclients += nclients;

            }

            if ((actualorders + nclients * 2) >= 0)
            {
                country[i].GetComponent<PropertyInfo>().ingamedata.GetComponent<ProInGameData>().actualorders += nclients * 2;

                money += country[i].GetComponent<PropertyInfo>().ingamedata.GetComponent<ProInGameData>().actualorders * 8000;

                country[i].GetComponent<PropertyInfo>().ingamedata.GetComponent<ProInGameData>().nprofits = country[i].GetComponent<PropertyInfo>().ingamedata.GetComponent<ProInGameData>().actualorders * 8000;
            }

            nclients = 0;
        }
    }

    void WorkersPro(List<GameObject> country)
    {
        for (int i = 0; i < country.Count; i++)
        {

            int actualclients = country[i].GetComponent<PropertyInfo>().ingamedata.GetComponent<ProInGameData>().actualclients;
            actualworkers = country[i].GetComponent<PropertyInfo>().ingamedata.GetComponent<ProInGameData>().actualworkers * 2;

            if (actualworkers < actualclients)
            {
                money -= 2000000;
                Debug.Log("Te han sancionado por tener a tus trabajadores trabajando demasiado!");
            }
        }
    }

    public void LevelUpButton(GameObject lvlupbutton)
    {
        if (money >= -dmain.GetComponent<PropertyDisplayMain>().property.nextlevelprice)
        {

            dmain.GetComponent<PropertyDisplayMain>().actualpro.GetComponent<PropertyInfo>().ingamedata.GetComponent<ProInGameData>().level++;

            money = money + dmain.GetComponent<PropertyDisplayMain>().property.nextlevelprice;

            displaymoney.text = money.ToString();

            soundlevelup.GetComponent<AudioSource>().Play();

            countrydata.GetComponent<InfoCountries>().SaveOnLvlUp(dmain.GetComponent<PropertyDisplayMain>().actualpro.GetComponent<PropertyInfo>().ingamedata);

            dmain.GetComponent<PropertyDisplayMain>().onclick(dmain.GetComponent<PropertyDisplayMain>().actualpro);
        }
    }

    public void AdsButtons(GameObject button)
    {
        id = button.GetComponent<id>().idobject;

        switch (id)
        {
            case 0:
                
                if (money >= 2000)
                {
                    plusclients += 5;
                    money += -2000;
                    displaymoney.text = money.ToString();
                    displayads.text = plusclients.ToString();
                    newsound.GetComponent<AudioSource>().Play();
                }
                break;
            case 1:
                if(money>= 10000)
                {
                    plusclients += 10;
                    money += -10000;
                    displaymoney.text = money.ToString();
                    displayads.text = plusclients.ToString();
                    newsound.GetComponent<AudioSource>().Play();
                }
                break;
            case 2:
                if(money>= 20000)
                {
                    plusclients += 20;
                    money += -20000;
                    displaymoney.text = money.ToString();
                    displayads.text = plusclients.ToString();
                    newsound.GetComponent<AudioSource>().Play();
                }
                break;
        }
    }

    public void WebButtons(GameObject button)
    {
        id = button.GetComponent<id>().idobject;
        bool used = button.GetComponent<id>().used;

        switch (id)
        {
            case 0:

                if (money >= 10000 && used == false)
                {
                    moneywebupgrades += 5000;
                    money += -10000;
                    button.GetComponent<id>().used = true;
                    button.GetComponent<id>().buy.SetActive(true);
                    displaywebprofits.text = "+" + moneywebupgrades + "/5s";
                    displaymoney.text = money.ToString();
                    webupgrades.Add(button);
                    newsound.GetComponent<AudioSource>().Play();
                }
                break;
            case 1:
                if (money >= 40000 && used == false)
                {
                    moneywebupgrades += 10000;
                    money += -40000;
                    button.GetComponent<id>().used = true;
                    button.GetComponent<id>().buy.SetActive(true);
                    displaywebprofits.text = "+" + moneywebupgrades + "/5s";
                    displaymoney.text = money.ToString();
                    webupgrades.Add(button);
                    newsound.GetComponent<AudioSource>().Play();
                }
                break;
            case 2:
                if (money >= 80000 && used == false)
                {
                    moneywebupgrades += 20000;
                    money += -80000;
                    button.GetComponent<id>().used = true;
                    button.GetComponent<id>().buy.SetActive(true);
                    displaywebprofits.text = "+" + moneywebupgrades + "/5s";
                    displaymoney.text = money.ToString();
                    webupgrades.Add(button);
                    newsound.GetComponent<AudioSource>().Play();
                }
                break;
        }
    }

    public void WebButtonsLoad(GameObject button)
    {
        id = button.GetComponent<id>().idobject;
        bool used = button.GetComponent<id>().used;

        switch (id)
        {
            case 0:

                button.GetComponent<id>().used = true;
                button.GetComponent<id>().buy.SetActive(true);

                break;
            case 1:

                button.GetComponent<id>().used = true;
                button.GetComponent<id>().buy.SetActive(true);

                break;
            case 2:

                button.GetComponent<id>().used = true;
                button.GetComponent<id>().buy.SetActive(true);
                
                break;
        }
    }

    public void DeliveryButtons(GameObject button)
    {
        id = button.GetComponent<id>().idobject;

        switch (id)
        {
            case 0:

                if (money >= 10000)
                {
                    money += -10000;
                    deliveryseconds += 10;
                    deliverysecondstext.text = deliveryseconds + "s";
                    newsound.GetComponent<AudioSource>().Play();
                }
                break;
            case 1:
                if (money >= 20000)
                {
                    money += -20000;
                    deliveryseconds += 20;
                    deliverysecondstext.text = deliveryseconds + "s";
                    newsound.GetComponent<AudioSource>().Play();
                }
                break;
            case 2:
                if (money >= 30000)
                {
                    money += -30000;
                    deliveryseconds += 30;
                    deliverysecondstext.text = deliveryseconds + "s";
                    newsound.GetComponent<AudioSource>().Play();
                }
                break;
        }
    }

    /*public void WorkersButtons(GameObject button)
    {
        id = button.GetComponent<id>().idobject;
        int actualworkers = dmain.GetComponent<PropertyDisplayMain>().actualpro.GetComponent<PropertyInfo>().ingamedata.GetComponent<ProInGameData>().actualworkers;
        int workersmax = dmain.GetComponent<PropertyDisplayMain>().property.workersmax;
        int plusworkers = dmain.GetComponent<PropertyDisplayMain>().actualpro.GetComponent<PropertyInfo>().ingamedata.GetComponent<ProInGameData>().plusworkers;

        switch (id)
        {
            case 0:

                if (money >= 2000 && (actualworkers+5) <= workersmax)
                {
                    dmain.GetComponent<PropertyDisplayMain>().actualpro.GetComponent<PropertyInfo>().ingamedata.GetComponent<ProInGameData>().plusworkers += 5;
                    costnewworkers += 2000;
                    dmain.GetComponent<PropertyDisplayMain>().onclick(dmain.GetComponent<PropertyDisplayMain>().actualpro);
                }
                break;
            case 1:
                if ((plusworkers-5) >= 0)
                {
                    dmain.GetComponent<PropertyDisplayMain>().actualpro.GetComponent<PropertyInfo>().ingamedata.GetComponent<ProInGameData>().plusworkers -= 5;
                    costnewworkers -= 2000;
                    dmain.GetComponent<PropertyDisplayMain>().onclick(dmain.GetComponent<PropertyDisplayMain>().actualpro);
                }
                break;
        }
    }*/

    void WorkersClientsGlobal()
    {
        for (int i = 0; i < lossantos.Count; i++)
        {
            workers += lossantos[i].GetComponent<PropertyInfo>().ingamedata.GetComponent<ProInGameData>().actualworkers;
            clients += lossantos[i].GetComponent<PropertyInfo>().ingamedata.GetComponent<ProInGameData>().actualclients;
        }
        for (int i = 0; i < springfield.Count; i++)
        {
            workers += springfield[i].GetComponent<PropertyInfo>().ingamedata.GetComponent<ProInGameData>().actualworkers;
            clients += springfield[i].GetComponent<PropertyInfo>().ingamedata.GetComponent<ProInGameData>().actualclients;
        }

        displayworkers.text = workers.ToString();
        displayclients.text = clients.ToString();
        workers = 0;
        clients = 0;
    }

    void DisplayCountryProfits()
    {
        int nprofitssantos = 0;
        int nprofitsspringfield = 0;

        for(int i =0; i< lossantos.Count; i++)
        {
            nprofitssantos += lossantos[i].GetComponent<PropertyInfo>().ingamedata.GetComponent<ProInGameData>().nprofits;
        }
        for(int i = 0; i < springfield.Count; i++)
        {
            nprofitsspringfield += springfield[i].GetComponent<PropertyInfo>().ingamedata.GetComponent<ProInGameData>().nprofits;
        }

        profitssantos.text = nprofitssantos.ToString();

        profitsspring.text = nprofitsspringfield.ToString();
    }

    public void SaveData()
    {
        SaveSystem.SaveMoney(this);
    }
    public void LoadData()
    {

        MoneyData data = SaveSystem.LoadMoney();

        if (data == null)
        {
            SaveData();
        }
        else
        {
            money = data.money;
            notgiveinicialmoney = data.notgiveinicialmoney;
            plusclients = data.plusclients;
            moneywebupgrades = data.moneywebupgrades;
            deliveryseconds = data.deliveryseconds;

            for (int i = 0; i < data.webupgrades.Count; i++)
            {
                WebButtonsLoad(data.webupgrades[i]);
            }
        }
    }

    public void RemoveProgess()
    {
        cost = 0;
        nclients = 0;
        plusclients = 0;
        moneywebupgrades = 0;
        webupgrades.Clear();
        deliveryseconds = 0;

        web1.GetComponent<id>().used = false;
        web1.GetComponent<id>().buy.SetActive(false);
        web2.GetComponent<id>().used = false;
        web2.GetComponent<id>().buy.SetActive(false);
        web3.GetComponent<id>().used = false;
        web3.GetComponent<id>().buy.SetActive(false);

        moneytimer = 0.0f;
        workerstimer = 0.0f;
        deliverytimer = 0.0f;

        money = 0;
    }

    public void startmoney()
    {
        money = 1000000;

        displaymoney.text = money.ToString();
        displayads.text = plusclients.ToString();
        displaywebprofits.text = "+" + moneywebupgrades + "/5s";
        deliverysecondstext.text = deliveryseconds + "s";
        WorkersClientsGlobal();

        SaveData();
    }

    // Start is called before the first frame update
    void Start()
    {
        lossantos = countrydata.gameObject.GetComponent<InfoCountries>().prolossantos;
        springfield = countrydata.gameObject.GetComponent<InfoCountries>().prospringfield;

        
        LoadData();

        //-------------------------------------- solo se debe ejecutar cuando es la primera vez que se inicia la app ----------------------------
        if (!notgiveinicialmoney)
        {
            money = 1000000;
            notgiveinicialmoney = true;
        }
        //---------------------------------------------------------------------------------------------------------------------------------------

        displaymoney.text = money.ToString();
        displayads.text = plusclients.ToString();
        displaywebprofits.text = "+" + moneywebupgrades + "/5s";
        deliverysecondstext.text = deliveryseconds + "s";
        DisplayCountryProfits();
        WorkersClientsGlobal();
    }

    // Update is called once per frame
    void Update()
    {
        if (moneytimer < 5)
        {
            moneytimer += Time.deltaTime;
        }
        else
        {


            moneytimer = 0.0f;
            Money(lossantos);
            Money(springfield);
            money += cost + moneywebupgrades;
            money += -countrydata.GetComponent<InfoCountries>().costnewworkers;
            displaymoney.text = money.ToString();


            ClientsOrders(lossantos);
            ClientsOrders(springfield);

            displaymoney.text = money.ToString();
            dmain.GetComponent<PropertyDisplayMain>().onclick(dmain.GetComponent<PropertyDisplayMain>().actualpro);

            if (plusclients > 0)
            {
                plusclients--;
                displayads.text = plusclients.ToString();
            }



            SaveData();
            
        }
        if (workerstimer < 10)
        {
            workerstimer += Time.deltaTime;
        }
        else
        {
            workerstimer = 0.0f;

            WorkersPro(lossantos);
            WorkersPro(springfield);

            displaymoney.text = money.ToString();
            dmain.GetComponent<PropertyDisplayMain>().onclick(dmain.GetComponent<PropertyDisplayMain>().actualpro);
        }

        if (deliverytimer < 1)
        {
            deliverytimer += Time.deltaTime;
        }
        else
        {
            deliverytimer = 0.0f;

            if (deliveryseconds > 0)
            {
                for (int i = 0; i < lossantos.Count; i++)
                {
                    level = lossantos[i].GetComponent<PropertyInfo>().ingamedata.GetComponent<ProInGameData>().level;
                    int clients = lossantos[i].GetComponent<PropertyInfo>().ingamedata.GetComponent<ProInGameData>().actualclients;
                    int orders = lossantos[i].GetComponent<PropertyInfo>().ingamedata.GetComponent<ProInGameData>().actualorders;

                    if (level >= 1 && (clients - 4) >= 0 && (orders - 8) >= 0)
                    {
                        lossantos[i].GetComponent<PropertyInfo>().ingamedata.GetComponent<ProInGameData>().actualclients -= 4;
                        lossantos[i].GetComponent<PropertyInfo>().ingamedata.GetComponent<ProInGameData>().actualorders -= 8;

                        money += 4 * 4000;
                        lossantos[i].GetComponent<PropertyInfo>().ingamedata.GetComponent<ProInGameData>().nprofits += 4 * 2000;

                    }
                }
                for (int i = 0; i < springfield.Count; i++)
                {
                    level = springfield[i].GetComponent<PropertyInfo>().ingamedata.GetComponent<ProInGameData>().level;
                    int clients = springfield[i].GetComponent<PropertyInfo>().ingamedata.GetComponent<ProInGameData>().actualclients;
                    int orders = springfield[i].GetComponent<PropertyInfo>().ingamedata.GetComponent<ProInGameData>().actualorders;

                    if (level >= 1 && (clients - 4) >= 0 && (orders - 8) >= 0)
                    {
                        springfield[i].GetComponent<PropertyInfo>().ingamedata.GetComponent<ProInGameData>().actualclients -= 4;
                        springfield[i].GetComponent<PropertyInfo>().ingamedata.GetComponent<ProInGameData>().actualorders -= 8;

                        money += 4 * 4000;
                        springfield[i].GetComponent<PropertyInfo>().ingamedata.GetComponent<ProInGameData>().nprofits += 4 * 2000;

                    }
                }

                deliveryseconds--;
                deliverysecondstext.text = deliveryseconds + "s";
            }
        }



        DisplayCountryProfits();
        WorkersClientsGlobal();
        dmain.GetComponent<PropertyDisplayMain>().onclick(dmain.GetComponent<PropertyDisplayMain>().actualpro);

        if (dmain.GetComponent<PropertyDisplayMain>().actualpro.GetComponent<PropertyInfo>().ingamedata.GetComponent<ProInGameData>().level == 1)
        {
            lvlupbutton.SetActive(false);
        }
        else
        {
            lvlupbutton.SetActive(true);
        }
    }
}
