using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGunTwo : MonoBehaviour
{
    [SerializeField] private Transform m_target;
    [SerializeField] private Bullets m_bulletToShoot;
    [SerializeField] private Transform m_shootingPointL;
    [SerializeField] private Transform m_shootingPointR;
    [SerializeField] private Transform m_bulletParent;
    [SerializeField] private float m_delayShootBullets = 10f;
    [SerializeField] private float m_healtEnemy;
    private float m_currentTime;
    private Boolean m_isDea;
    private void Awake()
    {
        m_currentTime = m_delayShootBullets;
        m_isDea = false;
    }
    // Update is called once per frame
    void Update()
    {
        m_currentTime -= Time.deltaTime;
        FollowTarget();
        if (m_currentTime <= 0 && m_healtEnemy > 0)
        {            
            if (m_healtEnemy > 0) StartCoroutine(ShootDelay());
        }
        if (m_healtEnemy <= 0 && m_isDea)
        {
            Debug.Log("Enemy TWO Dead");
            gameObject.GetComponent<Animator>().enabled = false;
            GameManager.Instance.AddScoreplayer(EnemyDeadScore());
            m_isDea = false;
        }
    }
    IEnumerator ShootDelay()
    {
        //Instanciar(class in prefab, position to Shoot, direccion to shoot, GO parent to shoot)
        yield return new WaitForSeconds(1.5f);
        Instantiate(m_bulletToShoot, m_shootingPointL.position, Quaternion.Euler(90f, 0f, 0f), m_bulletParent);
        yield return new WaitForSeconds(0.3f);
        Instantiate(m_bulletToShoot, m_shootingPointR.position, Quaternion.Euler(90f, 0f, 0f), m_bulletParent);
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
    public float GetHealtEnemy()
    {
        return m_healtEnemy;
    }
    private int EnemyDeadScore()
    {
        int l_score = 100;
        return l_score;
    }

}
