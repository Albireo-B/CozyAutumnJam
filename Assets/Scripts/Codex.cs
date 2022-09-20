using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Codex : MonoBehaviour
{
    [SerializeField]
    private GameObject openedCodex;
    [SerializeField]
    private GameObject closedCodex;

    // Update is called once per frame
    void Update()
    {

    }

    //We open or close the corresponding codex depending if its visible/active
    public void OpenOrCloseCodex() {
        if (openedCodex.activeSelf){
            openedCodex.SetActive(false);
            closedCodex.SetActive(true);
        } else if (closedCodex.activeSelf) {
            closedCodex.SetActive(false);
            openedCodex.SetActive(true);
        }
    }

    //Check if the codex is open
    public bool CodexOpen(){
        return openedCodex.activeSelf;
    }
}
