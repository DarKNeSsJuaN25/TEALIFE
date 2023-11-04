using UnityEngine;

public class NPC1 : MonoBehaviour
{
    public DialogueSystem dialogueSystem;
    public string npcName;
    public string[] sentences;
    private Animator animator;
    private bool isWalking = false;
    private bool hasStartedDialogue = false;
    private bool hasStartedWalking = false;
    private Transform player;
    private float walkSpeed = 1.2f; // Velocidad de caminata de María
    private float firstWalkDuration = 4.8f; // Duración del primer paseo
    private bool hasTurnedOnce = false;
    private bool hasTurned180 = false;

    void Start()
    {
        animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        dialogueSystem.OnDialogueComplete += StartWalking; // Suscribe al evento del sistema de diálogo
    }

    void OnDestroy()
    {
        dialogueSystem.OnDialogueComplete -= StartWalking; // Desuscribe para evitar referencias nulas
    }

    void Update()
    {
        // Comprueba si el jugador está cerca y el diálogo aún no ha comenzado
        if (Vector3.Distance(transform.position, player.position) <= 1.6f && !hasStartedDialogue)
        {
            hasStartedDialogue = true;
            dialogueSystem.StartDialogue(npcName, sentences); // Inicia el diálogo
        }

        // Actualiza el movimiento si María está caminando
        if (isWalking)
        {
            animator.SetBool("isWalking", true); // Activa la animación de caminata

            // Aquí es donde María se moverá si la bandera isWalking es verdadera
            transform.Translate(Vector3.forward * walkSpeed * Time.deltaTime);
        }
    }

    // Este método se llama cuando el evento OnDialogueComplete es disparado
    void StartWalking()
    {
        if (!hasStartedWalking)
        {
            transform.Rotate(0, 90, 0);
            hasStartedWalking = true;
            isWalking = true; // Permite que el NPC se mueva en Update
            // Puedes agregar aquí cualquier inicialización adicional para el movimiento o comportamiento de María
            Invoke("TurnRight", firstWalkDuration / 2);
            Invoke("StopWalking", firstWalkDuration / 2 + 1);
            Invoke("TurnRight", firstWalkDuration / 2 + 1);
            Invoke("Turn180", firstWalkDuration / 2 + 1);
            Invoke("StopWalking", firstWalkDuration / 2 + 1);
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

        // Desactiva la animación de caminata en el Animator
        animator.SetBool("isWalking", false);
    }

    void ContinueWalking()
    {
        isWalking = true;
        Debug.Log("Continuando caminata...");
    }
    // Puedes agregar aquí métodos adicionales para girar o detener a María según sea necesario
}
