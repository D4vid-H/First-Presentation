using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class Enemy : CharactersController
{
    //private CharactersController m_controllerCharacter;
    //private HealtController m_healtController;
    [SerializeField] protected Transform m_target;
    [SerializeField] protected float m_distanceToChase;

    private void Awake()
    {
        //m_controllerCharacter = new CharactersController();        
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }

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

}
