
using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class MenuEnPartida : MonoBehaviour
{
    //Para cambiar la escena
    public string Inicio;

    [SerializeField]
    GameObject menuOpciones;
    private void Start()
    {
        menuOpciones.SetActive(false);
    }
    private void Update()
    {
        
    }
    public void Pausa()
    {
        menuOpciones.SetActive(true);
    }
    public void Continuar()
    {
        menuOpciones.SetActive(false);
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
}
