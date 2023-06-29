using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class outsidemap : MonoBehaviour
{
    public logics logic;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 7)
        {
            logic.gameOver();
        }
    }
    
    
}
