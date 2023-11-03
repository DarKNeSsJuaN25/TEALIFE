using UnityEngine;

public class sonidoBostezo : MonoBehaviour
{
    public AudioClip soundClip; // Asigna el archivo de audio desde el Editor de Unity
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (soundClip != null)
        {
            audioSource.clip = soundClip;
            audioSource.Play();
        }
    }
}