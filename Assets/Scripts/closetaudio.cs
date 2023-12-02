using UnityEngine;

public class closetaudio : MonoBehaviour
{
    AudioSource audio;
    private Transform player;
    public GameObject invisibleCube;
    private bool hasStartedDialogue = false;
    private OVRPlayerController movement;

    void Start()
    {
        player = FindObjectOfType<OVRPlayerController>().transform;
        audio = GetComponent<AudioSource>();
        movement = FindObjectOfType<OVRPlayerController>();
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, player.position) <= 2.5f && !hasStartedDialogue)
        {
            movement.EnableMovement(false);
            Invoke("desbloquear", 10);
            hasStartedDialogue = true;
            audio.Play();
        }
    }
    void desbloquear()
    {
        movement.EnableMovement(true);
    }
}