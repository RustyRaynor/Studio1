using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public GameObject gameMan;

    GameManager game;
    CharacterController controller;
    Animator anim;
    PlayerHealth player;

    public Vector3 move;

    public enum State { alive, dead}
    public State state;

    public Transform cameraRot;

    public float speed;
    float gravity = -9.81f;

    public int soundMade;

    bool crouch = false;
    bool dead = true;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
        player = GetComponent<PlayerHealth>();
        game = gameMan.GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            case State.alive:
                anim.speed = 1;
                Speed();
                NormalMovement();
                AnimationsAndRotations();
                break;

            case State.dead:
                Dead();
                break;

            default:
                break;
        }

            if(player.health <= 0)
            {
                state = State.dead;
            }
            else
            {
                state = State.alive;
            }

    }

    void NormalMovement()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            if (crouch != true)
            {
                crouch = true;
                anim.SetTrigger("Crouch");
                controller.height = 1.3f;
                controller.center = new Vector3(0, 0.73f, 0);
            }
            else
            {
                crouch = false;
                anim.SetTrigger("Idle");
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

        if(Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") == 0)
        {
            soundMade = 0;
        }
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
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, cameraRot.eulerAngles.y, transform.eulerAngles.z);
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
            soundMade = 1;
        }
        else
        {
            if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.W))
            {
                soundMade = 10;
                speed += 0.1f;
                if (speed >= 5)
                {
                    speed = 5;
                }
            }
            else
            {
                soundMade = 5;
                speed -= 0.1f;
                if (speed <= 2)
                {
                    speed = 2;
                }
            }
        }
    }

    void Dead()
    {
        if(dead == true)
        {
            anim.SetTrigger("dead");
            dead = false;
        }
        game.state = GameManager.State.gameOver;
    }
}