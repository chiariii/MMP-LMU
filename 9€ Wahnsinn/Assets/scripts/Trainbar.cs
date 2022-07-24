using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Trainbar : MonoBehaviour
{
    public Slider trainSlider;
    public Gradient gradient;
    public Image fill;

    public void SetMaxCapacity(int capacity)
    {
        trainSlider.maxValue = capacity;
            
    }

    public void SetCurrentInTrain(int numberOfPassengers)
    {
         trainSlider.value = numberOfPassengers;
        fill.color = gradient.Evaluate(trainSlider.normalizedValue);        
    }

}
