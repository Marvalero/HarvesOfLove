using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ConversationController : MonoBehaviour
{
    [Header("Conversation")]
    public ConversationNode currentConversationNode;
    private int currentConversationNodeIndex;
    public List<ConversationNode> conversationNodeList = new List<ConversationNode>();
    public TextMeshProUGUI conversationText;
    public GameObject[] answerButtons;
    private bool wasOptionSelected = false;


    [Header("Plants")]
    public string[] plants = {"Bubbles", "Zen", "Ivy"};
    public int[] plantPoints = {0, 0, 0};

    [Header("SpritesAndImage")]
    public Image characterImage;
    // Order: BubblesHappy, BubblesNautral, BubblesAngry, ZenHappy, ZenNeutral,...
    public Sprite[] sprites = new Sprite[9];
    public Sprite neutralNarratorSprite;

    void Start() {
        currentConversationNodeIndex = 0;
        currentConversationNode = conversationNodeList[currentConversationNodeIndex];
        DisplayQuestion();
    }

    void Update() {
        bool waitForSubmit = currentConversationNode.ShowOptionForReply();
        bool showNextConversation = waitForSubmit ? (wasOptionSelected && Input.GetAxis("Fire1") > 0) : wasOptionSelected;
        if(showNextConversation) {
            wasOptionSelected = false;
            currentConversationNodeIndex++;
            if(currentConversationNodeIndex < conversationNodeList.Count) {
                currentConversationNode = conversationNodeList[currentConversationNodeIndex];
                GetNextQuestion();
            }
        }
    }

    public void OnAnswerSelected(int choosenOption) {
        if(currentConversationNode.IsPlantNameSet()) {
          plantPoints[currentConversationNode.PlantNumber()] += currentConversationNode.GetPointsForOption(choosenOption);
          SetCorrectSpriteForPoints(currentConversationNode.GetPointsForOption(choosenOption));
        } else {
            characterImage.sprite = neutralNarratorSprite;
        }
        if(currentConversationNode.ShowOptionForReply()) {
            conversationText.text = currentConversationNode.GetReplyForOption(choosenOption);
        }
        SetButtonState(false);
        
        // Go to next node
        wasOptionSelected = true;
    }

    private void DisplayQuestion() {
        conversationText.text = currentConversationNode.GetText();
        ChangeButtonText(0, currentConversationNode.GetOption(0));
        ChangeButtonText(1, currentConversationNode.GetOption(1));
        ChangeButtonText(2, currentConversationNode.GetOption(2));
        SetCorrectSpriteForPoints(5);
    }

    private void ChangeButtonText(int buttonIndex, string text) {
        TextMeshProUGUI buttonText = answerButtons[buttonIndex].GetComponentInChildren<TextMeshProUGUI>();
        buttonText.text = text;
    }

    private void SetCorrectSpriteForPoints(int totalPoints) {
        if(!currentConversationNode.IsPlantNameSet()) {
            return;
        }
        int plantIndex = currentConversationNode.PlantNumber() * 3;
        if(totalPoints > 5) {
            int spriteIndex = plantIndex + 0; // Happy
            characterImage.sprite = sprites[spriteIndex];
        }
        if(totalPoints == 5) {
            int spriteIndex = plantIndex + 1; // Neutral
            characterImage.sprite = sprites[spriteIndex];
        }
        if(totalPoints < 5) {
            int spriteIndex = plantIndex + 2; // Angry
            characterImage.sprite = sprites[spriteIndex];
        }
    } 

    private void SetButtonState(bool state) {
        for (int index = 0; index < answerButtons.Length; index++) {
            Button button = answerButtons[index].GetComponent<Button>();
            button.interactable = state;
        }
    }

    private void GetNextQuestion() {
        SetButtonState(true);
        DisplayQuestion();
    }
}
