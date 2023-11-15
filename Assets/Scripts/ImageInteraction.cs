using UnityEngine;

public class ImageInteraction : MonoBehaviour
{
    public DialogueSystem dialogueSystem;
    private Transform player;
    public string npcName;
    public string[] sentences;
    public GameObject invisibleCube;
    private bool hasStartedDialogue = false;
    
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, player.position) <= 1.3f && !hasStartedDialogue)
        {
            hasStartedDialogue = true;
            NPC2.hasActivatedImage = true;
            dialogueSystem.StartDialogue(npcName, sentences);
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
}