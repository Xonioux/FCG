using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class GoalKeeper : MonoBehaviour
{
    public DiveDecision db;
    public GameObject ball;
    public GameObject goal;
    public Animator animator;
    

    void Start() 
    {
        animator.enabled = true;
        animator = GetComponent<Animator>();
    }

    void Update() 
    {
        if (db.jumpLeft == true) 
        {
            animator.Play("mixamo_com 1");
        } else if (db.jumpRight == true) 
        {
            animator.Play("mixamo_com");
        } else 
        {
            animator.Play("idle");
        }

    }

}
