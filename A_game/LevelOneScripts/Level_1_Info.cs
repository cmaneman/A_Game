using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_1_Info : MonoBehaviour
{
    #region Simple Way To Know Which Level To Redirect The User To If There Is a Game Over

    readonly int currentLevel = 1;

    void Awake()
    {
        RedirectLevel.levelRedirector = currentLevel;
    }

    #endregion Look To RedirectLevel.cs

}
