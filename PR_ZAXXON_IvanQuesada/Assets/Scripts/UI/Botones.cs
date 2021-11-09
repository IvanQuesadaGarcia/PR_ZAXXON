using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Botones : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Jugar()
    {
        if (Input.GetKeyDown("space") || Input.GetKeyDown("enter"))
        {
            SceneManager.LoadScene(1);
        }
    }

    public void Opciones()
    {
        if (Input.GetKeyDown("space") || Input.GetKeyDown("enter"))
        {
            SceneManager.LoadScene(2);
        }
    }
    public void HighScores()
    {
        if (Input.GetKeyDown("space") || Input.GetKeyDown("enter"))
        {
            SceneManager.LoadScene(3);
        }
    }

    public void Regresar()
    {
        if (Input.GetKeyDown("space") || Input.GetKeyDown("enter"))
        {
            SceneManager.LoadScene(0);
        }
    }
}
