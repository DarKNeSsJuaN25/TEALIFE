using SojaExiles;
using UnityEngine;

public class MovimientoCamara : MonoBehaviour
{
    private Transform player;
    private PlayerMovement playerMovement;
    private Vector3 initialPosition; // Para almacenar la posición inicial
    private bool isTriggered = false; // Para saber si el jugador está en el trigger

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        playerMovement = player.GetComponent<PlayerMovement>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform == player)
        {
            initialPosition = player.position; // Guarda la posición inicial
            isTriggered = true;
            if (playerMovement != null)
            {
                playerMovement.SetMovement(false);
            }
            player.Rotate(0, 180, 0);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform == player)
        {
            isTriggered = false;
            if (playerMovement != null)
            {
                playerMovement.SetMovement(true);
            }
            // INICIAR CONVERSACION AQUI Y PONER UN BOOL PARA QUE SE PUEDA MOVER CUANDO TERMINE LA CONVERSACION
        }
    }

    void Update()
    {
        // Verifica si el jugador presiona la tecla "T" y está en el trigger
        if (isTriggered && Input.GetKeyDown(KeyCode.T))
        {
            Vector3 moveBackPosition = initialPosition  + player.forward; // Calcula la nueva posición
            player.position = moveBackPosition; // Mueve al jugador de vuelta a la posición calculada
            isTriggered = false; // Opcional: desactivar el trigger después de regresar
        }
    }
}
