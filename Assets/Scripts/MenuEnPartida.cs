
using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class MenuEnPartida : MonoBehaviour
{
    [SerializeField]
    DeteccionEnemigos deteccionEnemigos;

    //Para cambiar la escena
    public string Inicio;
    public string SampleScene;

    [SerializeField]
    GameObject menuPausa;
    [SerializeField]
    GameObject menuOpciones;

    bool cerrarPausa;
    private void Start()
    {
        menuPausa.SetActive(false);
        menuOpciones.SetActive(false);
        cerrarPausa = false;
    }
    private void Update()
    {
        //Poner que si se le da al escape o al boton option que se abra el menu de pausa
        if (Input.GetButtonDown("Cancel"))
        {
            if (!cerrarPausa)
            {
                menuPausa.SetActive(true);
                deteccionEnemigos.menuPausa = true;
                cerrarPausa = true;
            }
            else
            {
                menuPausa.SetActive(false);
                deteccionEnemigos.menuPausa = false;
                cerrarPausa = false;
            }
        }
    }
    public void Pausa()
    {
        menuPausa.SetActive(true);
        deteccionEnemigos.menuPausa = true;
    }
    public void Continuar()
    {
        menuPausa.SetActive(false);
        deteccionEnemigos.menuPausa = false;
    }
    public void MenuPrincipal()
    {
        SceneManager.LoadScene(Inicio);
    }
    public void BotonSalir()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; // Detiene el juego en el editor
#else
        Application.Quit(); // Cierra la aplicación en la build
#endif
    }
    public void Opciones()
    {
        menuPausa.SetActive(false);
        menuOpciones.SetActive(true);
    }
    public void FullScreen()
    {
        Screen.fullScreen = !Screen.fullScreen;
    }
    public void Volver()
    {
        menuPausa.SetActive(true);
        menuOpciones.SetActive(false);
    }
    public void Reintentar()
    {
        SceneManager.LoadScene(SampleScene);
    }
}
