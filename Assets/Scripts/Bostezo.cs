using Oculus.Interaction;
using UnityEngine;

public class sonidoBostezo : MonoBehaviour
{
    public AudioClip soundClip; // Asigna el archivo de audio desde el Editor de Unity
    private AudioSource audio;
    private AudioSource[] audioSources;
    void Start()
    {
        audioSources = GetComponents<AudioSource>();

        foreach (var source in audioSources)
        {
            if (source.clip != null && source.clip.name == "bostezo")
            {
                audio = source;
                audio.Play();
                Invoke("playExterno", 2);
                // Suponiendo que tienes una referencia al OVRPlayerController llamada 'playerController'
                break; // Rompe el ciclo una vez que encuentres el AudioSource correcto
            }
        }
    }
    private void playExterno()
    {
        foreach (var source in audioSources)
        {
            if (source.clip != null && source.clip.name == "externo1")
            {
                audio = source;
                audio.Play();

                // Suponiendo que tienes una referencia al OVRPlayerController llamada 'playerController'
                break; // Rompe el ciclo una vez que encuentres el AudioSource correcto
            }
        }
    }
}