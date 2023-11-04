using UnityEngine;

public class ImageInteraction : MonoBehaviour
{
    public DialogueSystem dialogueSystem;
    private Transform player;
    public string npcName;
    public string[] sentences;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if(Vector3.Distance(transform.position, player.position) <= 1.3f)
        {
            dialogueSystem.StartDialogue(npcName, sentences);
        }
    }
}