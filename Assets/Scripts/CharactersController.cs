using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class CharactersController : Entity
{   
    [SerializeField] protected float m_Healt;
    [SerializeField] protected float m_scoreAdd;
    [SerializeField] protected CharacterControlerDataMove m_speedMove;    
    [SerializeField] protected HealtControllerData m_healtFull;
    [SerializeField] public Animator m_anim;
    
    public float HealtFull()
    {
        return m_Healt = m_healtFull.GetHealtFull();
    }

    public float HealtCurrent()
    {
        Debug.Log("Esto es en CharacterController: " + m_Healt);
        return m_Healt;
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
