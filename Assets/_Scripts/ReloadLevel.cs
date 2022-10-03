using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReloadLevel : MonoBehaviour
{
    //[SerializeField] private int nextLevelIndex;
    public void Reload()
    {
        SceneManager.LoadScene("Level_1");
    }

    public void WinGame()
    {
        //SceneManager.LoadScene(nextLevelIndex);
        SceneManager.LoadScene("Level_1");
        
    }
}
