using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MoneyData
{
    public int money, plusclients, moneywebupgrades, deliveryseconds;
    public bool notgiveinicialmoney;
    public List<GameObject> webupgrades = new List<GameObject>();

    public MoneyData(MoneyManager moma)
    {
        money = moma.money;
        notgiveinicialmoney = moma.notgiveinicialmoney;
        plusclients = moma.plusclients;
        moneywebupgrades = moma.moneywebupgrades;
        webupgrades = moma.webupgrades;
        deliveryseconds = moma.deliveryseconds;
    }
}
