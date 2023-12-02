using UnityEngine;

public class MovimientoCamara : MonoBehaviour
{
    private OVRPlayerController playerController; // Referencia al OVRPlayerController
    private bool isTriggered = false;

    void Start()
    {
        playerController = FindObjectOfType<OVRPlayerController>();
        // Asegúrate de que el componente OVRPlayerController está en el objeto correcto.
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == playerController.gameObject)
        {
            isTriggered = true;
            playerController.EnableMovement(false);
            // Suponiendo que NPC5 es una clase que maneja el estado de los NPC
            NPC5.isNPCsat = true;
            playerController.transform.Rotate(0, 180, 0); // Rota al jugador
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == playerController.gameObject)
        {
            isTriggered = false;
            // INICIAR CONVERSACION AQUI Y PONER UN BOOL PARA QUE SE PUEDA MOVER CUANDO TERMINE LA CONVERSACION
        }
    }

    void Update()
    {
        // En VR, debes usar los botones del controlador en lugar de KeyCode.T
        // Podrías usar algo así como OVRInput.GetDown(OVRInput.Button.One) para detectar un botón específico del controlador de Oculus.
        if (isTriggered && OVRInput.GetDown(OVRInput.Button.Two))
        {
            NPC5.isNPCsat = false;
            playerController.EnableMovement(true);
            // Mueve al jugador hacia atrás o realiza la acción deseada
            playerController.transform.position += playerController.transform.forward; // Este es un ejemplo simple, probablemente querrás suavizar esto.
            isTriggered = false;
        }
    }
}
