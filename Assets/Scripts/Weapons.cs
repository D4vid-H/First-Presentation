using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons : MonoBehaviour
{

    [SerializeField] private List<GameObject> m_weapons = new List<GameObject>();



    public void AddWeapons(GameObject weapon)
    {
        m_weapons.Add(weapon);
    }

    public GameObject GetWeapons(bool select) 
    {
        if (select)
        {
            for(int i=0; i< m_weapons.Count; i++)
            {
                return m_weapons[i];
            }
        }
        else
        {
            for (int i = m_weapons.Count - 1; i >= 0 ; i--)
            {
                return m_weapons[i];
            }
        }

        return m_weapons[0];
    }



}
