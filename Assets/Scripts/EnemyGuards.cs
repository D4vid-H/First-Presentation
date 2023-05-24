using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyGuards : Enemy
{
    //[SerializeField] private Transform m_target;
    [SerializeField] private Transform m_rayCastShoot;
    [SerializeField] private LayerMask m_layerMask;
    [SerializeField] private float m_rayCastDistance;
    [SerializeField] private float m_sphereCastRadius;
    [SerializeField] private Vector3 m_halfCast;
    [SerializeField] private float m_turningSpeed;
    //public Animator m_anim;

    // Start is called before the first frame update
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        TargetOnRange();
    }
    private void IsVisible()
    {
        //bool l_rayCast = Physics.BoxCast SphereCast(m_rayCastShoot.position, m_sphereCastRadius, m_rayCastShoot.forward,out RaycastHit l_rayHit ,m_rayCastDistance, m_layerMask);
        bool l_rayCast = Physics.BoxCast(m_rayCastShoot.position, m_halfCast, m_rayCastShoot.forward, out RaycastHit l_rayHit, Quaternion.identity ,m_rayCastDistance, m_layerMask);
        Debug.Log("Tirando Rayo1");
        Debug.Log("Disparo?: " + l_rayCast);

        if (l_rayCast && l_rayHit.collider.tag == "Player")
        {
            //Debug.Log("Rayo TRUE");
            //Debug.Log(l_rayHit.collider.name);
            //Debug.Log(l_rayHit.distance);
            //Debug.Log(l_rayHit.rigidbody.name);
            PoursuitTarget();
        }

    }

    private void TargetOnRange()
    {
        Debug.Log("Tirando Rayo2");
        if ((m_target.position - transform.position).magnitude <= 15f)
        {
            Debug.Log("Corrutina-----");
            StartCoroutine(Watch());
        }
    }

    IEnumerator Watch()
    {
        Debug.Log("Tirando Rayo3");
        yield return new WaitForSeconds(1f);        
        IsVisible();
        var l_diffVector = m_target.position - transform.position;
        Quaternion l_newRotation = Quaternion.LookRotation(l_diffVector.normalized);
        transform.rotation = Quaternion.Lerp(transform.rotation, l_newRotation, Time.deltaTime * m_turningSpeed);

    }

    private void OnDrawGizmosSelected()
    {
        //Gizmos.color = Color.red;
        //Gizmos.DrawLine(transform.position, m_rayCastShoot.forward);
                
        Gizmos.color = Color.green;        
        Gizmos.DrawWireCube(m_rayCastShoot.position, m_halfCast);
    }

    protected override void PoursuitTarget()
    {
        base.PoursuitTarget();
        //if ((m_target.position - transform.position).magnitude > 25f)
        //{
        //    Debug.Log("Walk");
        //    base.PoursuitTarget();
        //    m_anim.SetBool("walkF", true);
        //}

        //if ((m_target.position - transform.position).magnitude > 20f)
        //{
        //    Debug.Log("WalkFast");
        //    var l_dir = (m_target.position - transform.position).normalized;
        //    WalkFastCharacter(l_dir);
        //}

        //if ((m_target.position - transform.position).magnitude > 15f)
        //{
        //    Debug.Log("Run");
        //    var l_dir = (m_target.position - transform.position).normalized;
        //    RunCharacter(l_dir);
        //}

        //if ((m_target.position - transform.position).magnitude > 10f)
        //{
        //    Debug.Log("RunFast");
        //    var l_dir = (m_target.position - transform.position).normalized;
        //    RunFastCharacter(l_dir);
        //}
    }
}
