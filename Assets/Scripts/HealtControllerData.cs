using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/HealtCharacterData")]
public class HealtControllerData : ScriptableObject
{
    [SerializeField] public float m_healtFull;

    public float GetHealtFull()
    {
        return m_healtFull;
    }
    public void SetHealtFull( float p_healtFull)
    {
        m_healtFull = p_healtFull;
    }
}
