using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Follow : MonoBehaviour
{
    private Transform monstertr;

    private Transform playertr;

    private NavMeshAgent nvAgent;

    //-애니메이터
    public Animator anim;

    public enum State
    {
        Idle,
        Move,
        Attack
    }

    public State state;

    // Use this for initialization

    void Start()
    {
        state = State.Idle;

        monstertr = gameObject.GetComponent<Transform>();

        playertr = GameObject.FindWithTag("Player").GetComponent<Transform>();



        nvAgent = gameObject.GetComponent<NavMeshAgent>();





    }


    float curTime;


    //hp 상태체크 - 총3방

    int hp = 3;
    public void AddDamage()
    {
        hp--;
        if (hp == 0)
        {
            Destroy(this.gameObject);
        }
    }


    // Update is called once per frame

    void Update()
    {
        nvAgent.destination = playertr.position;

        if (state == State.Idle)
        {
            UpdateIdle();
        }
        else if (state == State.Move)
        {
            UpdateMove();
        }
        else if (state == State.Attack)
        {
            UpdateAttack();
        }

    }

    private void UpdateAttack()
    {
        nvAgent.speed = 0;
    }

    private void UpdateMove()
    {
        state = State.Move; // : 전이
        anim.SetTrigger("Move");// 애니메이터의 Move 트리거 발동!!
    }

    private void UpdateIdle()
    {
        state = State.Move; // : 전이
        anim.SetTrigger("Move");// 애니메이터의 Move 트리거 발동!!
    }
}


