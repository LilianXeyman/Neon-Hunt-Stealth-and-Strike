using System.Collections;
using System.Collections.Generic;
using StarterAssets;
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
    [SerializeField]
    LeanTweenType animCurv;

    //bool para el movimiento del personaje
    public bool menuPausa = false;

    //Para la musica
    [SerializeField]
    AudioSource audioSource;

    //Efectos especiales
    [SerializeField]
    GameObject efectoDisparoPrefab;
    [SerializeField]
    GameObject efectoHumoPrefab;

    StarterAssetsInputs input;

    // Start is called before the first frame update
    void Start()
    {
        canShoot = true;
        LeanTween.scale(mirilla, Vector3.zero, 0);
        audioSource = GetComponent<AudioSource>();
        input = GetComponent<StarterAssetsInputs>();
    }

    // Update is called once per frame
    void Update()
    {
        tiempoRecarga = tiempoRecarga-Time.deltaTime;
        //Poner que si el tiempo es >=0 que se vea una imagen como que esta recargando y al pasar el tiempo se quita
        ExplosionDamage();

        if (input.shoot && shootAb && menuPausa == false) //o el fire1 Input.GetButtonDown("Fire1)
        {
            audioSource.Play();
            LeanTween.scale(mirilla, Vector3.zero, 0f).setEase(animCurv);
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
               /* if (hitCollider != robotADisparar && !canShoot)
                {
                    robotADisparar = null;
                    canShoot = true;
                }
                Debug.Log(robotADisparar.name);*/
                shootAb = true;
                LeanTween.scale(mirilla, Vector3.one, 0.25f).setEase(animCurv);
            }
        }
        //Hacer que si se sale del area el canShoot vuelve a ser true <-Para que busque un nuevo objetivo // Poner en los enemigos un distintivo para que se sepa que es a ese al que se le va a apuntar //Agrandar el mapa y añadir más enemigos //sonidos "efectos especiales" (disparos)
    }
    void Disparar()
    {
        GameObject balaActual = generatePool.CogerBala();
        balaActual.transform.rotation = gameObject.transform.rotation;
        balaActual.transform.position = gameObject.transform.position + transform.up * 1.05f + transform.forward * 1.5f+ transform.right * 0.75f;//transform. right / left //Para el arma derecha
        balaActual.SetActive(true);
        // Instanciar los efectos de disparo y humo en la posición de la bala
        Instantiate(efectoDisparoPrefab, balaActual.transform.position, Quaternion.identity); // Efecto de disparo
        Instantiate(efectoHumoPrefab, balaActual.transform.position, Quaternion.identity);    // Efecto de humo

    }
    void Disparar2()
    {
        GameObject balaActual = generatePool.CogerBala();
        balaActual.transform.rotation = gameObject.transform.rotation;
        balaActual.transform.position = gameObject.transform.position + transform.up * 1.60f + transform.forward * 0.75f + transform.right * -0.65f;//transform. right / left //Para el arma derecha
        balaActual.SetActive(true);
        // Instanciar los efectos de disparo y humo en la posición de la bala
        Instantiate(efectoDisparoPrefab, balaActual.transform.position, Quaternion.identity); // Efecto de disparo
        Instantiate(efectoHumoPrefab, balaActual.transform.position, Quaternion.identity);    // Efecto de humo

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(gameObject.transform.position, radioAlcance);
    }
}
