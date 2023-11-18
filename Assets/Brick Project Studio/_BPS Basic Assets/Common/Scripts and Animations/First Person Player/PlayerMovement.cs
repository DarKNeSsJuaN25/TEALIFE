using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace SojaExiles

{
    public class PlayerMovement : MonoBehaviour
    {
        public DialogueSystem dialogueSystem;
        public CharacterController controller;
        public bool canMove = true;

        public float speed = 5f;
        public float gravity = -15f;

        Vector3 velocity;

        // Update is called once per frame
        void Update()
        {
            if (canMove)
            {
                if (dialogueSystem.IsDialogueActive)
                {
                    return;
                }

                float x = Input.GetAxis("Horizontal");
                float z = Input.GetAxis("Vertical");

                Vector3 move = transform.right * x + transform.forward * z;

                controller.Move(move * speed * Time.deltaTime);

                velocity.y += gravity * Time.deltaTime;

                controller.Move(velocity * Time.deltaTime);
            }
        }
        public void SetMovement(bool status)
        {
            canMove = status;
        }
    }
}