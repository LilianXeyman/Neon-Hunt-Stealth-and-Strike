using UnityEngine;

public class TireMarkController : MonoBehaviour
{
    public CapsuleCollider tireCollider; // El CapsuleCollider de la rueda
    public ParticleSystem tireParticles; // El sistema de part�culas de la marca de neum�tico
    public LayerMask groundLayer; // Capa del suelo para detectar colisiones

    void Update()
    {
        // Obtener la posici�n del punto m�s bajo del CapsuleCollider
        Vector3 rayStart = tireCollider.transform.position + Vector3.down * (tireCollider.height / 2);

        // Lanza un raycast hacia abajo para detectar el suelo
        bool isGrounded = Physics.Raycast(rayStart, Vector3.down, out RaycastHit hit, 0.1f, groundLayer);

        // Activar o desactivar las part�culas seg�n el contacto con el suelo
        if (isGrounded)
        {
            if (!tireParticles.isPlaying) tireParticles.Play();
        }
        else
        {
            if (tireParticles.isPlaying) tireParticles.Stop();
        }
    }

    // Visualizar el Raycast en la escena para depuraci�n
    void OnDrawGizmos()
    {
        if (tireCollider != null)
        {
            Vector3 rayStart = tireCollider.transform.position + Vector3.down * (tireCollider.height / 2);
            Gizmos.color = Color.red;
            Gizmos.DrawLine(rayStart, rayStart + Vector3.down * 0.1f);
        }
    }
}
