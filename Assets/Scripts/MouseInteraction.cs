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
            LayerMask ingredientsLayer = (1<<10);
            Collider2D targetObject = Physics2D.OverlapPoint(mousePosition, ingredientsLayer);
            //If we have clicked on an ingredient, we save its initial position for later and we set it as the selected object
            if (targetObject)
            {
                selectedObject = targetObject.transform.gameObject;
                initalObjectPosition = targetObject.transform.position;
                offset = selectedObject.transform.position - mousePosition;
            }
        }

        //If we have an ingredient selected we make it follow the mouse position
        if (selectedObject)
        {
            selectedObject.transform.position = mousePosition;
        }

        //If we un-click and have a selected ingredient, we check if we are overlapping the cauldron collider
        if (Input.GetMouseButtonUp(0) && selectedObject)
        {
            LayerMask cauldronLayer = (1<<9);
            Collider2D targetObject = Physics2D.OverlapPoint(mousePosition, cauldronLayer);
            //If we are overlapping with the cauldron, we add the ingredient to its script, and we move back the 
            //ingredient to its initial position
            if (targetObject){
                //If the cauldron doesn't already have this ingredient it adds it to its mix
                if (cauldron.Add(selectedObject.name)){
                    Debug.Log("Ingredient " + selectedObject.name + " added to the Cauldron !");
                    //Play animation for ingredient added
                }
                selectedObject.transform.position = initalObjectPosition;
                selectedObject = null;
            } else {
                selectedObject.transform.position = initalObjectPosition;
                selectedObject = null;
            }
        }
    }
}
