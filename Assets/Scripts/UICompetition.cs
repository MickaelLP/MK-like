using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UICompetition : MonoBehaviour
{
    [SerializeField] GameObject UIPlayerPoints1;
    [SerializeField] GameObject UIPlayerPoints2;
    private TextMeshProUGUI Player1PointsTMP;
    private TextMeshProUGUI Player2PointsTMP;
    // Start is called before the first frame update
    void Start()
    {
        Player1PointsTMP = UIPlayerPoints1.GetComponent<TextMeshProUGUI>();
        Player2PointsTMP = UIPlayerPoints2.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        Player1PointsTMP.text = GameManager.player1Points.ToString();
        Player2PointsTMP.text = GameManager.player2Points.ToString();
    }
}
