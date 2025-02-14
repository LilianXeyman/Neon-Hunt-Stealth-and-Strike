
/*using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MenuEnPartida : MonoBehaviour
{
    private StarterAssetsInputs _input;

    [SerializeField]
    GameObject menuEnPartida;

    bool menuAbierto;
    // Start is called before the first frame update
    void Start()
    {
        menuEnPartida.SetActive(false);
        menuAbierto = false;
        //Para poder acceder al inputSystem
        _input = GetComponent<StarterAssetsInputs>();
    }

    // Update is called once per frame
    void Update()//Inventada maxima
    {
        if (_input.menu != _input.menu)
        {
            menuAbierto ? true:false;
        }
        if (menuAbierto)
        {
            menuEnPartida.SetActive(true);
        }
        else
        { 
            menuEnPartida.SetActive(false);
        }
    }
}*/
