using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectCustomObject : MonoBehaviour
{
    //[HideInInspector]
    public GameObject selectedObject;
    string gameObjectTag = "Object";
    public bool isSelection;
    Camera cameraObj;

    [SerializeField]
    float multiplier = 1;

    [SerializeField]
    Material[] selectedMaterial;
    Material materialToApply;

    private void Awake()
    {
        cameraObj = Camera.main;
    }

    public void SelectedColor(int index)
    {
        materialToApply = selectedMaterial[index];
    }

    private void Update()
    {
        SelectObject();
        RotateObject();
        DeleteObject();
        MoveObjectAxis();

    }

    private void SelectObject()
    {
        if (Input.GetMouseButton(0) && isSelection)
        {
            Ray ray = cameraObj.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;

            if (Physics.Raycast(ray, out hitInfo))
            {
                if (hitInfo.transform.tag == gameObjectTag)
                {
                    selectedObject = hitInfo.transform.gameObject;
                }
            }
        }
    }

    private void DeleteObject()
    {
        if (Input.GetKeyDown(KeyCode.Delete) && selectedObject != null)
        {
            selectedObject.SetActive(false);
            selectedObject = null;
        }
    }

    private void RotateObject()
    {
        if (selectedObject != null)
        {
            float mouseWheelRot = Input.mouseScrollDelta.y;
            selectedObject.transform.Rotate(Vector3.up, mouseWheelRot * 10f);
        }

    }

    public void ButtonConfigCustomization()
    {
        selectedObject.GetComponent<MeshRenderer>().material = materialToApply;
    }


    public void MoveObjectAxis()
    {
        if (Input.GetKey(KeyCode.LeftArrow) && selectedObject != null)
        {
            selectedObject.transform.position += Vector3.left * multiplier * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.UpArrow) && selectedObject != null)
        {
            selectedObject.transform.position += Vector3.up * multiplier * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.RightArrow) && selectedObject != null)
        {
            selectedObject.transform.position += Vector3.right * multiplier * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.DownArrow) && selectedObject != null &&
            selectedObject.transform.position.y >= 0)
        {
            selectedObject.transform.position += Vector3.down * multiplier * Time.deltaTime;
            if (selectedObject.transform.position.y < 0)
                selectedObject.transform.position = new Vector3(selectedObject.transform.position.x, 0, 
                    selectedObject.transform.position.z);
        }
    }


}
