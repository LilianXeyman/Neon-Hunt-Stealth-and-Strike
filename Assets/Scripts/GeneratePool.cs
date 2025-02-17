using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratePool : MonoBehaviour
{
    Stack<GameObject> pool = new Stack<GameObject>();

    [SerializeField]
    GameObject bala;

    [SerializeField]
    int tamanoPool;

    private void Start()
    {
        for (int i = 0; i < tamanoPool; i++)
        {
            GameObject balaCreada = Instantiate(bala, Vector3.zero, Quaternion.identity);
            balaCreada.GetComponent<Balas>().balasPool = this;//Balas sabe que tiene un xiaomi pop sacar push meter
            pool.Push(balaCreada);
            balaCreada.SetActive(false);
        }
    }

    public GameObject CogerBala()
    {
        GameObject balaParaDar = null;
        if (pool.Count == 0)
        {
            balaParaDar = Instantiate(bala, Vector3.zero, Quaternion.identity);
            balaParaDar.GetComponent<Balas>().balasPool = this;
            balaParaDar.SetActive(false);
        }
        else
        {
            balaParaDar = pool.Pop();
        }
        return balaParaDar;
    }

    public void GuardarBala(GameObject balaParaGuardar)
    { 
        balaParaGuardar.SetActive(false);
        pool.Push(balaParaGuardar);
    }
}
