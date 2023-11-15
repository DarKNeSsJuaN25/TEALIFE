using UnityEngine;

public class NPC3 : MonoBehaviour
{
    public DialogueSystem dialogueSystem;
    public string npcName;
    private Transform player;

    public string[] sentences;
    private bool hasStartedDialogue = false;
    public static bool comida = false;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

    }



    void Update()
    {
        // Comprueba si el jugador está cerca y el diálogo aún no ha comenzado
        if (Vector3.Distance(transform.position, player.position) <= 1.6f  && !hasStartedDialogue && comida)
        {
            hasStartedDialogue = true;
            dialogueSystem.StartDialogue(npcName, sentences); // Inicia el diálogo
        }

    }

    // Este método se llama cuando el evento OnDialogueComplete es disparado

}