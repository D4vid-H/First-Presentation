using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Windows;
using Cursor = UnityEngine.Cursor;
using Input = UnityEngine.Input;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private string m_namePlayer;
    [SerializeField] private string m_userPlayer;
    [SerializeField] private int m_agePlayer;
    [SerializeField] private BulletPlayer m_bulletToShoot;
    [SerializeField] private Transform m_shootingPoint;
    [SerializeField] private Transform m_bulletParent;
    [SerializeField] private float m_horizontal;
    [SerializeField] private float m_vertical;
    [SerializeField] private float m_rotationSpeed;
    [SerializeField] private float m_speed;
    [SerializeField] private float m_timeToShoot;
    [SerializeField] private float m_healtPlayerFull;
    [SerializeField] private float m_currentHealtPlayer;
    [SerializeField] private Animator m_anim;
    [SerializeField] private float m_jumpForce;    
    [SerializeField] private int m_ammunitionClip;
    private float speedRun;
    private AudioSource m_Sound;
    private Light m_lightColor;
    private Dictionary <string, PlayerData> m_playerDirectory = new Dictionary<string, PlayerData>();
    private float m_currentTimeToShoot;
    private CapsuleCollider m_playerCollider;
    private Vector3 m_centerStandUp;
    private float m_heightStandUp;
    private Vector3 m_centerStandDown;
    private float m_heightStandDown;

    // Start is called before the first frame update
    private void Awake()
    {
        speedRun = m_speed;
        m_Sound = GetComponentInChildren<AudioSource>();
        m_currentHealtPlayer = m_healtPlayerFull;
        m_currentTimeToShoot = m_timeToShoot;
        m_playerCollider = GetComponent<CapsuleCollider>();
        m_centerStandUp = m_playerCollider.center;
        m_heightStandUp = m_playerCollider.height;
        m_centerStandDown = new Vector3(-0.0007503776f, 0.62358f, 0.00604f);
        m_heightStandDown = 1.236531f;
    }
    // Update is called once per frame
    void Update()
    {
        MovePlayer(GetMovementInput());
        Rotate(GetRotationInput());
        WalkSound();
        ShootGun();
        PlayerDead();
        LightPower();
        JumpPlayer();        

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
        if (Input.GetKey(KeyCode.LeftControl))
        {
            m_anim.SetBool("IdleCro", true);
            GetComponent<CapsuleCollider>().center = m_centerStandDown;
            GetComponent<CapsuleCollider>().height = m_heightStandDown;
        }
        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            m_anim.SetBool("IdleCro", false);
            GetComponent<CapsuleCollider>().center = m_centerStandUp;
            GetComponent<CapsuleCollider>().height = m_heightStandUp;
        }
        
        if (Input.GetKey(KeyCode.LeftShift))
        {
            m_speed = 5f;
        }
        else
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
        m_timeToShoot -= Time.deltaTime;

        if (Input.GetMouseButton(0) && m_timeToShoot <=0)
        {             
            if(m_ammunitionClip > 0)
            {
                m_anim.SetTrigger("Fire");
                Instantiate(m_bulletToShoot, m_shootingPoint.position, Quaternion.Euler(90f, 0f, 0f), m_bulletParent);
                m_ammunitionClip--;
            }
            m_currentTimeToShoot = m_timeToShoot;
        }
    }

    public int GetCurrentAmmunition()
    {
        return m_ammunitionClip;
    }

    public void HealtPlayer(float p_danoEnemy)
    {
        m_currentHealtPlayer -= p_danoEnemy;       
    }

    public float CurrentHealtPlayer()
    {
        float l_currentHealtToCanva;
        l_currentHealtToCanva = m_currentHealtPlayer / m_healtPlayerFull;
        return l_currentHealtToCanva;
    }

    private void PlayerDead()
    {
        if (m_currentHealtPlayer <= 0)
        {
            m_anim.SetBool("Die", true);            
        }
    }

    private void WalkSound()
    {
        if (Input.GetButtonDown("Horizontal"))
        {
            m_Sound.Play();
        }
        if (Input.GetButtonDown("Vertical"))
        {
            m_Sound.Play();
        }
        if (Input.GetButtonUp("Horizontal"))
        {
            m_Sound.Pause();
        }
        if (Input.GetButtonUp("Vertical"))
        {
            m_Sound.Pause();
        }
    }

    private void LightPower()
    {
        m_lightColor = gameObject.GetComponentInChildren<Light>();

        if (Input.GetKeyDown(KeyCode.L))
        {
            Debug.Log("Entre al tocar y soltar la L");
            if(m_lightColor.color == Color.red)
            {
                m_lightColor.color = Color.green;
            }
            else if (m_lightColor.color == Color.green)
            {
                m_lightColor.color = Color.blue;
            }
            else if (m_lightColor.color == Color.blue)
            {
                m_lightColor.color = Color.white;
            }
            else if (m_lightColor.color == Color.white)
            {
                m_lightColor.color = Color.cyan;
            }
            else if (m_lightColor.color == Color.cyan)
            {
                m_lightColor.color = Color.red;
            }            
        }
    }

    private void JumpPlayer()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            m_anim.SetBool("Jump", true);
            if (gameObject.TryGetComponent<Rigidbody>(out Rigidbody l_rB))
            {
                l_rB.AddForceAtPosition(transform.up * m_jumpForce, l_rB.centerOfMass, ForceMode.Impulse);                
            }
        }
        if(Physics.Raycast(transform.position, new Vector3(0,-1f,0)))
        {            
            m_anim.SetBool("Jump", false);
        }
    }
    
}
