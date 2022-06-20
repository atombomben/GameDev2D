using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public Animator animaitor;
[SerializeField] private float attackCooldown;
//[SerializeField] private int damage;
//[SerializeField] private float range;
//[SerializeField] private float colliderDistance;
//[SerializeField] private BoxCollider2D boxCollder;

public Transform attackPoint;
public float attackRange = 0.5f;
public float attackRate  = 2f;
float nextAttackTime = 0f;
[SerializeField] private LayerMask playerLayer;
private float cooldownTimer = Mathf.Infinity;
public int attackDamage = 40;


    public int maxHealth = 100;
    int curentHealth;
    // Start is called before the first frame update
    void Start()
    {
        curentHealth = maxHealth;
    }

    private void Awake()
    {
        animaitor = GetComponent<Animator>();
    }


    private void Update()
    {
        //Attack only when player is in range
        cooldownTimer += Time.deltaTime;

        if (PlayerInSight())
        {
             if (cooldownTimer >= attackCooldown)
        {
            //Attack
            cooldownTimer = 0;
            animaitor.SetTrigger("EnemyAttack");
        }
        }
    }

        bool PlayerInSight()
       {
         Collider2D[] hitPlayer = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, playerLayer);
          foreach(Collider2D player in hitPlayer)
        {
           Debug.Log("Hit" + player.name);
        }
        return true;
         
      

       }



       void OnDrawGizmosSelected()
       {
        if (attackPoint == null)
        return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
       }
    /*private bool PlayerInSight()
        {
            RaycastHit2D hit = Physics2D.BoxCast(boxCollder.bounds.center + transform.right * range * transform.localScale.x* colliderDistance,
             new Vector3(boxCollder.bounds.size.x * range, boxCollder.bounds.size.y, boxCollder.bounds.size.z),
              0, Vector2.left, 0, playerLayer);
            return hit.collider != null;
        }*/


     /*private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireCube(boxCollder.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
             new Vector3(boxCollder.bounds.size.x * range, boxCollder.bounds.size.y, boxCollder.bounds.size.z));
        }*/







    


    public void TakeDamage(int damage)
    {
        curentHealth -= damage;
        // Play hurt animaiton

        animaitor.SetTrigger("Hurt");

        if(curentHealth <=0)
        {
            Die();
        }
    }


    public void Die()
    {
        Debug.Log("Enemy died!");

        // play Die animation
        animaitor.SetBool("IsDead", true);

        // disable enemy

        GetComponent<Collider2D>().enabled = false;
        this.enabled = false; 

    }
   
}
