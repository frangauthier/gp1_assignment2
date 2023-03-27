using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : Health
{
    Animator anim;

    new void Start()
    {
        base.Start();
        anim = GetComponentInChildren<Animator>();
    }


    public override void Die()
    {
        base.Die();
        //anim.SetTrigger("Death");
        Destroy(gameObject, 2);
    }

}
