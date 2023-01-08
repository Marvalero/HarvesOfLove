using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    ConversationController conversationController;
    EndGameController endGameController;
    MainMenuController mainMenuController;

    private void Awake() {
        conversationController = FindObjectOfType<ConversationController>();
        endGameController = FindObjectOfType<EndGameController>();        
        mainMenuController = FindObjectOfType<MainMenuController>();        
    }
    void Start()
    {
        conversationController.gameObject.SetActive(false);
        endGameController.gameObject.SetActive(false);
        mainMenuController.gameObject.SetActive(true);
    }

    void Update()
    {
        if(conversationController.conversationIsFinished) {
            mainMenuController.gameObject.SetActive(false);
            conversationController.gameObject.SetActive(false);
            endGameController.gameObject.SetActive(true);
            endGameController.ShowFinalScoreText();
        }
    }

    public void OnReplayLevel() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void OnStartGame() {
        conversationController.gameObject.SetActive(true);
        endGameController.gameObject.SetActive(false);
        mainMenuController.gameObject.SetActive(false);
    }
}
