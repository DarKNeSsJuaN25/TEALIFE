using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SojaExiles
{
    public class opencloseDoor : MonoBehaviour
    {
        public Animator openandclose;
        public bool open;
        public Transform Player; // Asumiendo que este es el jugador en VR

        void Start()
        {
            open = false;
        }

        void Update()
        {
            if (Player)
            {
                float dist = Vector3.Distance(Player.position, transform.position);
                if (dist < 2.5f)
                {
                    if (open == false)
                    {
                        // Cambiar a botón A del controlador de Oculus
                        if (OVRInput.GetDown(OVRInput.Button.One))
                        {
                            StartCoroutine(opening());
                        }
                    }
                    else
                    {
                        // Cambiar a botón A del controlador de Oculus
                        if (OVRInput.GetDown(OVRInput.Button.One))
                        {
                            StartCoroutine(closing());
                        }
                    }
                }
            }
        }

        IEnumerator opening()
        {
            Debug.Log("you are opening the door");
            openandclose.Play("Opening");
            open = true;
            yield return new WaitForSeconds(.5f);
        }

        IEnumerator closing()
        {
            Debug.Log("you are closing the door");
            openandclose.Play("Closing");
            open = false;
            yield return new WaitForSeconds(.5f);
        }
    }
}
