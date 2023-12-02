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
    private Transform player; // Referencia al transform del jugador VR
    private OVRPlayerController movement;
    private float walkSpeed = 1.2f; // Velocidad de caminata
    private float firstWalkDuration = 4.8f; // Duración del primer paseo
    private bool hasTurnedOnce = false;
    private bool hasTurned180 = false;
    AudioSource[] audioSources;
    AudioSource audio;
    void Start()
    {
        animator = GetComponent<Animator>();
        // Obtiene la referencia al jugador VR
        player = FindObjectOfType<OVRPlayerController>().transform;
        movement = FindObjectOfType<OVRPlayerController>();
        audioSources = GetComponents<AudioSource>();
        //Cuando el audio termina, llamar a la funcion StartWalking()
    }

    void Update()
    {
        // Comprueba si el jugador está cerca y el diálogo aún no ha comenzado
        if (Vector3.Distance(transform.position, player.position) <= 1.6f && !hasStartedDialogue)
        {
            Invoke("StartWalking", 8);
            hasStartedDialogue = true;
            foreach (var source in audioSources)
            {
                if (source.clip != null && source.clip.name == "mucama")
                {
                    audio = source;
                    audio.Play();

                    // Suponiendo que tienes una referencia al OVRPlayerController llamada 'playerController'
                    movement.EnableMovement(false); // Desactiva el movimiento y la rotación

                    break; // Rompe el ciclo una vez que encuentres el AudioSource correcto
                }
            }
        }

        // Actualiza el movimiento si María está caminando
        if (isWalking)
        {
            movement.EnableMovement(true);
            animator.SetBool("isWalking", true); // Activa la animación de caminata
            transform.Translate(Vector3.forward * walkSpeed * Time.deltaTime);
        }
    }

    // Este método se llama cuando el evento OnDialogueComplete es disparado
    void StartWalking()
    {
        if (!hasStartedWalking)
        {
            foreach (var source in audioSources)
            {
                if (source.clip != null && source.clip.name == "externo2")
                {
                    audio = source;
                    audio.Play();

                    // Suponiendo que tienes una referencia al OVRPlayerController llamada 'playerController'
                    movement.EnableMovement(false); // Desactiva el movimiento y la rotación

                    break; // Rompe el ciclo una vez que encuentres el AudioSource correcto
                }
            }
            transform.Rotate(0, 90, 0);
            hasStartedWalking = true;
            isWalking = true; // Permite que el NPC se mueva en Update
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
        isWalking = false;
        Debug.Log("Deteniendo el caminar...");
        animator.SetBool("isWalking", false);
    }

    void ContinueWalking()
    {
        isWalking = true;
        Debug.Log("Continuando caminata...");
    }
}
