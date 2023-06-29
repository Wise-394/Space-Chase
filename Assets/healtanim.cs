using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class healtanim : MonoBehaviour
{
    public Sprite full;
    public Sprite hp2;
    public Sprite hp1;
    public Image health;
    public Sprite hp0;
    public static float currenthp;
    public logics logic;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (currenthp == 3) 
        {
            health.sprite = full;
        }
        if (currenthp == 2) 
        {
            health.sprite = hp2;
        }
        if(currenthp == 1) 
        {
            health.sprite = hp1;
        }
        if (currenthp == 0)
        {
            health.sprite = hp0;
            logic.gameOver();
        }
    }
  public  void getCurrentHp(float hp) 
    {
        currenthp = hp;
    }
}
