using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cursor = UnityEngine.Cursor;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private BulletPlayer m_bulletToShoot;
    [SerializeField] private Transform m_shootingPoint;
    [SerializeField] private Transform m_bulletParent;

    [SerializeField] private float m_horizontal;
    [SerializeField] private float m_vertical;
    [SerializeField] private float m_rotationSpeed;
    [SerializeField] private float m_speed;
    [SerializeField] private float m_healtPlayer;
    [SerializeField] private Animator m_anim;
    private float speedRun;

    // Start is called before the first frame update
    private void Awake()
    {
        speedRun = m_speed;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer(GetMovementInput());
        Rotate(GetRotationInput());
        if (Input.GetMouseButton(0))
        {
            ShootGun();
        }
        if(m_healtPlayer <= 0)
        {
            m_anim.SetBool("Die", true);
        }
    }

    private Vector3 GetMovementInput()
    {
        m_horizontal = Input.GetAxis("Horizontal");
        m_vertical = Input.GetAxis("Vertical");        
        return new Vector3(m_horizontal, 0, m_vertical).normalized;
    }

    private void MovePlayer(Vector3 p_inputMovement)
    {
        var transform1 = transform;
        transform1.position += (p_inputMovement.z * transform1.forward + p_inputMovement.x * transform1.right) *
                               (m_speed * Time.deltaTime);
        m_anim.SetFloat("WalkFB", p_inputMovement.z);
        m_anim.SetFloat("WalkLR", p_inputMovement.x);
        m_anim.SetBool("RunF", Input.GetKey(KeyCode.LeftShift));
        m_anim.SetBool("IdleCro", Input.GetKey(KeyCode.LeftControl));
        if (Input.GetKey(KeyCode.LeftShift))
        {
            m_speed = 5f;
        }
        else if (!Input.GetKey(KeyCode.LeftShift))
        {
            m_speed = speedRun;
        }
    }
    private void Rotate(Vector2 p_scrollDelta)
    {
        transform.Rotate(Vector3.up, p_scrollDelta.x * m_rotationSpeed * Time.deltaTime, Space.Self);
    }

    private Vector2 GetRotationInput()
    {
        var l_mouseX = Input.GetAxis("Mouse X");
        var l_mouseY = Input.GetAxis("Mouse Y");
        return new Vector2(l_mouseX, l_mouseY);
    }

    private void OnApplicationFocus(bool hasFocus)
    {
        Cursor.visible = !hasFocus;
        Cursor.lockState = hasFocus ? CursorLockMode.None : CursorLockMode.Confined;
    }

    private void ShootGun()
    {
        m_anim.SetTrigger("Fire");
        Instantiate(m_bulletToShoot, m_shootingPoint.position, Quaternion.Euler(90f, 0f, 0f), m_bulletParent);
    }

    public void HealtPlayer(float p_danoEnemy)
    {
        m_healtPlayer -= p_danoEnemy;
    }

}
