using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Tiempo : MonoBehaviour
{
    public static Tiempo instance;

    [SerializeField]
    DeteccionEnemigos deteccionEnemigos;

    [SerializeField]
    float tiempo;
    public float minutos;
    public float segundos;
    [SerializeField]
    TextMeshProUGUI textoTiempo;

    //Para cambiar la escena
    public string Derrota;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (deteccionEnemigos.menuPausa == false)
        {
            tiempo = tiempo - Time.deltaTime;
            minutos = Mathf.FloorToInt(tiempo / 60);
            segundos = Mathf.FloorToInt(tiempo % 60);
            textoTiempo.text = minutos.ToString("00") + " : " + segundos.ToString("00"); //Tambien asi textoTiempo.text = $"{minutos:00}:{segundos:00}";

            if (tiempo <= 0)
            {
                SceneManager.LoadScene(Derrota);//Cambiar condicion
            }
        }
    }
}
