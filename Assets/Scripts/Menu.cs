using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class Menu : MonoBehaviour
{
    [SerializeField]
    GameObject gameTitle;
    [SerializeField]
    GameObject enterStart;
    [SerializeField]
    GameObject imageCargando;

    //Imput System
    PlayerInput _playerInput;

    //Bool Menu
    bool menuActivo;

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
    }
        // Update is called once per frame
        void Update()
        {
            //Debug /Poner en todas las escenas
            FullScreen();

            //Para el menu

            //Para la primera parte del menu
            if (Input.GetButtonDown("Submit") || Input.anyKeyDown)
            {
                LeanTween.cancel(enterStart);
                enterStart.SetActive(false);
            //LeanTween.
                Debug.Log("Empezar");
            }
        }
        void FullScreen()
        {
            if (Input.GetKeyDown(KeyCode.K))//Cambiar para la forma genérica
            {
                Screen.fullScreen = !Screen.fullScreen;
            }
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
