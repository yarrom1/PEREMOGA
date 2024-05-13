using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fly : MonoBehaviour
{
    public float speed = 5f; 
    public float rotationSpeed = 100f; 

    // Ìועמה Update גûחûגאועסÿ ךאזהûי ךאהנ
    void Update()
    {
       
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

   
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
    }
}
