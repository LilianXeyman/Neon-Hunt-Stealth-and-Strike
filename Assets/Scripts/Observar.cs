using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Observar : MonoBehaviour
{
    //Para cambiar la escena
    public string Derrota;

    public Transform player;

    [SerializeField]
    float distancia;

    private void Update()
    {
        
    }

    private void FixedUpdate()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))
        {
            if (hit.collider.CompareTag("Player"))
            {
                SceneManager.LoadScene(Derrota);
            }
        }
    }
}
