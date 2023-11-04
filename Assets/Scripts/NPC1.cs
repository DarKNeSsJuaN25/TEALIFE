using UnityEngine;

public class NPC1 : MonoBehaviour
{
    private Animator animator;
    private bool isWalking = false;
    private bool hasStarted = false;
    private bool hasTurnedOnce = false;
    private bool hasTurned180 = false;
    private Transform player;
    private float firstWalkDuration = 4.8f; // Duración del primer paseo
    public GameObject cubeCollider;
    void Start()
    {
        animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        cubeCollider.GetComponent<MeshRenderer>().enabled = false; // Deshabilita el Mesh Renderer al inicio

    }

    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.position);

        if (distance <= 1.6f && !hasStarted)
        {
            // Comienza la actividad del NPC
            StartActivity();
        }

        if (isWalking)
        {
            // Mueve al NPC en el eje z (puede que necesites ajustar esto según la orientación de tu NPC)
            transform.Translate(Vector3.forward * 1.2f * Time.deltaTime);

            // Activa la animación de caminata en el Animator
            animator.SetBool("isWalking", true);
        }
    }

    void StartActivity()
    {
        if (!hasStarted)
        {
            // Gira 90 grados a la derecha
            transform.Rotate(0, 90, 0);
            Debug.Log("Comenzando a caminar...");

            // Indica que el NPC está caminando
            isWalking = true;

            // Invoca la parada del movimiento después de firstWalkDuration segundos
            Invoke("TurnRight", firstWalkDuration / 2);
            Invoke("StopWalking", firstWalkDuration / 2 + 1);
            Invoke("TurnRight", firstWalkDuration /2 + 1);
            Invoke("Turn180", firstWalkDuration/2  + 1);
            Invoke("StopWalking", firstWalkDuration/2 + 1);


            // Actualiza la bandera de hasStarted
            hasStarted = true;
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
        cubeCollider.GetComponent<MeshRenderer>().enabled = true;
    }

    void ContinueWalking()
    {
        isWalking = true;
        Debug.Log("Continuando caminata...");
    }
}
