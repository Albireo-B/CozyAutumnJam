using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cauldron : MonoBehaviour
{
    private IngredientMap ingredientMap; 

    private List<string> ingredientList;

    // Start is called before the first frame update
    void Start()
    {
        ingredientList = new List<string>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool Add(string ingredientName){
        if (!ingredientList.Contains(ingredientName)){
            ingredientList.Add(ingredientName);
            //if list size = 3 then mix !
            return true;
        }
        return false;
    }
}
