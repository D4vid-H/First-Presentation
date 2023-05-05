using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyOne : MonoBehaviour
{
    [SerializeField] private Transform m_target;
    [SerializeField] private Bullets m_bulletToShoot;
    [SerializeField] private Transform m_shootingPoint;
    [SerializeField] private Transform m_bulletParent;
    [SerializeField] private float m_delayShootBullets = 10f;
    [SerializeField] private float m_healtEnemy;
    private float m_currentTime;

    private void Awake()
    {
        m_currentTime = m_delayShootBullets;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        m_currentTime -= Time.deltaTime;
        FollowTarget();
        if (m_currentTime <= 0 )
        {
            if (m_healtEnemy > 0) StartCoroutine(ShootDelay());
        }
        if(m_healtEnemy <= 0)
        {
            Debug.Log("Enemy ONE Dead");
        }
    }
    IEnumerator ShootDelay()
    {
        //Instanciar(class in prefab, position to Shoot, direccion to shoot, GO parent to shoot)
        yield return new WaitForSeconds(0.5f);
        Instantiate(m_bulletToShoot, m_shootingPoint.position, Quaternion.Euler(90f, 0f, 0f), m_bulletParent);
    }
    private void FollowTarget()
    {
        transform.LookAt(m_target);
    }
    public void SetHealtEnemy(float p_danoPlayer)
    {
        m_healtEnemy -= p_danoPlayer;
    }
    public float GetHealtEnemy()
    {
        return m_healtEnemy;
    }
}
