using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    CharacterController controller;
    Animator anim;

    Vector3 move;

    public Transform cameraRot;

    public float speed;
    float gravity = -9.81f;

    bool crouch = false;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Speed();
        NormalMovement();
        AnimationsAndRotations();
    }

    void NormalMovement()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            if (crouch != true)
            {
                crouch = true;
            }
            else
            {
                crouch = false;
            }
        }

        if (controller.isGrounded == true)
        {
            move = new Vector3(Input.GetAxis("Horizontal") * speed, 0, Input.GetAxis("Vertical") * speed);
        }
        move.y += gravity;

        controller.Move(transform.TransformDirection(move) * Time.deltaTime);
    }

    void AnimationsAndRotations()
    {
        if (Input.GetKey(KeyCode.W))
        {
            anim.SetBool("walk", true);
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, cameraRot.eulerAngles.y, transform.eulerAngles.z);
        }
        else
        {
            anim.SetBool("walk", false);
        }
    }

    void Speed()
    {
        if (crouch == true)
        {
            speed = 1;
        }
        else
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                speed += 0.1f;
                if (speed >= 10)
                {
                    speed = 10;
                }
            }
            else
            {
                speed -= 0.1f;
                if (speed <= 2)
                {
                    speed = 2;
                }
            }
        }
    }
}