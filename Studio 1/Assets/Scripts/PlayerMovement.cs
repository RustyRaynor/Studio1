using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public GameObject gameMan;

    GameManager game;
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
        game = gameMan.GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (game.pause == false)
        {
            Speed();
            NormalMovement();
            AnimationsAndRotations();
        }
    }

    void NormalMovement()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl) && Input.GetKey(KeyCode.W) == false && Input.GetKey(KeyCode.D) == false && Input.GetKey(KeyCode.A) == false)
        {
            if (crouch != true)
            {
                crouch = true;
                anim.SetBool("crouch", true);
                controller.height = 1.3f;
                controller.center = new Vector3(0, 0.73f, 0);
            }
            else
            {
                crouch = false;
                anim.SetBool("crouch", false);
                controller.height = 1.85f;
                controller.center = new Vector3(0, 1.01f, 0);
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
        anim.SetFloat("Speed", speed);
        if (Input.GetKey(KeyCode.W))
        {
            anim.SetBool("walk", true);
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, cameraRot.eulerAngles.y, transform.eulerAngles.z);
        }
        else
        {
            anim.SetBool("walk", false);
        }
        if (Input.GetKey(KeyCode.S))
        {
            anim.SetBool("walk back", true);
        }
        else
        {
            anim.SetBool("walk back", false);
        }
        if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.W) == false && Input.GetKey(KeyCode.S) == false) 
        {
            anim.SetBool("walk left", true);
        }
        else
        {
            anim.SetBool("walk left", false);
        }
        if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.W) == false && Input.GetKey(KeyCode.S) == false)
        {
            anim.SetBool("walk right", true);
        }
        else
        {
            anim.SetBool("walk right", false);
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
            if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.W))
            {
                speed += 0.1f;
                if (speed >= 8)
                {
                    speed = 8;
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