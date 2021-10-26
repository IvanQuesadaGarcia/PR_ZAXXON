using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    [SerializeField] GameObject initObject;
    InitGameScript initGameScript;

    float obstacleSpeed;
    
    
    // Start is called before the first frame update
    void Start()
    {
        initObject = GameObject.Find("InitGame");

        initGameScript = initObject.GetComponent<InitGameScript>();

        obstacleSpeed = initGameScript.naveSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        obstacleSpeed = initGameScript.naveSpeed;
        transform.Translate(Vector3.back * Time.deltaTime * obstacleSpeed);

        float obstPosZ = transform.position.z;

        if (obstPosZ < -27)
        {
            Destroy(gameObject);
        }
    }
}
