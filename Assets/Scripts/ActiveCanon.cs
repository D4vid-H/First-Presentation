using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ActiveCanon : MonoBehaviour
{
    [SerializeField] GameObject[] m_canonEnemyActive;

    private void Awake()
    {
        m_canonEnemyActive = GameObject.FindGameObjectsWithTag("Enemy");
    }

    private void OnTriggerExit(Collider other)
    {
        for(int i =0;  i<m_canonEnemyActive.Length; i++)
        {
            if (m_canonEnemyActive[i].name == "Canon_lvl_3")
            {
                m_canonEnemyActive[i].GetComponent<EnemyController>().IsActiveEnemy(true);
            }
        }
    }





}
