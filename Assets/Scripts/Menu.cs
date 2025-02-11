using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    //Para cambiar la escena
    public string SampleScene;

    [SerializeField]
    GameObject gameTitle;
    [SerializeField]
    GameObject enterStart;
    [SerializeField]
    GameObject imageCargando;
    [SerializeField]
    GameObject botonEmpezar;
    [SerializeField]
    GameObject botonOpciones;
    [SerializeField]
    GameObject botonSalir;
    [SerializeField]
    GameObject imagenPlayer;
    [SerializeField]
    GameObject imagenEnemy;
    [SerializeField]
    GameObject imagenVs1;
    [SerializeField]
    GameObject imagenVs2;

    //Parámetros
    [SerializeField]
    float posPantallaBotonEmpezar;
    [SerializeField]
    float posPantallaBotonOpciones;
    [SerializeField]
    float posPantallaBotonSalir;
    [SerializeField]
    float tiempoAnim;
    [SerializeField]
    LeanTweenType curvAnim;
    [SerializeField]
    float posPantallaImagenPlayer;
    [SerializeField]
    float posPantallaImagenEnemy;
    [SerializeField]
    float posPantallaImagenVs1;
    [SerializeField]
    float posPantallaImagenVs2;
    [SerializeField]
    LeanTweenType curvAnim2;

    //Imput System
    PlayerInput _playerInput;

    //Bool Menu
    bool menuActivo;
    bool empezar;

    // Start is called before the first frame update
    void Start()
    {
        gameTitle.SetActive(true);
        enterStart.SetActive(true);
        imageCargando.SetActive(false);

        //Implementar ImputSystem
        _playerInput = GetComponent<PlayerInput>();

        //Para el enter
        menuActivo = true;
        empezar = false;

        //Botones
        LeanTween.moveLocalY(botonEmpezar, -1200, 0);
        LeanTween.moveLocalY(botonOpciones, -1200, 0);
        LeanTween.moveLocalY(botonSalir, -1200, 0);
        botonEmpezar.SetActive(false);
        botonOpciones.SetActive(false);
        botonSalir.SetActive(false);

        //Imagenes Menu
        LeanTween.moveLocalY(imagenPlayer, 1200, 0);
        LeanTween.moveLocalY(imagenEnemy, -1200, 0);
        LeanTween.moveLocalY(imagenVs1, -1200, 0);
        LeanTween.moveLocalY(imagenVs2, 1200, 0);
    }
        // Update is called once per frame
        void Update()
        {
            //Debug /Poner en todas las escenas
            FullScreen();

        //Para el menu

        //Para la primera parte del menu
        if (empezar==false)
        {
            if (Input.GetButtonDown("Submit") || Input.anyKeyDown)
            {
                empezar=true;
                ShowButtons();
                //LeanTween.
                Debug.Log("Empezar");
            }
        }
        }
        void FullScreen()
        {
            if (Input.GetKeyDown(KeyCode.K))//Cambiar para la forma genérica
            {
                Screen.fullScreen = !Screen.fullScreen;
            }
        }
    void ShowButtons()
    {
        //Para el parpadeo del título
        LeanTween.cancel(enterStart);
        enterStart.SetActive(false);
        gameTitle.SetActive(false);
        botonEmpezar.SetActive(true);
        botonOpciones.SetActive(true);
        botonSalir.SetActive(true);

        //Botones
        LeanTween.moveLocalY(botonEmpezar, posPantallaBotonEmpezar, tiempoAnim).setEase(curvAnim).setOnComplete(() => { 
            LeanTween.moveLocalY(botonOpciones, posPantallaBotonOpciones, tiempoAnim).setEase(curvAnim).setOnComplete(() => {
                LeanTween.moveLocalY(botonSalir, posPantallaBotonSalir, tiempoAnim ).setEase(curvAnim).setOnComplete(() => {
                    //Imagenes robots
                    LeanTween.moveLocalY(imagenPlayer, posPantallaImagenPlayer, tiempoAnim).setEase(curvAnim2).setOnComplete(() => {
                        LeanTween.moveLocalY(imagenVs1, posPantallaImagenVs1, tiempoAnim * 0.25f).setEase(curvAnim2).setOnComplete(() => {
                            LeanTween.moveLocalY(imagenVs2, posPantallaImagenVs2, tiempoAnim * 0.25f).setEase(curvAnim2).setOnComplete(() => {
                                LeanTween.moveLocalY(imagenEnemy, posPantallaImagenEnemy, tiempoAnim).setEase(curvAnim2);
                            });
                        });
                    });
                });
            });
        });
    }
    public void BotonSalir()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; // Detiene el juego en el editor
#else
        Application.Quit(); // Cierra la aplicación en la build
#endif
    }
    public void Comenzar()
    {
        SceneManager.LoadScene(SampleScene);
    }
    public void Opciones()
    { 
    
    }
    public void Volver()
    { 
    
    }
    /*void AlternarMenu()
    { 
        menuActivo=!menuActivo;

        if (menuActivo)
        {
            StartCoroutine(ParpadearMenu());
            Time.timeScale = 0;
        }
        else 
        {
            StopAllCoroutiine();
            menuCanvas.alpha=1
        }
    }*/
}
