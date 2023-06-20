using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGunThree : MonoBehaviour
{
    [SerializeField] private string m_name;
    [SerializeField] private Transform m_target;
    [SerializeField] private Bullets m_bulletToShoot;
    [SerializeField] private Transform m_shootingPointLUp;
    [SerializeField] private Transform m_shootingPointLDn;
    [SerializeField] private Transform m_shootingPointRUp;
    [SerializeField] private Transform m_shootingPointRDn;
    [SerializeField] private Transform m_bulletParentL;
    [SerializeField] private Transform m_bulletParentR;
    [SerializeField] private float m_delayShootBullets = 10f;
    private float m_healtEnemy;
    [SerializeField] private float m_healtFullEnemy;
    [SerializeField] private ParticleSystem[] m_particleSystem;
    [SerializeField] private ParticleSystem m_particleSystemDead;
    [SerializeField] private EnemyGunController m_enemyGunController;
    private float m_currentTime;
    private Boolean m_isDea = false;
    private void Awake()
    {
        m_currentTime = m_delayShootBullets;
        m_isDea = false;
        m_healtEnemy = m_healtFullEnemy;
        m_enemyGunController.FireEventThree.AddListener(ParticlesOn);
        m_particleSystem[0].gameObject.SetActive(false);
        m_particleSystem[1].gameObject.SetActive(false);
        m_particleSystem[2].gameObject.SetActive(false);
        m_particleSystem[3].gameObject.SetActive(false);
        m_particleSystemDead.gameObject.SetActive(false);
    }
    
    // Update is called once per frame
    void Update()
    {
        m_currentTime -= Time.deltaTime;
        FollowTarget();
        if (m_currentTime <= 0 && m_healtEnemy > 0)
        {           
            if (m_healtEnemy > 0) StartCoroutine(ShootDelay());
            //m_currentTime = m_delayShootBullets;
        }
        if (m_healtEnemy <= 0 && m_isDea)
        {
            Debug.Log("Enemy THREE Dead");
            gameObject.GetComponent<Animator>().enabled = false;
            GameManager.Instance.AddScoreplayer(EnemyDeadScore());
            m_particleSystem[0].gameObject.SetActive(false);
            m_particleSystem[1].gameObject.SetActive(false);
            m_particleSystem[2].gameObject.SetActive(false);
            m_particleSystem[3].gameObject.SetActive(false);
            m_particleSystemDead.gameObject.SetActive(true);
            m_isDea = false;
            StartCoroutine(DeadEnemyGun());
        }
    }
    IEnumerator ShootDelay()
    {
        //Instanciar(class in prefab, position to Shoot, direccion to shoot, GO parent to shoot)
        yield return new WaitForSeconds(1.5f);
        Instantiate(m_bulletToShoot, m_shootingPointLUp.position, Quaternion.Euler(90f, 0f, 0f), m_bulletParentL);
        Instantiate(m_bulletToShoot, m_shootingPointLDn.position, Quaternion.Euler(90f, 0f, 0f), m_bulletParentL);
        yield return new WaitForSeconds(0.5f);
        Instantiate(m_bulletToShoot, m_shootingPointRUp.position, Quaternion.Euler(90f, 0f, 0f), m_bulletParentR);
        Instantiate(m_bulletToShoot, m_shootingPointRDn.position, Quaternion.Euler(90f, 0f, 0f), m_bulletParentR);
    }
    private void FollowTarget()
    {
            transform.LookAt(m_target);        
    }
    public void SetHealtEnemy(float p_danoPlayer)
    {
        m_healtEnemy -= p_danoPlayer;
        if (m_healtEnemy <= 0) m_isDea = true;
    }
    public float CurrentHealt()
    {
        var l_currentHealt = m_healtEnemy / m_healtFullEnemy;
        if (m_healtEnemy <= 0f)
        {
            float l_dead = 0f;
            return l_dead;
        }
        return l_currentHealt;
    }

    public string GetName()
    {
        return m_name;
    }

    private int EnemyDeadScore()
    {
        int l_score = 100;
        return l_score;
    }

    private void ParticlesOn()
    {        
        m_particleSystem[0].gameObject.SetActive(true);
        m_particleSystem[1].gameObject.SetActive(true);
        m_particleSystem[2].gameObject.SetActive(true);
        m_particleSystem[3].gameObject.SetActive(true);
    }

    IEnumerator DeadEnemyGun()
    {
        yield return new WaitForSeconds(0.4f);
        Destroy(gameObject);
    }

}
