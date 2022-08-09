using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ProData
{
    public bool notgiveinicialpro;
    public List<int> prolossantosdata = new List<int>();
    public List<int> prospringfielddata = new List<int>();

    public ProData(InfoCountries inco)
    {
        notgiveinicialpro = inco.notgiveinicialpro;
        prolossantosdata = inco.prolossantosdata;
        prospringfielddata = inco.prospringfielddata;
    }
}
