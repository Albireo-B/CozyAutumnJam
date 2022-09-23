using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Codex : MonoBehaviour
{
    [SerializeField]
    private GameObject openedCodex;
    [SerializeField]
    private GameObject closedCodex;
    [SerializeField]
    private GameObject mainPage;

    private GameObject infoDisplay;

    // Update is called once per frame
    void Update()
    {
        Transform targetObject = null;

        //We check if we are in contact with an object collider on their layer
        RaycastHit hit;
        Vector3 hitPoint = Vector3.zero;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        LayerMask interactableLayer = (1 << 11);
        if (Physics.Raycast(ray, out hit, 50000, interactableLayer))
        {
            targetObject = hit.transform;
            hitPoint = hit.point;
            hitPoint.z = 0;
        }


        if (CodexOpen()){
        
            //If the mouse is hovering a codex animal
            if (targetObject){
                GameObject selectedObject = targetObject.gameObject;
                if (selectedObject.tag == "CodexAnimal")
                    DisplayAnimalInfos(selectedObject);
            } else {
                if (infoDisplay)
                    infoDisplay.SetActive(false);
                mainPage.SetActive(true);
            }
        }
    }

    private void DisplayAnimalInfos(GameObject animal){
        mainPage.SetActive(false);
        if (infoDisplay)
            infoDisplay.SetActive(false);
        infoDisplay = animal.transform.GetChild(2).gameObject;
        infoDisplay.SetActive(true);
    }

    //We open or close the corresponding codex depending if its visible/active
    public void OpenOrCloseCodex() {
        if (openedCodex.activeSelf){
            if (!GetComponent<Cauldron>().GetDiablotinSpawned())
                GetComponent<MouseInteraction>().DisableIngredientsInteractions(false);
            if (infoDisplay)
                infoDisplay.SetActive(false);
            openedCodex.SetActive(false);
            closedCodex.SetActive(true);
        } else if (closedCodex.activeSelf) {
            GetComponent<MouseInteraction>().DisableIngredientsInteractions(true);
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
