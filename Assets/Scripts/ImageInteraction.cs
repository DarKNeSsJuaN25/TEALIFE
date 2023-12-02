using UnityEngine;

public class ImageInteraction : MonoBehaviour
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
        if (Vector3.Distance(transform.position, player.position) <= 1.3f && !hasStartedDialogue)
        {
            movement.EnableMovement(false);
            Invoke("desbloquear", 10);
            hasStartedDialogue = true;
            audio.Play();
            NPC2.hasActivatedImage = true;
            if (invisibleCube != null)
            {
                BoxCollider cubeRender = invisibleCube.GetComponent<BoxCollider>();
                if (cubeRender != null)
                {
                    cubeRender.enabled = false;
                }
            }
        }
    }
    void desbloquear()
    {
        movement.EnableMovement(true);
    }
}