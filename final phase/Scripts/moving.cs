﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moving : MonoBehaviour
{

    public GameObject player1;
    public Transform player;
    static Animator anim;
    public float damage = 20f;

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
       
    }

    // Update is called once per frame
    void Update()
    {
        anim = GetComponent<Animator>();
        Vector3 direction = player.position - this.transform.position;
        float angle = Vector3.Angle(direction, this.transform.forward);
        if (Vector3.Distance(player.position, this.transform.position) < 20 && angle < 330)
        {
            direction.y = 0;
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), 0.1f);

            anim.SetBool("IsIdle", false);
            if (direction.magnitude > 10)
            {
                this.transform.Translate(0, 0, 0.05f);
                anim.SetBool("IsWalking", true);
                anim.SetBool("IsAttacking", false);

            }
            else
            {               
                anim.SetBool("IsAttacking", true);

                anim.SetBool("IsWalking", false);
                player1.transform.GetComponent<HealthController>().applyDamage(damage);
            }

        }
        else
        {
            anim.SetBool("IsIdle", true);
            anim.SetBool("IsWalking", false);
            anim.SetBool("IsAttacking", false);
        }
    }
}
