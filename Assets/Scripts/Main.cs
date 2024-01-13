using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Main : MonoBehaviour
{
    public Button theButton;
    private void Start()
    {
        Button btn = theButton.GetComponent<Button>();
        btn.onClick.AddListener(Onclick);
    }
    void Onclick()
    {
       print("Hello world!");
       SceneManager.LoadScene(1);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Onclick();
        }
    }
}
