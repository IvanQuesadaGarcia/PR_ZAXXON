using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrenoMove : MonoBehaviour
{
    float speed;

    InitGameScript initGameScript;

    [SerializeField] GameObject terrenoPrefab;

    Vector3 instPos = new Vector3(0f, -2.6f, 990f);

    // Start is called before the first frame update
    void Start()
    {
        initGameScript = GameObject.Find("InitGame").GetComponent<InitGameScript>();       
    }

    // Update is called once per frame
    void Update()
    {
        speed = initGameScript.naveSpeed;

        transform.Translate(Vector3.back * Time.deltaTime * speed);

        if(transform.position.z <= -210)
        {
            Instantiate(terrenoPrefab, instPos, Quaternion.identity);
            Destroy(gameObject);
        }   
        
    }
}
