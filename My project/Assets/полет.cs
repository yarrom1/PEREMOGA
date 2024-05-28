using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class полет : MonoBehaviour
{
    public float rotationSpeed = 5f;
    public float speed = 5f;
    public float speedmouse = 10f;

    Rigidbody rb;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;

    }

    void Update()
    {


        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");



        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");
        transform.Rotate(Vector3.up, mouseX * speedmouse, Space.World);

        Vector3 movement = new Vector3(0f, 0f, vertical) * speed * Time.deltaTime;
        transform.Translate(movement);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = Vector3.zero;
        }
    }
    public void IncreaseSpeed(float amount)
    {
        speed += amount;
    }
}
