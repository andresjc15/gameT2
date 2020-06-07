using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MovimientoPersonaje : MonoBehaviour
{

    public float velocidad;
    public int numeroBonus = 0;
    private bool cogioBonus = false;
    public int vida;

    // Start is called before the first frame update
    void Start()
    {
        vida = 5;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Input.GetAxis("Horizontal")*velocidad, 0, Input.GetAxis("Vertical")*velocidad);
        transform.Rotate(0, Input.GetAxis("Mouse X"), 0);
    }


private void OnCollisionEnter(Collision collision)
    {
/*
        if (collision.collider.tag == "bono") {
               //SceneManager.LoadScene(0);
            Debug.Log("Cajas recolectadas: " + numeroBonus);      
           //FindObjectOfType<interfazJuego>().recibirGolpe();


           //transform.Translate(13, 1, 43);

        }*/

        if (collision.collider.tag == "gemaover2") {
               //SceneManager.LoadScene(0);    
           //FindObjectOfType<interfazJuego>().recibirGolpe();
           vida--;
           

            if(vida==0){
                SceneManager.LoadScene(3);
            }
            Debug.Log("colisiono con personaje"+vida);  

           transform.position = new Vector3(12, 1.5f, 30);

           //transform.Translate(13, 1, 43);

        }
        
                StartCoroutine(desactivarColision());
            }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "bono")
        {
            Destroy(other.gameObject);
            if(cogioBonus == false)
            {
                cogioBonus = true;
                numeroBonus = numeroBonus + 1;

                Debug.Log("Puntos: " + numeroBonus);
                StartCoroutine(activarBonus());
            if(numeroBonus==3){
  Debug.Log("Ganaste");
  SceneManager.LoadScene(1);


            }

            }

        }
    }

    IEnumerator desactivarColision()
    {
        yield return new WaitForSeconds(0.1f);
        //colisionoBala = false;
    }

     IEnumerator activarBonus()
    {
        yield return new WaitForSeconds(0.1f);
        cogioBonus = false;
    }

}