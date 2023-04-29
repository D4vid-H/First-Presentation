using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullets : MonoBehaviour
{
    [SerializeField] private float m_speed;
    [SerializeField] private float m_damage;
    [SerializeField] private float m_initialTime = 3f;
    private float m_currentTime;
    // Start is called before the first frame update
    private void Awake()
    {
        m_currentTime = m_initialTime;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        m_currentTime -= Time.deltaTime;

        if (m_currentTime <= 0)
        {
            Destroy(gameObject);
        }

        transform.position += m_speed * Time.deltaTime * transform.up;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //Debug.Log($"{collision.impulse}");
        }
    }

}
