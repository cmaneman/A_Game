using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MPlatformGrip : MonoBehaviour
{
    public GameObject Mplatform;
    public GameObject player;


    // Start is called before the first frame update
    void Start()
    {
        Mplatform = GetComponent<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        other.transform.parent = transform;

        Debug.Log("On the Platform");
    }

    void OnTriggerStay(Collider other)
    {
        other.transform.parent = transform;
      
        Debug.Log("Still on the Platform");
    }

    void OnTriggerExit(Collider other)
    {
        other.transform.parent = null;

        Debug.Log("Off the Platform");
    }
}
