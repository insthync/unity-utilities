using UnityEngine;
using UnityEngine.AI;
using System.Collections;

[RequireComponent(typeof(NavMeshAgent))]
public class SetNavMeshAgentByCollider : MonoBehaviour
{
    private void LateUpdate()
    {
        NavMeshAgent navAgent = GetComponent<NavMeshAgent>();
        if (navAgent != null)
        {
            BoxCollider boxCollider = GetComponent<BoxCollider>();
            if (boxCollider != null)
            {
                navAgent.radius = (boxCollider.size.x + boxCollider.size.z) / 2;
                navAgent.height = boxCollider.size.y;
                navAgent.baseOffset = 0;
                return;
            }
            CapsuleCollider capsuleCollider = GetComponent<CapsuleCollider>();
            if (capsuleCollider != null)
            {
                navAgent.radius = capsuleCollider.radius;
                navAgent.height = capsuleCollider.height;
                navAgent.baseOffset = 0;
                return;
            }
            SphereCollider sphereCollider = GetComponent<SphereCollider>();
            if (sphereCollider != null)
            {
                navAgent.radius = sphereCollider.radius;
                navAgent.height = sphereCollider.radius * 2;
                navAgent.baseOffset = 0;
                return;
            }
            CharacterController characterController = GetComponent<CharacterController>();
            if (characterController != null)
            {
                navAgent.radius = characterController.radius;
                navAgent.height = characterController.height;
                navAgent.baseOffset = 0;
                return;
            }
        }
    }
}
