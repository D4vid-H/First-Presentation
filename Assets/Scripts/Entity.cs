using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Entity : MonoBehaviour
{
    [SerializeField] private string m_nameEntity;
    [SerializeField] private string m_id;


    public string GetNameEntity()
    {
        return m_nameEntity;
    }
    public void SetNameEntity(string p_name)
    {
        m_nameEntity = p_name;
    }
    public string GetId()
    {
        return m_id;
    }
    public void SetId(string p_id)
    {
        m_id = p_id;
    }

}
