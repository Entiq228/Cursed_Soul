using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHunter : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform player;
    [SerializeField] private float speed;
    [SerializeField] private float agrDistanse;

    public void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    public void Update()
    {
        float distanseToPlayer = Vector2.Distance(transform.position, player.position);
        if (distanseToPlayer < agrDistanse)
        {
            StartHunting();
        }
        else if (distanseToPlayer > agrDistanse)
        {
            StopHunting();
        }
    }

    public void StartHunting()
    {
        if (player.position.x < transform.position.x)
        {
            rb.velocity = new Vector2(-speed, 0);
            transform.localScale = new Vector2(0.3150305f, 0.3150305f);
        }
        else if (player.position.x > transform.position.x)
        {
            rb.velocity = new Vector2(speed, 0);
            transform.localScale = new Vector2(-0.3150305f, 0.3150305f);
        }
    }
    public void StopHunting()
    {
        rb.velocity = new Vector2(0, 0);
    }
}
