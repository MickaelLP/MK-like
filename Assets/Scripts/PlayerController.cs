using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private InputActionProperty Z;
    [SerializeField] private InputActionProperty S;
    [SerializeField] private InputActionProperty Q;
    [SerializeField] private InputActionProperty D;
    [SerializeField] private InputActionProperty right;
    [SerializeField] private InputActionProperty left;
    [SerializeField] private InputActionProperty up;
    [SerializeField] private InputActionProperty down;

    [SerializeField, Tooltip("Player 1")] private GameObject Player1;
    [SerializeField, Tooltip("Player 2")] private GameObject Player2;

    [SerializeField, Tooltip("Movement speed")]
    /// <summary>Movement speed in m/s</summary>
    private float MoveSpeed = 0.1f;
    // Start is called before the first frame update
    private bool isPlayer1Forward = false;
    private bool isPlayer1Backward = false;
    private bool isPlayer2Forward = false;
    private bool isPlayer2Backward = false;

    [SerializeField] private GameObject UIComboPlayer1;
    [SerializeField] private GameObject UIComboPlayer2;

    [SerializeField] private Animator AnimatorPlayer1;
    [SerializeField] private Animator AnimatorPlayer2;
    void Start()
    {
        Z.action.Enable();
        S.action.Enable();
        Q.action.Enable();
        D.action.Enable();
        up.action.Enable();
        down.action.Enable();
        left.action.Enable();
        right.action.Enable();
        D.action.performed += SetIsPlayer1Forward;
        D.action.canceled += SetIsPlayer1Forward;
        Q.action.performed += SetIsPlayer1Backward;
        Q.action.canceled += SetIsPlayer1Backward;
        left.action.performed += SetIsPlayer2Forward;
        left.action.canceled += SetIsPlayer2Forward;
        right.action.performed += SetIsPlayer2Backward;
        right.action.canceled += SetIsPlayer2Backward;
        Z.action.performed += Player1Fist;
        up.action.performed += Player2Fist;
        S.action.performed += Player1Foot;
        down.action.performed += Player2Foot;

        UIComboPlayer1.SetActive(false);
        UIComboPlayer2.SetActive(false);
    }

    private void Update()
    {
        if (isPlayer1Forward)
        {
            Player1Forward();
        }

        if (isPlayer1Backward)
        {
            Player1Backward();
        }

        if (isPlayer2Forward)
        {
            Player2Forward();
        }

        if (isPlayer2Backward)
        {
            Player2Backward();
        }
    }

    private void SetIsPlayer1Forward(InputAction.CallbackContext context)
    {
        isPlayer1Forward = !isPlayer1Forward;
        if (GameManager.endGame == false)
        {
            AnimatorPlayer1.SetBool("Walk", isPlayer1Forward);
        }
    }

    private void SetIsPlayer1Backward(InputAction.CallbackContext context)
    {
        isPlayer1Backward = !isPlayer1Backward;
        if (GameManager.endGame == false)
        {
            AnimatorPlayer1.SetBool("Walk back", isPlayer1Backward);
        }
    }

    private void SetIsPlayer2Forward(InputAction.CallbackContext context)
    {
        isPlayer2Forward = !isPlayer2Forward;
        if (GameManager.endGame == false)
        {
            AnimatorPlayer2.SetBool("Walk", isPlayer2Forward);
        }
    }

    private void SetIsPlayer2Backward(InputAction.CallbackContext context)
    {
        isPlayer2Backward = !isPlayer2Backward;
        if (GameManager.endGame == false)
        {
            AnimatorPlayer2.SetBool("Walk back", isPlayer2Backward);
        }
    }

    private void Player1Forward()
    {
        if (GameManager.endGame == false)
        {
            Player1.transform.position += Player1.transform.forward * MoveSpeed;
        }
    }

    private void Player1Backward()
    {
        if (GameManager.endGame == false)
        {
            Player1.transform.position -= Player1.transform.forward * (MoveSpeed/2);
        }
    }

    private void Player1Fist(InputAction.CallbackContext context)
    {
        // Gérer le coup de poing player 1.
        if (GameManager.isTriggerPlayerOneFist == true && GameManager.endGame == false)
        {
            if(isPlayer2Backward == false)
            {
                UILife.player2Life -= 8;
            } else
            {
                AnimatorPlayer2.SetTrigger("Block");
            }
            GameManager.manageComboPlayer1("haut", UIComboPlayer1);
        }
        if (GameManager.endGame == false)
        {
            AnimatorPlayer1.SetTrigger("Punch");
        }
    }

    private void Player2Fist(InputAction.CallbackContext context)
    {
        if (GameManager.isTriggerPlayerTwoFist == true && GameManager.endGame == false)
        {
            if (isPlayer1Backward == false)
            {
                UILife.player1Life -= 8;
            }
            else
            {
                AnimatorPlayer1.SetTrigger("Block");
            }
            GameManager.manageComboPlayer2("haut", UIComboPlayer2);
        }
        if (GameManager.endGame == false)
        {
            AnimatorPlayer2.SetTrigger("Punch");
        }
    }

    private void Player1Foot(InputAction.CallbackContext context)
    {
        // Gérer le coup de poing player 1.
        if (GameManager.isTriggerPlayerOneFoot == true && GameManager.endGame == false)
        {
            if (isPlayer2Backward == false)
            {
                UILife.player2Life -= 13;
            }
            else
            {
                AnimatorPlayer2.SetTrigger("Block");
            }
            GameManager.manageComboPlayer1("bas", UIComboPlayer1);
        }
        if (GameManager.endGame == false)
        {
            AnimatorPlayer1.SetTrigger("Kick");
        }
    }

    private void Player2Foot(InputAction.CallbackContext context)
    {
        // Gérer le coup de poing player 1.
        if (GameManager.isTriggerPlayerTwoFoot == true && GameManager.endGame == false)
        {
            if (isPlayer1Backward == false)
            {
                UILife.player1Life -= 13;
            }
            else
            {
                AnimatorPlayer1.SetTrigger("Block");
            }
            GameManager.manageComboPlayer2("bas", UIComboPlayer2);
        }
        if (GameManager.endGame == false)
        {
            AnimatorPlayer2.SetTrigger("Kick");
        }
    }

    private void Player2Forward()
    {
        if (GameManager.endGame == false)
        {
            Player2.transform.position += Player2.transform.forward * MoveSpeed;

        }
    }

    private void Player2Backward()
    {
        if (GameManager.endGame == false)
        {
            Player2.transform.position -= Player2.transform.forward * MoveSpeed;
        }
    }

    void OnDestroy()
    {
        D.action.performed -= SetIsPlayer1Forward;
        Q.action.performed -= SetIsPlayer1Backward;
        left.action.performed -= SetIsPlayer2Forward;
        right.action.performed -= SetIsPlayer2Backward;
        Z.action.performed -= Player1Fist;
        up.action.performed -= Player2Fist;
        S.action.performed -= Player1Foot;
        down.action.performed -= Player2Foot;
    }
}
