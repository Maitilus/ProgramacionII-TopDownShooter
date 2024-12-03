using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagementScript : MonoBehaviour
{
    public void LoadScene(String SceneName)
    {
        SceneManager.LoadScene(SceneName);
    }
}
