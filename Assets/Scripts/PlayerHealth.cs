using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(HeroKnightController))]
public class PlayerHealth : Health
{
    Animator anim;
    HeroKnightController controller;

    new void Start()
    {
        base.Start();
        anim = GetComponentInChildren<Animator>();
        controller = GetComponent<HeroKnightController>();
    }

    public override void Die()
    {
        base.Die();
        anim.SetTrigger("Death");
        controller.Die();
        Invoke("Dead", 2f);
        //Destroy(gameObject, 2);
    }

    public void Dead()
    {
        GameManager.PlayerIsDead();
    }

    public override void Hurt()
    {
        base.Hurt();
        controller.Hurt();
    }
}
