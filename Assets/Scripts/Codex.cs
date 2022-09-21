using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Codex : MonoBehaviour
{
    [SerializeField]
    private GameObject openedCodex;
    [SerializeField]
    private GameObject closedCodex;

    private GameObject infoDisplay;

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (CodexOpen()){
            LayerMask interactableLayer = (1<<11);
            Collider2D targetObject = Physics2D.OverlapPoint(mousePosition, interactableLayer);
            //If the mouse is hovering a codex animal
            if (targetObject){
                DisplayAnimalInfos(targetObject.transform.gameObject);
            }
        }
    }

    private void DisplayAnimalInfos(GameObject animal){
        if (infoDisplay)
            infoDisplay.SetActive(false);
        infoDisplay = animal.transform.GetChild(2).gameObject;
        infoDisplay.SetActive(true);
    }

    //We open or close the corresponding codex depending if its visible/active
    public void OpenOrCloseCodex() {
        if (openedCodex.activeSelf){
            if (infoDisplay)
                infoDisplay.SetActive(false);
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

    public void CheckAnimal(string animalName){
        GameObject animalToCheck = openedCodex.transform.Find(animalName).gameObject;
        if (animalToCheck){
            animalToCheck.transform.GetChild(0).gameObject.SetActive(true);
        }
    }

}
