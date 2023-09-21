using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControler : MonoBehaviour
{
    private Vector2 rot;
    private float zoom;

    [SerializeField]
    private float speed;

    [SerializeField]
    private float sensitivity;

    [SerializeField]
    private float sensitivityZoom;

    [SerializeField]
    private Transform cameraHolder;

    [SerializeField]
    private Transform cameraTransform;
    // Start is called before the first frame update
    void Start()
    {
        zoom = cameraTransform.position.z;
        //Debug.Log(zoom);
    }

    // Update is called once per frame
    void Update()
    {
        MakeMove();
        RotateCamera();
        ZoomCamera();
    }

    void MakeMove()
    {
        var forward = Input.GetAxisRaw("Vertical"); // -1, 0, 1
        var sides = Input.GetAxisRaw("Horizontal"); // -1, 0, 1
        
        Vector3 localVelocity = (new Vector3(sides, 0, forward)).normalized * speed * Time.deltaTime;
        var transformed = transform.TransformDirection(localVelocity);

        //rb.velocity = new Vector3(transformed.x, 0, transformed.z);
        transform.position = new Vector3(transform.position.x + transformed.x, 0, transform.position.z + transformed.z);
    }

    void RotateCamera()
    {
        if (Input.GetKey(KeyCode.LeftAlt))
        {
            Cursor.lockState = CursorLockMode.Locked;
            rot.x += Input.GetAxis("Mouse X") * sensitivity;
            rot.y += Input.GetAxis("Mouse Y") * sensitivity;

            if (rot.y > 90)
                rot.y = 90;

            if (rot.y < -90)
                rot.y = -90;

            transform.rotation = Quaternion.Euler(0, rot.x, 0);
            cameraHolder.localRotation = Quaternion.Euler(-rot.y, 0, 0);
        }
        else
        {
            Cursor.lockState = CursorLockMode.Confined;
        }
    }

    void ZoomCamera()
    {
        cameraTransform.localPosition = new Vector3(cameraTransform.localPosition.x, cameraTransform.localPosition.y, cameraTransform.localPosition.z + Input.mouseScrollDelta.y);

        if(cameraTransform.localPosition.z > 0)
        cameraTransform.localPosition = new Vector3(cameraTransform.localPosition.x, cameraTransform.localPosition.y, 0);
    }
}
