using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class logicsript : MonoBehaviour
{
    public GameObject closeButton;
    public GameObject title;
  public void onClickPlay() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void onClickCloseButton() 
    {
        closeButton.SetActive(false);
        title.SetActive(true);
    }
    public  void onClickHowToPlay() 
    {
        title.SetActive(false);
        closeButton.SetActive(true);
    }
}
