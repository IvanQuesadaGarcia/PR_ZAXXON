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

    
   
    [SerializeField] Text scoreText;
    [SerializeField] Text scoreGO;


    [SerializeField] GameObject navePrefab;

    bool alive = true;
    float tiempoPasado;

    //Game over
    GameObject GameOver;
    [SerializeField] Button btnPlay;
    [SerializeField] Sprite btnSelected;


    // Start is called before the first frame update
    void Start()
    {
        naveSpeed = 100f;

        var video = GameObject.Find("Background").GetComponent<UnityEngine.Video.VideoPlayer>();

        video.isLooping = true;
        video.Play();

        int y = SceneManager.GetActiveScene().buildIndex;

        GameManager.score = 0f;

        maxSpeed = 400f;
        
        alive = true;

        tiempoPasado = Time.time;

        scoreText.text = "Score: 0";
        scoreGO.text = "Score: 0";

        GameOver = GameObject.Find("GOparent");
        
        GameOver.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(naveSpeed < maxSpeed && alive == true && GameManager.score > 1000)
        {
            naveSpeed += 0.005f;
        }

        float tiempoReal = Time.time - tiempoPasado;

        

        if(alive)
            GameManager.score = Mathf.Round(tiempoReal) * naveSpeed;
        
        scoreText.text = "Score: " + Mathf.Round(GameManager.score);
    }

    //Morir
    public void Morir()
    {
        var video = GameObject.Find("Background").GetComponent<UnityEngine.Video.VideoPlayer>();
        alive = false;
        naveSpeed = 0f;        
        ObstGenerator obstGenerator = GameObject.Find("ObstGenerator").GetComponent<ObstGenerator>();
        ObstGenerator2 obstGenerator2 = GameObject.Find("ObstGenerator2").GetComponent<ObstGenerator2>();       
        obstGenerator.SendMessage("Parar");
        obstGenerator2.SendMessage("Parar");
        navePrefab.SetActive(false);
        video.playbackSpeed = 0f;

        Invoke("ActivarGameOver", 2f);

        if(GameManager.score > GameManager.highscore)
        {
            GameManager.highscore = Mathf.Round(GameManager.score);
        }
    }

    void ActivarGameOver()
    {
        GameOver.SetActive(true);
        btnPlay.Select();
    }
}
