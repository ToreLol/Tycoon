    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceDetector : MonoBehaviour
{
    //Public Variables
    public ResourceManager resourceManager;

    //If Object enters Trigger
    private void OnTriggerEnter(Collider other)
    {
        //If Object is Resource
        if(other.gameObject.GetComponent<Resource>())
        {
            //Adds Resource's Value & Desstroys Object
            resourceManager.AddResources(other.gameObject.GetComponent<Resource>().value);
            Destroy(other.gameObject);
        }
    }
}
