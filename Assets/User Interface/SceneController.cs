using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    // Scene Name
    public string Scene;

    // Scene Function
    public void ChangeScene()
    {
        SceneManager.LoadScene(Scene);
    }
}