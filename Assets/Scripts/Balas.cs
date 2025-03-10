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

    bool puedeRestar;

    //Efectos especiales
    [SerializeField]
    GameObject explosion;
    [SerializeField]
    GameObject marcasExplosion;
    [SerializeField]
    AudioSource audioSource;
    public AudioClip explosionSound;

    //para los powerUps
    [SerializeField]
    float probabilidad;
    [SerializeField]
    GameObject powerUp;
    [SerializeField]
    GameObject powerUpMaxEnergy;
    [SerializeField]
    GameObject powerUpMantenerEnergy;
    void Start()
    {
        //navMeshAgent = GetComponent<NavMeshAgent>();
        tiempoReset = coolDown;
        balaRb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
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
            audioSource.PlayOneShot(explosionSound);
            Destroy(collision.gameObject);
            Instantiate(explosion, transform.position, Quaternion.identity);
            deteccionEnemigos.canShoot = true;
            EnemysLeft.instance.puedeSumar = true;
            if (EnemysLeft.instance.puedeSumar ==true)
            {
                EnemysLeft.instance.puedeSumar = false;
                EnemysLeft.instance.RemoveEnemy();
            }
            balasPool.GuardarBala(gameObject);
            probabilidad = Random.value*100;
            if (probabilidad <= 10f)
            {
                //Instanciar PowerUp
                powerUp = Instantiate(powerUpMaxEnergy, transform.position, Quaternion.identity);
            }
            if (probabilidad <= 16f && probabilidad >= 11f)
            {
                //Instanciar PowerUp
                powerUp = Instantiate(powerUpMantenerEnergy, transform.position, Quaternion.identity);
            }
        }
        else 
        {
            audioSource.PlayOneShot(explosionSound);//No suena
            balasPool.GuardarBala(gameObject);
            Instantiate(explosion, transform.position, Quaternion.identity);
            Instantiate(marcasExplosion, transform.position, Quaternion.identity);
            deteccionEnemigos.canShoot = true;
            puedeRestar = true;
            if (puedeRestar)
            {
                puedeRestar = false;
                EnemysLeft.instance.puntuacionFinal = EnemysLeft.instance.puntuacionFinal - EnemysLeft.instance.valorBalas;
                EnemysLeft.instance.puntuacionEnPantalla.text = EnemysLeft.instance.puntuacionFinal.ToString("0000");
            }
        }
    }
}
