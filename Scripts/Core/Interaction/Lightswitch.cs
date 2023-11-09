using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lightswitch : Interactable
{
    [SerializeField] private GameObject[] lights;

    private bool isOn = true;

    public override void Interact()
    {
        base.Interact();

        AudioManager.instance.Play("LightSwitch");

        if (isOn)
        {
            TurnOffLights();
            isOn = false;
        } else
        {
            TurnOnLights();
            isOn = true;
        }
    }

    private void TurnOffLights()
    {
        foreach (GameObject light in lights)
        {
            light?.SetActive(false);
        }
    }

    private void TurnOnLights()
    {
        foreach (GameObject light in lights)
        {
            light?.SetActive(true); 
        }
    }
}
