using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public enum EnemyActions {
    Walk,
    Attack,
    Wait,
}

public class EnemySensor : MonoBehaviour
{
    private GameObject target;
    [SerializeField] float attackRange = 1f;

    // Start is called before the first frame update
    void Start()
    {
            
    }

    public GameObject GetTarget()
    {
        return target;
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Player"){
            target = other.gameObject;
        }            
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            target = null;
        }
    }

    public EnemyActions GetNextAction()
    {
        if(target == null)
        {
            return EnemyActions.Wait;
        }

        float distanceToTarget = target.transform.position.x - transform.position.x;
        if(MathF.Abs(distanceToTarget) < attackRange)
        {
            return EnemyActions.Attack;
        } else
        {
            return EnemyActions.Walk;
        }
    }

    public Vector3 GetWalkDirection()
    {
        return new Vector3(target.transform.position.x - transform.position.x, 0f, 0f).normalized;
    }

}
