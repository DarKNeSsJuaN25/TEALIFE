using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sentarse : MonoBehaviour
{
    public Animator Personaje;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Personaje.Play("sentarse");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Personaje.Play("pararse");
        }
    }
}
