using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    public Animator zombie_anima;
    public Rigidbody zombie_rigid;
    public float walk_speed = 50, rotate_speed = 50;
    public bool walking;
    public Transform zombie_trans;

    private void Start()
    {
        InvokeRepeating("UpdateState", 2f, 2f);
    }

    private void FixedUpdate()
    {
        if (walking)
        {
            zombie_rigid.velocity = transform.forward * walk_speed * Time.deltaTime;
        }
    }

    private void Update()
    {
        
    }

    private void UpdateState()
    {
        if (!walking)
        {
            walking = true;

            if (Random.Range(0.0f, 1.0f) > 0.3)
            {
                zombie_trans.Rotate(0, rotate_speed, 0);
            }

            zombie_anima.SetTrigger("Run");
            zombie_anima.ResetTrigger("Idle");
        }
        else
        {
            walking = false;
            zombie_anima.ResetTrigger("Run");
            zombie_anima.SetTrigger("Idle");
        }
    }
}
