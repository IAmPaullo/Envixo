using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraDrag : MonoBehaviour
{

    float panSpeed = 10f;
    Vector3 startPos;
    [SerializeField]
    float horizontalSpeed, verticalSpeed;

    [SerializeField]
    CinemachineFreeLook cameraFreeLook;

    [SerializeField]
    Transform camera;


    private void Start()
    {

    }

    private void Update()
    {
        //MousePan();
        Cinema();
    }

    void MousePan()
    {
        if (Input.GetMouseButton(1))
        {

            Vector3 newPosition = new Vector3();
            newPosition.y = Input.GetAxis("Mouse X") * panSpeed * Time.deltaTime;
            newPosition.x = Input.GetAxis("Mouse Y") * panSpeed * Time.deltaTime;

            //transform.Translate(-newPosition);
            transform.Rotate(newPosition);

        }

        if (Input.GetMouseButtonDown(0))
        {
            startPos = Input.mousePosition;

        }
        if (Input.GetMouseButton(0))
        {
            Vector3 velocity = Input.mousePosition - startPos;
            velocity = new Vector2(velocity.y, velocity.x);

            Debug.Log(velocity);


            transform.eulerAngles = new Vector3(Mathf.Clamp(transform.eulerAngles.x, -90, 90), transform.eulerAngles.y, transform.eulerAngles.z);
            transform.Rotate(velocity * Time.deltaTime * panSpeed);


        }

    }



    public void Cinema()
    {
        if (Input.GetMouseButton(0))
        {
            cameraFreeLook.m_XAxis.m_MaxSpeed = horizontalSpeed;
            cameraFreeLook.m_YAxis.m_MaxSpeed = verticalSpeed;
        }
        else
        {
            cameraFreeLook.m_XAxis.m_MaxSpeed = 0;
            cameraFreeLook.m_YAxis.m_MaxSpeed = 0;
        }

        if (Input.GetMouseButton(1))
        {

            Vector3 newPosition = new Vector3();
            newPosition.x = Input.GetAxis("Mouse X");
            newPosition.y = Input.GetAxis("Mouse Y");

            transform.position += camera.right * newPosition.x * panSpeed * Time.deltaTime;
            transform.position += camera.up * newPosition.y * panSpeed * Time.deltaTime;

        }

    }




}
