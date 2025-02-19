using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Patrulla : MonoBehaviour
{
    [SerializeField]
    DeteccionEnemigos deteccionEnemigos;

    public NavMeshAgent navMeshAgent;

    public Transform[] waypoints;
    int m_CurrentWaypointIndex;
    // Start is called before the first frame update
    void Start()
    {
        EnemysLeft.instance.AddEnemy();
        navMeshAgent.SetDestination(waypoints[0].position);
    }

    // Update is called once per frame
    void Update()
    {
        if (deteccionEnemigos.menuPausa)
        {
            navMeshAgent.isStopped = true;
            return; // Salir de la función si el menú de pausa está activo
        }
        else 
        {
            navMeshAgent.isStopped = false;
        }
        if (navMeshAgent.remainingDistance < navMeshAgent.stoppingDistance)
        {
            m_CurrentWaypointIndex = (m_CurrentWaypointIndex + 1) % waypoints.Length;
            navMeshAgent.SetDestination(waypoints[m_CurrentWaypointIndex].position);
        }
    }
}
