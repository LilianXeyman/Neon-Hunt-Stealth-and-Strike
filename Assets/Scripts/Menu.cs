using System.Collections;
using System.Collections.Generic;
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
    
    // Start is called before the first frame update
    void Start()
    {
        gameTitle.SetActive(true);
        enterStart.SetActive(true);
        imageCargando.SetActive(false);

        //Implementar ImputSystem
        _playerInput = GetComponent<PlayerInput>();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug /Poner en todas las escenas
        FullScreen();

        //Para la primera parte del menu
        /*if (Input.GetButtonDown("AnyKey"))
        {
            Debug.Log("Empezar");
        }*/
    }
    void FullScreen()
    {
        if (Input.GetKeyDown(KeyCode.K))//Cambiar para la forma genérica
        {
            Screen.fullScreen = !Screen.fullScreen;
        }
    }
}
