using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseInteraction : MonoBehaviour
{

    private GameObject selectedObject;
    private Vector3 offset;
    private Vector3 initalObjectPosition;

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButtonDown(0))
        {
            Collider2D targetObject = Physics2D.OverlapPoint(mousePosition);

            if (targetObject && targetObject.transform.gameObject.tag == "Ingredient")
            {
                selectedObject = targetObject.transform.gameObject;
                initalObjectPosition = targetObject.transform.position;
                offset = selectedObject.transform.position - mousePosition;
            }
        }

        if (selectedObject)
        {
            selectedObject.transform.position = mousePosition;
        }

        if (Input.GetMouseButtonUp(0) && selectedObject)
        {
            Collider2D targetObject = Physics2D.OverlapPoint(mousePosition);
            if (targetObject && targetObject.transform.gameObject.tag == "Cauldron"){
                GetComponent<Cauldron>().Add(selectedObject.name);
                selectedObject = null;
            } else {
                selectedObject.transform.position = initalObjectPosition;
                selectedObject = null;
            }
        }
    }
}
