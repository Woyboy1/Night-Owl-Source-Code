using Cinemachine.Utility;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JumpscareManager : MonoBehaviour
{
    private const int bathroomIndex = 0;

    [Header("Assignables")]
    [SerializeField] private LocalPosition[] positions;
    [SerializeField] private GameObject horrorZombieGhost;
    [SerializeField] private Transform deathLocation;
    [SerializeField] private GameObject screenOverlay;

    [Header("Death")]
    [SerializeField] private AnimatorOverrider animatorOverrider;
    [SerializeField] private float deathDuration = 3.0f;
    [SerializeField] private AudioListener originalListener;
    [SerializeField] private AudioListener jumpscareListener;

    private void Start()
    {
        jumpscareListener.enabled = false;
    }

    public void CheckReadyJumpscare()
    {
        CycleJumpscares();
    }

    public void DeathJumpscare() // called for when the player is dead.
    {
        originalListener.enabled = false;
        jumpscareListener.enabled = true;
        PlayerManager.instance.gameObject.transform.position = deathLocation.position;
        PlayerManager.instance.DisableControls();
        PlayerManager.instance.SwitchPriorityTarget();
        animatorOverrider.OverrideAnimator();

        AudioManager.instance.Play("ZombieEating");
        AudioManager.instance.Play("ManScream");

        StartCoroutine(SwitchScenes());
    }

    IEnumerator SwitchScenes()
    {
        string sceneName = "Ending";
        yield return new WaitForSeconds(deathDuration);

        AudioManager.instance.Stop("ZombieEating");
        AudioManager.instance.Stop("ManScream");

        SceneManager.LoadScene(sceneName);
        Cursor.lockState = CursorLockMode.None;
    }

    public void ScareJumpscare() // called for light jumpscare
    {
        float delay = 2.0f;

        AudioManager.instance.Play("Jumpscare3");
        AudioManager.instance.Play("PlayShock");
        AudioManager.instance.Play("PlayerBreathing");

        StartCoroutine(DisplayScreenOverlay(delay));
    }

    IEnumerator DisplayScreenOverlay(float duration)
    {
        screenOverlay.SetActive(true);
        yield return new WaitForSeconds(duration);
        screenOverlay.SetActive(false);
    }

    private void CycleJumpscares() // abandoned 
    {
        switch (GameHandler.instance.TaskIndex)
        {
            case 0:
                break;
            case 1:
                InstantiateHallwayOneHorror();
                break;
            case 2:
                break;
            default:
                break;
        }
    }

    private Vector3 FindLocalPosition(string name)
    {
        Vector3 positionTransform;

        foreach (LocalPosition pos in positions)
        {
            if (pos.localPositionName == name)
            {
                positionTransform = pos.gameObject.transform.position;
                return positionTransform;
            }
        }

        Debug.LogWarning("FindLocalPosition returned empty!");
        return Vector3.zero;
    }

    private void InstantiateHallwayOneHorror()
    {
        string hallway = "Hallway1";
        Instantiate(horrorZombieGhost, FindLocalPosition(hallway), Quaternion.identity);
    }
}
