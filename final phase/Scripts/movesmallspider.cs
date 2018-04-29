using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movesmallspider : MonoBehaviour {

    public Transform player;
    static Animator anim;

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
        if (Vector3.Distance(player.position, this.transform.position) < 10 && angle < 330)
        {
            direction.y = 0;
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), 0.1f);

            anim.SetBool("isidle", false);
            if (direction.magnitude < 10)
            {
                this.transform.Translate(0, 0, 5f);
                anim.SetBool("iswalking", true);

            }

        }
        else
        {
            anim.SetBool("isidle", true);
            anim.SetBool("iswalking", false);
        }
    }
}

