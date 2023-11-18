using UnityEngine;

public class ChickenInteraction : MonoBehaviour
{
    public DialogueSystem dialogueSystem;
    private Transform player;
    public string npcName;
    public string[] sentences;
    public GameObject pollo;
    private bool hasStartedDialogue = false;
    AudioSource audio;
    
    void Start()
    {
        audio = GetComponent<AudioSource>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, player.position) <= 1.3f && !hasStartedDialogue)
        {
            audio.Play();
            NPC3.comida = true;
            hasStartedDialogue = true;
            dialogueSystem.StartDialogue(npcName, sentences);
            DisableChicken();
        }
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