using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeadZoneStructureMesh1 : MonoBehaviour
{
    public GameObject GameOverObj; //Object that deals with animations
    [SerializeField] private int waitTime = 2;
    public AudioSource LevelOneMusic;
    public GameObject fadeOut;

    void OnTriggerEnter()
    {
        Debug.Log("Triggered");
        StartCoroutine(GameOver());
    }

    IEnumerator GameOver()
    {
        GameOverObj.SetActive(true);
        LevelOneMusic.Stop();
        yield return new WaitForSeconds(waitTime);
        GameOverObj.SetActive(false); //to do: smooth out via animation...
        fadeOut.SetActive(true);
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene(0);
    }

}
