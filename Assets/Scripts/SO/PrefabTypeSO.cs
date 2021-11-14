using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Objeto", 
    menuName = "Objetos/Primitivas", order = 1)]
public class PrefabTypeSO : ScriptableObject
{

    public GameObject primitiveObject;
    public float weight;
}
