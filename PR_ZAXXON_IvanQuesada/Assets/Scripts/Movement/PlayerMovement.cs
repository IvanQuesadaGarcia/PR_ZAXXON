using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Variables para el movimiento de la nave.
    [SerializeField] Vector3 playerPosition = new Vector3(0f, 0f, 0f);
    [SerializeField] float desplSpeed;
    

    //Variables de restriccion.
    float limiteR = 57f;
    float limiteL = -57f;
    float limiteU = 40f;
    float limiteD = 0f;
    //float limiteRotU = -20f;
    //float limiteRotD = 20f;

    //booleanas para saber si puedo moverme.
    bool inLimitH = true;
    bool inLimitV = true;
    //bool inLimitRot = true;

    InitGameScript initGameScript;

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

    // M�todo para el movimiento
    void Movimiento()
    {
        //variables de los ejes de movimiento.
        float desplH = Input.GetAxis("Horizontal");
        float desplV = Input.GetAxis("Vertical");

        /**
        
        //Variables de los ejes de rotaci�n.
        float rotationV = Input.GetAxis("Vertical");
        
        //Variables para restringir la rotaci�n.
        float rotV = transform.rotation.x;  

        //Rotaci�n
        transform.Rotate(Vector3.back * Time.deltaTime * 200f, Space.Self);
        
        **/

        //Variables de posici�n para restringir.
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

        //Rotaci�n restringida
        /**if (rotV > limiteRotU && rotationV > 0 || rotV < limiteRotD && rotationV < 0)
        {
            inLimitRot = false;
        }
        else
        {
            inLimitRot = true;
        }

        if (inLimitRot)
        {
          transform.Rotate(Vector3.left * Time.deltaTime * rotationV * 250f, Space.Self);  
        }**/
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 6)
        {
            initGameScript.SendMessage("Morir");            
        }
    }
}
