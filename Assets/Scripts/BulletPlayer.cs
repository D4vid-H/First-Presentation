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

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            if(collision.gameObject.name == "EnemyOne")
            {
                collision.gameObject.GetComponent<EnemyGunOne>().SetHealtEnemy(m_damage);
                GameManager.Instance.AddScoreplayer(HitEnemy());
                Destroy(gameObject);
            }
            else if (collision.gameObject.name == "EnemyTwo")
            {
                collision.gameObject.GetComponent<EnemyGunTwo>().SetHealtEnemy(m_damage);
                GameManager.Instance.AddScoreplayer(HitEnemy());
                Destroy(gameObject);
            }
            else if (collision.gameObject.name == "EnemyThree")
            {
                collision.gameObject.GetComponent<EnemyGunThree>().SetHealtEnemy(m_damage);
                GameManager.Instance.AddScoreplayer(HitEnemy());
                Destroy(gameObject);
            }
        }
        else if (collision.gameObject.CompareTag("EnemyGuards"))
        {
            collision.gameObject.GetComponent<EnemyGuards>().TakeDamage(m_damage);
            GameManager.Instance.AddScoreplayer(HitEnemy());
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private int HitEnemy()
    {
        int l_hit = 7;
        return l_hit;
    }

}
