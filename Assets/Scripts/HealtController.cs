using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class HealtController
{    
    private float m_currentHealt;
    private float m_Healt;

    public event Action<float> OnEntityDead;

    public void SetHealt(float p_healt)
    {
        m_Healt = p_healt;
        m_currentHealt = m_Healt;
    }

    public float TakeDamage(float p_damage)
    {
        if (m_currentHealt <= 0)
        {
            IsDead();
        }
        if (m_currentHealt > 0) 
        { 
            m_currentHealt -= p_damage;

            if (m_currentHealt <= 0)
            {
                IsDead();
            }
        }
        return m_currentHealt;
    }

    public float TakeHealt(float p_healt)
    {
        if(m_currentHealt < m_Healt)
        {
            m_currentHealt += p_healt;
            if (m_currentHealt > m_Healt)
            {
                m_currentHealt = m_Healt;
            }
        }

        return m_currentHealt;
    }

    public float GetCurrentHealt() => m_currentHealt;
    public float GetHealtFull() => m_Healt;

    public void IsDead()
    {
        Debug.Log("muerto");
        OnEntityDead?.Invoke(0f);
    }

}
