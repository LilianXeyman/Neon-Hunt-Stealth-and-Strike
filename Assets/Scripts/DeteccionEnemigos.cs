using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeteccionEnemigos : MonoBehaviour
{
    [SerializeField]
    GeneratePool generatePool;

    [SerializeField]
    float radioAlcance;
    [SerializeField]
    LayerMask layerEnemigos;

    //Para disparar
    [SerializeField]
    public bool canShoot;
    [SerializeField]
    bool shootAb = false;

    //Para la recarga
    [SerializeField]
    float tiempoRecarga;
    [SerializeField]
    float tiempo;

    //Para la animacion
    [SerializeField] Animator _animator;

    //Para que la bala persiga
    public GameObject robotADisparar;

    //Cuenta para las balas
    [SerializeField]
    public int balasTotales=3;

    //Imagen Apuntar
    [SerializeField]
    GameObject mirilla;

    //bool para el movimiento del personaje
    public bool menuPausa = false;

    // Start is called before the first frame update
    void Start()
    {
        canShoot = true;
        LeanTween.scale(mirilla, Vector3.zero, 0);
    }

    // Update is called once per frame
    void Update()
    {
        tiempoRecarga = tiempoRecarga-Time.deltaTime;
        //Poner que si el tiempo es >=0 que se vea una imagen como que esta recargando y al pasar el tiempo se quita
        ExplosionDamage();

        if (Input.GetButtonDown("Fire1") && shootAb && menuPausa == false)
        {
            LeanTween.scale(mirilla, Vector3.zero, 0.25f);
            shootAb = false;
            tiempoRecarga = tiempo;
            Disparar();
            Disparar2();
            //Restar aqui el numero de balas
            balasTotales -= 1;
            ControlMunicion.instance.RevisarCantidadBalas();
            _animator.SetTrigger("Disparo");
        }

        //Hacer una cuenta para restar balas/que se añada la imagen de sombreado/Coger como coleccionable
    }
    void ExplosionDamage()
    {
        Collider[] hitColliders = Physics.OverlapSphere(gameObject.transform.position, radioAlcance, layerEnemigos);
        foreach (var hitCollider in hitColliders)
        {
            if (canShoot == true && tiempoRecarga <= 0)
            {
                robotADisparar = hitCollider.gameObject;
                canShoot = false;
                Debug.Log(hitCollider.gameObject.name);
                shootAb = true;
                LeanTween.scale(mirilla, Vector3.one, 0.25f);
            }
        }
    }
    void Disparar()
    {
        GameObject balaActual = generatePool.CogerBala();
        balaActual.transform.rotation = gameObject.transform.rotation;
        balaActual.transform.position = gameObject.transform.position + transform.up * 1.05f + transform.forward * 1.5f+ transform.right * 0.75f;//transform. right / left //Para el arma derecha
        balaActual.SetActive(true);
    }
    void Disparar2()
    {
        GameObject balaActual = generatePool.CogerBala();
        balaActual.transform.rotation = gameObject.transform.rotation;
        balaActual.transform.position = gameObject.transform.position + transform.up * 1.60f + transform.forward * 0.75f + transform.right * -0.65f;//transform. right / left //Para el arma derecha
        balaActual.SetActive(true);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(gameObject.transform.position, radioAlcance);
    }
}
