using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager : MonoBehaviour
{
   public void SceneLoad(int index, LoadSceneMode single)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(index, LoadSceneMode.Single);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
