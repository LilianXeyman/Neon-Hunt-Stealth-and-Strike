using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestaurarEnergia : MonoBehaviour
{
    [SerializeField]
    DeteccionEnemigos deteccionEnemigos;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            EnergySystem.instance.energy = 100;
            EnergySystem.instance.ActualizarEtiqueta();
            Destroy(this.gameObject);
        }
    }
}
