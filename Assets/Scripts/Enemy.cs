using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;
using System;

public class Enemy : CharactersController
{
    
    //private HealtController m_healtController;
    [SerializeField] protected Transform m_target;
    [SerializeField] protected float m_distanceToChase;
    [SerializeField] protected float m_inRange;

    private void Awake()
    {
         
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        //TargetOnRange();
    }

    //public delegate void ToDiscover();
    //public ToDiscover OnTargetRange;

    //public event Action<int> OnTargetRange;

    protected virtual void PoursuitTarget()
    {
        var l_dir = (m_target.position - transform.position).normalized;
        var l_mag = (m_target.position - transform.position).magnitude;
        if (l_mag > m_distanceToChase)
        {
            if ((m_target.position - transform.position).magnitude > 25f)
            {
                Debug.Log("Walk");
                WalkCharacter(l_dir);
                m_anim.SetBool("walkF", true);
            }

            if ((m_target.position - transform.position).magnitude > 20f)
            {
                Debug.Log("WalkFast");
                l_dir = (m_target.position - transform.position).normalized;
                WalkFastCharacter(l_dir);
            }

            if ((m_target.position - transform.position).magnitude > 15f)
            {
                Debug.Log("Run");
                l_dir = (m_target.position - transform.position).normalized;
                RunCharacter(l_dir);
            }

            if ((m_target.position - transform.position).magnitude > 0f)
            {
                Debug.Log("RunFast");
                l_dir = (m_target.position - transform.position).normalized;
                RunFastCharacter(l_dir);
            }
        }
    }

    public virtual void GetTarget(Transform p_target)
    {
        m_target = p_target;
    }

    //private void TargetOnRange()
    //{
    //    if ((m_target.position - transform.position).magnitude <= m_inRange)
    //    {
    //        Debug.Log("Evento 1");
    //        OnTargetRange?.Invoke();
    //    }
    //}


}
