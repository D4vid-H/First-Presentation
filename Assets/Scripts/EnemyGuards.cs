using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyGuards : Enemy
{
    [SerializeField] private Transform m_rayCastShoot;
    [SerializeField] private LayerMask m_layerMask;
    [SerializeField] private float m_rayCastDistance;
    [SerializeField] private float m_sphereCastRadius;
    [SerializeField] private Vector3 m_halfCast;
    [SerializeField] private float m_turningSpeed;
    [SerializeField] private HealtController m_healtControl;
    //[SerializeField] private float m_helatNow;
    
    private void Awake()
    {
        m_healtControl = new HealtController();
        m_healtControl.SetHealt(HealtFull());
    }

    private void Start()
    {
        m_healtControl.GetCurrentHealt();       
    }

    void Update()
    {
        TargetOnRange();
    }

    public delegate void ToDiscover();

    public ToDiscover OnTargetRangeGuards;

    private void IsVisible()
    {        
        bool l_rayCast = Physics.BoxCast(m_rayCastShoot.position, m_halfCast, m_rayCastShoot.forward, out RaycastHit l_rayHit, Quaternion.identity ,m_rayCastDistance, m_layerMask);

        if (l_rayCast && l_rayHit.collider.tag == "Player")
        {
            PoursuitTarget();
        }
    }

    private void TargetOnRange()
    {
        if ((m_target.position - transform.position).magnitude <= m_inRange)
        {
            Debug.Log("Target on Range");
            OnTargetRangeGuards?.Invoke();
            StartCoroutine(Watch());
        }        
    }

    IEnumerator Watch()
    {
        Debug.Log("Tirando Rayo buscando al player");
        yield return new WaitForSeconds(1f);        
        IsVisible();
        var l_diffVector = m_target.position - transform.position;
        Quaternion l_newRotation = Quaternion.LookRotation(l_diffVector.normalized);
        transform.rotation = Quaternion.Lerp(transform.rotation, l_newRotation, Time.deltaTime * m_turningSpeed);

    }

    private void OnDrawGizmosSelected()
    {                
        Gizmos.color = Color.green;        
        Gizmos.DrawWireCube(m_rayCastShoot.position, m_halfCast);
    }

    public void TakeDamage(float p_damage)
    {        
        m_healtControl.TakeDamage(p_damage);
    }

    public float CurrentHealt()
    {
        return m_healtControl.GetCurrentHealt();
    }
        
    public void OnCollisionStay(Collision collision)
    {
        Debug.Log("Colicionado");
        if(collision.collider.tag == "Player")
        {
            Debug.Log("Daño");
            collision.gameObject.GetComponent<PlayerController>().HealtPlayer(10f);
        }
    }  

}
