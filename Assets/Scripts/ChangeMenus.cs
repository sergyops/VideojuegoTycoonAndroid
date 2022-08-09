using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMenus : MonoBehaviour
{
    public void showMenu(GameObject nameMenu)
    {
        nameMenu.SetActive(true);
    }

    public void hideMenu(GameObject nameMenu)
    {
        nameMenu.SetActive(false);
    }
}
