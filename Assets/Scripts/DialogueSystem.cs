using System.Collections;
using UnityEngine;
using TMPro;
using System.Collections.Generic;
using System; // Asegúrate de incluir este espacio de nombres para usar eventos

public class DialogueSystem : MonoBehaviour
{
    public TextMeshProUGUI dialogueText;
    public TextMeshProUGUI nameText;
    public GameObject dialoguePanel;
    public event Action OnDialogueComplete; // Evento para notificar cuando el diálogo esté completo

    private Queue<string> sentences;

    public bool IsDialogueActive { get; private set; }

    void Start()
    {
        sentences = new Queue<string>();
        dialoguePanel.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            DisplayNextSentence();
        }
    }

    public void StartDialogue(string name, string[] sentences)
    {
        dialoguePanel.SetActive(true);
        IsDialogueActive = true;
        nameText.text = name;
        this.sentences.Clear();

        foreach (string sentence in sentences)
        {
            this.sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        float delay = 2.0f / sentence.Length;
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(delay);
        }
    }

    void EndDialogue()
    {
        dialoguePanel.SetActive(false);
        IsDialogueActive = false;
        OnDialogueComplete?.Invoke(); // Dispara el evento cuando el diálogo termina
    }
}
