using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField]    GameObject menu;
    [SerializeField]    GameObject credits;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Play()
    {
        SceneManager.LoadScene(sceneName: "GameParalax");
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Credit()
    {
        credits.SetActive(true);
        menu.SetActive(false);
    }

    public void Back()
    {
        menu.SetActive(true);
        credits.SetActive(false);
    }

}
