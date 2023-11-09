using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HorrorObject : MonoBehaviour
{
    [Header("Assignables")]
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject orientation;
    [SerializeField] private AudioClip customScareSFX;

    [Header("Jumpscare Settings")]
    [SerializeField] private string jumpscareSFXName = "Jumpscare1";
    [SerializeField] private float moveSpeed = 5.0f;
    [SerializeField] private float destroyInterval = 3.0f;

    [Header("Animation State")]
    [SerializeField] private bool isWalking = false;
    [SerializeField] private bool isRunning = false;
    [SerializeField] private bool isCustom = false;

    private bool isActive = false;
    private AudioSource source;

    public Animator Animator
    {
        get { return animator; }
        set { animator = value; }
    }

    private void Start()
    {
        source = GetComponent<AudioSource>();
        CycleAnimationState();
    }

    private void Update()
    {
        if (isActive)
        {
            MoveObject();
        }
    }

    void CycleAnimationState()
    {
        if (!isCustom) return;
        if (isWalking) animator.SetBool("isWalking", true);
        if (isRunning) animator.SetBool("isRunning", true);
    }

    public void JumpscarePlayer()
    {
        if (isActive) return;
        isActive = true;

        PlayCustomSFX();
        Destroy(this.gameObject, destroyInterval);
    }

    private void MoveObject()
    {
        Vector3 direction = Vector3.forward;
        transform.Translate(direction * moveSpeed * Time.deltaTime);
    }

    private void PlayCustomSFX()
    {
        // Audiomanager
        AudioManager.instance.Play(jumpscareSFXName);

        // Local SFX
        if (customScareSFX == null) return;
        source.PlayOneShot(customScareSFX);
    }
}
