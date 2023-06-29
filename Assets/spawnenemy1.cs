using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnenemy1 : MonoBehaviour
{
    public GameObject enemy1;
    public float spawnrate = 10;
    public float timer;
    public GameObject player;
    public float num;
    public enemy2dying script;
    public static float currentdead;
    public float enemy2spawner;
    public float timer1;
    public float spawnrate1 = 7;
    public GameObject enemy2;
    // Start is called before the first frame update
    void Start()
    {
        currentdead = 0;
    }

    // Update is called once per frame
    [System.Obsolete]
    void Update()
    {
     
        if (currentdead <= 15)
        {

            if (timer < spawnrate)
            {
                timer += Time.deltaTime;

            }
            if (timer > spawnrate)
            {
                num = Random.RandomRange(0, 100);
                //right
                if (num >= 51)
                {
                    Instantiate(enemy1, new Vector3(player.transform.position.x + Random.RandomRange(10, 20), player.transform.position.y + Random.RandomRange(6, 15), transform.position.z), transform.rotation);
                }
                else
                {
                    Instantiate(enemy1, new Vector3(player.transform.position.x + Random.RandomRange(-10, -20), player.transform.position.y + Random.RandomRange(-6, -15), transform.position.z), transform.rotation);
                }


                timer = 0;
            }
        }
        else if (currentdead > 10 && currentdead < 20)
        {
            if (timer < spawnrate + 2)
            {
                timer += Time.deltaTime;

            }
            if (timer > spawnrate + 2)
            {
                num = Random.RandomRange(0, 100);
                //right
                if (num >= 51)
                {
                    Instantiate(enemy1, new Vector3(player.transform.position.x + Random.RandomRange(10, 20), player.transform.position.y + Random.RandomRange(6, 15), transform.position.z), transform.rotation);
                }
                else
                {
                    Instantiate(enemy1, new Vector3(player.transform.position.x + Random.RandomRange(-10, -20), player.transform.position.y + Random.RandomRange(-6, -15), transform.position.z), transform.rotation);
                }


                timer = 0;
            }
            if (timer1 < spawnrate1)
            {
                timer1 += Time.deltaTime;

            }
            if (timer1 > spawnrate1)
            {
                enemy2spawner = Random.RandomRange(0, 100);
                num = Random.RandomRange(0, 100);
                if (enemy2spawner > 60)
                {
                    //right
                    if (num >= 51)
                    {
                        Instantiate(enemy2, new Vector3(player.transform.position.x + Random.RandomRange(10, 20), player.transform.position.y + Random.RandomRange(6, 15), transform.position.z), transform.rotation);
                    }
                    else
                    {
                        Instantiate(enemy2, new Vector3(player.transform.position.x + Random.RandomRange(-10, -20), player.transform.position.y + Random.RandomRange(-6, -15), transform.position.z), transform.rotation);
                    }
                }
                timer1 = 0;
            }

            }
        else if (currentdead > 20 && currentdead < 30)
        {
            if (timer < spawnrate + 4)
            {
                timer += Time.deltaTime;

            }
            if (timer > spawnrate + 4)
            {
                num = Random.RandomRange(0, 100);
                //right
                if (num >= 51)
                {
                    Instantiate(enemy1, new Vector3(player.transform.position.x + Random.RandomRange(10, 20), player.transform.position.y + Random.RandomRange(6, 15), transform.position.z), transform.rotation);
                }
                else
                {
                    Instantiate(enemy1, new Vector3(player.transform.position.x + Random.RandomRange(-10, -20), player.transform.position.y + Random.RandomRange(-6, -15), transform.position.z), transform.rotation);
                }


                timer = 0;
            }
            if (timer1 < spawnrate1)
            {
                timer1 += Time.deltaTime;

            }
            if (timer1 > spawnrate1)
            {
                enemy2spawner = Random.RandomRange(0, 100);
                num = Random.RandomRange(0, 100);
                if (enemy2spawner > 30)
                {
                    //right
                    if (num >= 51)
                    {
                        Instantiate(enemy2, new Vector3(player.transform.position.x + Random.RandomRange(10, 20), player.transform.position.y + Random.RandomRange(6, 15), transform.position.z), transform.rotation);
                    }
                    else
                    {
                        Instantiate(enemy2, new Vector3(player.transform.position.x + Random.RandomRange(-10, -20), player.transform.position.y + Random.RandomRange(-6, -15), transform.position.z), transform.rotation);
                    }
                }
                timer1 = 0;
            }

        }
        else if (currentdead > 30)
        {
            if (timer < spawnrate + 4)
            {
                timer += Time.deltaTime;

            }
            if (timer > spawnrate + 4)
            {
                num = Random.RandomRange(0, 100);
                //right
                if (num >= 51)
                {
                    Instantiate(enemy1, new Vector3(player.transform.position.x + Random.RandomRange(10, 20), player.transform.position.y + Random.RandomRange(6, 15), transform.position.z), transform.rotation);
                }
                else
                {
                    Instantiate(enemy1, new Vector3(player.transform.position.x + Random.RandomRange(-10, -20), player.transform.position.y + Random.RandomRange(-6, -15), transform.position.z), transform.rotation);
                }


                timer = 0;
            }
            if (timer1 < spawnrate1)
            {
                timer1 += Time.deltaTime;

            }
            if (timer1 > spawnrate1)
            {
                enemy2spawner = Random.RandomRange(0, 100);
                num = Random.RandomRange(0, 100);
                if (enemy2spawner > 0)
                {
                    //right
                    if (num >= 51)
                    {
                        Instantiate(enemy2, new Vector3(player.transform.position.x + Random.RandomRange(10, 20), player.transform.position.y + Random.RandomRange(6, 15), transform.position.z), transform.rotation);
                    }
                    else
                    {
                        Instantiate(enemy2, new Vector3(player.transform.position.x + Random.RandomRange(-10, -20), player.transform.position.y + Random.RandomRange(-6, -15), transform.position.z), transform.rotation);
                    }
                }
                timer1 = 0;
            }

        }
    }
        public void deadEnemies(float deadenemy)
        {
           
            currentdead += deadenemy;
        Debug.Log(currentdead);
    }
    }
