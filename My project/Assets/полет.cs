using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class полет : MonoBehaviour
{
    public float rotationSpeed = 5f;
    public float speed = 5f;
    public float speedmouse = 10f;

    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;

    }

    // Update is called once per frame
    void Update()
    {


        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");


        // ѕолучаем значени€ движени€ мыши по ос€м
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");
        transform.Rotate(Vector3.up, mouseX * speedmouse, Space.World);
        // transform.Rotate(Vector3.left, mouseY * speedmouse, Space.Self);
        Vector3 movement = new Vector3(0f, 0f, vertical) * speed * Time.deltaTime;
        transform.Translate(movement);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = Vector3.zero;
        }


    }
}
