using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MechaController : MonoBehaviour
{
    [SerializeField] private string m_name;
    private float m_healtEnemy = 0f;
    [SerializeField] private float m_healtFullEnemy;
    private Light m_onLine;
    [SerializeField] private PlayerController m_player;
    [SerializeField] private Transform m_target;
    [SerializeField] private BulletsBoss m_bulletToShoot;
    [SerializeField] private Transform m_shootingPointLUp;
    [SerializeField] private Transform m_shootingPointLDn;
    [SerializeField] private Transform m_shootingPointRUp;
    [SerializeField] private Transform m_shootingPointRDn;
    [SerializeField] private Transform m_bulletParentL1;
    [SerializeField] private Transform m_bulletParentL2;
    [SerializeField] private Transform m_bulletParentR1;
    [SerializeField] private Transform m_bulletParentR2;
    [SerializeField] private ParticleSystem m_particleSystemDead;
    [SerializeField] private float m_delayShootBullets = 10f;
    private float m_currentTime;
    private Boolean m_isDea;
    private Boolean m_activate;

    // Start is called before the first frame update
    private void Awake()
    {
        m_healtEnemy = m_healtFullEnemy;
        m_currentTime = m_delayShootBullets;
        m_onLine = GetComponentInChildren<Light>();
        m_particleSystemDead.gameObject.SetActive(false);
        m_isDea = false;
        m_activate = false;
        m_player.BossOnLine.AddListener(MechaOnLine);
    }

    void Start()
    {
        m_onLine.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (m_activate)
        {
            StartMechaShoot(); 
            MechaDead();
        }
    }

    public UnityEvent Activate;

    private void MechaOnLine()
    {
        m_onLine.enabled = true;
        m_activate = true;
        Activate?.Invoke();
    }

    private void StartMechaShoot()
    {
        m_currentTime -= Time.deltaTime;
        if (m_currentTime <= 0 && m_healtEnemy > 0)
        {
            if (m_healtEnemy > 0) StartCoroutine(ShootMachineGunDelay());
            m_currentTime = m_delayShootBullets;
        }
        
    }

    private void MechaDead()
    {
        if (m_healtEnemy <= 0 && m_isDea)
        {
            GameManager.Instance.AddScoreplayer(EnemyDeadScore());
            m_particleSystemDead.gameObject.SetActive(true);
            m_isDea = false;
            StartCoroutine(DeadEnemyGun());
        }
    }

    IEnumerator ShootMachineGunDelay()
    {
        //Instanciar(class in prefab, position to Shoot, direccion to shoot, GO parent to shoot)
        yield return new WaitForSeconds(1.5f);
        Instantiate(m_bulletToShoot, m_shootingPointLUp.position, Quaternion.Euler(0f, 0f, 0f), m_bulletParentL1);
        Instantiate(m_bulletToShoot, m_shootingPointLDn.position, Quaternion.Euler(0f, 0f, 0f), m_bulletParentL2);
        yield return new WaitForSeconds(0.5f);
        Instantiate(m_bulletToShoot, m_shootingPointRUp.position, Quaternion.Euler(0f, 0f, 0f), m_bulletParentR1);
        Instantiate(m_bulletToShoot, m_shootingPointRDn.position, Quaternion.Euler(0f, 0f, 0f), m_bulletParentR2);
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
        int l_score = 10000;
        return l_score;
    }

    IEnumerator DeadEnemyGun()
    {
        yield return new WaitForSeconds(0.4f);
        Destroy(gameObject);
    }

}
