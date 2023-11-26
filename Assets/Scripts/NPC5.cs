using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC5 : MonoBehaviour
{
    public DialogueSystem dialogueSystem;
    public string npcName;
    public string[] sentences;
    private Animator animator;
    private Transform player;
    private bool hasStartedDialogue = false;
    public static bool isNPCsat = false;
    
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        // Comprueba si el jugador está cerca y el diálogo aún no ha comenzado
        if ( !hasStartedDialogue && isNPCsat)
        {
            hasStartedDialogue = true;
            dialogueSystem.StartDialogue(npcName, sentences); // Inicia el diálogo
        }
    }
}
