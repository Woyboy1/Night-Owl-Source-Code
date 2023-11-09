using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEventHandler : MonoBehaviour
{
    [Header("Assignables")]
    [SerializeField] private AudioSource source;
    [SerializeField] private AudioClip stepSFX;

    public void AnimationEventStepSFX()
    {
        source.PlayOneShot(stepSFX);
    }
}
