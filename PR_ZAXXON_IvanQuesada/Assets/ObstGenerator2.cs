using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstGenerator2 : MonoBehaviour
{
    [SerializeField] Transform initPos;
    float intervalo;
    [SerializeField] GameObject obstacle;

    // Start is called before the first frame update
    void Start()
    {
        intervalo = 0.5f;
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
            Instantiate(obstacle, new Vector3(Random.Range(-57f, 57f), 20f, initPos.position.z), Quaternion.identity);
            yield return new WaitForSeconds(intervalo);

        }
    }
}
