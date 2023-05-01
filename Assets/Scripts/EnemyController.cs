using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private GameObject m_enemy;
    [SerializeField] private Transform m_target;
    [SerializeField] private Bullets m_bulletToShoot;
    [SerializeField] private Transform m_shootingPointLUp;
    [SerializeField] private Transform m_shootingPointLDn;
    [SerializeField] private Transform m_shootingPointRUp;
    [SerializeField] private Transform m_shootingPointRDn;
    [SerializeField] private Transform m_bulletParentL;
    [SerializeField] private Transform m_bulletParentR;
    [SerializeField] private float m_delayShootBullets = 10f;
    [SerializeField] private float m_healtEnemy;
    private float m_currentTime;
    private Boolean m_isShoot = false;
    // Start is called before the first frame update
    private void Awake()
    {
        m_currentTime = m_delayShootBullets;
        m_enemy = GameObject.Find("Canon_lvl_2");
    }
    void Start()
    {
        m_enemy.GetComponent<Animator>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        m_currentTime -= Time.deltaTime;        
        FollowTarget();
        if(m_currentTime <= 0 && m_isShoot)
        {
            StartCoroutine(ShootDelay());
        }
        if(m_healtEnemy <= 0)
        {
            Debug.Log("Enemigo muerto");
            m_enemy.GetComponent<Animator>().enabled = true;
        }
    }    
    IEnumerator ShootDelay()
    {
        m_currentTime = m_delayShootBullets;
        //Instanciar(class in prefab, position to Shoot, direccion to shoot, GO parent to shoot)
        Instantiate(m_bulletToShoot, m_shootingPointLUp.position, Quaternion.Euler(90f, 0f, 0f), m_bulletParentL);
        Instantiate(m_bulletToShoot, m_shootingPointLDn.position, Quaternion.Euler(90f, 0f, 0f), m_bulletParentL);
        yield return new WaitForSeconds(0.5f);
        Instantiate(m_bulletToShoot, m_shootingPointRUp.position, Quaternion.Euler(90f, 0f, 0f), m_bulletParentR);
        Instantiate(m_bulletToShoot, m_shootingPointRDn.position, Quaternion.Euler(90f, 0f, 0f), m_bulletParentR);
    }
    private void FollowTarget()
    {
        if (m_isShoot)
        {            
            transform.LookAt(m_target);
        }
    }

    public void HealtEnemy(float p_danoPlayer)
    {
        m_healtEnemy -= p_danoPlayer;
    }

    public void IsActiveEnemy(Boolean p_isActive)
    {
        m_isShoot = p_isActive;
        gameObject.GetComponent<Animator>().enabled = m_isShoot;
    }

}
