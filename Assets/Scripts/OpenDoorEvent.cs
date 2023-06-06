using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OpenDoorEvent : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public UnityEvent OpenDoor;

    public void OnTriggerEnter(Collider other)
    {
        OpenDoorHandler();
        other.GetComponentInChildren<CinemachineVirtualCamera>().enabled = true;
    }

    public void OpenDoorHandler()
    {
        OpenDoor?.Invoke();
    }
}
