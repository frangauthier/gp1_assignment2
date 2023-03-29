using UnityEngine;
using UnityEngine.Windows;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Sensor_Bandit))]
[RequireComponent(typeof(EnemySensor))]
public class HeavyBanditController : MonoBehaviour
{
    [SerializeField] float      m_speed = 4.0f;
    [SerializeField] float      attackCooldown = 3.0f;
    //[SerializeField] float      m_jumpForce = 7.5f;

    private Animator            m_animator;
    private Rigidbody2D         m_body2d;
    private Sensor_Bandit       m_groundSensor;
    private EnemySensor         m_enemySensor;
    private bool                m_grounded = false;
    private bool                m_canMove = true;
    private bool                m_isDead = false;
    private float nextAttack = 0f;

    // Use this for initialization
    void Start () {
        m_animator = GetComponent<Animator>();
        m_body2d = GetComponent<Rigidbody2D>();
        m_groundSensor = transform.Find("GroundSensor").GetComponent<Sensor_Bandit>();
        m_enemySensor = transform.Find("EnemySensor").GetComponent<EnemySensor>();
    }
	
	// Update is called once per frame
	void Update () {

        if (m_isDead)
        {
            return;
        }
        //Check if character just landed on the ground
        if (!m_grounded && m_groundSensor.State()) {
            m_grounded = true;
            m_animator.SetBool("Grounded", m_grounded);
        }

        //Check if character just started falling
        if(m_grounded && !m_groundSensor.State()) {
            m_grounded = false;
            m_animator.SetBool("Grounded", m_grounded);
        }


        // -- Handle Animations --
        EnemyActions nextAction = m_enemySensor.GetNextAction();
        if (nextAction == EnemyActions.Walk && m_canMove)
        {
            // Move
            float directionX = m_enemySensor.GetWalkDirection().x;
            m_body2d.velocity = new Vector2(directionX * m_speed, m_body2d.velocity.y);
            Flip(directionX);
            // set run animation
            m_animator.SetInteger("AnimState", 2);
        } 
        else if(nextAction == EnemyActions.Walk && !m_canMove)
        {
            // set combat idle animation
            m_animator.SetInteger("AnimState", 1);
        }
        else if (nextAction == EnemyActions.Attack && Time.time > nextAttack) 
        {
            //Attack
            m_animator.SetTrigger("Attack");
            nextAttack = Time.time + attackCooldown;
            m_canMove = false;
            Invoke("EnableMovement", attackCooldown);
        } 
        else if(nextAction == EnemyActions.Wait)
        {
            // set idle animation
            m_animator.SetInteger("AnimState", 0);
        }

        //Set AirSpeed in animator
        m_animator.SetFloat("AirSpeed", m_body2d.velocity.y);
    }

    void Flip(float directionX)
    {
        // Swap direction of sprite depending on walk direction
        if (directionX > 0)
            transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
        else if (directionX < 0)
            transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
    }

    void EnableMovement()
    {
        if (!m_isDead)
        {
            m_canMove = true;
        }
    }

    public void Hurt()
    {
        m_animator.SetTrigger("Hurt");
    }

    public void Die()
    {
        if (!m_isDead)
        {
            m_animator.SetTrigger("Death");
        }

        m_isDead = true;
    }

}
