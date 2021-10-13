using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstGenerator : MonoBehaviour
{
    [SerializeField] GameObject obstacle;
    [SerializeField] Transform initPos;
    float intervalo;
    [SerializeField] GameObject[] arrayObst = new GameObject[5];
    
    // Start is called before the first frame update
    void Start()
    {
        intervalo = 1.2f;
        StartCoroutine("CrearObst");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator CrearObst()
    {
        while (true)
        {
            Instantiate(arrayObst[Random.Range(0, arrayObst.Length)], new Vector3(Random.Range(-57f, 57f), Random.Range(1f, 40f), initPos.position.z), Quaternion.identity);
            yield return new WaitForSeconds(intervalo);
            
        }
    }
}
