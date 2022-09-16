using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cauldron : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> animalList; 

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
            //TODO ADD "ADD" ANIMATION
            //If we have 3 ingredients in the cauldron we create the mix 
            if (ingredientList.Count == 3){
                CreateMix();
            }
            return true;
        }
        return false;
    }

    private void CreateMix(){

        //TODO ADD MIX ANIMATION
        GameObject animalMix = null;
        foreach (var animal in animalList)
        {
            if (CompareLists(animal.GetComponent<Animal>().GetIngredientsNeeded(),ingredientList)){
                animalMix = animal;
                break;
            }
        }
        if (animalMix){
            SpawnAnimal(animalMix);
        } else {
            Debug.Log("Not a correct mix !");
            //TODO CREATE "EMPTY MIX" ANIMATION
        }
        ingredientList.Clear();
    }

    private bool CompareLists(List<string> animalIngredients, List<string> cauldronIngredients){
        for (int i = 0; i < cauldronIngredients.Count; i++)        {
            if (!cauldronIngredients.Contains(animalIngredients[i]))
                return false;
        }
        return true;

    }

    private void SpawnAnimal(GameObject animalToSpawn){
        //TODO ADD SPAWN ANIMATION
        if (animalToSpawn.activeSelf){
            //TODO ADD ANIMATION OF ANIMAL ALREADY THERE
            Debug.Log("Animal already here !");
        } else {
            animalToSpawn.SetActive(true);
        }
    }
}
