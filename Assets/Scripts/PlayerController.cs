using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cursor = UnityEngine.Cursor;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float m_horizontal;
    [SerializeField] private float m_vertical;
    [SerializeField] private float m_rotationSpeed;
    [SerializeField] private float speed;
    [SerializeField] private Animator anim;
    private float speedRun;

    // Start is called before the first frame update
    private void Awake()
    {
        speedRun = speed;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer(GetMovementInput());
        Rotate(GetRotationInput());
    }

    private Vector3 GetMovementInput()
    {
        m_horizontal = Input.GetAxis("Horizontal");
        m_vertical = Input.GetAxis("Vertical");
        //if (Input.GetKey(KeyCode.LeftControl))
        //    {
        //    return new Vector3(m_horizontal, 0, m_vertical).normalized;
        //}
        return new Vector3(m_horizontal, 0, m_vertical).normalized;
    }

    private void MovePlayer(Vector3 p_inputMovement)
    {
        var transform1 = transform;
        transform1.position += (p_inputMovement.z * transform1.forward + p_inputMovement.x * transform1.right) *
                               (speed * Time.deltaTime);
        anim.SetFloat("WalkFB", p_inputMovement.z);
        anim.SetFloat("WalkLR", p_inputMovement.x);
        anim.SetBool("RunF", Input.GetKey(KeyCode.LeftShift));
        anim.SetBool("IdleCro", Input.GetKey(KeyCode.LeftControl));
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = 5f;
        }
        else if (!Input.GetKey(KeyCode.LeftShift))
        {
            speed = speedRun;
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
}
