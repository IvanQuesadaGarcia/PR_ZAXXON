using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Variables para el movimiento de la nave.
    [SerializeField] Vector3 playerPosition = new Vector3(0f, 0f, 0f);
    [SerializeField] float desplSpeed;
    [SerializeField] Transform nave;
 
    //Variables de restriccion.
    float limiteR = 57f;
    float limiteL = -57f;
    float limiteU = 40f;
    float limiteD = 0f;

    //booleanas para saber si puedo moverme.
    bool inLimitH = true;
    bool inLimitV = true;

    InitGameScript initGameScript;

    [SerializeField] GameObject expl;

    //Audio
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioSource audioSourceBG;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = playerPosition;

        desplSpeed = 70f;

        initGameScript = GameObject.Find("InitGame").GetComponent<InitGameScript>();
    }

    // Update is called once per frame
    void Update()
    {
        Movimiento();
    }

    // Método para el movimiento
    void Movimiento()
    {
        //variables de los ejes de movimiento.
        float desplH = Input.GetAxis("Horizontal");
        float desplV = Input.GetAxis("Vertical");

        //Variables de posición para restringir.
        float posX = transform.position.x;
        float posY = transform.position.y;        

        //Movimiento restringido.
        if (posX > limiteR && desplH > 0 || posX < limiteL && desplH < 0)
        {
            inLimitH = false;
        }
        else
        {
            inLimitH = true;
        }

        if (inLimitH)
        {
            transform.Translate(Vector3.right * Time.deltaTime * desplH * desplSpeed, Space.World);
        }

        if (posY > limiteU && desplV > 0 || posY < limiteD && desplV < 0)
        {
            inLimitV = false;
        }
        else
        {
            inLimitV = true;
        }

        if (inLimitV)
        {
            transform.Translate(Vector3.up * Time.deltaTime * desplV * desplSpeed, Space.World);
        }

        //Rotación 
        transform.Rotate(Vector3.forward * Time.deltaTime * 50f, Space.Self);
        transform.rotation = Quaternion.Euler(-50 * desplV, 0, -30 * desplH);     
    }

    void PararMusica()
    {
        audioSourceBG.Stop();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 6)
        {
            audioSource.Play();
            initGameScript.SendMessage("Morir");
            Instantiate(expl, new Vector3(nave.position.x, nave.position.y, nave.position.z), Quaternion.identity);
            Invoke("PararMusica", 2f);
        }
    }
}
