using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullets : MonoBehaviour
{
    [SerializeField] private float m_speed;
    [SerializeField] private float m_damage;
    [SerializeField] private float m_initialTime = 3f;
    [SerializeField] private GameObject m_hitPlayer;
    private float m_currentTime;
    // Start is called before the first frame update
    private void Awake()
    {
        m_currentTime = m_initialTime;
        m_hitPlayer = GameObject.FindGameObjectWithTag("Player");
    }
    // Update is called once per frame
    void Update()
    {
        m_currentTime -= Time.deltaTime;

        if (m_currentTime <= 0)
        {
            Destroy(gameObject);
        }

        transform.position += m_speed * Time.deltaTime * (m_hitPlayer.transform.position - transform.position).normalized;
        transform.LookAt(m_hitPlayer.transform.position);
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            m_hitPlayer.GetComponent<PlayerController>().HealtPlayer(m_damage);
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

}
