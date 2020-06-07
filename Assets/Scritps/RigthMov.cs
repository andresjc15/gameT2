using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigthMov : MonoBehaviour
{
    public GameObject cubo;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.LookAt(cubo.transform);
        GetComponent<Rigidbody>().velocity = transform.right;
        
    }
}
