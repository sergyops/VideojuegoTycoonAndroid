using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProfileFunc : MonoBehaviour
{
    public InputField nombre, empresa;

    public GameObject music, soundbutton, soundlvlup, soundnew, enablesoundimage, disablesoundimage, enablemusicimage, disablemusicimage;

    public string nombretxt, empresatxt;

    public bool enablesound, enablemusic, notinicialconf;

    public void ChangeText(InputField objectchange)
    {
        switch (objectchange.GetComponent<id>().idobject)
        {
            case 0:
                nombretxt = objectchange.text;
                Debug.Log(nombretxt);
                SaveData();
                break;
            case 1:
                empresatxt = objectchange.text;
                Debug.Log(empresatxt);
                SaveData();
                break;
        }
    }

    public void EnableSound(bool enable)
    {
        soundbutton.GetComponent<AudioSource>().mute = enable;
        soundlvlup.GetComponent<AudioSource>().mute = enable;
        soundnew.GetComponent<AudioSource>().mute = enable;

        enablesound = enable;

        SaveData();
    }

    public void EnableMusic(bool enable)
    {
        music.GetComponent<AudioSource>().mute = enable;

        enablemusic = enable;

        SaveData();
    }

    public void LoadEnableSound(bool enable)
    {
        soundbutton.GetComponent<AudioSource>().mute = enable;
        soundlvlup.GetComponent<AudioSource>().mute = enable;
        soundnew.GetComponent<AudioSource>().mute = enable;

        if (enable)
        {
            enablesoundimage.SetActive(false);
            disablesoundimage.SetActive(true);
        }
        else
        {
            enablesoundimage.SetActive(true);
            disablesoundimage.SetActive(false);
        }


        SaveData();
    }

    public void LoadEnableMusic(bool enable)
    {
        music.GetComponent<AudioSource>().mute = enable;

        if (enable)
        {
            enablemusicimage.SetActive(false);
            disablemusicimage.SetActive(true);
        }
        else
        {
            enablemusicimage.SetActive(true);
            disablemusicimage.SetActive(false);
        }

        SaveData();
    }

    public void ClickMusic()
    {
        if (enablemusic)
        {
            enablemusic = false;

            EnableMusic(enablemusic);

            enablemusicimage.SetActive(true);
            disablemusicimage.SetActive(false);
        }
        else
        {
            enablemusic = true;

            EnableMusic(enablemusic);

            enablemusicimage.SetActive(false);
            disablemusicimage.SetActive(true);
        }
    }

    public void ClickSound()
    {
        if (enablesound)
        {
            enablesound = false;

            EnableSound(enablesound);

            enablesoundimage.SetActive(true);
            disablesoundimage.SetActive(false);
        }
        else
        {
            enablesound = true;

            EnableSound(enablesound);

            enablesoundimage.SetActive(false);
            disablesoundimage.SetActive(true);
        }
    }


    public void SaveData()
    {
        SaveSystem.SaveProfile(this);
    }
    public void LoadData()
    {

        ProfileData data = SaveSystem.LoadProfile();

        if (data == null)
        {
            SaveData();
        }
        else
        {
            nombretxt = data.nombre;
            empresatxt = data.empresa;

            enablesound = data.sound;
            enablemusic = data.music;

            notinicialconf = data.notinicialconf;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        LoadData();

        //----------------------------------Ejecutar solo el primer inicio----------------------
        if (!notinicialconf)
        {
            enablesound = false;
            enablemusic = false;

            notinicialconf = true;

            SaveData();
        }
        //--------------------------------------------------------------------------------------

        nombre.text = nombretxt;
        empresa.text = empresatxt;
        LoadEnableSound(enablesound);
        LoadEnableMusic(enablemusic);
    }
}
