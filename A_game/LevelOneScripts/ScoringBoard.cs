using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoringBoard : MonoBehaviour
{
    public GameObject scoreText;
    public static int scorePoints;
    public GameObject itemText;
    public static int itemPoints;

    void Update()
    {
        scoreText.GetComponent<Text>().text = "SCORE: " + scorePoints;
        itemText.GetComponent<Text>().text = "ITEMS OBTAINED: " + itemPoints;
    }
}
