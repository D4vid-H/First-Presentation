using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class HealtController
{
    private float m_healtFull;
    private float m_currentHealt;

    public HealtController(float p_healtFull) 
    {
        m_currentHealt = m_healtFull = p_healtFull;
    }

    public void TakeDamage(float p_damage)
    {
        m_currentHealt -= p_damage;
    }

    public void TakeHealt(float p_healt)
    {
        m_currentHealt += p_healt;
    }

    public float GetCurrentHealt() => m_currentHealt;
}


public class ControllerCharacters : Entity
{
    [SerializeField] private float m_healtFull;
    [SerializeField] private float m_currentHealt;
    [SerializeField] private float m_scoreAdd;
    private HealtController m_healtController;

    private void Awake()
    {
        m_healtController = new HealtController(m_healtFull);
    }
    protected float HealtCurrent()
    {
        return m_healtController.GetCurrentHealt();
    }
}
