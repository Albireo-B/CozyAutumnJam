using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cauldron : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> animalList; 

    [SerializeField]
    private GameObject mueSerpent;
    [SerializeField]
    private GameObject chocolate;
    [SerializeField]
    private GameObject cholocateMixVariations;

    private List<GameObject> ingredientList;
    private GameObject chocolateColor;
    private bool diablotinSpawned;

    // Start is called before the first frame update
    void Start()
    {
        diablotinSpawned = false;
        ingredientList = new List<GameObject>();
    }

    public bool Add(GameObject ingredient){
        if (!ingredientList.Contains(ingredient)){
            ingredient.SetActive(false);
            ingredientList.Add(ingredient);
            if (ingredient.name == "Chocolate")
                GetComponent<MouseInteraction>().EndGame();
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
        List<string> ingredientsListNames = new List<string>();
        foreach (var ingredient in ingredientList)
        {
            ingredientsListNames.Add(ingredient.name);
        }

        foreach (var animal in animalList)
        {
            if (CompareLists(animal.GetComponent<Animal>().GetIngredientsNeeded(), ingredientsListNames)){
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
        ResetIngredientsUsed();
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
            GetComponent<Codex>().CheckAnimal(animalToSpawn.name);
            DisplayChocolate(animalToSpawn.name);
            //If the spawning animal is the diablotin, we stop the ingredient mixing possibility
            if (animalToSpawn.name == "Diablotin"){
                diablotinSpawned = true;
                GetComponent<MouseInteraction>().DisableIngredientsInteractions(true);
            }
        }
    }

    public void DisplayChocolate(string animalName){
        if (chocolateColor)
            chocolateColor.SetActive(false);
        chocolateColor = cholocateMixVariations.transform.Find(animalName).gameObject;
        chocolateColor.SetActive(true);
    }

    private void ResetIngredientsUsed(){
        foreach (var ingredient in ingredientList)
        {
            if (ingredient.name != "MueSerpent")
                ingredient.SetActive(true);
        }
        ingredientList.Clear();
    }


    public bool GetDiablotinSpawned(){
        return diablotinSpawned;
    }

    public GameObject GetMueSerpent(){
        return mueSerpent;
    }

    public GameObject GetChocolate(){
        return chocolate;
    }
}
