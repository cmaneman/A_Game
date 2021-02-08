using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ProjectileTouchTrigger : MonoBehaviour
{
    public GameObject player;
    public GameObject projectile;
    public AudioSource LevelTwoMusic;

    // Start is called before the first frame update
    void Start()
    {
        projectile = GameObject.FindGameObjectWithTag("turrentProjectile");
        player = GameObject.FindGameObjectWithTag("player");
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("player"))
        {
            StartCoroutine(PlayerDie());
        }
    }

   IEnumerator PlayerDie()
   {
        LevelTwoMusic.Stop();
        //Destroy(player);
        yield return new WaitForSeconds(1);
        //SceneManager.LoadScene(2);
    }
}
