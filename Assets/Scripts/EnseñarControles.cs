using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnseñarControles : MonoBehaviour
{
    [SerializeField]
    GameObject controles;
    // Start is called before the first frame update
    void Start()
    {
        // Verifica si es un dispositivo Android
#if UNITY_ANDROID
        Debug.Log("Estás usando un dispositivo Android");
        // Aquí va el código específico para Android
        controles.SetActive(true);
        // Verifica si es un dispositivo PC (Windows, Mac, Linux)
#elif UNITY_STANDALONE
            Debug.Log("Estás usando una PC");
            // Aquí va el código específico para PC
         controles.SetActive(false);
        // Si el dispositivo no es ninguno de los anteriores
#else
            Debug.Log("Dispositivo desconocido");
#endif
    }
}
