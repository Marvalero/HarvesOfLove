using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    ConversationController conversationController;
    EndGameController endGameController;
    MainMenuController mainMenuController;
    CreditsController creditsController;
    InteractionsController interactionsController;


    private void Awake() {
        conversationController = FindObjectOfType<ConversationController>();
        endGameController = FindObjectOfType<EndGameController>();        
        mainMenuController = FindObjectOfType<MainMenuController>();        
        creditsController = FindObjectOfType<CreditsController>();        
        interactionsController = FindObjectOfType<InteractionsController>();  
    }
    void Start()
    {
        OnlySetActive(mainMenuController);
    }

    void Update()
    {
        if(conversationController.conversationIsFinished) {
            OnlySetActive(endGameController);
            endGameController.ShowFinalScoreText();
        }
    }

    public void OnReplayLevel() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void OnStartGame() {
        interactionsController.WasNextPressedThisFrame();
        OnlySetActive(conversationController);
    }

    public void OnViewCredits() {
        OnlySetActive(creditsController);
    }

    public void OnlySetActive(MonoBehaviour controller) {
        conversationController.gameObject.SetActive(false);
        endGameController.gameObject.SetActive(false);
        mainMenuController.gameObject.SetActive(false);
        creditsController.gameObject.SetActive(false);

        controller.gameObject.SetActive(true);
    }
}
