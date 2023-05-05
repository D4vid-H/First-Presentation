using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private GameObject[] m_enemys;
    [SerializeField] private GameObject m_enemyActive = null;
    private Boolean m_isShoot = false;
    // Start is called before the first frame update
    private void Awake()
    {
        m_enemys = GameObject.FindGameObjectsWithTag("Enemy");        
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (m_isShoot)
        {            
            m_enemyActive = m_enemys[SelectRandom()];

            if (m_enemyActive.gameObject.name == "EnemyOne" && (m_enemyActive.GetComponent<EnemyOne>().GetHealtEnemy() > 0))
            {
                EnemySelect(m_enemyActive);
            }
            else if (m_enemyActive.gameObject.name == "EnemyTwo" && (m_enemyActive.GetComponent<EnemyTwo>().GetHealtEnemy() > 0))
            {
                EnemySelect(m_enemyActive);
            }
            else if (m_enemyActive.gameObject.name == "EnemyThree" && (m_enemyActive.GetComponent<EnemyThree>().GetHealtEnemy() > 0))
            {
                EnemySelect(m_enemyActive);
            }
            m_isShoot = false;

        }
        if (!m_isShoot)
        {
            if(m_enemyActive.GetComponent<EnemyTwo>().GetHealtEnemy() <= 0)
            {
                m_isShoot = true;
            }

        }
        
    }    
    private int SelectRandom()
    {
        int l_random = UnityEngine.Random.Range(0, 3);
        Debug.Log(l_random);
        return l_random;
    }

    private void EnemySelect(GameObject p_enemy)
    {
        Debug.Log("Nombre q entra al switch" + p_enemy.name);
        switch (p_enemy.name)
        {
            case "EnemyOne":
                p_enemy.GetComponent<EnemyOne>().enabled = true;
                p_enemy.GetComponent<Animator>().enabled = true;
                break;
            case "EnemyTwo":
                p_enemy.GetComponent<EnemyTwo>().enabled = true;
                p_enemy.GetComponent<Animator>().enabled = true;
                break;
            case "EnemyThree":
                p_enemy.GetComponent<EnemyThree>().enabled = true;
                p_enemy.GetComponent<Animator>().enabled = true;
                break;
        }
    }
    
    public void IsActive(Boolean p_isActive)
    {
        m_isShoot = p_isActive;

    }
}
