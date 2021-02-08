using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZoneStructureMesh2 : MonoBehaviour
{
    public GameObject GameOverObj; //Deals with the animation triggering...

    void OnTriggerEnter()
    {
        Debug.Log("Triggered");
        StartCoroutine(GameOver());
    }

    IEnumerator GameOver()
    {
        yield return new WaitForSeconds(1);
    }
}
