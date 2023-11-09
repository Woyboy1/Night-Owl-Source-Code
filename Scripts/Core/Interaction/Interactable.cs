using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public bool canView { get; set; } = true;
    public bool isObjective { get; set; } = false;
    public string audioName { get; set; } // Only read and set if inheriting interactable is labeled objective.
    public float interactDelay { get; set; } // Only read and set if inheriting interactable is labeled objective.

    public virtual void Interact()
    {
        if (!canView) return;
    }
}
