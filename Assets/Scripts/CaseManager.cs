using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CaseManager : MonoBehaviour
{
    [SerializeField]
    enum States
    {
        CameraDrag,
        SpawnObject,
        SelectObject
    }

    [SerializeField]
    CameraDrag cameraDrag;
    [SerializeField]
    UIHandler uiSpawner;
    [SerializeField]
    SelectCustomObject customizeObj;

    [SerializeField]
    GameObject objectsButton, materialButton;

    [SerializeField] GameObject btnCamera, btnClick, btnSpawn;

    private States enumStates;



    public void CaseSetup()
    {
        enumStates = default;
    }


    public void Update()
    {
        if (Input.GetKey(KeyCode.C) || Input.GetKey(KeyCode.Alpha1) || Input.GetKey(KeyCode.Keypad1))
        {
            enumStates = States.CameraDrag;
            FunctionCases();
        }

        if (Input.GetKey(KeyCode.O) || Input.GetKey(KeyCode.Alpha2) || Input.GetKey(KeyCode.Keypad2))
        {
            enumStates = States.SpawnObject;
            FunctionCases();
        }

        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.Alpha3) || Input.GetKey(KeyCode.Keypad3))
        {
            enumStates = States.SelectObject;
            FunctionCases();
        }

        Debug.Log(enumStates);
    }

    public void FunctionCases()
    {
        switch (enumStates)
        {
            default:
                btnCamera.SetActive(true);
                btnClick.SetActive(false);
                btnSpawn.SetActive(false);
                materialButton.SetActive(false);
                objectsButton.SetActive(false);
                //cameraDrag.isDrag = true;
                uiSpawner.isSpawn = false;
                customizeObj.isSelection = false;
                customizeObj.selectedObject = null;
                break;

            case States.CameraDrag:
                btnCamera.SetActive(true);
                btnClick.SetActive(false);
                btnSpawn.SetActive(false);
                cameraDrag.isDrag = true;
                uiSpawner.isSpawn = false;
                customizeObj.isSelection = false;
                materialButton.SetActive(false);
                objectsButton.SetActive(false);
                customizeObj.selectedObject = null;
                break;

            case States.SpawnObject:
                btnSpawn.SetActive(true);
                btnCamera.SetActive(false);
                btnClick.SetActive(false);
                uiSpawner.isSpawn = true;
                uiSpawner.SelectedObject(0);
                objectsButton.SetActive(true);
                materialButton.SetActive(false);
                cameraDrag.isDrag = false;
                customizeObj.isSelection = false;
                customizeObj.selectedObject = null;
                break;

            case States.SelectObject:
                btnClick.SetActive(true);
                btnCamera.SetActive(false);
                btnSpawn.SetActive(false);
                customizeObj.isSelection = true;
                materialButton.SetActive(true);
                objectsButton.SetActive(false);
                cameraDrag.isDrag = false;
                uiSpawner.isSpawn = false;
                break;


        }
    }


}
