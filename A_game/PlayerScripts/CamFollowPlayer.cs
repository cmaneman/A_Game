using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollowPlayer : MonoBehaviour
{
    public GameObject Player;
    public GameObject child_camContraint;
    public float speed;
    
    void Awake()
    {
        Player = GameObject.FindGameObjectWithTag("player");
        child_camContraint = Player.transform.Find("CamContraint").gameObject;
    }
    void FixedUpdate()
    {
        Follow();
    }

    private void Follow()
    {
        gameObject.transform.position = Vector3.Lerp(transform.position, child_camContraint.transform.position, Time.deltaTime * speed);
        gameObject.transform.LookAt(Player.gameObject.transform.position);
    }
}
