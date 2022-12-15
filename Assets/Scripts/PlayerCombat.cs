using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    //Animation and VFX
    public GameObject slashVFX;
    public Animator animator;


    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;


    public int attackDamage=20;

    private void Start()
    {
        slashVFX.SetActive(false);
    }
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Debug.Log("Mouse down");
            Attack();
        }
    }

    void Attack()
    {
        //Play attack animation
        animator.SetTrigger("Attack");
        slashVFX.SetActive(true);

        //Detect hit enemies
        Collider[] hitEnemies = Physics.OverlapSphere(attackPoint.position,attackRange,enemyLayers);


        //Apply damage
        foreach(Collider enemy in hitEnemies)
        {
            enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
        }


    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        //debug tool
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
