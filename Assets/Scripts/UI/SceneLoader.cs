using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Loads a new Scene Function
    public void LoadScene(int _scene)
    {
        SceneManager.LoadScene(_scene);
    }

    //Exits Application Function
    public void Exit()
    {
        Application.Quit();
    }
}
