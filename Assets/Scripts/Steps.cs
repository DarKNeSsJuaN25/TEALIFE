using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Steps : MonoBehaviour
{
    public AudioSource footstepsSound;
    private  OVRPlayerController movement;

    private void Start()
    {
        movement = GetComponent<OVRPlayerController>();
    }
    void Update()
    {
        // Obtén el input del joystick del controlador de Oculus
        Vector2 primaryThumbstick = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick);

        // Revisa si hay movimiento significativo en el joystick
        if (primaryThumbstick.magnitude > 0.1f)
        {
            if (!footstepsSound.isPlaying && movement.isEnabledMovement()) // Verifica si el sonido no se está reproduciendo actualmente
            {
                footstepsSound.Play(); // Reproduce el sonido de pasos
            }
        }
        else
        {
            footstepsSound.Stop(); // Detiene el sonido de pasos
        }
    }
}
