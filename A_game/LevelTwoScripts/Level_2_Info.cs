using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_2_Info : MonoBehaviour
{
    readonly int currentLevel = 2;

    void Awake()
    {
        RedirectLevel.levelRedirector = currentLevel;
    }
}
