using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyGuardOne : MonoBehaviour
{
    [SerializeField] private float m_speed;
    [SerializeField] private float m_currentTime;
    [SerializeField] private Transform m_rayCastShoot;
    [SerializeField] private LayerMask m_layerMask;
    [SerializeField] private float m_rayCastDistance;
    [SerializeField] private Animator m_anim;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        GuardPatrolling();
    }

    private void GuardPatrolling()
    {
        var l_transform1 = transform;
        if (l_transform1.position.x <= -10f && l_transform1.position.z == 23.36f)
        {
            
            l_transform1.position += (l_transform1.position.z * l_transform1.forward) * (m_speed * Time.deltaTime);
            //m_anim.SetTrigger("PatrolGuard");
        }
        else if (l_transform1.rotation.y >= 0.70f)
        {
            m_anim.SetBool("WalkAround", true);
            StartCoroutine(GuardFocused(l_transform1));
        }
        else if(l_transform1.position.x >= -16f && l_transform1.rotation.y <= -0.70)
        {
            m_anim.SetBool("WalkAround", false);
            l_transform1.position -= (l_transform1.position.x * l_transform1.forward) * (m_speed * Time.deltaTime);
            //m_anim.SetBool("WalkAround", false);
        }
        else if (l_transform1.rotation.y <= -0.70)
        {
            m_anim.SetTrigger("PatrolGuard");
            l_transform1.rotation = Quaternion.Euler(0f, 0f, 0f);
            StartCoroutine(GuardFocused(l_transform1));
        }
    }
    IEnumerator GuardFocused(Transform p_GuardRotation)
    {
        if (p_GuardRotation.rotation.y >= 0.70f)
        {
            p_GuardRotation.rotation = Quaternion.Euler(0f, 0f, 0f);
            IsVisible();
            yield return new WaitForSeconds(5f);
            p_GuardRotation.rotation = Quaternion.Euler(0f, -90f, 0f);
            p_GuardRotation.position += new Vector3(0f, 0f, 0.02f);

        }
        if (p_GuardRotation.rotation.y == 0)
        {
            IsVisible();
            yield return new WaitForSeconds(5f);
            p_GuardRotation.position += new Vector3(0f, 0f, -0.02f);
            p_GuardRotation.rotation = Quaternion.Euler(0f, 90f, 0f);

        }
    }

    private void IsVisible()
    {
        bool l_rayCast = Physics.Raycast(m_rayCastShoot.position, m_rayCastShoot.forward,out RaycastHit l_rayHit ,m_rayCastDistance, m_layerMask);
        Debug.Log("Disparo?: " + l_rayCast);

        if (l_rayCast)
        {
            Debug.Log(l_rayHit.collider.name);
        }

    }
}
