using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class Menu : MonoBehaviour
{
    //Para el menu
    public EventSystem eventSystem;
    public GameObject pantallaCompleta;

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
    [SerializeField]
    GameObject menuOpciones;

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
    [SerializeField]
    float posPantallaMenuOpciones;
    [SerializeField]
    float posPantallaImagenPlayerX;
    [SerializeField]
    float posPantallaImagenEnemyX;

    //Imput System
    PlayerInput _playerInput;

    //Bool Menu
    bool menuActivo;
    bool empezar;

    //Audio
    [SerializeField]
    AudioSource audioSource;
    [SerializeField]
    AudioClip clipBotones;

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
        menuOpciones.SetActive(false);

        //Imagenes Menu
        LeanTween.moveLocalY(imagenPlayer, 1200, 0);
        LeanTween.moveLocalY(imagenEnemy, -1200, 0);
        LeanTween.moveLocalY(imagenVs1, -1200, 0);
        LeanTween.moveLocalY(imagenVs2, 1200, 0);

        //Pantalla Completa
        FullScreen();
    }
        // Update is called once per frame
    void Update()
    {
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
    public void FullScreen()
    {
         Screen.fullScreen = !Screen.fullScreen;
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
        menuOpciones.SetActive(true);
        eventSystem.SetSelectedGameObject(pantallaCompleta);
        //Quitarle el alpha a los botones y desasctivarlos. Mover las imágenes hacia los lados y el menu de opciones cae desde arriba
        SetAlpha(botonEmpezar, 0, 0.75f);
        SetAlpha(botonOpciones, 0, 0.75f);
        SetAlpha(botonSalir, 0, 0.75f);
           LeanTween.moveLocalX(imagenPlayer, -1900, 0.25f).setOnComplete(() => {
               botonEmpezar.SetActive(false);
               botonOpciones.SetActive(false);
               botonSalir.SetActive(false);
               LeanTween.moveLocalX(imagenEnemy, 1900, 0.25f);
                   LeanTween.moveLocalX(imagenVs1, -1900, 0.25f).setOnComplete(() => {
                       LeanTween.moveLocalX(imagenVs2, 1900, 0.25f).setOnComplete(() =>
                       {
                           LeanTween.moveLocalY(menuOpciones, posPantallaMenuOpciones, tiempoAnim).setEase(curvAnim);
                       });
                   });
           });
  
    }
    public void Volver()
    {
        menuOpciones.SetActive(false);
        eventSystem.SetSelectedGameObject(botonEmpezar);
        //Reestablecer el menu inicial
        LeanTween.moveLocalY(menuOpciones, 1900, tiempoAnim).setOnComplete(() =>
        {
            LeanTween.moveLocalX(imagenVs1, posPantallaImagenVs1, tiempoAnim * 0.25f).setEase(curvAnim2);
            LeanTween.moveLocalX(imagenVs2, posPantallaImagenVs2, tiempoAnim * 0.25f).setEase(curvAnim2).setOnComplete(() =>
            {
                LeanTween.moveLocalX(imagenPlayer, posPantallaImagenPlayerX, tiempoAnim).setEase(curvAnim2);
                LeanTween.moveLocalX(imagenEnemy, posPantallaImagenEnemyX, tiempoAnim).setEase(curvAnim2).setOnComplete(() =>
                {
                    botonEmpezar.SetActive(true);
                    botonOpciones.SetActive(true);
                    botonSalir.SetActive(true);
                    SetAlpha(botonEmpezar, 1, 0.75f);
                    SetAlpha(botonOpciones, 1, 0.75f);
                    SetAlpha(botonSalir, 1, 0.75f);
                });
            });
        });
    }
        // Corutina para cambiar el alpha con una transición suave
        IEnumerator SetAlphaOverTime(GameObject obj, float targetAlpha, float duration)
        {
            // Verificamos si el objeto tiene un MeshRenderer (para objetos 3D)
            /*MeshRenderer meshRenderer = obj.GetComponent<MeshRenderer>();
            if (meshRenderer != null)
            {
                Color initialColor = meshRenderer.material.color;
                float elapsedTime = 0f;
                while (elapsedTime < duration)
                {
                    elapsedTime += Time.deltaTime;
                    float alpha = Mathf.Lerp(initialColor.a, targetAlpha, elapsedTime / duration);
                    Color newColor = new Color(initialColor.r, initialColor.g, initialColor.b, alpha);
                    meshRenderer.material.color = newColor;
                    yield return null;
                }
                // Asegurarse de que el alpha final sea el objetivo
                Color finalColor = new Color(initialColor.r, initialColor.g, initialColor.b, targetAlpha);
                meshRenderer.material.color = finalColor;
            }*/

            // Verificamos si el objeto tiene un Image (para UI)
            UnityEngine.UI.Image image = obj.GetComponent<UnityEngine.UI.Image>();
            if (image != null)
            {
                Color initialColor = image.color;
                float elapsedTime = 0f;
                while (elapsedTime < duration)
                {
                    elapsedTime += Time.deltaTime;
                    float alpha = Mathf.Lerp(initialColor.a, targetAlpha, elapsedTime / duration);
                    Color newColor = new Color(initialColor.r, initialColor.g, initialColor.b, alpha);
                    image.color = newColor;
                    yield return null;
                }
                // Asegurarse de que el alpha final sea el objetivo
                Color finalColor = new Color(initialColor.r, initialColor.g, initialColor.b, targetAlpha);
                image.color = finalColor;
            }

            // Verificamos si el objeto tiene un TextMeshPro (para texto)
            TextMeshProUGUI text = obj.GetComponent<TextMeshProUGUI>();
            if (text != null)
            {
                Color initialColor = text.color;
                float elapsedTime = 0f;
                while (elapsedTime < duration)
                {
                    elapsedTime += Time.deltaTime;
                    float alpha = Mathf.Lerp(initialColor.a, targetAlpha, elapsedTime / duration);
                    Color newColor = new Color(initialColor.r, initialColor.g, initialColor.b, alpha);
                    text.color = newColor;
                    yield return null;
                }
                // Asegurarse de que el alpha final sea el objetivo
                Color finalColor = new Color(initialColor.r, initialColor.g, initialColor.b, targetAlpha);
                text.color = finalColor;
            }
        }

    // Método que se puede llamar para cambiar el alpha de un objeto con tiempo
    public void SetAlpha(GameObject obj, float targetAlpha, float duration)
    {
        StartCoroutine(SetAlphaOverTime(obj, targetAlpha, duration));
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

