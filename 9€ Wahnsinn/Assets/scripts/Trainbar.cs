using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Trainbar : MonoBehaviour
{
    public Slider slider1;
    

    public void SetMaxCapacity(int capacity)
    {
        slider1.maxValue = capacity;
        slider1.value = 0;

    
    }

    public void SetCapacity(int capacity)
    {
 
        slider1.value = capacity;

        
    }

}
