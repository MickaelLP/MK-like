using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderFist : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player2")
        {
            if (this.tag == "Fist")
            {
                GameManager.isTriggerPlayerOneFist = true;
            }
            if (this.tag == "Foot")
            {
                GameManager.isTriggerPlayerOneFoot = true;
            }
        }
        if (other.gameObject.tag == "Player1")
        {
            if(this.tag == "Fist")
            {
                GameManager.isTriggerPlayerTwoFist = true;
            }
            if (this.tag == "Foot")
            {
                GameManager.isTriggerPlayerTwoFoot = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player2")
        {
            if (this.tag == "Fist")
            {
                GameManager.isTriggerPlayerOneFist = false;
            }
            if (this.tag == "Foot")
            {
                GameManager.isTriggerPlayerOneFoot = false;
            }
        }
        if (other.gameObject.tag == "Player1")
        {
            if (this.tag == "Fist")
            {
                GameManager.isTriggerPlayerTwoFist = false;
            }
            if (this.tag == "Foot")
            {
                GameManager.isTriggerPlayerTwoFoot = false;
            }
        }
    }
}
