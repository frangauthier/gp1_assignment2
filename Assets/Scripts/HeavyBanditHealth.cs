using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(HeavyBanditController))]
public class HeavyBanditHealth : Health
{
    Animator anim;
    HeavyBanditController controller;

    new void Start()
    {
        base.Start();
        anim = GetComponentInChildren<Animator>();
        controller = GetComponent<HeavyBanditController>();
    }


    public override void Die()
    {
        base.Die();
        //anim.SetTrigger("Death");
        controller.Die();
        Destroy(gameObject, 2);
    }
}
