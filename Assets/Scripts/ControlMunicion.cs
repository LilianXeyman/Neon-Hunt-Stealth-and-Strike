using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlMunicion : MonoBehaviour
{
    public static ControlMunicion instance;
    
    [SerializeField]
    DeteccionEnemigos deteccionEnemigos;

    [SerializeField]
    GameObject[] imagenBalas;

    [SerializeField]
    GameObject noBalas;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        /*for (int i = 0; i < imagenBalas.Length; i++)
        {
            imagenBalas[i].SetActive(false);
        }*/
        imagenBalas[2].SetActive(false);
        imagenBalas[1].SetActive(false);
        imagenBalas[0].SetActive(false);
        noBalas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void RevisarCantidadBalas()
    {
        /*for (int i = 0; i < deteccionEnemigos.balasTotales; i++)
        {
            imagenBalas[i].SetActive(true);
        }*/
        if (deteccionEnemigos.balasTotales == 0)
        {
            imagenBalas[2].SetActive(true);
            imagenBalas[1].SetActive(true);
            imagenBalas[0].SetActive(true);
            noBalas.SetActive(true);
        }
        if (deteccionEnemigos.balasTotales == 1)
        {
            imagenBalas[2].SetActive(false);
            imagenBalas[1].SetActive(true);
            imagenBalas[0].SetActive(true);
            noBalas.SetActive(false);
        }
        if (deteccionEnemigos.balasTotales == 2)
        {
            imagenBalas[2].SetActive(false);
            imagenBalas[1].SetActive(false);
            imagenBalas[0].SetActive(true);
            noBalas.SetActive(false);
        }
        if (deteccionEnemigos.balasTotales == 3)
        {
            imagenBalas[2].SetActive(false);
            imagenBalas[1].SetActive(false);
            imagenBalas[0].SetActive(false);
            noBalas.SetActive(false);
        }
    }
}
