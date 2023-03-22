using System;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

namespace Gameplay
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private NavMeshAgent agent;
        [SerializeField] private Camera mainCamera;
        [SerializeField] private Animator animator;
        [SerializeField] private AudioSource audioSource;

        private const string RUNNING = "Running";
        private const string GATHER = "Gather";
        private const string TREASURE = "Treasure";
        
        public delegate void OnTreasureCollect();
        public event OnTreasureCollect onTreasureCollect;
        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (EventSystem.current.IsPointerOverGameObject()) return;
                Ray movePosition = mainCamera.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(movePosition, out var hitInfo))
                {
                    agent.SetDestination(hitInfo.point);
                    animator.SetBool(RUNNING, true);
                }
            }
            else if (!agent.pathPending)
            {
                if (agent.remainingDistance <= agent.stoppingDistance)
                {
                    if (!agent.hasPath || agent.velocity.sqrMagnitude == 0f)
                    {
                        animator.SetBool(RUNNING, false);
                    }
                }
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag(TREASURE))
            {
                animator.SetTrigger(GATHER);
                audioSource.Play();
                if (Enum.TryParse(other.name, out TreasureType treasureType))
                {
                    Debug.Log($"{other.name} is not listed, please check Enum Treasure");
                    return;
                }
                onTreasureCollect?.Invoke();
                Destroy(other.gameObject);
            }
        }
    }
}