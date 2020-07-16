using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CameraMoveScript : MonoBehaviour
{
    public float scrollSpeed;
    public float mDelta; // Pixels. The width border at the edge in which the movement work
    Vector3 rightDir = Vector3.right;
    Vector3 upDir = Vector3.up;
    public static bool enableMovement=false;
    // Update is called once per frame
    void Update()
    {
        if (!enableMovement)
            return;

        if(Input.GetKeyDown(KeyCode.R))
        {
            transform.position =new Vector3(0,0,transform.position.z);
        }
        if (Input.mousePosition.x >= Screen.width - mDelta)
        {
            // Move the camera
            transform.position += rightDir * Time.deltaTime * (Input.mousePosition.x-Screen.width+mDelta);
        }
        if (Input.mousePosition.x <=  mDelta)
        {
            // Move the camera
            transform.position += rightDir * Time.deltaTime * (Input.mousePosition.x- mDelta);
        }
        if (Input.mousePosition.y >= Screen.height - mDelta)
        {
            // Move the camera
            transform.position += upDir * Time.deltaTime * (Input.mousePosition.y - Screen.height + mDelta);
        }
        if (Input.mousePosition.y <= mDelta)
        {
            // Move the camera
            transform.position += upDir * Time.deltaTime * (Input.mousePosition.y- mDelta);
        }
        gameObject.GetComponent<Camera>().orthographicSize -= Input.mouseScrollDelta.y * Time.deltaTime * scrollSpeed;
    }
}
