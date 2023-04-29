using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private Transform m_target;
    [SerializeField] private Bullets m_bulletToShoot;
    [SerializeField] private Transform m_shootingPointLUp;
    [SerializeField] private Transform m_shootingPointLDn;
    [SerializeField] private Transform m_shootingPointRUp;
    [SerializeField] private Transform m_shootingPointRDn;
    [SerializeField] private Transform m_bulletParentL;
    [SerializeField] private Transform m_bulletParentR;
    [SerializeField] private float m_delayShootBullets = 10f;
    private float m_currentTime;
    // Start is called before the first frame update
    private void Awake()
    {
        m_currentTime = m_delayShootBullets;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(m_target);
        m_currentTime -= Time.deltaTime;
        
        if(m_currentTime <= 0)
        {
            //Debug.Log("bala");
            //Debug.Log(m_currentTime);
            StartCoroutine(ShootDelay());
        }
        //Shooting();
    }

    private void Shooting()
    {
        //Paso 1: Instanciar una nueva bala        
        Instantiate(m_bulletToShoot, m_shootingPointLUp.position, Quaternion.Euler(90f, 0f, 0f), m_bulletParentL);
        Instantiate(m_bulletToShoot, m_shootingPointLDn.position, Quaternion.Euler(90f, 0f, 0f), m_bulletParentL);
        Instantiate(m_bulletToShoot, m_shootingPointRUp.position, Quaternion.Euler(90f, 0f, 0f), m_bulletParentR);
        Instantiate(m_bulletToShoot, m_shootingPointRDn.position, Quaternion.Euler(90f, 0f, 0f), m_bulletParentR);
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

}
