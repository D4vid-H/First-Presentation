using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPlayer : MonoBehaviour
{
    [SerializeField] private float m_speed;
    [SerializeField] private float m_damage;
    [SerializeField] private float m_initialTime = 3f;
    [SerializeField] GameObject m_hitDano;
    private float m_currentTime;
    // Start is called before the first frame update
    private void Awake()
    {
        m_currentTime = m_initialTime;
        m_hitDano = GameObject.Find("Canon_lvl_3");
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

        transform.localPosition += m_speed * Time.deltaTime * transform.up;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            if(m_hitDano.name == "Canon_lvl_3")
            {
                Debug.Log(collision.gameObject.name);
                m_hitDano.GetComponent<EnemyController>().HealtEnemy(m_damage);
                Destroy(gameObject);
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }

}
