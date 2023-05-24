using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class HealtController
{
    [SerializeField] private HealtControllerData m_healtData;
    private float m_currentHealt;

    public HealtController(float p_healtFull) 
    {
        m_healtData.SetHealtFull(p_healtFull);
        m_currentHealt = m_healtData.GetHealtFull();
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
    public float GetHealtFull() => m_healtData.GetHealtFull();
}

public class CharactersController : Entity
{   
    [SerializeField] protected float m_currentHealt;
    [SerializeField] protected float m_scoreAdd;
    [SerializeField] protected CharacterControlerDataMove m_speedMove;
    [SerializeField] protected HealtControllerData m_healtFull;
    public Animator m_anim;
    protected HealtController m_healtController;

    private void Awake()
    {
        m_healtController = new HealtController(m_healtFull.GetHealtFull());
    }
    protected float HealtCurrent()
    {
        return m_healtController.GetCurrentHealt();
    }

    public void WalkCharacter(Vector3 p_direction)
    {
        transform.position += p_direction * m_speedMove.m_speedWalk * Time.deltaTime;
    }

    public void WalkFastCharacter(Vector3 p_direction)
    {
        transform.position += p_direction * m_speedMove.m_speedWalkFast * Time.deltaTime;
    }
    public void RunCharacter(Vector3 p_direction)
    {
        transform.position += p_direction * m_speedMove.m_speedRun * Time.deltaTime;
    }

    public void RunFastCharacter(Vector3 p_direction)
    {
        transform.position += p_direction * m_speedMove.m_speedRunFast * Time.deltaTime;
    }

}
