using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceManager : MonoBehaviour
{
    //Public Variables
    public Text resourceText;

    //Private Variables
    private float currentResources;

    // Start is called before the first frame update
    void Start()
    {
        //Initialize Variables
        currentResources = 0f;
        UpdateUI();
    }

    //Adding Resources Function
    public void AddResources(float _value)  //_ is used to identif local variables
    {
        currentResources += _value;
        UpdateUI();
    }

    //Remove Resources Function
    public void RemoveResources(float _value)
    {
        currentResources -= _value;
        UpdateUI();
    }

    //Return Current Resources Function
    public float CurrentResources()
    {
        return currentResources;
    }

    //UI Update Function
    public void UpdateUI()
    {
        resourceText.text = "Money: $" + currentResources;
    }
}
