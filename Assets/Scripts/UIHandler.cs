using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIHandler : MonoBehaviour
{
    public PrefabTypeSO[] activePrefab;

    [SerializeField]
    Camera cameraObj;

    //[SerializeField]
    //Transform objBtnHolder;

    GameObject objectToSpawn;
    private Vector3 placeableObjPos;

    public bool isSpawn = false;



    public void SelectedObject(int index)
    {
        objectToSpawn = activePrefab[index].primitiveObject;
    }

    private void Update()
    {
        InputButtonHandler();

    }

    public void InputButtonHandler()
    {
        if (Input.GetMouseButtonDown(0) && isSpawn && !EventSystem.current.IsPointerOverGameObject())
        {
            ObjectToMousePos();
        }
    }


    private Vector3 GetMouseWorldPos()
    {
        Vector3 mouseWorldPosition = cameraObj.WorldToScreenPoint(Input.mousePosition);

        return mouseWorldPosition;
    }

    private void ObjectToMousePos()
    {
        Ray ray = cameraObj.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;

        if (Physics.Raycast(ray, out hitInfo))
        {
            placeableObjPos = hitInfo.point;
            Debug.Log(hitInfo.transform.name);

            Instantiate(objectToSpawn, placeableObjPos, Quaternion.FromToRotation(Vector3.up, hitInfo.normal));
        }


    }
}
