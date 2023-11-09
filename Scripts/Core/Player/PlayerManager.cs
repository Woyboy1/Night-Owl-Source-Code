using Cinemachine;
using Suburb;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager instance;

    [Header("Assignables")]
    [SerializeField] private SimplePlayerController playerController;
    [SerializeField] private SimplePlayerUse playerUse;
    [SerializeField] private PlayerUIManager playerUIManager;
    [SerializeField] private PlayerAudioController playerAudioController;
    [SerializeField] private PlayerSanityManager playerSanityManager;
    [SerializeField] private CinemachineVirtualCamera virtualCamera;

    public SimplePlayerController PlayerController => playerController;
    public SimplePlayerUse PlayerUse => playerUse;
    public PlayerUIManager PlayerUIManager => playerUIManager;
    public PlayerAudioController PlayerAudioController => playerAudioController;
    public PlayerSanityManager PlayerSanityManager => playerSanityManager;

    private void Awake()
    {
        instance = this;
        Application.targetFrameRate = 70;
    }

    public void DisableControls()
    {
        playerController.CanMove = false;
        playerUse.CanUse = false;
    }

    public void EnableControls()
    {
        playerController.CanMove = true;
        playerUse.CanUse = true;
    }

    public void EnableFootstepSFX()
    {
        playerAudioController.isMoving = true;
    }

    public void DisableFootstepSFX()
    {
        playerAudioController.isMoving = false;
    }
    
    // Cinemachine
    public void SwitchPriorityTarget()
    {
        virtualCamera.m_Priority = 80;
    }
}
