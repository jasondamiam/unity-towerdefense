using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;


public class Camera : MonoBehaviour
{
    public Camera maincamera;
    public Camera targetcamera;
    public int z = 0;
    public int y = 0;
    public int x = 0;
    // Start is called before the first frame update
    void Start()
    {
        //Vector3(x * 2 ,y * 2, z  * 2);
        GetComponent<Camera>();
        Camera cam = GetComponent<Camera>();
        transform.position = cam.transform.position;
        transform.rotation = cam.transform.rotation;
       // maincamera.transform.position = maincamera.transform.rotation;

        // Update is called once per frame
        void Update()
        {

        }
    }
}
