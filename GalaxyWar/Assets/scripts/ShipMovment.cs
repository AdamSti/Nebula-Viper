using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ShipMovment : MonoBehaviour
{
    [SerializeField]
    DodgeType dodgeType;
    //[SerializeField]
    //NavMeshAgent navShip;
    [SerializeField]
    float dodgeTime;


    void Start()
    {
        AddMovmentManager();
    }

    internal void AddMovmentManager() 
    {
        ScenarioManager sM = gameObject.AddComponent<ScenarioManager>();
        switch (dodgeType)
        {
            case DodgeType.None:
                sM.AvoidanceType = ObstacleAvoidanceType.NoObstacleAvoidance;
                break;
            case DodgeType.Low:
                sM.AvoidanceType = ObstacleAvoidanceType.LowQualityObstacleAvoidance;
                break;
            case DodgeType.Medium:
                sM.AvoidanceType = ObstacleAvoidanceType.MedQualityObstacleAvoidance;
                break;
            case DodgeType.Good:
                sM.AvoidanceType = ObstacleAvoidanceType.GoodQualityObstacleAvoidance;
                break;
            default:
                sM.AvoidanceType = ObstacleAvoidanceType.HighQualityObstacleAvoidance;
                break;
        }
        sM.AgentPrefab = gameObject.GetComponent<NavMeshAgent>();
        sM.AvoidancePredictionTime = dodgeTime;
    }

    enum DodgeType
    {
        None,
        Low,
        Medium,
        Good,
        Hight
    }
}
