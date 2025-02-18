using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemysLeft : MonoBehaviour
{
    public static EnemysLeft instance;

    int enemigosDerrotados;
    int enemigos;

    [SerializeField]
    TextMeshProUGUI textEnemysLeft;

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
    public void RemoveEnemy()
    {
        enemigosDerrotados += 1;
        ActualizarEtiqueta();
        if (enemigosDerrotados == enemigos)
        {
            Debug.Log("Mision finalizada");
        }
    }
    void ActualizarEtiqueta()
    {
        textEnemysLeft.text = enemigosDerrotados.ToString() + "/" + enemigos.ToString();
    }
    public void AddEnemy()
    {
        //enemys = GameObject.FindGameObjectsWithTag("Enemy").Length;
        enemigos += 1;
        ActualizarEtiqueta();
    }
}
