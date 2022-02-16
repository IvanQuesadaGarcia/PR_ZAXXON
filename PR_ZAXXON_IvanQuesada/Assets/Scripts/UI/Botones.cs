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
        GameManager.score = 0;
        SceneManager.LoadScene(1);
    }

    public void Opciones()
    {
            SceneManager.LoadScene(2);
    }
    public void HighScores()
    {
            SceneManager.LoadScene(3);
    }

    public void Regresar()
    {
       // InitGameScript.score = 0;
        SceneManager.LoadScene(0);
    }
}
