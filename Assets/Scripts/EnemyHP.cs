using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHP : MonoBehaviour
{
    public Animator anims;
    private Rigidbody rb;
    public int maxHealth = 3;
    int currentHealth;
    public float knockbackForce = 100f;

    void Start()
    {
        currentHealth = maxHealth;
        rb = GetComponent<Rigidbody>();
    }

    public void GetDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {

            currentHealth = 0;
            Destroy(gameObject);
        }
    }
}
