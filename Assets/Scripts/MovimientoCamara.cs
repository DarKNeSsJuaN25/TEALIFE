using SojaExiles;
using UnityEngine;

public class MovimientoCamara : MonoBehaviour
{
    private Transform player;
    private PlayerMovement playerMovement;
    private Vector3 initialPosition; // Para almacenar la posici�n inicial
    private bool isTriggered = false; // Para saber si el jugador est� en el trigger
    AudioSource audio;
    void Start()
    {
        audio = GetComponent<AudioSource>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        playerMovement = player.GetComponent<PlayerMovement>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform == player)
        {
            initialPosition = player.position; // Guarda la posici�n inicial
            isTriggered = true;
            if (playerMovement != null)
            {
                playerMovement.SetMovement(false);
                audio.Play();
                NPC5.isNPCsat = true;
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
        // Verifica si el jugador presiona la tecla "T" y est� en el trigger
        if (isTriggered && Input.GetKeyDown(KeyCode.T))
        {
            Vector3 moveBackPosition = initialPosition  + player.forward; // Calcula la nueva posici�n
            player.position = moveBackPosition; // Mueve al jugador de vuelta a la posici�n calculada
            isTriggered = false; // Opcional: desactivar el trigger despu�s de regresar
        }
    }
}
