using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaseManager : MonoBehaviour
{
    [SerializeField]
    enum States
    {
        CameraDrag,
        SpawnObject
    }

    [SerializeField]
    CameraDrag cameraDrag;
    [SerializeField]
    UIHandler uiSpawner;

    private States enumStates;



    public void CaseSetup()
    {
        enumStates = default;
    }


    public void Update()
    {
        if (Input.GetKey(KeyCode.C))
        {
            enumStates = States.CameraDrag;
            FunctionCases();
        }

        if (Input.GetKey(KeyCode.O))
        {
            enumStates = States.SpawnObject;
            FunctionCases();
        }

        Debug.Log(enumStates);
    }

    public void FunctionCases()
    {
        switch (enumStates)
        {
            case States.CameraDrag:
                cameraDrag.isDrag = true;
                uiSpawner.isSpawn = false;
                break;

            case States.SpawnObject:
                cameraDrag.isDrag = false;
                uiSpawner.SelectedObject(0);
                uiSpawner.isSpawn = true;
                break;

            default:
                cameraDrag.isDrag = true;
                uiSpawner.isSpawn = false;
                break;
        }
    }


}
