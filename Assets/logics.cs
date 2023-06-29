using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class logics : MonoBehaviour
{
    public static float score;
    public int attackdmg = 1;
    public GameObject gameoverscr;
    public Text scoretext;
    public float scoretochange;
    public TextMeshProUGUI scorefinal;
    public GameObject player;
    public void Start()
    {
        score = 0;
        scoretext.text = "0";
    }
    public void Update()
    {
        scoretext.text = score.ToString();
    }
    public int currentDmg()
    {
        return attackdmg;
    }
    public void gameOver() 
    {
        player.SetActive(false);
        scorefinal.text = score.ToString();
        gameoverscr.SetActive(true);
    }
    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void scoreTracker(float scoretoadd)
    {
        score += scoretoadd;
    }
    public void onClickMainMenu() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex -  1);
    }
}
