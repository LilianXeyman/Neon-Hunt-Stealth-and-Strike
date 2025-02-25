using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemysLeft : MonoBehaviour
{
    public static EnemysLeft instance;

    int enemigosDerrotados;
    int enemigos;

    //Para la puntuacion
    [SerializeField]
    public int puntuacionFinal;
    [SerializeField]
    int valorRobots;
    public int valorBalas;

    [SerializeField]
    TextMeshProUGUI textEnemysLeft;
    [SerializeField]
    public TextMeshProUGUI puntuacionEnPantalla;
    [SerializeField]
    TextMeshProUGUI puntuacionEnPantallaFinalVictoria;
    [SerializeField]
    TextMeshProUGUI puntuacionEnPantallaFinalDerrota;

    public bool puedeSumar;

    //Pantalla Victoria
    [SerializeField]
    GameObject pantallaVictoria;
    [SerializeField]
    GameObject infoPantallaVictoria;
    [SerializeField]
    LeanTweenType animCurv;
    [SerializeField]
    GameObject miniMapa;
    [SerializeField]
    GameObject controles;

    //Para ver los fps
    [SerializeField]
    TextMeshProUGUI fpsEnPantalla;
    float fpsNumero;
    float totalFPS;
    int frameCount;
    float timeElapsed;

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
    private void Start()
    {
        LeanTween.scale(infoPantallaVictoria, Vector3.zero, 0f);
        pantallaVictoria.SetActive(false);
        miniMapa.SetActive(true);
        controles.SetActive(true); //Poner en modo tablet

        Application.targetFrameRate = 140;
        fpsNumero = 1f / Time.deltaTime;
        fpsEnPantalla.text = "FPS: " + Mathf.RoundToInt(fpsNumero);
    }
    void Update()
    {
        fpsNumero = 1f / Time.deltaTime;
        totalFPS += fpsNumero;
        frameCount ++;
        timeElapsed += Time.deltaTime;
        if (timeElapsed >= 5f)
        {
            float fpsPromedio = totalFPS / frameCount;
            fpsEnPantalla.text = "FPS: " + Mathf.RoundToInt(fpsPromedio);
            totalFPS = 0f;
            frameCount = 0;
            timeElapsed = 0f;
        }
    }
    public void RemoveEnemy()
    {
        enemigosDerrotados += 1;
        ActualizarEtiqueta();
        ActualizarPuntuacion();
        if (enemigosDerrotados == enemigos)
        {
            Debug.Log("Mision finalizada");
            //Pantalla Victoria
            miniMapa.SetActive(false);
            controles.SetActive(false);
            pantallaVictoria.SetActive(true);
            LeanTween.scale(infoPantallaVictoria, Vector3.one, 2f).setEase(animCurv);
            //Sumar el resto del tiempo en la puntuacion, por cada segundo son 10 puntos
            puntuacionFinal = puntuacionFinal + (Mathf.FloorToInt(Tiempo.instance.minutos * 60f) + Mathf.FloorToInt(Tiempo.instance.segundos))*10;
            puntuacionEnPantallaFinalVictoria.text = puntuacionFinal.ToString("0000");
            //Falta restar la puntuacion
        }
        puedeSumar = true;
    }
    void ActualizarEtiqueta()
    {
        textEnemysLeft.text = enemigosDerrotados.ToString() + "/" + enemigos.ToString();
    }
    public void AddEnemy()
    {
        enemigos += 1;
        ActualizarEtiqueta();
    }
    public void ActualizarPuntuacion()
    {
        puntuacionFinal = puntuacionFinal + valorRobots;
        //puntuacionFinal += valorRobots;
        //puntuacionFinal -= valorBalas;
        puntuacionEnPantalla.text = puntuacionFinal.ToString("0000");
        puntuacionEnPantallaFinalVictoria.text = puntuacionFinal.ToString("0000");
        puntuacionEnPantallaFinalDerrota.text = puntuacionFinal.ToString("0000");
    }
}
