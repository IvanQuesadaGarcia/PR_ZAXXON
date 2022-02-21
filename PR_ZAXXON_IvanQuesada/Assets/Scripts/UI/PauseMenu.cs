using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    
    bool gamePaused = false;

    [SerializeField] Button btnContinue, btnExit;
    [SerializeField] AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        pauseMenu = GameObject.Find("PauseParent");

        pauseMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire3"))
        {
            AbrirMenu();
        }
    }

    void AbrirMenu()
    {
        var video = GameObject.Find("Background").GetComponent<UnityEngine.Video.VideoPlayer>();
        if (!gamePaused)
        {
            gamePaused = true;

            Time.timeScale = 0f;

            pauseMenu.SetActive(true);
            video.playbackSpeed = 0f;
            btnContinue.Select();
            audioSource.volume = 0.1f;
        }
        else
        {
            gamePaused = false;

            Time.timeScale = 1f;

            pauseMenu.SetActive(false);
            btnExit.Select();
            audioSource.volume = 1f;
        }  
    }

    public void Resume()
    {
        gamePaused = false;
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
        btnExit.Select();
        audioSource.volume = 1f;
    }

    public void Salir()
    {
        SceneManager.LoadScene(0);
    }
}
