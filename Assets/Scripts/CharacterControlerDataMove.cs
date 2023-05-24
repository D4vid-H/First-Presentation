using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/CharacterData")]
public class CharacterControlerDataMove : ScriptableObject
{
    public float m_speedWalk;
    public float m_speedWalkFast;
    public float m_speedRun;
    public float m_speedRunFast;    
}
