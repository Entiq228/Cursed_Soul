using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHP : MonoBehaviour
{
    public int health;
    public int numberOfLives;

    public Image[] lives;

    private bool enemyTriger;

    private bool isGod;
    private float godTimeDelay;
    public float godTime;

    private bool takeHeart;
    private int healsDamage = 1;

    private Animator anim;
    public float timeTriger;
    private float timeDetector = 0;



    private void Start()
    {
        anim = GetComponent<Animator>();


    }

    private void Update()
    {
        for (int i = 0; i < lives.Length; i++)
        {
            if (i < numberOfLives) lives[i].enabled = true;

            else lives[i].enabled = false;

        }
    }

    private void FixedUpdate()
    {
        if (isGod)
        {
            godTimeDelay += Time.deltaTime;
            if (godTimeDelay >= godTime)
            {
                isGod = false;
                godTimeDelay = 0;
            }
        }
        if (enemyTriger && !isGod)
        {
            TakeDamage();
            timeDetector = timeTriger;
            anim.SetBool("isHit", true);
            timeDetector -= Time.deltaTime;
            isGod = true;
        }
        if (takeHeart)
        {
            AddHp();
            takeHeart = false;
        }
    }
    public void AddHp()
    {
        numberOfLives += 1;

        if (numberOfLives >= health)
        {
            numberOfLives = health;
        }
    }
    private void TakeDamage()
    {
        numberOfLives -= healsDamage;
        if (numberOfLives <= 0)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Heal")
        {
            takeHeart = true;
        }

        if (collision.gameObject.tag == "Enemy")
        {
            enemyTriger = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            enemyTriger = false;
        }
    }
}
