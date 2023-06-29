using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletscript : MonoBehaviour
{
    public GameObject explosion;
    public float timer = 0;
   

    public void Start()
    {
        Invoke("destroyBullet", 3f);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            Instantiate(explosion, transform.position, transform.rotation);
        }
        Instantiate(explosion, transform.position, transform.rotation);
        Destroy(gameObject);
    }
    public void destroyBullet() 
    {
        
        Destroy(gameObject);
    }
}
