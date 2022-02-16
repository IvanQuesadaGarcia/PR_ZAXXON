using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HScoreScript : MonoBehaviour
{
    [SerializeField] Text hsText;

    // Start is called before the first frame update
    void Start()
    {
        hsText.text = GameManager.highscore + " Pts";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
