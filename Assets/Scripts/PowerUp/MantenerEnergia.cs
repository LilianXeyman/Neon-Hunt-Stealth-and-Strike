using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MantenerEnergia : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            EnergySystem.instance.energy = 100;
            EnergySystem.instance.PowerUpMantenerEnerg�a();
            EnergySystem.instance.ActualizarEtiqueta();
            Destroy(this.gameObject);
        }
    }
}
