using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy2dying : MonoBehaviour
{
    public int health;
    public logics logic;
    public shooting shoot;
    public spawnenemy1 script;
    public GameObject explosion;
    public AudioSource onhitsound;
    public void Start()
    {
        logic = GameObject.FindGameObjectWithTag("logic").GetComponent<logics>();
        shoot = GameObject.FindGameObjectWithTag("Player").GetComponent<shooting>();
        script = GameObject.FindGameObjectWithTag("spawner").GetComponent<spawnenemy1>();
    }
    public void Update()
    {
        if (health <= 0)
        {
            enemyDead();
            shoot.enemyDeadAddAmmo(true,4);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 3)
        {
            camerashake.Instance.ShakeCamera(3f, .1f);
            onhitsound.Play();
            
            health -= logic.currentDmg();
        }
    }
    void enemyDead()
    {
        Instantiate(explosion, transform.transform.position, transform.rotation);
        logic.scoreTracker(5);
        script.deadEnemies(1);
        Destroy(gameObject);
    }
}
