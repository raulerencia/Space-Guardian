using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class myBullet : MonoBehaviour
{
    public GameObject autoAimObject;

    public int velocity = 20;
    
    // Start is called before the first frame update
    void Start()
    {
        autoAimObject = GameObject.Find("Nave");
        autoAim autoAim = autoAimObject.GetComponent<autoAim>();

        Rigidbody rb = GetComponent<Rigidbody>();

        if(autoAim.hit.transform.gameObject.tag.Equals("autoAim")){
            Vector3 heading = autoAim.target.position - this.transform.position;

            rb.velocity =  heading.normalized * velocity;
        }else{
            //rb.velocity =  autoAimObject.transform..normalized * velocity;
        }

        
    }

}
