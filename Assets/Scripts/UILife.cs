using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UILife : MonoBehaviour
{
    [SerializeField] GameObject UIPlayer1;
    [SerializeField] GameObject UIPlayer2;
    private TextMeshProUGUI Player1TMP;
    private TextMeshProUGUI Player2TMP;
    public static int player1Life;
    public static int player2Life;
    [SerializeField] GameObject UICompetition;
    // Start is called before the first frame update
    void Start()
    {
        player1Life = 100;
        player2Life = 100;
        Player1TMP = UIPlayer1.GetComponent<TextMeshProUGUI>();
        Player2TMP = UIPlayer2.GetComponent<TextMeshProUGUI>();
        UICompetition.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        Player1TMP.text = player1Life.ToString();
        Player2TMP.text = player2Life.ToString();

        if (player1Life <= 0 && GameManager.endGame == false)
        {
            GameManager.player2Points += 15;
            UICompetition.SetActive(true);
            GameManager.endGame = true;
        }

        if (UICompetition.activeSelf == true && GameManager.endGame == false)
        {
            UICompetition.SetActive(false);
        }

        if (player2Life <= 0 && GameManager.endGame == false)
        {
            GameManager.player1Points += 15;
            UICompetition.SetActive(true);
            GameManager.endGame = true;
        }

        
    }

}
