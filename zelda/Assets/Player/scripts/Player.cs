using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum PlayerState
{
    Idle = 0,
    walking,
    attack_sword,
    attack_wand,
    attack_other,
    cheer,
    death
}
public enum Walking
{
    up = 0,
    right,
    down,
    left
}

public class Player : MonoBehaviour
{
    private Walking walking;
    private PlayerState playerstate;
    [SerializeField] private Vector3 speed;
    [SerializeField] private float maxspeedtitlesec;

    [SerializeField] private float Xaxis;
    [SerializeField] private float Yaxis;
    [SerializeField] private bool fire1;
    [SerializeField] private bool fire2;
    [SerializeField] private bool fire3;
    [SerializeField] private bool attack;

    private Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();

        speed = new Vector3();
    }


    private void FixedUpdate()
    {
        Xaxis = Input.GetAxis("Horizontal");
        Yaxis = Input.GetAxis("Vertical");

        fire1 = Input.GetButton("Fire1"); //L ctrl  
        fire2 = Input.GetButton("Fire2"); //L alt
        fire3 = Input.GetButton("Fire3"); //L Shift

        attack = Input.GetButton("attack"); // space

        

        //laten animeten met movement
        if (Xaxis == 0 && Yaxis == 0)
            playerstate = PlayerState.Idle;
        else
            playerstate = PlayerState.walking;
        if (attack)
            playerstate = PlayerState.attack_sword;
        else if (fire1)
            playerstate = PlayerState.attack_wand;
        else if (fire2)
            playerstate = PlayerState.attack_other;
        else if (fire3)
            playerstate = PlayerState.death;
        
        //van de vier dingen switchen
        if(Xaxis < -0.1f)
        {
            walking = Walking.left;
            Yaxis = 0;
        }
        else if(Xaxis > 0.1f)
        {
            walking = Walking.right;
            Yaxis = 0;
        }
        if ( Yaxis < -0.1f)
        {
            walking = Walking.down;
            Xaxis = 0;
        }
        else if ( Yaxis > 0.1f)
        {
            walking = Walking.up;
            Xaxis = 0;
        }
        speed = new Vector3(Xaxis * maxspeedtitlesec, Yaxis * maxspeedtitlesec);

        //speed
        //transform.position += speed* Time.deltaTime;
        transform.position = transform.position + (speed * Time.fixedDeltaTime);

        //status door sturren aan animator
        animator.SetFloat("Direction", (float) walking);
        animator.SetInteger("State", (int) playerstate);
    }
    

}
    