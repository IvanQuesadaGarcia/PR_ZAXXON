using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class Botones : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip btnSelect;
    [SerializeField] AudioClip btnClic;
    [SerializeField] AudioClip btnBack;

    public void Aceptar()
    {
        audioSource.PlayOneShot(btnClic, 1f);
    }

    public void Atras()
    {
        audioSource.PlayOneShot(btnBack, 1f);
    }
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
        Invoke("CargarScene1", 0.5f);
    }

    public void Opciones()
    {
        Invoke("CargarScene2", 0.5f);
    }
    public void HighScores()
    {
        Invoke("CargarScene3", 0.5f);      
    }

    public void Regresar()
    {
        Invoke("CargarScene0", 0.5f);        
    }

    public void CargarScene1()
    {
        GameManager.score = 0;
        SceneManager.LoadScene(1);
    }
    public void CargarScene2()
    {
        SceneManager.LoadScene(2);
    }
    public void CargarScene3()
    {
        SceneManager.LoadScene(3);
    }
    public void CargarScene0()
    {
        SceneManager.LoadScene(0);
    }
}
