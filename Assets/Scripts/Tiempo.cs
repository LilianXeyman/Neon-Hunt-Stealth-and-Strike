using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Tiempo : MonoBehaviour
{
    [SerializeField]
    float tiempo;
    float minutos;
    float segundos;
    [SerializeField]
    TextMeshProUGUI textoTiempo;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        tiempo = tiempo - Time.deltaTime;
        minutos = Mathf.FloorToInt(tiempo / 60);
        segundos = Mathf.FloorToInt(tiempo % 60);
        textoTiempo.text = minutos.ToString("00") + " : "+ segundos.ToString("00"); //Tambien asi textoTiempo.text = $"{minutos:00}:{segundos:00}";
    }
}
