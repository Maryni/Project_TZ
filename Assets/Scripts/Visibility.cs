using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Visibility : MonoBehaviour
{
    [SerializeField] GameObject menu;
    public void ChangeBool()
    {
        if (menu.gameObject.activeSelf)
        {
            menu.gameObject.SetActive(false);
        }
        else
        {
            menu.gameObject.SetActive(true);
        }
    }
}
