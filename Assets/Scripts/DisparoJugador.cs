using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisparoJugador : MonoBehaviour
{
    [SerializeField]
    GeneratePool generatePool;

    [SerializeField]
    GameObject arma;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Disparar();
        }
    }

    void Disparar()
    {
        GameObject balaActual = generatePool.CogerBala();
        balaActual.transform.rotation = gameObject.transform.rotation;
        balaActual.transform.position = arma.transform.position +  transform.forward*0.5f;//transform. right / left
        balaActual.SetActive(true);
    }
}
