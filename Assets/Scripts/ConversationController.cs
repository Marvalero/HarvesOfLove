using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ConversationController : MonoBehaviour
{
    [Header("Conversation")]
    public ConversationNode conversationNode;
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
        DisplayQuestion();
    }

    private void DisplayQuestion() {
        conversationText.text = conversationNode.GetText();
        ChangeButtonText(0, conversationNode.GetOption(0));
        ChangeButtonText(1, conversationNode.GetOption(1));
        ChangeButtonText(2, conversationNode.GetOption(2));
    }

    private void ChangeButtonText(int buttonIndex, string text) {
        TextMeshProUGUI buttonText = answerButtons[buttonIndex].GetComponentInChildren<TextMeshProUGUI>();
        buttonText.text = text;
    }

    public void OnAnswerSelected(int choosenOption) {
        if(conversationNode.IsPlantNameSet()) {
          plantPoints[conversationNode.PlantNumber()] += conversationNode.GetPointsForOption(choosenOption);
          SetCorrectSpriteForPoints(conversationNode.GetPointsForOption(choosenOption));
        } else {
            characterImage.sprite = neutralNarratorSprite;
        }
        if(conversationNode.ShowOptionForReply()) {
            conversationText.text = conversationNode.GetReplyForOption(choosenOption);
        }
        SetButtonState(false);
        
        // Go to next node
        wasOptionSelected = true;
    }

    private void SetCorrectSpriteForPoints(int totalPoints) {
        int plantIndex = conversationNode.PlantNumber() * 3;
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

    void Update() {
        if(wasOptionSelected && Input.GetAxis("Submit") > 0) {
            wasOptionSelected = false;
            GetNextQuestion();
        }
    }

    private void GetNextQuestion() {
        SetButtonState(true);
        DisplayQuestion();
    }
}
