using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "IngredientMixes", menuName = "CozyAutumnJam/IngredientMixes", order = 0)]
public class MixScriptableScript : ScriptableObject 
{

    public List<GameObject> ingredients;
    //public List<GameObject> rareIngredients;

    public List<GameObject> animals;

    public List<GameObject> mixes;

    public Trio trio;

    public struct Trio
    {
        int ingredient1;
        int ingredient2;
        int ingredient3;
    }


    public Dictionary<int,string> ingredientMap = new Dictionary<int,string>();
    public Dictionary<int, string> animalsMap = new Dictionary<int, string>();
    public Dictionary<int, Trio> mixesMap = new Dictionary<int, Trio>();



}
