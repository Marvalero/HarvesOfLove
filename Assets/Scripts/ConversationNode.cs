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
    public bool showOptionForReply = true;
    public int[] optionPoints = new int[3];
    public string plantName = null;
    public ConversationNode[] childNodes;

    public string GetText() {
        return text;
    }
    public bool ShowOptionForReply() {
        return showOptionForReply;
    }
    public string GetOption(int index) {
        return options[index];
    }
    public int GetPointsForOption(int index) {
        return optionPoints[index];
    }
    public string GetReplyForOption(int index) {
        return replyForOptions[index];
    }
    public string GetPlantName() {
        return plantName;
    }
    public bool IsPlantNameSet() {
        return (plantName == "Bubbles" || plantName == "Zen" || plantName == "Ivy");
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
}
