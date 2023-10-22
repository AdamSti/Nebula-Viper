using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CameraClickToMove : MonoBehaviour
{
    [SerializeField]
    private Camera cam;

    [SerializeField]
    internal List<NavMeshAgent> listShips = new List<NavMeshAgent>();

    [SerializeField]
    internal Transform testObject;

    
    void Start()
    {
        //cam = GetComponent<Camera>();
    }

  
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && listShips.Count > 0)
        {
            CreateShipFormationAndMove();
        }
    }

    internal void CreateShipFormationAndMove()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            testObject.transform.position = hit.point;
            foreach (var ship in listShips)
            {
                ship.SetDestination(hit.point);
            }
        }
    }
}
