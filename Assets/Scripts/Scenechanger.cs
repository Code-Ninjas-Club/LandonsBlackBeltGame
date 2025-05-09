using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class Scenechanger : MonoBehaviour
{
    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
    public void levelthing(string Name)
    {
        Storeddata.Levelthing = Name;
    }

    public void Character(string Name)
    {
        Storeddata.character = Name;
    }
    public void toLevelSelect()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Level select");
    }
    public void toMainMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    public void tolevel()
    {
        SceneManager.LoadScene(Storeddata.Levelthing);
    }

    public void LOADING()
    {
        SceneManager.sceneLoaded += SceneManager_sceneLoaded;
        SceneManager.LoadScene("LOADING");
        //StartCoroutine(WaitLOAD());
    }

    private void SceneManager_sceneLoaded(Scene arg0, LoadSceneMode arg1)
    {
        StartCoroutine(WaitLOAD());
        SceneManager.sceneLoaded -= SceneManager_sceneLoaded;
    }

    public void Credits()
    {
        SceneManager.LoadScene("Credits");

    }
    public void Settings()
    {
        SceneManager.LoadScene("Settings");
    }
    public void Tothecharacters()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Character Select");
    }
    IEnumerator WaitLOAD()
    {
        yield return new WaitForSeconds(5);
        tolevel();
    }
}
