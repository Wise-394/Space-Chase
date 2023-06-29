using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerscript : MonoBehaviour
{
    public float moveSpeed = 5;
    public GameObject bullet;
    public Camera myCamera;
    public Rigidbody2D myRigidBody2D;
    float angle;
    
    

    Vector2 mousePos;
    // Start is called before the first frame update
    void Start()
    {
       

    }

    // Update is called once per frame
    void Update()
    {
        mousePos = myCamera.ScreenToWorldPoint(Input.mousePosition);
        Vector2 lookDirection = mousePos - myRigidBody2D.position;
        angle = Mathf.Atan2(lookDirection.y,lookDirection.x) * Mathf.Rad2Deg -90f;
        myRigidBody2D.rotation = angle;
        /*
        if (Input.GetMouseButton(0))
        {
            player.transform.position -= transform.right * moveSpeed * Time.deltaTime;
        }*/
    }
    }
