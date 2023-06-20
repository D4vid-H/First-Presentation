using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

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
                p_enemy.GetComponent<Collider>().enabled = true;
                p_enemy.GetComponent<Animator>().enabled = true;
                break;
            case "EnemyTwo":
                p_enemy.GetComponent<EnemyGunTwo>().enabled = true;
                p_enemy.GetComponent<Collider>().enabled = true;
                p_enemy.GetComponent<Animator>().enabled = true;
                break;
            case "EnemyThree":
                p_enemy.GetComponent<EnemyGunThree>().enabled = true;
                p_enemy.GetComponent<Collider>().enabled = true;
                p_enemy.GetComponent<Animator>().enabled = true;
                break;
        }
    }    

    public void IsActive(Boolean p_isActive)
    {
        m_isShoot = p_isActive;
    }


    public delegate void ToDiscover();
    public delegate void ToDead();

    public ToDiscover OnTargetRange;
    public ToDead DeadEnemy;
    public UnityEvent FireEventOne;
    public UnityEvent FireEventTwo;
    public UnityEvent FireEventThree;

    private void EnemyActive()
    {
        if (m_isShoot)
        {
            m_enemyActive = m_enemys[RandomEnemy()];
            if (m_enemyActive.gameObject.name == "EnemyOne" && (m_enemyActive.GetComponent<EnemyGunOne>().CurrentHealt() > 0))
            {
                EnemySelect(m_enemyActive);
                OnTargetRange?.Invoke();
                FireEventOne?.Invoke();
            }
            else if (m_enemyActive.gameObject.name == "EnemyTwo" && (m_enemyActive.GetComponent<EnemyGunTwo>().CurrentHealt() > 0))
            {
                EnemySelect(m_enemyActive);
                OnTargetRange?.Invoke();
                FireEventTwo?.Invoke();
            }
            else if (m_enemyActive.gameObject.name == "EnemyThree" && (m_enemyActive.GetComponent<EnemyGunThree>().CurrentHealt() > 0))
            {
                EnemySelect(m_enemyActive);
                OnTargetRange?.Invoke();
                FireEventThree?.Invoke();
            }
            m_isShoot = false;
        }
    }

    private void EnemyChange()
    {
        if (!m_isShoot && m_enemyActive)
        {
            if (m_enemyActive.TryGetComponent<EnemyGunOne>(out EnemyGunOne l_enemyOne) && l_enemyOne.CurrentHealt() <= 0)
            {
                m_isShoot = true;
                DeadEnemy?.Invoke();
            }
            if (m_enemyActive.TryGetComponent<EnemyGunTwo>(out EnemyGunTwo l_enemyTwo) && l_enemyTwo.CurrentHealt() <= 0)
            {
                m_isShoot = true;
                DeadEnemy?.Invoke();
            }
            if (m_enemyActive.TryGetComponent<EnemyGunThree>(out EnemyGunThree l_enemyThree) && l_enemyThree.CurrentHealt() <= 0)
            {
                m_isShoot = true;
                DeadEnemy?.Invoke();
            }
        }
    }

}
