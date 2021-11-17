using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraDrag : MonoBehaviour
{

    float panSpeed = 10f;
    Vector3 startPos;
    [SerializeField]
    float horizontalSpeed, verticalSpeed, zoomValue;

    [SerializeField]
    float addCameraHeightValue;

    [SerializeField]
    CinemachineFreeLook cameraFreeLook;

    [SerializeField]
    Transform cameraObj;

    float zoom = 10f;

    float topRigHeight, midRigRadius, botRigRadius;

    public bool isDrag;

    private void Update()
    {

        MouseControl();
    }

    void MousePan()
    {
        if (Input.GetMouseButton(2))
        {

            Vector3 newPosition = new Vector3();
            newPosition.y = Input.GetAxis("Mouse X") * panSpeed * Time.deltaTime;
            newPosition.x = Input.GetAxis("Mouse Y") * panSpeed * Time.deltaTime;

            //transform.Translate(-newPosition);
            transform.Rotate(newPosition);

        }

        if (Input.GetMouseButtonDown(1))
        {
            startPos = Input.mousePosition;

        }
        if (Input.GetMouseButton(1))
        {
            Vector3 velocity = Input.mousePosition - startPos;
            velocity = new Vector2(velocity.y, velocity.x);

            Debug.Log(velocity);


            transform.eulerAngles = new Vector3(Mathf.Clamp(transform.eulerAngles.x, -90, 90), transform.eulerAngles.y, transform.eulerAngles.z);
            transform.Rotate(velocity * Time.deltaTime * panSpeed);


        }

    }



    public void MouseControl()
    {
        if (isDrag)
        {
            if (Input.GetMouseButton(1))
            {
                cameraFreeLook.m_XAxis.m_MaxSpeed = horizontalSpeed;
                cameraFreeLook.m_YAxis.m_MaxSpeed = verticalSpeed;
            }
            else
            {
                cameraFreeLook.m_XAxis.m_MaxSpeed = 0;
                cameraFreeLook.m_YAxis.m_MaxSpeed = 0;
            }

        }

        MouseMoveCameraAxis();
        MouseZoom();
    }

    public void MouseMoveCameraAxis()
    {
        if (Input.GetMouseButton(2))
        {

            Vector3 newPosition = new Vector3();
            newPosition.x = Input.GetAxis("Mouse X") * -1;
            newPosition.y = Input.GetAxis("Mouse Y") * -1;

            transform.position += cameraObj.right * newPosition.x * panSpeed * Time.deltaTime;
            transform.position += cameraObj.up * newPosition.y * panSpeed * Time.deltaTime;

        }
    }

    public void MouseZoom()
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            zoom -= zoomValue;
        }
        else if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {

            zoom += zoomValue;
        }

        zoom = Mathf.Clamp(zoom, 1, 50);
        cameraFreeLook.m_Orbits[0].m_Height = zoom;
        cameraFreeLook.m_Orbits[1].m_Radius = zoom;
        cameraFreeLook.m_Orbits[2].m_Height = -zoom;
    }



}
