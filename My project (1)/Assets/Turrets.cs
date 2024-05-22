using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turrets : MonoBehaviour
{

    public GameObject gatlingtower;
    GameObject focusObs;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (!Physics.Raycast(ray, out hit)){ return; }
            focusObs = Instantiate(gatlingtower,hit.point,gatlingtower.transform.rotation);
            focusObs.GetComponent<Collider>().enabled = false;
        }else if (Input.GetMouseButtonDown(0))
        {

        }else if(Input.GetMouseButtonDown(0))
        {

        }
    }
}
