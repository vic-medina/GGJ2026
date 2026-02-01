using UnityEngine;

public class CameraToPlayer : MonoBehaviour
{
    [Header("Objetivo a seguir")]
    public Transform player; // Asigna tu jugador en el Inspector

    [Header("Configuración de seguimiento")]
    public float smoothSpeed = 0.125f; // Qué tan suave se mueve la cámara
    public Vector3 offset = new Vector3(0, 0, -10); // Mantén la cámara detrás del plano 2D

    void LateUpdate()
    {
        if (player == null) return;

        // Posición deseada (solo X y Y del jugador, Z fijo)
        Vector3 desiredPosition = new Vector3(player.position.x, player.position.y, offset.z);

        // Movimiento suave hacia la posición deseada
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        transform.position = smoothedPosition;
    }

}
