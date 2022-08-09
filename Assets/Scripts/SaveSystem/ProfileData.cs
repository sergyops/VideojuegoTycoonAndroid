using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ProfileData
{
    public string nombre, empresa;
    public bool sound, music, notinicialconf;

    public ProfileData(ProfileFunc profun)
    {
        nombre = profun.nombretxt;
        empresa = profun.empresatxt;
        sound = profun.enablesound;
        music = profun.enablemusic;
        notinicialconf = profun.notinicialconf;
    }
}
