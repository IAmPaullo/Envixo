using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class UIHandler : MonoBehaviour
{
    [SerializeField]
    public PrefabTypeSO prefab;

    [SerializeField]
    Camera cameraObj;



    Vector3 placeableObjPos = new Vector3(10, 0, 0);


    private void Update()
    {
        InputButtonHandler();
    }

    public void InputButtonHandler()
    {
        if (Input.GetMouseButtonDown(0))
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

        if(Physics.Raycast(ray, out hitInfo))
        {
            placeableObjPos = hitInfo.point;
            Debug.Log(hitInfo.transform.name);
            Instantiate(prefab.primitiveObject, placeableObjPos, Quaternion.FromToRotation(Vector3.up, hitInfo.normal));
        }
        

    }
}
