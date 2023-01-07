using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class EndGameController : MonoBehaviour
{
    public TextMeshProUGUI finalResultText;
    public int minimumScoreForHarvest = 9;
    ScoreKeeper scoreKeeper;
    // Start is called before the first frame update
    void Awake()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }

    public void ShowFinalScoreText() {
        string finalText = "";
        for(int index = 0; index < scoreKeeper.GetScoreLength(); index ++) {
            string resultForPlant = scoreKeeper.GetScoreForIndex(index) >= minimumScoreForHarvest ? " wants you to harvest their fruits.\n" : " does not want you to harvest their fruit.\n";
            finalText = finalText + scoreKeeper.GetPlantForIndex(index) + resultForPlant;
        }

        finalResultText.text = finalText;
    }
}
