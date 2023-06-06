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
    [SerializeField] private OpenDoorEvent m_doorIsOpen;

    private Boolean m_IsDoor;
    // Start is called before the first frame update
    void Awake()
    {
        m_doorSideLeft = GameObject.FindGameObjectWithTag("DoorSideLeft");
        m_doorSideRight = GameObject.FindGameObjectWithTag("DoorSideRight");
        m_camRoom = GameObject.FindGameObjectWithTag("CamRoom");
        m_doorIsOpen.OpenDoor.AddListener(IsOpen);
        m_IsDoor = false;        
    }

    void Start()
    {        
        m_doorSideLeft.GetComponent<BoxCollider>().enabled = false;
        m_camRoom.GetComponentInChildren<CinemachineFreeLook>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (m_IsDoor)
        {
            OpenDoors();
        }
    }

    //public void OnTriggerEnter(Collider other)
    //{
    //    m_IsDoor = true;
    //    m_doorSideLeft.GetComponent<BoxCollider>().enabled = false;
    //    other.GetComponentInChildren<CinemachineVirtualCamera>().enabled = true;
    //    m_camRoom.GetComponentInChildren<CinemachineFreeLook>().enabled = false;
    //}

    public Boolean OpenDoors()
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

    private void IsOpen()
    {
        m_IsDoor = true;
    }

}
