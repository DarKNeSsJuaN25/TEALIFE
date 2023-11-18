using UnityEngine;

public class NPC4 : MonoBehaviour
{
    private Animator animator;
    private bool isWalking = false;
    private bool hasStartedWalking = false;
    private Transform player;
    private float walkSpeed = 1.2f; // Velocidad de caminata de Mar�a
    private float firstWalkDuration = 4.8f; // Duraci�n del primer paseo
    private bool hasTurnedOnce = false;
    private bool hasTurned180 = false;
    public static bool hasEndedScene3 = false;
    void Start()
    {
        animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }



    void Update()
    {
        // Comprueba si el jugador est� cerca y el di�logo a�n no ha comenzado
        if (Vector3.Distance(transform.position, player.position) <= 1.6f && hasEndedScene3)
        {
            StartWalking();
        }

        // Actualiza el movimiento si Mar�a est� caminando
        if (isWalking)
        {
            animator.SetBool("isWalking", true); // Activa la animaci�n de caminata

            // Aqu� es donde Mar�a se mover� si la bandera isWalking es verdadera
            transform.Translate(Vector3.forward * walkSpeed * Time.deltaTime);
        }

    }

    // Este m�todo se llama cuando el evento OnDialogueComplete es disparado
    void StartWalking()
    {
        if (!hasStartedWalking)
        {
            transform.Rotate(0, 180, 0);
            hasStartedWalking = true;
            isWalking = true; // Permite que el NPC se mueva en Update
            // Puedes agregar aqu� cualquier inicializaci�n adicional para el movimiento o comportamiento de Mar�a
            Invoke("StopWalking", firstWalkDuration / 2 + 2);
            Invoke("Turn180", firstWalkDuration / 2 + 2);
        }
    }

    void TurnRight()
    {
        if (!hasTurnedOnce)
        {
            transform.Rotate(0, 90, 0);
            hasTurnedOnce = true;
            Debug.Log("Girando a la derecha...");
        }
    }

    void Turn180()
    {
        if (!hasTurned180)
        {
            transform.Rotate(0, 180, 0);
            hasTurned180 = true;
            Debug.Log("Girando 180 grados...");
        }
    }

    void StopWalking()
    {
        // Detiene el movimiento
        isWalking = false;
        Debug.Log("Deteniendo el caminar...");

        // Desactiva la animaci�n de caminata en el Animator
        animator.SetBool("isWalking", false);
    }

    void ContinueWalking()
    {
        isWalking = true;
        Debug.Log("Continuando caminata...");
    }
    // Puedes agregar aqu� m�todos adicionales para girar o detener a Mar�a seg�n sea necesario
}
