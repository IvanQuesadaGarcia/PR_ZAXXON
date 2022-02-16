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
            print("pausa");
            AbrirMenu();
        }
    }

    void AbrirMenu()
    {
        if (!gamePaused)
        {
            gamePaused = true;

            Time.timeScale = 0f;

            pauseMenu.SetActive(true);
            btnContinue.Select();
        }
        else
        {
            gamePaused = false;

            Time.timeScale = 1f;

            pauseMenu.SetActive(false);
            btnExit.Select();
        }

        
    }

    public void Resume()
    {
        gamePaused = false;
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
        btnExit.Select();
    }

    public void Salir()
    {
        SceneManager.LoadScene(0);
    }
}
