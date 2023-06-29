using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemydying : MonoBehaviour
{
    public int health;
    public logics logic;
    public shooting shoot;
    public spawnenemy1 script;
    public GameObject explosion;
    public AudioSource hitsound;
    public AudioSource onhitdead;

    public SpriteRenderer hprender;
    public Sprite dmg1;
    public Sprite dmg2;
    public void Start()
    {
        onhitdead = GameObject.FindGameObjectWithTag("onhit").GetComponent<AudioSource>();
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
        if (health == 2) 
        {
       
            hprender.sprite = dmg1;
        }
        if (health == 1)
        {
            hprender.sprite = dmg2;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 3) 
        {
            camerashake.Instance.ShakeCamera(3f, .1f);
            health -= logic.currentDmg() ;
            hitsound.Play();
         
        }
        if (collision.gameObject.layer == 7)
        {
            enemyDead();

        }
    }
    void enemyDead() 
    {
        onhitdead.Play();
        Instantiate(explosion, transform.position, transform.rotation);
        logic.scoreTracker(3);
        Destroy(gameObject);
        script.deadEnemies(1);
    }
}
