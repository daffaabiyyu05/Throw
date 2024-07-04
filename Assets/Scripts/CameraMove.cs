using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField] float rotationX = 0;
    [SerializeField] float rotationY = 0;

    float sensitivity = 1f;

    // Update is called once per frame
    void Update()
    {
        rotationX -= Input.GetAxis("Vertical") * sensitivity;
        rotationY += Input.GetAxis("Horizontal") * sensitivity;

        rotationX = Mathf.Clamp(rotationX, -90f, 90f);
        rotationY = Mathf.Clamp(rotationY, -60f, 60f);
        transform.localEulerAngles = new Vector3(rotationX, rotationY, 0);
    }
}
