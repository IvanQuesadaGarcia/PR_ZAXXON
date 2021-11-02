using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InitGameScript : MonoBehaviour
{
    /*---------------------------
    //------VARIABLES GLOBALES
    ------------------------------*/

    //Velocidad global
    public float naveSpeed;

    [SerializeField] float maxSpeed;

    //Puntuación
    static float score;
   
    [SerializeField] Text scoreText;


    [SerializeField] GameObject navePrefab;

    bool alive;

    // Start is called before the first frame update
    void Start()
    {
        naveSpeed = 100f;

        int y = SceneManager.GetActiveScene().buildIndex;
        if (y == 0)
        {
            score = 0;
        }

        maxSpeed = 400f;
        
        alive = true;

        float tiempoPasado = Time.time;

        scoreText.text = "Score: " + score;
    }

    // Update is called once per frame
    void Update()
    {
        if(naveSpeed < maxSpeed && alive == true && score > 1000)
        {
            naveSpeed += 0.005f;
        }

        float tiempo = Time.time;

        score = Mathf.Round(tiempo) * naveSpeed;
        scoreText.text = "Score: " + Mathf.Round(score);
    }

    //Morir
    public void Morir()
    {
        naveSpeed = 0f;
        alive = false;
        ObstGenerator obstGenerator = GameObject.Find("ObstGenerator").GetComponent<ObstGenerator>();
        ObstGenerator2 obstGenerator2 = GameObject.Find("ObstGenerator2").GetComponent<ObstGenerator2>();
        obstGenerator.SendMessage("Parar");
        obstGenerator2.SendMessage("Parar");
        navePrefab.SetActive(false);
        Destroy(gameObject);
    }
}
