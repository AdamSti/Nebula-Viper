using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class testShipScript : MonoBehaviour
{
    NavMeshAgent navMeshAgentLodi;

    [SerializeField]
    Transform movePointObjectTest;
    private void Awake()
    {
        navMeshAgentLodi = GetComponent<NavMeshAgent>();
        navMeshAgentLodi.destination = movePointObjectTest.position;
    }

    // Update is called once per frame
    void Update()
    {
        //navMeshAgentLodi.destination = movePointObjectTest.position;
    }
}
