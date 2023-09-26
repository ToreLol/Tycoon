using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
    //Private Variables
    private Transform mainCamera;

    // Start is called before the first frame update
    void Start()
    {
        //Obtain Transform of main Camera
        mainCamera = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        //Look at Camera
        transform.LookAt(mainCamera);
    }
}
