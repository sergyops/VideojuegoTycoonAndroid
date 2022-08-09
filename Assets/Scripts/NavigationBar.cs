using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NavigationBar : MonoBehaviour
{
    [SerializeField] GameObject[] todisable,buttons;

    public void NavigationPropServ(GameObject active)
    {
        for(int i = 0; i < todisable.Length; i++)
        {
            todisable[i].SetActive(false);
        }
        active.SetActive(true);
    }

    public void ChangeColor(GameObject button)
    {

        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].GetComponent<Image>().color = new Color32(104, 104, 104, 255);
        }
        button.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
    }
}
