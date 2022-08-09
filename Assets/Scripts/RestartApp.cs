using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartApp : MonoBehaviour
{
    public InfoCountries infco;

    public MoneyManager moma;
    public void Restart()
    {
        infco.GetComponent<InfoCountries>().RemoveProgres();
        infco.GetComponent<InfoCountries>().StartPro();

        moma.GetComponent<MoneyManager>().RemoveProgess();
        moma.GetComponent<MoneyManager>().startmoney();
    }
}
