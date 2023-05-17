using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGunOne : MonoBehaviour
{
    [SerializeField] private Transform m_target;
    [SerializeField] private Bullets m_bulletToShoot;
    [SerializeField] private Transform m_shootingPoint;
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
            StartCoroutine(ShootDelay());
        }
        if(m_healtEnemy <= 0 && m_isDea)
        {
            Debug.Log("Enemy ONE Dead");
            gameObject.GetComponent<Animator>().enabled = false;
            GameManager.Instance.AddScoreplayer(EnemyDeadScore());
            m_isDea = false;
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
