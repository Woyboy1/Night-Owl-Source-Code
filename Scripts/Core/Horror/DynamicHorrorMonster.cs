using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DynamicHorrorMonster : MonoBehaviour
{
    [Header("Assignables")]
    [SerializeField] private Transform[] patrolPoints;
    [SerializeField] private Animator animator;

    private Vector3 originalPos;
    private int currentPatrolIndex = 0;
    private NavMeshAgent navMeshAgent;
    private bool playedSound = false;

    private void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        originalPos = transform.position;
    }

    private void Update()
    {
        CheckIfMoving();

        if (navMeshAgent.remainingDistance < 0.1f)
        {
            SetNextPatrolDestination();
        }
    }

    private void SetNextPatrolDestination()
    {
        if (patrolPoints.Length == 0)
            return;

        navMeshAgent.SetDestination(patrolPoints[currentPatrolIndex].position);
        currentPatrolIndex = (currentPatrolIndex + 1) % patrolPoints.Length;
    }

    private void CheckIfMoving()
    {
        if (navMeshAgent.velocity.magnitude > 0)
        {
            animator.SetBool("isWalking", true);
        } else
        {
            animator.SetBool("isWalking", false);
        }
    }

    public void PlayScareSFX()
    {
        if (playedSound) return;
        AudioManager.instance.Play("Jumpscare2");
        playedSound = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            GameHandler.instance.FlashScare();
            transform.position = originalPos;
        }
    }
}
