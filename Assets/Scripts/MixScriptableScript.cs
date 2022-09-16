using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "IngredientMixes", menuName = "CozyAutumnJam/IngredientMixes", order = 0)]
public class MixScriptableScript : ScriptableObject 
{

    public List<GameObject> ingredients;
    //public List<GameObject> rareIngredients;

    public List<GameObject> animals;

}
