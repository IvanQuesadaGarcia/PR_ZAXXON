using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Variables para el movimiento de la nave.
    [SerializeField] Vector3 playerPosition = new Vector3(0f, 0f, 0f);
    public float desplSpeed = 60f;

    //Variables de restriccion.
    float limiteR = 57f;
    float limiteL = -57f;
    float limiteU = 40f;
    float limiteD = 0f;

    //booleanas para saber si puedo moverme.
    bool inLimitH = true;
    bool inLimitV = true;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = playerPosition;   
    }

    // Update is called once per frame
    void Update()
    {
        Movimiento();

        //Variables de los ejes de rotación.
        float rotationH = Input.GetAxis("Horizontal");
        float rotationV = Input.GetAxis("Vertical");

        //transform.Rotate(Vector3.back * Time.deltaTime * rotationH * 250f, Space.Self);
        //transform.Rotate(Vector3.left * Time.deltaTime * rotationV * 250f, Space.Self);
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
    }
}
