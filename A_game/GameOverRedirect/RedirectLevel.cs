using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RedirectLevel: MonoBehaviour
{
    /// <summary>
    /// Whatever the value of levelRedirector is, will determine what Scene will be called...
    /// 
    /// Check the .cs files with this template file name: Level_#_Info
    /// 
    /// </summary>
    public static int levelRedirector;
    public float delay = 2.5f;

    /*Figure out how to redirect the player to a specific level
    depending on the level/scene they are in...*/

   
    // Update is called once per frame
    void Update()
    {
        SceneManager.LoadScene(levelRedirector);
    }
}
