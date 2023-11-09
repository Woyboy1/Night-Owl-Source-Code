using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{

    public static GameHandler instance;

    private const string freeTime = "Free time"; // a special case where "free time" for player roams around.

    [Header("Assignables")]
    [SerializeField] private PlayerManager playerManager;
    [SerializeField] private LocalSoundManager localSoundManager;
    [SerializeField] private JumpscareManager jumpscareManager;
    [SerializeField] private GameObject horrorZombie;

    [Header("Settings")]
    [SerializeField] private Objective[] objectives;
    [SerializeField] private float freeTimeInterval = 20f;
    [SerializeField] private float decayRecoverAmount = 2.5f;
    [SerializeField] private float decayLossAmount = 4.0f;

    int taskIndex = 0;
    bool zombieHorrorActive = false;

    public int TaskIndex => taskIndex;
    public Objective[] Objectives => objectives;

    private void Awake()
    {
        instance = this;
        UpdateNextObjective();
    }

    private void Start()
    {
        jumpscareManager.CheckReadyJumpscare();
    }

    private void Update()
    {
        if (zombieHorrorActive)
        {
            horrorZombie.SetActive(true);
        } else if (!zombieHorrorActive)
        {
            horrorZombie.SetActive(false);
        }
    }

    public void EnableZombieHorror()
    {
        zombieHorrorActive = true;
    }

    public void DisableZombieHorror()
    {
        zombieHorrorActive = false;
    }

    public void CompleteTask()
    {
        taskIndex++;

        // Other Scripts
        playerManager.PlayerSanityManager.IncreaseSanityValue(decayRecoverAmount);
        localSoundManager.CheckReadyAudio(taskIndex);
        jumpscareManager.CheckReadyJumpscare();
        ScoreManager.instance.IncrementScore();

        // Internal
        CheckObjectivesList();
        UpdateNextObjective();
    }

    public void KillPlayer() // DEATH jumpscare
    {
        ScoreManager.instance.ResetScores();
        jumpscareManager.DeathJumpscare();
    }

    public void FlashScare() // SCARE jumpscare
    {
        jumpscareManager.ScareJumpscare();
        playerManager.PlayerSanityManager.DecreaseSanityValue(decayLossAmount);
    }

    private void CheckObjectivesList()
    {
        if (taskIndex >= objectives.Length)
        {
            ResetTasks();
            foreach (Objective objective in objectives)
            {
                if (objective.physicalObjective == null) return; // returning here incase I ever left this field empty on purpose.

                objective.physicalObjective.ResetPhysicalObjective();
            }
        }
    }

    private void ResetTasks()
    {
        taskIndex = 0;
    }

    private void UpdateNextObjective()
    {
        if (taskIndex >= objectives.Length) return;

        if (objectives[TaskIndex].objectiveName == freeTime) // special case for free time objective
        {
            StartCoroutine(FreeTimeDelay());
        }

        playerManager.PlayerUIManager.UpdateNextObjective(objectives[taskIndex].objectiveDescription);
    }

    private IEnumerator FreeTimeDelay()
    {
        yield return new WaitForSeconds(freeTimeInterval);
        CompleteTask();
    }
}
