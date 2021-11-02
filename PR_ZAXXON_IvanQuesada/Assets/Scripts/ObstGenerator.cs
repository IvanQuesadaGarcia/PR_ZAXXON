using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstGenerator : MonoBehaviour
{
    [SerializeField] Transform initPos;
   
    [SerializeField] GameObject[] arrayObst;

    float intervalo;

    [SerializeField] float distanciaEntreObst;

    float speed;

    InitGameScript initGameScript;
    
    // Start is called before the first frame update
    void Start()
    {
        initGameScript = GameObject.Find("InitGame").GetComponent<InitGameScript>();
        distanciaEntreObst = 70f;
        intervalo = distanciaEntreObst / initGameScript.naveSpeed;

        StartCoroutine("CrearObst");
    }

    public void Parar()
    {
        StopCoroutine("CrearObst");
    }

    // Update is called once per frame
    void Update()
    {

    }
    IEnumerator CrearObst()
    {
        while (true)
        {
            Instantiate(arrayObst[Random.Range(0, arrayObst.Length)], new Vector3(Random.Range(-57f, 57f), Random.Range(3f, 40f), initPos.position.z), Quaternion.identity);
            yield return new WaitForSeconds(intervalo);            
        }
    }
}
