using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject[] m_OptionsMenu;

    private void Awake()
    {
        m_OptionsMenu = (GameObject.FindGameObjectsWithTag("MenuObject"));
        for (int i = 0; i < m_OptionsMenu.Length; i++)
        {
            m_OptionsMenu[i].gameObject.SetActive(false);
        }
    }

    private void Start()
    {
        ActiveMainMenu();
    }

    public void ActiveMainMenu()
    {
        Debug.Log("Entre al MainMenu");
        for(int i=0; i<m_OptionsMenu.Length; i++)
        {
            if (m_OptionsMenu[i].name == "MainMenu")
            {
                m_OptionsMenu[i].gameObject.SetActive(true);
            }
            else
            {
                m_OptionsMenu[i].gameObject.SetActive(false);
            }
        }
    }

    public void ActiveOptionsMenu()
    {
        Debug.Log("Entre al OptionsMenu");
        for (int i = 0; i < m_OptionsMenu.Length; i++)
        {
            if (m_OptionsMenu[i].name == "OptionsMenu")
            {
                m_OptionsMenu[i].gameObject.SetActive(true);
            }
            else
            {
                m_OptionsMenu[i].gameObject.SetActive(false);
            }
        }
    }

    public void ActiveCredits()
    {
        Debug.Log("Entre al Credits");
        for (int i = 0; i < m_OptionsMenu.Length; i++)
        {
            if (m_OptionsMenu[i].name == "Credits")
            {
                m_OptionsMenu[i].gameObject.SetActive(true);
            }
            else
            {
                m_OptionsMenu[i].gameObject.SetActive(false);
            }
        }
    }

    public void ActiveDemo()
    {
        Debug.Log("Entre al Demo");
        for (int i = 0; i < m_OptionsMenu.Length; i++)
        {
            if (m_OptionsMenu[i].name == "Demo")
            {
                m_OptionsMenu[i].gameObject.SetActive(true);
            }
            else
            {
                m_OptionsMenu[i].gameObject.SetActive(false);
            }
        }
    }

    public void ToMainMenu()
    {
        ActiveMainMenu();
    }

}
