using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ability : MonoBehaviour
{
    bool ability1Charge;
    bool ability2Charge;

    [SerializeField] Slider Ability1;
    [SerializeField] Slider Ability2;

    //Velocidad de carga de la habilidad 1
    [SerializeField] float chargeVel = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        Ability1.value = 0f;
        Ability2.value = 0f;
        ability1Charge = false;
        ability2Charge = false;
    }

    // Update is called once per frame
    void Update()
    {
        DashAbility1();
        DashAbility2();
    }

    private void DashAbility1()
    {
        if (ability1Charge == false)
        {
            Ability1.value += 0.5f * Time.deltaTime * chargeVel;

            if (Ability1.value >= 1f)
            {
                ability1Charge = true;
            }
        }

        if (Input.GetButtonDown("Fire1") && ability1Charge == true)
        {
            Ability1.value = 0f;
            print("dash");
            ability1Charge = false;
        }
    }

    private void DashAbility2()
    {
        if(ability2Charge == false)
        {
            Ability2.value += 1f * Time.deltaTime * chargeVel;

            if (Ability2.value >= 1f)
            {
                ability2Charge = true;
            }
        }
        
        if (Input.GetButtonDown("Fire2") && ability2Charge == true)
        {
            Ability2.value = 0f;
            print("dash");
            ability2Charge = false;
        }
    }
}
