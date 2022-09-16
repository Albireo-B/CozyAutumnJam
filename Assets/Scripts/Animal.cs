using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> ingredientsNeeded;

    public List<string> GetIngredientsNeeded() {
        List<string> ingredientNamesList = new List<string>();
        foreach (var ingredient in ingredientsNeeded)
        {
            ingredientNamesList.Add(ingredient.name);
        }
        return ingredientNamesList;
    }
}
