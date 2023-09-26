using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceDropper : MonoBehaviour
{
    //Public Variables
    public GameObject[] resources;
    public float spawnTime;

    //Private Variables
    private int dropperTier;

    // Start is called before the first frame update
    void Start()
    {
        //Initiallication of Variables
        dropperTier = 1;
        InvokeRepeating("DropResource", spawnTime, 1f);
    }

    //Instantiate Resource Function
    void DropResource()
    {
        if (resources[dropperTier - 1] != null || dropperTier <= resources.Length)
            Instantiate(resources[dropperTier - 1], transform.position, Quaternion.identity);
    }

    //Increase Time Function
    public void UpgradeDropper()
    {
        dropperTier++;
    }
}
