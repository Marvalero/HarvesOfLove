using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Conversation/Node")]
public class ConversationNode : ScriptableObject
{
    [TextArea(2,8)]
    public string text = "Lore ipsum";
    public string[] options = new string[3];
    public string[] replyForOptions = new string[3];
    public bool allowReply = true;
    public bool showOptionForReply = true;
    public int[] optionPoints = new int[3];
    public string plantName = null;
    public ConversationNode[] childNodes;

    public string GetText() {
        return text;
    }
    public string GetOption(int index) {
        return options[index];
    }
    public string GetReplyForOption(int index) {
        return replyForOptions[index];
    }
    public string GetPlantName() {
        return plantName;
    }

    public int GetPointsForOption(int index) {
        return optionPoints[index];
    }
    public int PlantNumber() {
        if(plantName == "Bubbles") {
            return 0;
        }
        if(plantName == "Zen") {
            return 1;
        }
        if(plantName == "Ivy") {
            return 2;
        }
        return 0;
    }


    public bool WaitForNextInteraction() {
        return !allowReply || showOptionForReply;
    }
    public bool ShowOptionForReply() {
        return showOptionForReply;
    }
    public bool IsReplyAllowed() {
        return allowReply;
    }
    public bool IsPlantNameSet() {
        return (plantName == "Bubbles" || plantName == "Zen" || plantName == "Ivy");
    }
}
