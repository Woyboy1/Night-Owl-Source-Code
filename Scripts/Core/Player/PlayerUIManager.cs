using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerUIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI objectiveText;
    [SerializeField] private GameObject usingText;

    public void UpdateNextObjective(string objectiveText)
    {
        this.objectiveText.text = objectiveText;
    }

    public void DisplayUsingText(bool toggle)
    {
        usingText.SetActive(toggle);
    }
}
