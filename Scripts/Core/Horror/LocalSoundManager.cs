using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Unity.Mathematics;

public class LocalSoundManager : MonoBehaviour
{
    private const int num_of_events = 1;

    [Header("Assignables")]
    [SerializeField] private LocalPosition[] audioCueLocations;

    [Header("Local Audio SFX")]
    [SerializeField] private AudioClip knockingSFX;
    [SerializeField] private AudioClip neighborsSFX;

    private bool isKnocked = false;
    private bool neighborActive = false;

    public void CheckReadyAudio(int taskIndex)
    {
        int randInt = UnityEngine.Random.Range(taskIndex, GameHandler.instance.Objectives.Length);

        if (randInt == taskIndex)
        {
            RandomSoundEvent();
        }
    }

    private void RandomSoundEvent()
    {
        int randInt = UnityEngine.Random.Range(0, num_of_events);
        switch (randInt)
        {
            case 0:
                FrontDoorEvent();
                break;
            case 1:
                GarageDoorEvent();
                break;
            case 2:
                NeighborEvent();
                break;
            default: // impossible for this to happen but left here to keep compiler happy. 
                break;
        }
    }

    private void PlayAudioAtPosition(string locationName, AudioClip clip)
    {
        foreach (LocalPosition localPosition in audioCueLocations)
        {
            if (localPosition.localPositionName == locationName)
            {
                AudioSource.PlayClipAtPoint(clip, localPosition.localPosVector);
                break;
            }
        }
    }

    private void FrontDoorEvent()
    {
        string locationName = "Front Door";
        AudioClip clip = knockingSFX;

        if (!isKnocked)
            PlayAudioAtPosition(locationName, clip);

        isKnocked = true;
    }

    private void GarageDoorEvent()
    {

    }

    private void NeighborEvent()
    {
        string locationName = "Front Door";
        AudioClip clip = neighborsSFX;

        if (!neighborActive)
            PlayAudioAtPosition(locationName, clip);

        neighborActive = true;
    }
}
