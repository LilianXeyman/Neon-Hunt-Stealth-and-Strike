using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnergySystem : MonoBehaviour
{
    public static EnergySystem instance;

    [SerializeField]
    TextMeshProUGUI porcentageEnergía;

    [SerializeField]
    public int energy;

    //Para contar el tiempo para recuperar la energia
    [SerializeField]
    public float tiempoRecargarEnergia;
    float segundos;

    //PowerUp MantenerEnergia
    [SerializeField]
    float tiempoMaxEnergy;
    [SerializeField]
    float valorTiempoMaxEnergy;

    public bool recargandoEnergia;
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
    // Start is called before the first frame update
    void Start()
    {
        energy = 100;
        ActualizarEtiqueta();
        tiempoRecargarEnergia = 0;
    }

    // Update is called once per frame
    void Update()
    {
        tiempoRecargarEnergia += Time.deltaTime;
        if (tiempoRecargarEnergia >= 33)
        {
            energy = 100;
            /*for (int i = 0; i < 33; i++)
            {
                energy += 3;????????
            }*/
            recargandoEnergia = false;
        }
        ActualizarEtiqueta();

        tiempoMaxEnergy -= Time.deltaTime;
        if (tiempoMaxEnergy >= 0)
        {
            EnergySystem.instance.energy = 100;
        }
    }
    public void RestarEnergy()
    {
        energy -= 33;
        ActualizarEtiqueta();
    }
    public void EnergyRecover()
    {
        //Cada segundo recupera un 3% cada 33% puedes disparar se necesitan 33 segundos para recargar hasta un 99%
        tiempoRecargarEnergia = 0;
    }
    public void ActualizarEtiqueta()
    { 
        porcentageEnergía.text=energy.ToString("00") + " %";
    }
    public void PowerUpMantenerEnergía()
    {
        tiempoMaxEnergy = valorTiempoMaxEnergy;
    }
}
