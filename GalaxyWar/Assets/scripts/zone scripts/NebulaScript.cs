using System.Collections;
using System.Collections.Generic;
using Unity.AI.Navigation;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Collider), typeof(NavMeshModifierVolume))]

public class NebulaScript : MonoBehaviour
{
    private NavMeshModifierVolume volume;

    private void Awake()
    {
        volume = GetComponent<NavMeshModifierVolume>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("ve�el do nebuly");
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("vy�el do nebuly");
    }
}
