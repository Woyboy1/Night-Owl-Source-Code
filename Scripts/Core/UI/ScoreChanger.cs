using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreChanger : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;

    private void Start()
    {
        scoreText.text = "You completed " + ScoreManager.instance.CurrentScore + " tasks.";
    }
}
