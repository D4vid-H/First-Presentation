using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapCamAisle : MonoBehaviour
{
    [SerializeField] private GameObject m_camAisle;
    [SerializeField] private Boolean m_flag;

    private void Awake()
    {
        m_camAisle = GameObject.FindGameObjectWithTag("CamAisle");
        m_flag = false;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player" && gameObject.name == "TrapCamAisleL")
        {
            if (!m_flag)
            {
                Debug.Log("entre al IF");
                m_camAisle.GetComponentInChildren<CinemachineFreeLook>().enabled = !m_flag;
                other.GetComponentInChildren<CinemachineVirtualCamera>().enabled = m_flag;
                m_flag = true;
            }
            else
            {
                Debug.Log("entre al ELSE");
                m_flag = true;
                m_camAisle.GetComponentInChildren<CinemachineFreeLook>().enabled = !m_flag;
                other.GetComponentInChildren<CinemachineVirtualCamera>().enabled = m_flag;
                m_flag = false;
            }
        }

        if (other.tag == "Player" && gameObject.name == "TrapCamAisleR")
        {
            if (m_flag)
            {
                Debug.Log("entre al IF");
                m_camAisle.GetComponentInChildren<CinemachineFreeLook>().enabled = m_flag;
                other.GetComponentInChildren<CinemachineVirtualCamera>().enabled = !m_flag;
                m_flag = false;
            }
            else
            {
                Debug.Log("entre al ELSE");
                m_camAisle.GetComponentInChildren<CinemachineFreeLook>().enabled = m_flag;
                other.GetComponentInChildren<CinemachineVirtualCamera>().enabled = !m_flag;
                m_flag = true;
            }
        }

    }


}
