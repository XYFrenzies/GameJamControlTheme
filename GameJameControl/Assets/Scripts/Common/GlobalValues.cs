using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalValues : Singleton<GlobalValues>
{
    [HideInInspector] public string time = "";
    [HideInInspector] public float score = 0;
    [HideInInspector] public bool isTowerDead = false;
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    public void RestartGlobalValues()
    {
        time = "";
        score = 0;
        isTowerDead = false;
    }
}
