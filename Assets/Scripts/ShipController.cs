using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ShipController : MonoBehaviour
{
    public GameObject shipBody;
    public float velocity = 60f;
    public float turn = 90f;
    public float inputHorizontal, inputVertical;


    // Update is called once per frame
    void FixedUpdate()
    {
        //Avance fijo hacia adelante
        transform.Translate(Vector3.forward * velocity * Time.deltaTime);

        transform.Rotate(Vector3.up * inputHorizontal * turn * Time.deltaTime, Space.World);

        transform.Rotate(Vector3.right * inputVertical * turn * Time.deltaTime * 2);

        if (shipBody.transform.localRotation.z > -0.6f && shipBody.transform.localRotation.z < 0.6f)
        {
            shipBody.transform.Rotate(Vector3.forward * inputHorizontal * -turn * Time.deltaTime * 2);
        }
        
        if (inputHorizontal == 0)
        {
            shipBody.transform.rotation = Quaternion.Slerp(shipBody.transform.rotation, transform.rotation, 0.05f);
        }
    }

    private void OnMove(InputValue valor)
    {
       inputHorizontal = valor.Get<Vector2>().x;
       inputVertical = valor.Get<Vector2>().y;
    }
}
