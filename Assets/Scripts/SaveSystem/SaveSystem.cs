using System.IO;
using UnityEngine;

public static class SaveSystem
{
    public static void SaveMoney(MoneyManager moma)
    {
        MoneyData data = new MoneyData(moma);

        string json = JsonUtility.ToJson(data);

        string path = Application.persistentDataPath + "/moneydata.json";

        File.WriteAllText(path, json);
    }

    public static MoneyData LoadMoney()
    {
        string path = Application.persistentDataPath + "/moneydata.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            MoneyData loadedmoneydata = JsonUtility.FromJson<MoneyData>(json);

            return loadedmoneydata;
        }
        else
        {
            Debug.LogError("El archivo de guardado no se encuentra en " + path);
            return null;
        }
    }

    public static void SavePro(InfoCountries inco)
    {
        ProData data = new ProData(inco);

        string json = JsonUtility.ToJson(data);

        string path = Application.persistentDataPath + "/prodata.json";

        File.WriteAllText(path, json);
    }

    public static ProData LoadPro()
    {
        string path = Application.persistentDataPath + "/prodata.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            ProData loadedprodata = JsonUtility.FromJson<ProData>(json);

            return loadedprodata;
        }
        else
        {
            Debug.LogError("El archivo de guardado no se encuentra en " + path);
            return null;
        }
    }

    public static void SaveProfile(ProfileFunc profun)
    {
        ProfileData data = new ProfileData(profun);

        string json = JsonUtility.ToJson(data);

        string path = Application.persistentDataPath + "/profiledata.json";

        File.WriteAllText(path, json);
    }

    public static ProfileData LoadProfile()
    {
        string path = Application.persistentDataPath + "/profiledata.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            ProfileData loadedprodata = JsonUtility.FromJson<ProfileData>(json);

            return loadedprodata;
        }
        else
        {
            Debug.LogError("El archivo de guardado no se encuentra en " + path);
            return null;
        }
    }
}
