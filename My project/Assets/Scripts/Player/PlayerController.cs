using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    Camera cam;
    public LayerMask groundLayer;
    public NavMeshAgent agent;
    void Awake()
    {
        cam=Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            agent.SetDestination(getPointUnderCursor());
        }
        
    }
    private Vector3 getPointUnderCursor()
    {
        Vector2 screenPos = Input.mousePosition;
        Ray ray = cam.ScreenPointToRay(screenPos);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 1000, groundLayer))
        {
            Debug.Log("HitPOINT: " + hit.point);
            return hit.point;
        }

        return Vector3.zero; // Valor predeterminado si no se encuentra intersección
    }
}
