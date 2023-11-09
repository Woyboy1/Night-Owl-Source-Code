using Suburb;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicalObjective : Interactable
{
    [Header("Assignables (Optional)")]
    [SerializeField] private SimpleOpenClose nearbyDoor; 

    [Header("Must match to Objective.cs objectID property")]
    [SerializeField] private int objectiveID;
    [SerializeField] private string audioLabel;
    [SerializeField] private float interactionInterval = 3.0f;

    public int ObjectiveId => objectiveID;

    private void Start()
    {
        isObjective = true;
        audioName = audioLabel;
        interactDelay = interactionInterval;
    }

    public override void Interact()
    {
        base.Interact();

        if (objectiveID != GameHandler.instance.TaskIndex) return;

        GameHandler.instance.CompleteTask();
        canView = false;
    }

    public void ResetPhysicalObjective()
    {
        canView = true;
    }

    public void ManageNearbyDoor()
    {
        if (nearbyDoor == null) return;
        if (!nearbyDoor.objectOpen) return; // if it's closed, return
        nearbyDoor?.BroadcastMessage("ObjectClicked");
    }
}
