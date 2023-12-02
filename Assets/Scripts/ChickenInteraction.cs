using UnityEngine;

public class ChickenInteraction : MonoBehaviour
{
    private Transform player;
    public GameObject pollo;
    private bool hasStartedDialogue = false;
    AudioSource audio;
    private OVRPlayerController movement;
    void Start()
    {
        audio = GetComponent<AudioSource>();
        player = FindObjectOfType<OVRPlayerController>().transform;
        movement = FindObjectOfType<OVRPlayerController>();
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, player.position) <= 1.3f && !hasStartedDialogue)
        {
            movement.EnableMovement(false);
            audio.Play();
            NPC3.comida = true;
            NPC5.hasEaten = true;
            hasStartedDialogue = true;
            DisableChicken();
            Invoke("enableChicken", 3);

        }
    }
    private void enableChicken()
    {
        movement.EnableMovement(true);
    }
    private void DisableChicken()
    {
        Debug.Log("Aqui");
        if (pollo != null)
        {
            // Desactivar todos los MeshRenderers en el prefab del pollo
            MeshRenderer[] renderers = pollo.GetComponentsInChildren<MeshRenderer>();
            foreach (MeshRenderer renderer in renderers)
            {
                renderer.enabled = false;
            }

            // Opcional: Desactivar también el BoxCollider si es necesario
            BoxCollider cubeRender = pollo.GetComponent<BoxCollider>();
            if (cubeRender != null)
            {
                cubeRender.enabled = false;
            }
        }
    }
}