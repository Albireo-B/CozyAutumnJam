using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class intro : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(startintro());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator startintro()
    {
        while (true)
        {
            yield return new WaitForSeconds(1.5f);
            SceneManager.LoadScene(sceneName: "menu");
        }

    }
}
