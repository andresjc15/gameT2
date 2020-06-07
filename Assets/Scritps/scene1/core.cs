using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class core : MonoBehaviour
{
    public float velocidad;
    public int vida;
    public int numeroBonus = 0;
    private bool cogioBonus = false;
    // Start is called before the first frame update
    void Start()
    {
        vida = 3;
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.Translate(Input.GetAxis("Horizontal")*velocidad, 0, Input.GetAxis("Vertical")*velocidad);
        
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.collider.tag == "gameover") {
               //SceneManager.LoadScene(0);
                
           //FindObjectOfType<interfazJuego>().recibirGolpe();

           vida--;
           

            if(vida==0){
                SceneManager.LoadScene(3);
            }
Debug.Log("colisiono con personaje"+vida);  
           transform.position = new Vector3(13, 1, 43);

           //transform.Translate(13, 1, 43);

        }
        
                StartCoroutine(desactivarColision());
            }

    IEnumerator desactivarColision()
    {
        yield return new WaitForSeconds(0.1f);
        //colisionoBala = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag =="bonus")
        {
            Debug.Log("Ganaste");
            //GetComponent<AudioSource>().Play();
             
            Destroy(other.gameObject);
            SceneManager.LoadScene(2);
            if(cogioBonus==false){
                cogioBonus=true;
           
               StartCoroutine(activarBonus());
            }
           
           


        }
    }

      IEnumerator activarBonus()
    {
        yield return new WaitForSeconds(0.1f);
        cogioBonus = false;
    }
}
