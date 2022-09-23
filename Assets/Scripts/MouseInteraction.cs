using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseInteraction : MonoBehaviour
{
    [SerializeField] int objectLatence;

    [SerializeField]
    private GameObject character;

    private GameObject selectedObject;
    private Vector3 offset;
    private Vector3 initalObjectPosition;
    private Cauldron cauldron;
    private Queue<Vector3> latenceQueue= new Queue<Vector3>();
    private bool ingredientsDisabled;
    private bool gameEnded;

    void Start() {
        GetComponent<CursorManager>().ChangeCursor(CursorManager.CursorStyle.BASE);
        ingredientsDisabled = false;
        gameEnded = false;
        cauldron = GetComponent<Cauldron>();
    }

    // Update is called once per frame
    void Update()
    {

        Transform targetObject = null;

        //We check if we are in contact with an object collider on their layer
        RaycastHit hit;
        Vector3 hitPoint = Vector3.zero;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        LayerMask interactableLayer = (1 << 10);
        if (Physics.Raycast(ray, out hit, 50000, interactableLayer))
        {
            targetObject = hit.transform;
            hitPoint = hit.point;
            hitPoint.z = 0;
        }

        if (!selectedObject){
            if (targetObject && targetObject.gameObject.name != "RoomBG") {
                if ((!ingredientsDisabled || targetObject.transform.gameObject.name == "Codex" 
                || targetObject.transform.gameObject.name == "MainMenu"  || targetObject.transform.gameObject.name == "Diablotin" 
                ) && !gameEnded){
                    GetComponent<CursorManager>().ChangeCursor(CursorManager.CursorStyle.INTERACT);
                } else 
                    GetComponent<CursorManager>().ChangeCursor(CursorManager.CursorStyle.BASE);
            } else {
                GetComponent<CursorManager>().ChangeCursor(CursorManager.CursorStyle.BASE);
            }
        }

        

        //If we click with the left-click
        if (Input.GetMouseButtonDown(0))
        {


            //If we have clicked on an ingredient, we save its initial position for later and we set it as the selected object
            if (targetObject && targetObject.gameObject.name != "RoomBG")
            {
                if (!ingredientsDisabled){
                    GetComponent<CursorManager>().ChangeCursor(CursorManager.CursorStyle.HOLD);
                    selectedObject = targetObject.transform.gameObject;
                    //If we clicked on an ingredient we save its position and mouse offset
                    if (selectedObject.tag == "Ingredient"){
                        initalObjectPosition = targetObject.transform.position;
                        offset = selectedObject.transform.position - hitPoint;
                    } else if (selectedObject.tag == "Serpent"){
                        selectedObject = GetComponent<Cauldron>().GetMueSerpent();
                        selectedObject.SetActive(true);
                        initalObjectPosition = selectedObject.transform.position;
                        offset = selectedObject.transform.position - hitPoint;
                    }
                }
                //If we clicked on the codex, we open or close it and reset the selectedObject
                if (targetObject.transform.gameObject.tag == "Codex"){
                    GetComponent<Codex>().OpenOrCloseCodex();
                    selectedObject = null;
                } else if (targetObject.transform.gameObject.tag == "MainMenu"){
                        Debug.Log("Go to main menu");//TODO GO TO MAIN MENU
                        selectedObject = null;
                } else if (targetObject.transform.gameObject.tag == "Diablotin" && !gameEnded){
                        GetComponent<CursorManager>().ChangeCursor(CursorManager.CursorStyle.HOLD);
                        selectedObject = GetComponent<Cauldron>().GetChocolate();
                        initalObjectPosition = selectedObject.transform.position;
                        offset = selectedObject.transform.position - hitPoint;
                        selectedObject.SetActive(true);
                }
            }
        }

        //If we have an ingredient selected we make it follow the mouse position
        if (selectedObject)
        {
            if (GetComponent<Codex>().CodexOpen())
                GetComponent<Codex>().OpenOrCloseCodex();
            //we implemente a bit of latence
            latenceQueue.Enqueue(hitPoint);
            if (latenceQueue.Count >= objectLatence)
            {

                selectedObject.transform.position = latenceQueue.Dequeue();
            }
        }

        //If we un-click and have a selected ingredient, we check if we are overlapping the cauldron collider
        if (Input.GetMouseButtonUp(0) && selectedObject)
        {
            LayerMask cauldronLayer = (1<<9);
            Collider2D targetObject2 = Physics2D.OverlapPoint(hitPoint, cauldronLayer);

            if (selectedObject.name == "MueSerpent" || selectedObject.name == "Chocolate")
                selectedObject.SetActive(false);

            //If we are overlapping with the cauldron, we add the ingredient to its script, and we move back the
            //ingredient to its initial position
            if (targetObject2){
                //If the cauldron doesn't already have this ingredient it adds it to its mix
                cauldron.Add(selectedObject);
            }
            selectedObject.transform.position = initalObjectPosition;
            selectedObject = null;
            latenceQueue.Clear();
            GetComponent<CursorManager>().ChangeCursor(CursorManager.CursorStyle.BASE);
        }
    }

    public void DisableIngredientsInteractions(bool disable){
        ingredientsDisabled = disable;
    }

    public void EndGame(){
        GetComponent<Cauldron>().DisplayChocolate("Chocolate");
        character.transform.GetChild(0).gameObject.SetActive(false);
        character.transform.GetChild(1).gameObject.SetActive(true);
        gameEnded = true;

    }
}
