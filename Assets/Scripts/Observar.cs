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

    //Pantalla Derrota
    [SerializeField]
    GameObject pantallaDerrota;
    [SerializeField]
    GameObject infoPantallaDerrota;
    [SerializeField]
    LeanTweenType animCurv;

    private void Start()
    {
        LeanTween.scale(infoPantallaDerrota, Vector3.zero, 0f);
        pantallaDerrota.SetActive(false);
    }

    private void FixedUpdate()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))
        {
            if (hit.collider.CompareTag("Player"))
            {
                pantallaDerrota.SetActive(true);
                LeanTween.scale(infoPantallaDerrota, Vector3.one, 2f).setEase(animCurv);
            }
        }
    }
}
