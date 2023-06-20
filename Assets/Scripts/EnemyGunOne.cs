using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGunOne : MonoBehaviour
{
    [SerializeField] private string m_name;
    [SerializeField] private Transform m_target;
    [SerializeField] private Bullets m_bulletToShoot;
    [SerializeField] private Transform m_shootingPoint;
    [SerializeField] private Transform m_bulletParent;
    [SerializeField] private float m_delayShootBullets = 10f;
    private float m_healtEnemy;
    [SerializeField] private float m_healtFullEnemy;
    [SerializeField] private ParticleSystem m_particleSystem;
    [SerializeField] private ParticleSystem m_particleSystemDead;
    [SerializeField] private EnemyGunController m_enemyGunController;
    private float m_currentTime;
    private Boolean m_isDea = false;
    

    private void Awake()
    {
        m_currentTime = m_delayShootBullets;
        m_isDea = false;
        m_healtEnemy = m_healtFullEnemy;
        m_enemyGunController.FireEventOne.AddListener(ParticlesOn) ;
        m_particleSystem.gameObject.SetActive(false);
        m_particleSystemDead.gameObject.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        m_currentTime -= Time.deltaTime;
        FollowTarget();
        if (m_currentTime <= 0 && m_healtEnemy > 0)
        {
            StartCoroutine(ShootDelay());            
        }
        if(m_healtEnemy <= 0 && m_isDea)
        {
            Debug.Log("Enemy ONE Dead");
            gameObject.GetComponent<Animator>().enabled = false;
            GameManager.Instance.AddScoreplayer(EnemyDeadScore());
            m_particleSystem.gameObject.SetActive(false);
            m_particleSystemDead.gameObject.SetActive(true);
            m_isDea = false;
            StartCoroutine(DeadEnemyGun());

        }
    }
    IEnumerator ShootDelay()
    {
        //Instanciar(class in prefab, position to Shoot, direccion to shoot, GO parent to shoot)
        yield return new WaitForSeconds(1.5f);
        Instantiate(m_bulletToShoot, m_shootingPoint.position, Quaternion.Euler(90f, 0f, 0f), m_bulletParent);
    }
    private void FollowTarget()
    {
        transform.LookAt(m_target);
    }
    public void SetHealtEnemy(float p_danoPlayer)
    {
        m_healtEnemy -= p_danoPlayer;
        if(m_healtEnemy <= 0) m_isDea = true;
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
        //var l_particleSystem = GameObject.FindGameObjectWithTag("FireSysPart");
        //if(l_particleSystem != null)
        //{
        //    l_particleSystem.SetActive = true;
        //}
        Debug.Log("SystemParticle");
        m_particleSystem.gameObject.SetActive (true);
    }

    IEnumerator DeadEnemyGun()
    {
        yield return new WaitForSeconds(0.4f);
        Destroy(gameObject);
    }
}
