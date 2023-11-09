using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudioController : MonoBehaviour
{
    [Header("Assignables")]
    [SerializeField] private AudioSource source;

    [Header("Audio")]
    [SerializeField] private AudioClip walkingSfx;

    public bool isMoving { get; set; }

    private void Update()
    {
        WalkingSFX();
    }

    private void WalkingSFX()
    {
        if (isMoving)
        {
            if (!source.isPlaying)
            {
                source.clip = walkingSfx;
                source.Play();
            }
        }
        else
        {
            source.Stop();
        }
    }
}
