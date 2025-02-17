using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Balas : MonoBehaviour
{
    public GeneratePool balasPool;

    [SerializeField]
    float coolDown;
    float tiempoReset;

    [SerializeField]
    float velocidadBala;
    void Start()
    {
        tiempoReset = coolDown;
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position += transform.forward * Time.deltaTime * velocidadBala;
        coolDown = coolDown - Time.deltaTime;
        if (coolDown <= 0)
        {
            coolDown = tiempoReset;
            balasPool.GuardarBala(gameObject);
        }
    }
}
