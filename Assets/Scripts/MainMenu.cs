using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    
    public void SwitchScene(int _index)
    {
        SceneManager.LoadScene(_index);
    }

    public void SideLoadScene(int _intindex)
    {
        SceneManager.LoadSceneAsync(_intindex, LoadSceneMode.Additive);
    }
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Bye");
    }
}
