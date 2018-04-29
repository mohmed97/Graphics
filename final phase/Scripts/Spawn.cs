using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour {
    public GameObject spawnn;
    public Transform player;
    static Animator anim;
    List<int> listx = new List<int>();
    List<int> listz = new List<int>();
    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
    }

// Update is called once per frame
void Update ()
    {
        int X,Z;
        int runx = 0;
        int runz = 0;
        X = (int)player.transform.position.x;
        Z = (int)player.transform.position.z;
        
        if (X % 50 == 0)
        {
            runx = 1;
            for (int i = 0; i < listx.Count; i++)
            {
                if (listx[i] == X)
                {
                    runx = 0;
                }

            }
            listx.Add(X); 
        }
        else if ( Z % 50 == 0)
            {
            runz = 1;
            for (int i = 0; i < listz.Count; i++)
            {
                if (listz[i] == Z)
                {
                    runz = 0;
                }

            }
             listz.Add(Z); 
        }
        if (runx == 1 || runz==1)
        {
            for (int i = 1; i <= 3; i++)
            {
                Instantiate(spawnn, player.transform.position + new Vector3(10 * i, 0, 30), Quaternion.identity);

            }
        }



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

