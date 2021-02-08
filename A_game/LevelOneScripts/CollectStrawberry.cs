using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectStrawberry : MonoBehaviour
{
    public AudioSource itemSound;

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("player"))
        {
            itemSound.Play();
            ScoringBoard.scorePoints += 50;
            ScoringBoard.itemPoints += 1;
            AllCollected.itemCount++;
            Destroy(gameObject);
        }
        
    }
}
