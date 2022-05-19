using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class LoadingLevel
{
    public static string NextLevel;

    public static void LevelLoading(string name)
    {
        NextLevel = name;
        SceneManager.LoadScene("ChargingScreen");
    }
}
