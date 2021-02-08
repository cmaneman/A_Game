using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AllCollected : MonoBehaviour
{
    public GameObject LevelCompleteObj; //Object that deals with animations
    public AudioSource LevelOneCompleteAudio;
    public AudioSource LevelOneMusic;
    public GameObject fadeIn;
    public static int itemCount = 0;
    bool levelCompleteCheck = true;
    
    void Update()
    {
        if(itemCount >= 10 && levelCompleteCheck == true)
        {
            //End trigger will now be accessible...
            Debug.Log("All Items Collected!!!");

            StartCoroutine(LevelComplete());
            
        }
        else
        {
            ;//Debug.Log("Collect All Items...");
        }
    }
    IEnumerator LevelComplete()
    {
        levelCompleteCheck = false;
        LevelOneMusic.Stop();
        LevelOneCompleteAudio.Play();
        LevelCompleteObj.SetActive(true); //Animations on and then off
        yield return new WaitForSeconds(3);
        fadeIn.SetActive(true); //fadeIn--gray
        LevelCompleteObj.SetActive(false); //to do: smooth out via animation...
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(2);
    }
}

