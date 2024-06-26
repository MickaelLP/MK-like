using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static bool isTriggerPlayerOneFist;
    public static bool isTriggerPlayerTwoFist;
    public static bool isTriggerPlayerOneFoot;
    public static bool isTriggerPlayerTwoFoot;
    public static int player1Points;
    public static int player2Points;
    public static bool endGame = true;
    [SerializeField] GameObject Player1;
    [SerializeField] GameObject Player2;
    private Vector3 basePositionPlayer1;
    private Vector3 basePositionPlayer2;
    [SerializeField] GameObject UIMenu;
    public static Queue<string> comboTabP1;
    public static Queue<string> comboTabP2;
    public static string[] twentylessCombo;

    // Start is called before the first frame update
    void Start()
    {
        GameManager.endGame = true;
        isTriggerPlayerOneFist = false;
        isTriggerPlayerTwoFist = false;
        isTriggerPlayerOneFoot = false;
        isTriggerPlayerTwoFoot = false;
        player1Points = 0;
        player2Points = 0;
        basePositionPlayer1 = Player1.gameObject.transform.position;
        basePositionPlayer2 = Player2.gameObject.transform.position;
        comboTabP1 = new Queue<string>(4);
        comboTabP2 = new Queue<string>(4);
        twentylessCombo = new string[] { "haut", "haut", "bas", "bas" };

        if (GameManager.endGame == true)
        {
            UIMenu.SetActive(true);
        }
        else
        {
            UIMenu.SetActive(false);
        }
    }

    private void Update()
    {
        if (GameManager.endGame == true && UIMenu.activeSelf == false)
        {
            UIMenu.SetActive(true);
        }
    }

    public void ResetScene()
    {
        // All elements to zero
        Player1.gameObject.transform.position = basePositionPlayer1;
        Player2.gameObject.transform.position = basePositionPlayer2;
        UILife.player1Life = 100;
        UILife.player2Life = 100;
        endGame = false;
        UIMenu.SetActive(false);
    }

    public static void manageComboPlayer1(string touche, GameObject UIComboPlayer1)
    {
        if (comboTabP1.Count >= 4)
        {
            comboTabP1.Dequeue();
            comboTabP1.Enqueue(touche);
        } else
        {
            comboTabP1.Enqueue(touche);
        }

        if (ArrayUtility.ArrayEquals(twentylessCombo, comboTabP1.ToArray()))
        {
            Debug.Log("Combo activated for Player 1 !");
            UILife.player2Life -= 13;
            if (UIComboPlayer1.activeSelf == false)
            {
                UIComboPlayer1.SetActive(true);
                FindObjectOfType<GameManager>().StartCoroutine(GameManager.WaitToHideCombo(UIComboPlayer1));
            }
            
        }
    }

    public static void manageComboPlayer2(string touche, GameObject UIComboPlayer2)
    {
        if (comboTabP2.Count >= 4)
        {
            comboTabP2.Dequeue();
            comboTabP2.Enqueue(touche);
        }
        else
        {
            comboTabP2.Enqueue(touche);
        }

        if (ArrayUtility.ArrayEquals(twentylessCombo, comboTabP2.ToArray()))
        {
            Debug.Log("Combo activated for Player 2 !");
            UILife.player1Life -= 13;
            if (UIComboPlayer2.activeSelf == false)
            {
                UIComboPlayer2.SetActive(true);
                FindObjectOfType<GameManager>().StartCoroutine(GameManager.WaitToHideCombo(UIComboPlayer2));
            }
        }
    }

    public static IEnumerator WaitToHideCombo(GameObject UICombo)
    {
        yield return new WaitForSeconds(1.5f);
        UICombo.SetActive(false);
        yield return null;
    }

}
