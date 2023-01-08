using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CreditsController : MonoBehaviour
{
    public TextMeshProUGUI creditsText;
    public float speed = 50f;

    // Update is called once per frame
    void Update()
    {
        var creditsRect = creditsText.rectTransform;
        creditsRect.anchoredPosition += Vector2.up * speed * Time.deltaTime;
    }
}
