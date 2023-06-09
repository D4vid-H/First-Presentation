using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPlayer : MonoBehaviour
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

        transform.localPosition += m_speed * Time.deltaTime * transform.up;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            if(collision.gameObject.name == "EnemyOne")
            {
                collision.gameObject.GetComponent<EnemyOne>().SetHealtEnemy(m_damage);
                Destroy(gameObject);
            }
            else if (collision.gameObject.name == "EnemyTwo")
            {
                collision.gameObject.GetComponent<EnemyTwo>().SetHealtEnemy(m_damage);
                Destroy(gameObject);
            }
            else if (collision.gameObject.name == "EnemyThree")
            {
                collision.gameObject.GetComponent<EnemyThree>().SetHealtEnemy(m_damage);
                Destroy(gameObject);
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }

}
