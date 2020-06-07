using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class movEnemigo : MonoBehaviour
{
    public float velocidad;
    public float x;
    public float y;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("girar", x, y);
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Rigidbody>().velocity = transform.right * velocidad;
    }

    void girar()
    {

        transform.Rotate(0,180,0);

    }

}
