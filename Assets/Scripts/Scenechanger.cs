using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class Scenechanger : MonoBehaviour
{
    public void toLevelSelect()
    {
        SceneManager.LoadScene("Level select");
    }
    public void toMainMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    public void tolevel1()
    {
        SceneManager.LoadScene("Level 1");
    }
}
