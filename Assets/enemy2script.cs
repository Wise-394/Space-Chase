using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy2script : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float stoppingDistance = 1f;
    
    private Transform player;
    private Rigidbody2D rb;
    private Vector2 movement;
    private float angle;
    public GameObject bulletprefab;
    public float bulletSpeed;
    public Transform firePoint;
    private bool shoot;
    public float timer;
    public float firerate = 2;

    void Start() {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update() {
        Vector3 direction = player.position - transform.position;
        float distance = direction.magnitude;
        angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
        

        if (distance > stoppingDistance) {
            direction.Normalize();
            movement = direction;
            shoot = false;
         
        } else 
        {
            movement = Vector2.zero;
             if (timer < firerate) 
            {
                timer += Time.deltaTime;
            }
            else if (timer > firerate)
            {
                GameObject bullet = Instantiate(bulletprefab, firePoint.position, firePoint.rotation);
                Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
                rb.AddForce(firePoint.up * bulletSpeed, ForceMode2D.Impulse);
                timer = 0;
            }

        }

    }

    void FixedUpdate() {
        moveCharacter(movement);
    }
   

    void moveCharacter(Vector2 direction) {
        rb.MovePosition(rb.position + direction * moveSpeed * Time.fixedDeltaTime);
    }
}

