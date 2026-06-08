using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Camera : MonoBehaviour
{

    private float YMin = -50f;
    private float YMax = 50f;
    private float YPos = 3f;

    public Transform lookAt;
    public Transform player;
    public float distance = 10.0f;
    private float currentX = 0.0f;
    private float currentY = 0.0f;
    public float sens = 50.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transform.position = new Vector3(0, 3, -3);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        currentX += Input.GetAxis("Mouse X") * sens * Time.deltaTime;
        currentY += Input.GetAxis("Mouse Y") * sens * Time.deltaTime;

        currentY = Mathf.Clamp(currentY, YMin, YMax);

        Vector3 dir = new Vector3(0, 0, -distance);
        Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);

        transform.position = new Vector3(lookAt.position.x, YPos, lookAt.position.z) + rotation * dir;
        transform.position = new Vector3(transform.position.x, YPos, transform.position.z);

        transform.LookAt(lookAt.position);
    }
}
