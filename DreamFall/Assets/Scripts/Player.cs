using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Animator playAnimator;
    [SerializeField] private Transform playerTR;
    private CharacterController controller;
    private float speed = 5;
    private float rotateSpeed = 10;

    private Vector3 moveDir;
    private bool isMove = false;

    private void Awake()
    {
        playAnimator = GetComponentInChildren<Animator>();
        playerTR = GetComponent<Transform>();
        controller = GetComponent<CharacterController>();
    }

    void Start()
    {
        Debug.Log("HellowWorld");
    }


    void Update()
    {
        float horizon = Input.GetAxis("Horizontal");
        float Vertical = Input.GetAxis("Vertical");
        moveDir = new Vector3(horizon, 0, Vertical);
        if (moveDir == Vector3.zero)
        {
            isMove = false;
            playAnimator.SetBool("isMove", isMove);
            return;
        }

        isMove = true;
        playAnimator.SetBool("isMove", isMove);
        Debug.Log(moveDir);
        moveDir = moveDir.normalized * speed * Time.deltaTime;
        controller.Move(moveDir);
        Quaternion rotation = Quaternion.LookRotation(moveDir);
        playerTR.rotation = Quaternion.Slerp(playerTR.rotation, rotation, rotateSpeed * Time.deltaTime);

        // if (Input.GetAxis("Horizontal") > 0f)
        // { 
        //     Debug.Log("R");
        //     playerTR.position += new Vector3(1, 0, 0);
        // }
        // if (Input.GetAxis("Horizontal") < 0f)
        // {
        //     Debug.Log("L");
        //     playerTR.position += new Vector3(-1, 0, 0);
        // }
    }
}