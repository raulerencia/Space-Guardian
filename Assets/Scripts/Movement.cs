using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Rigidbody rb;
    public float speed;
    public float rotationSpeed;
    public GameObject planet;
    
    private Vector3 directionForward;
    private float horizontal;
    private float vertical;
    private Vector3 directionSides;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    private void Update() {
        /*horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        directionSides = new Vector3(horizontal,0f,0f);*/
        var heading = planet.transform.position - this.transform.position;
        var distance = heading.magnitude;
        Debug.Log(distance);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        directionForward = transform.forward;

        Quaternion upRotation = Quaternion.FromToRotation(transform.up, -transform.position);
        Quaternion newRotation = Quaternion.Slerp(rb.rotation, upRotation * rb.rotation, Time.fixedDeltaTime * speed);
        rb.MoveRotation(newRotation);
        
        rb.MovePosition(transform.position + directionForward * Time.deltaTime * speed);
        
    }

}
