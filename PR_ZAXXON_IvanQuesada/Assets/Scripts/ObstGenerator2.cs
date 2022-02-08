using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstGenerator2 : MonoBehaviour
{
    [SerializeField] Transform initPos;
   
    float intervalo;
   
    [SerializeField] GameObject obstacle;
  
    [SerializeField] float distEntreObst;
   
    float speed;
   
    InitGameScript initGameScript;

    // Start is called before the first frame update
    void Start()
    {
        initGameScript = GameObject.Find("InitGame").GetComponent<InitGameScript>();
        distEntreObst = 70f;
        

        StartCoroutine("CrearObst2");
    }

    public void Parar()
    {
        StopCoroutine("CrearObst2");
    }
    // Update is called once per frame
    void Update()
    {
        if (initGameScript.naveSpeed > 300)
        {
            distEntreObst = 80f;
        }
        intervalo = distEntreObst / initGameScript.naveSpeed;
    }

    IEnumerator CrearObst2()
    {
        while (true)
        {
            Instantiate(obstacle, new Vector3(Random.Range(-57f, 57f), 23.5f, initPos.position.z), Quaternion.identity);
            yield return new WaitForSeconds(intervalo);
        }
    }
}
