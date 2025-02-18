using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class Balas : MonoBehaviour
{
    public GeneratePool balasPool;

    [SerializeField]
    public DeteccionEnemigos deteccionEnemigos;

    [SerializeField]
    float coolDown;
    float tiempoReset;

    [SerializeField]
    float velocidadBala;

    Rigidbody balaRb;

    //public NavMeshAgent navMeshAgent;
    void Start()
    {
        //navMeshAgent = GetComponent<NavMeshAgent>();
        tiempoReset = coolDown;
        balaRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        /*if (deteccionEnemigos.robotADisparar != null)
        {
            navMeshAgent.SetDestination(deteccionEnemigos.robotADisparar.transform.position);
        }*/

        //gameObject.transform.position = (deteccionEnemigos.robotADisparar.transform.position) * Time.deltaTime * velocidadBala;

        //gameObject.transform.position = transform.forward * Time.deltaTime * velocidadBala;

        if (deteccionEnemigos.robotADisparar != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, deteccionEnemigos.robotADisparar.transform.position, velocidadBala * Time.deltaTime);
        }
        else 
        {
            gameObject.transform.position = transform.forward * Time.deltaTime * velocidadBala;
        }

        coolDown = coolDown - Time.deltaTime;
        if (coolDown <= 0)
        {
            coolDown = tiempoReset;
            balasPool.GuardarBala(gameObject);
            deteccionEnemigos.canShoot = true;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemigos"))
        {
            Destroy(collision.gameObject);
            deteccionEnemigos.canShoot = true;
            EnemysLeft.instance.RemoveEnemy();
            balasPool.GuardarBala(gameObject);
        }
        else 
        {
            balasPool.GuardarBala(gameObject);
            deteccionEnemigos.canShoot = true;
        }
    }
}
