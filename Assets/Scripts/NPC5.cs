    using Oculus.Interaction;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class NPC5 : MonoBehaviour
    {
        private Animator animator;
        private Transform player;
        public static bool isNPCsat = false;
        private bool activated = false;
        public static bool hasEaten = false;
        public static bool hastalked = false;
        AudioSource audio;
        AudioSource[] audioSources;
        private bool hasTurnedOnce = false;
        private bool hasTurned180 = false;        // Start is called before the first frame update
        private bool isWalking = false;
        private bool hasStartedWalking = false;
        private OVRPlayerController movement;
        private float walkSpeed = 1.2f; // Velocidad de caminata de María
        private float firstWalkDuration = 4.8f; // Duración del primer paseo
        public GameObject fadeOutObject;

    void Start()
        {
            audioSources = GetComponents<AudioSource>();
            audio = GetComponent<AudioSource>();
            animator = GetComponent<Animator>();
            player = FindObjectOfType<OVRPlayerController>().transform;
            movement = FindObjectOfType<OVRPlayerController>();
            // Asegúrate de que el objeto de oscurecimiento esté desactivado inicialmente
            fadeOutObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
        {
            // Comprueba si el jugador está cerca y el diálogo aún no ha comenzado
            if (isNPCsat && !activated && hasEaten && hastalked)
            {   
                activated = true;
                foreach (var source in audioSources)
                {
                    if (source.clip != null && source.clip.name == "telefono")
                    {
                        audio = source;
                        audio.Play();

                        break; // Rompe el ciclo una vez que encuentres el AudioSource correcto
                    }
                }

             Invoke("llamada1",2);
             Invoke("llamada2", 7);
            Invoke("StartWalking", 10);
             Invoke("llamada3", 18);
             
            }
        if (isWalking)
        {
            animator.SetBool("isWalking", true); // Activa la animación de caminata

            // Aquí es donde María se moverá si la bandera isWalking es verdadera
            transform.Translate(Vector3.forward * walkSpeed * Time.deltaTime);
        }
    }
        private void llamada1()
        {
            foreach (var source in audioSources)
            {
                if (source.clip != null && source.clip.name == "mucama4")
                {
                    audio = source;
                    audio.Play();

                    break; // Rompe el ciclo una vez que encuentres el AudioSource correcto
                }
            }
        }
        private void llamada2()
        {
            foreach (var source in audioSources)
            {
                if (source.clip != null && source.clip.name == "mucama5")
                {
                    audio = source;
                    audio.Play();

                    break; // Rompe el ciclo una vez que encuentres el AudioSource correcto
                }
            }
        }
        private void llamada3()
        {
            foreach (var source in audioSources)
            {
                if (source.clip != null && source.clip.name == "mucama6")
                {
                    audio = source;
                    audio.Play();

                    break; // Rompe el ciclo una vez que encuentres el AudioSource correcto
                }
            }
        Invoke("FinalizarEscena", 15);
        }

    private void FinalizarEscena()
    {
        StartCoroutine(FadeOut());
    }

    private IEnumerator FadeOut()
    {
        fadeOutObject.SetActive(true);
        Renderer rend = fadeOutObject.GetComponent<Renderer>();
        Material fadeMaterial = rend.material;
        float duration = 2f;
        float currentTime = 0f;

        while (currentTime < duration)
        {
            float alpha = Mathf.Lerp(0, 1, currentTime / duration);
            fadeMaterial.color = new Color(0, 0, 0, alpha);
            currentTime += Time.deltaTime;
            yield return null;
        }

        // Opcional: Cerrar la aplicación o cambiar de escena
        // Application.Quit();
        // SceneManager.LoadScene("NombreDeTuSiguienteEscena");
    }




    void StartWalking()
    {

            movement.EnableMovement(true);
            hasStartedWalking = true;
            isWalking = true; // Permite que el NPC se mueva en Update
            // Puedes agregar aquí cualquier inicialización adicional para el movimiento o comportamiento de María
        Invoke("TurnLeft", firstWalkDuration / 2 + 3);
        Invoke("StopWalking",firstWalkDuration/2 + 5);
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
    void TurnLeft()
    {
        if (!hasTurnedOnce)
        {
            transform.Rotate(0, -90, 0);
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
}
