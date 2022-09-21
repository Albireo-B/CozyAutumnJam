using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseInteraction : MonoBehaviour
{

    private GameObject selectedObject;
    private Vector3 offset;
    private Vector3 initalObjectPosition;
    private Cauldron cauldron;

    void Start() {
        cauldron = GetComponent<Cauldron>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //If we click with the left-click
        if (Input.GetMouseButtonDown(0))
        {
            //We check if we are in contact with an ingredient collider on their layer
            LayerMask interactableLayer = (1<<10);
            Collider2D targetObject = Physics2D.OverlapPoint(mousePosition, interactableLayer);
            //If we have clicked on an ingredient, we save its initial position for later and we set it as the selected object
            if (targetObject)
            {
                selectedObject = targetObject.transform.gameObject;
                //If we clicked on an ingredient we save its position and mouse offset
                if (selectedObject.tag == "Ingredient"){
                    initalObjectPosition = targetObject.transform.position;
                    offset = selectedObject.transform.position - mousePosition;
                //If we clicked on the codex, we open or close it and reset the selectedObject
                } else if (selectedObject.tag == "Codex"){
                    GetComponent<Codex>().OpenOrCloseCodex();
                    selectedObject = null;
                } else if (selectedObject.tag == "MainMenu"){
                        Debug.Log("Go to main menu");//TODO GO TO MAIN MENU 
                        selectedObject = null;
                }else if (selectedObject.tag == "Serpent"){
                    selectedObject = GetComponent<Cauldron>().GetMueSerpent();
                    selectedObject.SetActive(true);
                    initalObjectPosition = selectedObject.transform.position;
                    offset = selectedObject.transform.position - mousePosition;
                } else if (selectedObject.tag == "Diablotin"){
                    selectedObject = GetComponent<Cauldron>().GetChocolate();
                    selectedObject.SetActive(true);
                    initalObjectPosition = selectedObject.transform.position;
                    offset = selectedObject.transform.position - mousePosition;
                }
            } 
        }

        //If we have an ingredient selected we make it follow the mouse position
        if (selectedObject)
        {
            if (GetComponent<Codex>().CodexOpen())
                GetComponent<Codex>().OpenOrCloseCodex();
            selectedObject.transform.position = mousePosition;
        }

        //If we un-click and have a selected ingredient, we check if we are overlapping the cauldron collider
        if (Input.GetMouseButtonUp(0) && selectedObject)
        {
            LayerMask cauldronLayer = (1<<9);
            Collider2D targetObject = Physics2D.OverlapPoint(mousePosition, cauldronLayer);
            
            if (selectedObject.name == "MueSerpent" || selectedObject.name == "Chocolate")
                selectedObject.SetActive(false);
                
            //If we are overlapping with the cauldron, we add the ingredient to its script, and we move back the 
            //ingredient to its initial position
            if (targetObject){
                //If the cauldron doesn't already have this ingredient it adds it to its mix
                cauldron.Add(selectedObject);
                selectedObject.transform.position = initalObjectPosition;
                selectedObject = null;
            } else {
                selectedObject.transform.position = initalObjectPosition;
                selectedObject = null;
            }

        }
    }

}
