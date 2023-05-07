using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ActiveCanon : MonoBehaviour
{
    [SerializeField] GameObject m_canonEnemyActive;

    private void Awake()
    {
        m_canonEnemyActive = GameObject.FindGameObjectWithTag("EnemyController");
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            m_canonEnemyActive.GetComponent<EnemyController>().IsActive(true);
            Destroy(gameObject);
        }
    }

}
