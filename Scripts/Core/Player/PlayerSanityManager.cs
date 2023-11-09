using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSanityManager : MonoBehaviour
{
    [Header("Assignables")]
    [SerializeField] private Slider sanitySlider;

    [Header("Settings")]
    [SerializeField] private float degenerateRate = 1.5f;
    [SerializeField] private float degenerateDelay = 2.0f;
    [SerializeField] private float minValue;
    [SerializeField] private float maxValue;

    public Slider SanitySlider => sanitySlider;

    private void Start()
    {
        sanitySlider.minValue = minValue;
        sanitySlider.maxValue = maxValue;

        sanitySlider.value = maxValue;

        StartCoroutine(Decay());
    }

    IEnumerator Decay()
    {
        const float percentage = 0.65f;
        WaitForSeconds waitForSeconds = new WaitForSeconds(degenerateDelay);

        while (true)
        {
            if (sanitySlider.value - degenerateRate <= 0)
            {
                GameHandler.instance.KillPlayer();
                yield return null;
            }

            if (sanitySlider.value <= (double) (percentage * maxValue))
            {
                GameHandler.instance.EnableZombieHorror();
            } else
            {
                GameHandler.instance.DisableZombieHorror();
            }

            DecreaseSanityValue(degenerateRate);

            yield return waitForSeconds;
        }
    }

    public void IncreaseSanityValue(float value)
    {
        sanitySlider.value += value;
    }

    public void DecreaseSanityValue(float value)
    {
        sanitySlider.value -= value;
    }
}
