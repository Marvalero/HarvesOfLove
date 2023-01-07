using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    ConversationController conversationController;
    EndGameController endGameController;

    private void Awake() {
        conversationController = FindObjectOfType<ConversationController>();
        endGameController = FindObjectOfType<EndGameController>();        
    }
    void Start()
    {
        conversationController.gameObject.SetActive(true);
        endGameController.gameObject.SetActive(false);
    }

    void Update()
    {
        if(conversationController.conversationIsFinished) {
            conversationController.gameObject.SetActive(false);
            endGameController.gameObject.SetActive(true);
            endGameController.ShowFinalScoreText();
        }
    }

    public void OnReplayLevel() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
