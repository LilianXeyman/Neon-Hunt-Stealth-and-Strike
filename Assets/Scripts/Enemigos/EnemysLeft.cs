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

    //Pantalla Victoria
    [SerializeField]
    GameObject pantallaVictoria;
    [SerializeField]
    GameObject infoPantallaVictoria;
    [SerializeField]
    LeanTweenType animCurv;
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
            pantallaVictoria.SetActive(true);
            LeanTween.scale(infoPantallaVictoria, Vector3.one, 2f).setEase(animCurv);
            //Sumar el resto del tiempo en la puntuacion, por cada segundo son 10 puntos
            puntuacionFinal = puntuacionFinal + (Mathf.FloorToInt(Tiempo.instance.minutos * 60f) + Mathf.FloorToInt(Tiempo.instance.segundos))*10;
            puntuacionEnPantallaFinalVictoria.text = puntuacionFinal.ToString("00000");
            //Falta restar la puntuacion
        }
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
        puntuacionFinal += valorRobots;
        puntuacionFinal -= valorBalas;
        puntuacionEnPantalla.text = puntuacionFinal.ToString("00000");
        puntuacionEnPantallaFinalVictoria.text = puntuacionFinal.ToString("00000");
        puntuacionEnPantallaFinalDerrota.text = puntuacionFinal.ToString("00000");
    }
}
