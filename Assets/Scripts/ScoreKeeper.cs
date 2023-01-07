using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    public int[] scores = {0, 0, 0};
    public string[] plants = {"Bubbles", "Zen", "Ivy"};

    public int GetScoreLength() {
        return scores.Length;
    }
    
    public int GetScoreForIndex(int index) {
        return scores[index];
    }

    public string GetPlantForIndex(int index) {
        return plants[index];
    }

    public void AddScoreForPlant(int index, int value) {
        scores[index] += value;
    }

}
