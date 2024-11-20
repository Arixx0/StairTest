using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.U2D.Animation;

public class Player : MonoBehaviour
{
    private PlayerInput m_PlayerInput;
    private InputActionMap m_InputActionMap;
    private InputAction m_MoveAction;
    private InputAction m_AttackAction;
    private InputAction m_JumpAction;

    private Animator m_PlayerAnim;
    private Rigidbody2D m_PlayerRigidBody;
    private float m_moveSpeed = 5;
    private float m_JumpForce = 5;

    private SpriteRenderer m_SpriteRenderer;

    [SerializeField]
    private SpriteLibraryAsset[] m_SpriteLibs;
    private SpriteLibrary m_SppriteLiber;
    private int m_closeIndex;

    void Start()
    {
        m_PlayerAnim = GetComponent<Animator>();
        m_PlayerRigidBody = GetComponent<Rigidbody2D>();
        m_SppriteLiber = GetComponent<SpriteLibrary>();
        m_SpriteRenderer = GetComponent<SpriteRenderer>();

        m_PlayerInput = GetComponent<PlayerInput>();
        m_InputActionMap = m_PlayerInput.actions.FindActionMap("Player");
        m_MoveAction = m_InputActionMap.FindAction("Move");
        m_AttackAction = m_InputActionMap.FindAction("Attack");
        m_JumpAction = m_InputActionMap.FindAction("Jump");


        m_AttackAction.started += ChangeClose;
        m_JumpAction.started += Jump;

    }

    private void Jump(InputAction.CallbackContext context)
    {
        m_PlayerRigidBody.AddForceY(m_JumpForce, ForceMode2D.Impulse);
    }

    private void ChangeClose(InputAction.CallbackContext context)
    {
        m_closeIndex = (m_closeIndex + 1) % m_SpriteLibs.Length;
        m_SppriteLiber.spriteLibraryAsset = m_SpriteLibs[m_closeIndex];

    }

    private void FixedUpdate()
    {
        Vector2 movePos = m_MoveAction.ReadValue<Vector2>();
        movePos.y = 0;
        m_PlayerRigidBody.linearVelocityX = movePos.x * m_moveSpeed;

        if (m_PlayerRigidBody.linearVelocityX < 0 && m_SpriteRenderer.flipX != true)
        {
            m_SpriteRenderer.flipX = true;
        }
        else if (m_PlayerRigidBody.linearVelocityX > 0 && m_SpriteRenderer.flipX != false)
        {
            m_SpriteRenderer.flipX = false;
        }


        if (m_PlayerRigidBody.linearVelocityX != 0 && m_PlayerAnim.GetBool("Run") == false)
        {
            m_PlayerAnim.SetBool("Run", true);
            Debug.Log("Run");
        }

        if (m_PlayerRigidBody.linearVelocityX == 0 && m_PlayerAnim.GetBool("Run") == true)
        {
            m_PlayerAnim.SetBool("Run", false);
            Debug.Log("Idle");
        }
    }

}
