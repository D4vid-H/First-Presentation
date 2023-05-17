using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyGunController : MonoBehaviour
{
    [SerializeField] private GameObject[] m_enemys;
    private GameObject m_enemyActive;
    private Boolean m_isShoot = false;
    // Start is called before the first frame update
    private void Awake()
    {
        m_enemys = GameObject.FindGameObjectsWithTag("Enemy");        
    }
    // Update is called once per frame
    void Update()
    {
        EnemyActive();
        EnemyChange();        
    }    

    private int RandomEnemy()
    {
        int l_random = UnityEngine.Random.Range(0, 3);
        return l_random;
    }

    private void EnemySelect(GameObject p_enemy)
    {
        switch (p_enemy.name)
        {
            case "EnemyOne":
                p_enemy.GetComponent<EnemyGunOne>().enabled = true;
                p_enemy.GetComponent<Animator>().enabled = true;
                break;
            case "EnemyTwo":
                p_enemy.GetComponent<EnemyGunTwo>().enabled = true;
                p_enemy.GetComponent<Animator>().enabled = true;
                break;
            case "EnemyThree":
                p_enemy.GetComponent<EnemyGunThree>().enabled = true;
                p_enemy.GetComponent<Animator>().enabled = true;
                break;
        }
    }    

    public void IsActive(Boolean p_isActive)
    {
        m_isShoot = p_isActive;
    }

    private void EnemyActive()
    {
        if (m_isShoot)
        {
            m_enemyActive = m_enemys[RandomEnemy()];
            Debug.Log(m_enemyActive.gameObject.name);
            if (m_enemyActive.gameObject.name == "EnemyOne" && (m_enemyActive.GetComponent<EnemyGunOne>().GetHealtEnemy() > 0))
            {
                EnemySelect(m_enemyActive);
            }
            else if (m_enemyActive.gameObject.name == "EnemyTwo" && (m_enemyActive.GetComponent<EnemyGunTwo>().GetHealtEnemy() > 0))
            {
                EnemySelect(m_enemyActive);
            }
            else if (m_enemyActive.gameObject.name == "EnemyThree" && (m_enemyActive.GetComponent<EnemyGunThree>().GetHealtEnemy() > 0))
            {
                EnemySelect(m_enemyActive);
            }
            m_isShoot = false;
        }
    }

    private void EnemyChange()
    {
        if (!m_isShoot && m_enemyActive)
        {
            if (m_enemyActive.TryGetComponent<EnemyGunOne>(out EnemyGunOne l_enemyOne) && l_enemyOne.GetHealtEnemy() <= 0)
            {
                m_isShoot = true;
            }
            if (m_enemyActive.TryGetComponent<EnemyGunTwo>(out EnemyGunTwo l_enemyTwo) && l_enemyTwo.GetHealtEnemy() <= 0)
            {
                m_isShoot = true;
            }
            if (m_enemyActive.TryGetComponent<EnemyGunThree>(out EnemyGunThree l_enemyThree) && l_enemyThree.GetHealtEnemy() <= 0)
            {
                m_isShoot = true;
            }
        }
    }

}
