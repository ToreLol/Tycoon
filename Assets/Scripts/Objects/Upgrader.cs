using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Upgrader : MonoBehaviour
{
    //Public Variables
    public ResourceManager resourceManager;
    public float cost;
    public string text;

    public UnityEvent OnActivated;

    //Private Variables
    private TextMesh textMesh;

    // Start is called before the first frame update
    void Start()
    {
        //Initiallization of Variables
        textMesh = GetComponentInChildren<TextMesh>();

        //Write Text & Cost
        textMesh.text = text + " $" + cost;
    }

    //If object enters collider
    private void OnTriggerEnter(Collider other)
    {
        //If object = player
        if (other.gameObject.CompareTag("Player"))
        {
            //If enough resources
            if (resourceManager.CurrentResources() >= cost)
            {
                //Remove cost from Upgrade, activate event & destroy it
                resourceManager.RemoveResources(cost);
                OnActivated.Invoke();
                Destroy(gameObject);
            }
        }
    }
}
