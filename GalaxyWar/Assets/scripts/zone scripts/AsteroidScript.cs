using System.Collections;
using System.Collections.Generic;
using Unity.AI.Navigation;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Collider), typeof(NavMeshModifierVolume))]
public class AsteroidScript : MonoBehaviour
{
    private NavMeshModifierVolume volume;

    private void Awake()
    {
        volume = GetComponent<NavMeshModifierVolume>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("ve�el do asterojd�");
        if (other.TryGetComponent<NavMeshAgent>(out NavMeshAgent agent))
        {
            if (volume.AffectsAgentType(agent.agentTypeID))
            {
                float costModifier = NavMesh.GetAreaCost(volume.area);

                agent.speed /= costModifier;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("vy�el do asterojd�");
        if (other.TryGetComponent<NavMeshAgent>(out NavMeshAgent agent))
        {
            if (volume.AffectsAgentType(agent.agentTypeID))
            {
                float costModifier = NavMesh.GetAreaCost(volume.area);

                agent.speed *= costModifier;
            }
        }
    }
}
