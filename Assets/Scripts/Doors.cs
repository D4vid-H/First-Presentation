using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors : MonoBehaviour
{
    [SerializeField] private GameObject m_doorSideLeft;
    [SerializeField] private GameObject m_doorSideRight;
    [SerializeField] private GameObject m_camRoom;

    private Boolean m_IsDoor;
    // Start is called before the first frame update
    private void Awake()
    {
        m_doorSideLeft = GameObject.FindGameObjectWithTag("DoorSideLeft");
        m_doorSideRight = GameObject.FindGameObjectWithTag("DoorSideRight");
        m_camRoom = GameObject.FindGameObjectWithTag("CamRoom");
        m_IsDoor = false;
    }
    
    // Update is called once per frame
    void Update()
    {
        if (m_IsDoor)
        {
            OpenDoor();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        m_IsDoor = true;
        m_doorSideLeft.GetComponent<BoxCollider>().enabled = false;
        other.GetComponentInChildren<CinemachineVirtualCamera>().enabled = true;
        m_camRoom.GetComponent<CinemachineFreeLook>().enabled = false;
    }

    private Boolean OpenDoor()
    {

        if (m_doorSideLeft.transform.position.x >= -1.3f)
        {
            m_doorSideLeft.transform.position += new Vector3(-0.1f,0,0);
            return m_IsDoor;
        }
        if (m_doorSideRight.transform.position.x <= 0.9f)
        {
            m_doorSideRight.transform.position += new Vector3(0.1f, 0, 0);
            return m_IsDoor;
        }

        return m_IsDoor = false;
    }
}
