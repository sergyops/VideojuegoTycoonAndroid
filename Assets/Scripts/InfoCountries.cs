using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoCountries : MonoBehaviour
{
    public Country lossantos, springfield;
    public Text countrytextmain, numpro, numprosantoscountry, numprospringcountry, profitssantoscountry, profitsspringcountry;
    public GameObject uibutton, prefab, prolist, newsound, datapro;
    string country;
    int propsantos, propspring;
    


    public List<GameObject> prolossantos = new List<GameObject>();
    public List<GameObject> dataprolossantos = new List<GameObject>();

    public List<GameObject> prospringfield = new List<GameObject>();
    public List<GameObject> dataprospringfield = new List<GameObject>();

    public List<int> prolossantosdata = new List<int>();//save


    public List<int> prospringfielddata = new List<int>();//save

    public bool notgiveinicialpro;//save

    Transform child,childdatapro;
    GameObject instanciado, instanciadodata;
    public int idsantos, idspring, posarrows, costnewworkers;

    public PropertyDisplayMain display;
    public MoneyManager moma;

    public void LosSantos()
    {
        for (int i=0; i<prospringfield.Count; i++)
        {
            prospringfield[i].SetActive(false);
        }
        for (int i=0; i<prolossantos.Count; i++)
        {
            prolossantos[i].SetActive(true);
        }
        
        country = "lossantos";
        propsantos = prolossantos.Count;

        countrytextmain.text = lossantos.namecountry;
        numpro.text = propsantos + "/" + lossantos.maxproperties;

        display.gameObject.GetComponent<PropertyDisplayMain>().onclick(prolossantos[0]);
    }
    public void Springfield()
    {
        for (int i = 0; i < prolossantos.Count; i++)
        {
            prolossantos[i].SetActive(false);
        }
        for (int i = 0; i < prospringfield.Count; i++)
        {
            prospringfield[i].SetActive(true);
        }

        country = "springfield";
        propspring = prospringfield.Count;

        countrytextmain.text = springfield.namecountry;
        numpro.text = propspring + "/" + springfield.maxproperties;

        display.gameObject.GetComponent<PropertyDisplayMain>().onclick(prospringfield[0]);
    }

    public void InstanciatePrefab()//solo se ejecuta cuando das click al boton de crear propiedad
    {
        if (country == "lossantos" && prolossantos.Count < lossantos.maxproperties)
        {

            CodeToInstanciate(true);
            propsantos++;

            numpro.text = propsantos + "/" + lossantos.maxproperties;
            DisplayCountryInfo();

            prolossantos.Add(instanciado);
            dataprolossantos.Add(instanciadodata);

            newsound.GetComponent<AudioSource>().Play();

            SaveData();
        }
        else if (country == "springfield" && prospringfield.Count < springfield.maxproperties)
        {

            CodeToInstanciate(true);
            propspring++;

            numpro.text = propspring + "/" + springfield.maxproperties;
            DisplayCountryInfo();

            prospringfield.Add(instanciado);
            dataprospringfield.Add(instanciadodata);

            newsound.GetComponent<AudioSource>().Play();

            SaveData();
        }
    }

    void CodeToInstanciate(bool active)//para instanciar propiedades en codigo
    {
        if (country == "lossantos")
        {
            //---------------> crear una instancia del prefab, colocarlo en la lista y cambiar el nombre <-------------

            child = uibutton.transform.parent;//recoge el padre del UI que tenemos en la variable "uibutton"
            prefab.name = "Pro_" + country + "_" + idsantos;//Le pone un nombre con un id que es un numero
            instanciado = Instantiate(prefab, child);//instancia el prefab y lo añade como el mismo child del UI de "uibutton"
            instanciado.SetActive(active);
            instanciado.GetComponent<PropertyInfo>().ingamedata.GetComponent<ProInGameData>().id = idsantos;
            instanciado.GetComponent<PropertyInfo>().ingamedata.GetComponent<ProInGameData>().idcountry = 10;
            instanciado.GetComponent<PropertyInfo>().ingamedata = instanciadodata;

            uibutton.transform.SetAsLastSibling();//Envía "uibutton" al final de la lista de hirachy

            //---------------------------------------datos de la propiedad ------------------------------------------
            childdatapro = datapro.transform.parent;

            instanciadodata = Instantiate(datapro,childdatapro);
            instanciadodata.name = "ProData_" + country + "_" + idsantos;

            //-----------------------------------------------------------------------------------------------------

            //---------------------------------------------se añaden referencias de cada uno-----------------------
            instanciadodata.GetComponent<ProInGameData>().gameobjectpro = instanciado;
            instanciado.GetComponent<PropertyInfo>().ingamedata = instanciadodata;

            //------------------------------------------------------------------------------------------------------------

            prolossantosdata.Insert(idsantos,0);

            idsantos++;
        }
        else if (country == "springfield")
        {
            //---------------> crear una instancia del prefab, colocarlo en la lista y cambiar el nombre <-------------

            child = uibutton.transform.parent;//recoge el padre del UI que tenemos en la variable "uibutton"
            prefab.name = "Pro_" + country + "_" + idspring;//Le pone un nombre con un id que es un numero
            instanciado = Instantiate(prefab, child);//instancia el prefab y lo añade como el mismo child del UI de "uibutton"
            instanciado.SetActive(active);
            instanciado.GetComponent<PropertyInfo>().ingamedata.GetComponent<ProInGameData>().id = idspring;
            instanciado.GetComponent<PropertyInfo>().ingamedata.GetComponent<ProInGameData>().idcountry = 20;

            uibutton.transform.SetAsLastSibling();//Envía "uibutton" al final de la lista de hirachy

            //---------------------------------------datos de la propiedad ------------------------------------------
            childdatapro = datapro.transform.parent;

            instanciadodata = Instantiate(datapro, childdatapro);
            instanciadodata.name = "ProData_" + country + "_" + idspring;

            //-----------------------------------------------------------------------------------------------------

            //---------------------------------------------se añaden referencias de cada uno-----------------------
            instanciadodata.GetComponent<ProInGameData>().gameobjectpro = instanciado;
            instanciado.GetComponent<PropertyInfo>().ingamedata = instanciadodata;

            //------------------------------------------------------------------------------------------------------------
            prospringfielddata.Insert(idspring, 0);

            idspring++;
        }
    }

    void InstanciateOnLoad(int id, int level)
    {
        if (country == "lossantos")
        {
            //---------------> crear una instancia del prefab, colocarlo en la lista y cambiar el nombre <-------------

            child = uibutton.transform.parent;//recoge el padre del UI que tenemos en la variable "uibutton"
            prefab.name = "Pro_" + country + "_" + id;//Le pone un nombre con un id que es un numero
            instanciado = Instantiate(prefab, child);//instancia el prefab y lo añade como el mismo child del UI de "uibutton"
            instanciado.SetActive(false);
            instanciado.GetComponent<PropertyInfo>().ingamedata.GetComponent<ProInGameData>().id = id;
            instanciado.GetComponent<PropertyInfo>().ingamedata.GetComponent<ProInGameData>().idcountry = 10;
            instanciado.GetComponent<PropertyInfo>().ingamedata = instanciadodata;

            uibutton.transform.SetAsLastSibling();//Envía "uibutton" al final de la lista de hirachy

            //---------------------------------------datos de la propiedad ------------------------------------------
            childdatapro = datapro.transform.parent;

            instanciadodata = Instantiate(datapro, childdatapro);
            instanciadodata.name = "ProData_" + country + "_" + id;


            instanciadodata.GetComponent<ProInGameData>().level = level;

            //-----------------------------------------------------------------------------------------------------

            //---------------------------------------------se añaden referencias de cada uno-----------------------
            instanciadodata.GetComponent<ProInGameData>().gameobjectpro = instanciado;
            instanciado.GetComponent<PropertyInfo>().ingamedata = instanciadodata;

            //-----------------------------------------------------------------------------------------------------

            prolossantos.Add(instanciado);
            prolossantosdata.Insert(id, level);
            dataprolossantos.Add(instanciadodata);

            idsantos++;
        }
        else if (country == "springfield")
        {
            //---------------> crear una instancia del prefab, colocarlo en la lista y cambiar el nombre <-------------

            child = uibutton.transform.parent;//recoge el padre del UI que tenemos en la variable "uibutton"
            prefab.name = "Pro_" + country + "_" + id;//Le pone un nombre con un id que es un numero
            instanciado = Instantiate(prefab, child);//instancia el prefab y lo añade como el mismo child del UI de "uibutton"
            instanciado.SetActive(false);
            instanciado.GetComponent<PropertyInfo>().ingamedata.GetComponent<ProInGameData>().id = id;
            instanciado.GetComponent<PropertyInfo>().ingamedata.GetComponent<ProInGameData>().idcountry = 20;

            uibutton.transform.SetAsLastSibling();//Envía "uibutton" al final de la lista de hirachy

            //---------------------------------------datos de la propiedad ------------------------------------------
            childdatapro = datapro.transform.parent;

            instanciadodata = Instantiate(datapro, childdatapro);
            instanciadodata.name = "ProData_" + country + "_" + id;


            instanciadodata.GetComponent<ProInGameData>().level = level;

            //-----------------------------------------------------------------------------------------------------

            //---------------------------------------------se añaden referencias de cada uno-----------------------
            instanciadodata.GetComponent<ProInGameData>().gameobjectpro = instanciado;
            instanciado.GetComponent<PropertyInfo>().ingamedata = instanciadodata;

            //------------------------------------------------------------------------------------------------------------

            prospringfield.Add(instanciado);
            prospringfielddata.Insert(id, level);
            dataprospringfield.Add(instanciadodata);

            idspring++;
        }
    }
    public void SaveOnLvlUp(GameObject prolvl)
    {
        int id = prolvl.GetComponent<ProInGameData>().id;
        int lvl = prolvl.GetComponent<ProInGameData>().level;
        int idcountry = prolvl.GetComponent<ProInGameData>().idcountry;

        if (idcountry == 10)
        {
            prolossantosdata[id] = lvl;
        }else if (idcountry == 20)
        {
            prospringfielddata[id] = lvl;
        }
        SaveData();
    }

    public void WorkersButtons(GameObject button)
    {
        int id = button.GetComponent<id>().idobject;
        int actualworkers = display.GetComponent<PropertyDisplayMain>().actualpro.GetComponent<PropertyInfo>().ingamedata.GetComponent<ProInGameData>().actualworkers;
        int workersmax = display.GetComponent<PropertyDisplayMain>().property.workersmax;
        int plusworkers = display.GetComponent<PropertyDisplayMain>().actualpro.GetComponent<PropertyInfo>().ingamedata.GetComponent<ProInGameData>().plusworkers;

        switch (id)
        {
            case 0:

                if (moma.GetComponent<MoneyManager>().money >= 2000 && (actualworkers + 5) <= workersmax)
                {
                    display.GetComponent<PropertyDisplayMain>().actualpro.GetComponent<PropertyInfo>().ingamedata.GetComponent<ProInGameData>().plusworkers += 5;
                    costnewworkers += 2000;
                    display.GetComponent<PropertyDisplayMain>().onclick(display.GetComponent<PropertyDisplayMain>().actualpro);
                    newsound.GetComponent<AudioSource>().Play();

                }
                break;
            case 1:
                if ((plusworkers - 5) >= 0)
                {
                    display.GetComponent<PropertyDisplayMain>().actualpro.GetComponent<PropertyInfo>().ingamedata.GetComponent<ProInGameData>().plusworkers -= 5;
                    costnewworkers -= 2000;
                    display.GetComponent<PropertyDisplayMain>().onclick(display.GetComponent<PropertyDisplayMain>().actualpro);
                    newsound.GetComponent<AudioSource>().Play();
                }
                break;
        }
    }

    void DisplayCountryInfo()
    {
        numprosantoscountry.text = propsantos + "/" + lossantos.maxproperties;
        profitssantoscountry.text = "0K/h";

        numprospringcountry.text = propspring + "/" + springfield.maxproperties;
        profitsspringcountry.text = "0K/h";
    }

    public void LeftArrow()
    {
        if (country == "lossantos")
        {
            if (posarrows > 0)
            {
                posarrows--;
                display.gameObject.GetComponent<PropertyDisplayMain>().onclick(prolossantos[posarrows]);
            }
            else
            {
                posarrows = prolossantos.Count-1;
                display.gameObject.GetComponent<PropertyDisplayMain>().onclick(prolossantos[posarrows]);
            }
        }else if (country == "springfield")
        {
            if (posarrows > 0)
            {
                posarrows--;
                display.gameObject.GetComponent<PropertyDisplayMain>().onclick(prospringfield[posarrows]);
            }
            else
            {
                posarrows = prospringfield.Count-1;
                display.gameObject.GetComponent<PropertyDisplayMain>().onclick(prospringfield[posarrows]);
            }
        }
    }

    public void RightArrow()
    {
        if (country == "lossantos")
        {
            if (posarrows < prolossantos.Count-1)
            {
                posarrows++;
                display.gameObject.GetComponent<PropertyDisplayMain>().onclick(prolossantos[posarrows]);
            }
            else
            {
                posarrows = 0;
                display.gameObject.GetComponent<PropertyDisplayMain>().onclick(prolossantos[posarrows]);
            }
        }
        else if (country == "springfield")
        {
            if (posarrows < prospringfield.Count-1)
            {
                posarrows++;
                display.gameObject.GetComponent<PropertyDisplayMain>().onclick(prospringfield[posarrows]);
            }
            else
            {
                posarrows = 0;
                display.gameObject.GetComponent<PropertyDisplayMain>().onclick(prospringfield[posarrows]);
            }
        }
    }

    public void SaveData()
    {
        SaveSystem.SavePro(this);
    }
    public void LoadData()
    {

        ProData data = SaveSystem.LoadPro();

        if (data == null)
        {
            SaveData();
        }
        else
        {
            notgiveinicialpro = data.notgiveinicialpro;

            country = "lossantos";
            for (int i = 0; i < data.prolossantosdata.Count; i++)
            {
                InstanciateOnLoad(i, data.prolossantosdata[i]);

            }

            country = "springfield";
            for (int i = 0; i < data.prospringfielddata.Count; i++)
            {
                InstanciateOnLoad(i, data.prospringfielddata[i]);
            }

        }
    }

    public void StartPro()
    {
        country = "lossantos";
        CodeToInstanciate(true);

        propsantos++;
        numpro.text = propsantos + "/" + lossantos.maxproperties;
        DisplayCountryInfo();
        prolossantos.Add(instanciado);

        country = "springfield";
        CodeToInstanciate(false);

        propspring++;
        DisplayCountryInfo();
        prospringfield.Add(instanciado);

        LosSantos();
        DisplayCountryInfo();
        display.gameObject.GetComponent<PropertyDisplayMain>().onclick(prolossantos[0]);

        notgiveinicialpro = true;
        SaveData();
    }
    public void RemoveProgres()
    {
        //------------------------------------limpieza de la lista de propiedades---------
        for (int i = 0; i < prospringfield.Count; i++)
        {
            Destroy(prospringfield[i]);
        }
        prospringfield.Clear();
        for (int i = 0; i < prolossantos.Count; i++)
        {
            Destroy(prolossantos[i]);
        }
        prolossantos.Clear();
        //------------------------------------limpieza de la lista de datos de propiedades---------
        for (int i = 0; i < dataprospringfield.Count; i++)
        {
            Destroy(dataprospringfield[i]);
        }
        dataprospringfield.Clear();
        for (int i = 0; i < dataprolossantos.Count; i++)
        {
            Destroy(dataprolossantos[i]);
        }
        dataprolossantos.Clear();
        //------------------------------------limpieza de la lista de datos guardados---------
        prospringfielddata.Clear();
        prolossantosdata.Clear();

        propsantos = 0;
        propspring = 0;
        idsantos = 0;
        idspring = 0;
        costnewworkers = 0;
    }


    // Start is called before the first frame update
    void Start()
    {
        LoadData();


        countrytextmain.text = lossantos.namecountry;


        //-------------------------------------- solo se debe ejecutar cuando es la primera vez que se inicia la app ----------------------------
        if (!notgiveinicialpro)
        {
            StartPro();
        }
        //------------------------------------------------------------------------------------------------------------------------------------

        LosSantos();
        DisplayCountryInfo();
        display.gameObject.GetComponent<PropertyDisplayMain>().onclick(prolossantos[0]);

    }
}