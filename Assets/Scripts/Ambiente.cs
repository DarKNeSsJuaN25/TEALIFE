using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ambiente : MonoBehaviour
{
    public AudioSource ambiente;
    public float saturationAmount = 0.8f; // Ajusta este valor para controlar la cantidad de saturación
    public float reverbAmount = 0.5f; // Ajusta este valor para controlar la cantidad de eco

    void Update()
    {
        ambiente.enabled = true;
        ambiente.volume = saturationAmount; // Ajusta la cantidad de saturación
        ambiente.reverbZoneMix = reverbAmount; // Ajusta la cantidad de eco
    }
}