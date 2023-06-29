using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class shooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletprefab;
    public float bulletSpeed = 20f;
    public float moveSpeed =10;
    public Rigidbody2D myrb;
    public float maxSpeed;
    public GameObject echo;
    public float timeBtwSpawns;
    public float startTimeBtwSpawns;
    private bool boosting = false;
    public GameObject trail;
    public TrailRenderer trailrender;
    public float ammo;
    public float recoildistance;
    public float decreaseRate;
    public float decreasetimer;
    public float decreasemax = 5;
    public float attackspeed;
    public float attacktimer;
    public float fuel;
    public float maxfuel;
    public float health;
    public healtanim healthAnim;
    public float currenthp;

    public Sprite fullfuel;
    public Sprite fuel4;
    public Sprite fuel3;
    public Sprite fuel2;
    public Sprite fuel1;
    public Sprite fuelempty;
    public Image fuelimage;
    public Text ammoui;

    public GameObject boosteffect;


    // Start is called before the first frame update
    void Start()
    {
        ammoui.text = ammo.ToString();
        healthAnim = GameObject.FindGameObjectWithTag("health").GetComponent<healtanim>();
        trailrender = trail.GetComponent<TrailRenderer>();
        healthAnim.getCurrentHp(health);
    }

    // Update is called once per frame
    void Update()
    {
      /*  if (timeBtwSpawns <= 0)
        {
            if (Input.GetMouseButton(0) && !Input.GetMouseButton(1) && ammo > 0)
            {
                
                   GameObject instance = (GameObject)Instantiate(echo, transform.position, Quaternion.identity);
                    Destroy(instance, 3f);
                    timeBtwSpawns = startTimeBtwSpawns;
                
            }
        }
        else
        {
            timeBtwSpawns -= Time.deltaTime;
        }*/
        
        if(myrb.velocity.magnitude > maxSpeed)
        {
            myrb.velocity = (Vector2)Vector3.ClampMagnitude((Vector3)myrb.velocity, maxSpeed);
        }
        if (Input.GetButtonDown("Fire1")) 
        {
            if (ammo > 0) 
            {
                myrb.AddForce(-transform.up * recoildistance, ForceMode2D.Impulse);
                Shoot();
                GameObject instance = (GameObject)Instantiate(echo, transform.position, Quaternion.identity);
                Destroy(instance, 3f);
            }
        }
        if (Input.GetMouseButton(0) && !Input.GetMouseButton(1)) 
        {
            if (ammo > 0)
            {
                if (attacktimer >= attackspeed)
                {
                    myrb.AddForce(-transform.up * recoildistance, ForceMode2D.Impulse);
                    Shoot();
                    attacktimer = 0;
                    GameObject instance = (GameObject)Instantiate(echo, transform.position, Quaternion.identity);
                    Destroy(instance, 3f);
                    timeBtwSpawns = startTimeBtwSpawns;
                }
                else 
                {
                    attacktimer += Time.deltaTime;
                }
            }
        }
        if (Input.GetMouseButton(1) && !Input.GetMouseButton(0))
        {
            if (fuel > 0)
            {
             
                trail.SetActive(true); // Make the trail visible
                StartCoroutine(FadeInTrail());
                myrb.AddForce(transform.up * moveSpeed * 2, ForceMode2D.Impulse);
                boosting = true;
                fuel -= Time.deltaTime;
            }
        }
        if(boosting == true && !Input.GetMouseButton(1) || fuel <= 0) 
        {
            Instantiate(boosteffect, transform.position, transform.rotation);
            StartCoroutine(FadeOutTrail());
            myrb.velocity = myrb.velocity * 0.5f;
            
            boosting = false;

        }
        if (!Input.GetMouseButton(1) && fuel < maxfuel) 
        {
            fuel += Time.deltaTime/5;
        }
        
        
        if(!Input.GetMouseButton(1)|| ammo == 0 && !Input.GetMouseButton(1))
        {
                 
                    myrb.velocity -= myrb.velocity * decreaseRate * Time.deltaTime;
                    decreasetimer = 0;                      
        }
        if (fuel >= 5) 
        {
            fuelimage.sprite = fullfuel;
        }
        if (fuel >=4 && fuel < 5) 
        {
            fuelimage.sprite = fuel4;
        }
        if (fuel >=3 && fuel < 4) 
        {
            fuelimage.sprite = fuel3;
        }
        if (fuel >= 2 && fuel < 3)
        {
            fuelimage.sprite = fuel2;
        }
        if (fuel >= 1 && fuel < 2)
        {
            fuelimage.sprite = fuel1;
        }
        if (fuel < 0)
        {
            fuelimage.sprite = fuelempty;
        }
        ammoui.text = ammo.ToString();

    }
    void Shoot() 
    {
     
        ammo--;
      GameObject bullet =  Instantiate(bulletprefab, firePoint.position, firePoint.rotation);
      Rigidbody2D rb =  bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletSpeed, ForceMode2D.Impulse);
       
    }
    IEnumerator FadeInTrail()
    {
        Material trailMaterial = trail.GetComponent<TrailRenderer>().material;
        float fadeDuration = 0.5f; // Set the duration of the fade
        float fadeStartTime = Time.time;

        

        while (Time.time < fadeStartTime + fadeDuration)
        {
            float alpha = Mathf.Lerp(0f, 1f, (Time.time - fadeStartTime) / fadeDuration);
            trailMaterial.SetColor("_Color", new Color(trailMaterial.color.r, trailMaterial.color.g, trailMaterial.color.b, alpha));
            yield return null;
        }
    }
    IEnumerator FadeOutTrail()
    {
        Material trailMaterial = trail.GetComponent<TrailRenderer>().material;
        float fadeDuration = 0.7f; // Set the duration of the fade
        float fadeStartTime = Time.time;

        while (Time.time < fadeStartTime + fadeDuration)
        {
            float alpha = Mathf.Lerp(1f, 0f, (Time.time - fadeStartTime) / fadeDuration);
            trailMaterial.SetColor("_Color", new Color(trailMaterial.color.r, trailMaterial.color.g, trailMaterial.color.b, alpha));
            yield return null;
           
        }

        trail.SetActive(false);
    }
    public void enemyDeadAddAmmo(bool dead,int ammoAmmount) 
    {
        if (dead == true) 
        {
            ammo += ammoAmmount;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 6 || collision.gameObject.layer == 3) 
        {
           
            health -= 1;
            currenthp = health;
            healthAnim.getCurrentHp(currenthp);
            Debug.Log(health);
        }
    }
}
