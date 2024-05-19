using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarProcessScript : MonoBehaviour
{
    private float second;
    [SerializeField]
    private GameObject rearLight;
    [SerializeField]
    private GameObject frontLight;
    private void Update()
    {
        second = GameObject.FindWithTag("Timer").GetComponent<TimerScript>().second;
        if(Input.GetKey(KeyCode.S))
        {
            rearLight.SetActive(true);
        }
        if(Input.GetKeyUp(KeyCode.S))
        {
            rearLight.SetActive(false);
        }
        if(Input.GetKeyDown(KeyCode.F))
        {
            if (frontLight.activeSelf == true)
                frontLight.SetActive(false);
            else
                frontLight.SetActive(true);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Hourglass"))
        {
            other.gameObject.GetComponent<BoxCollider>().isTrigger = true;
            Destroy(other.gameObject);
            second += 10;
            GameObject.FindWithTag("Timer").gameObject.GetComponent<TimerScript>().second = second;
        }
    }
}
