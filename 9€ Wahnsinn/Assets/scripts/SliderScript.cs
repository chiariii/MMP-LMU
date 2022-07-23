using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderScript : MonoBehaviour
{

    [SerializeField] private Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        SoundManager.Instance.ChangeVolume(slider.value);
        slider.onValueChanged.AddListener(val => SoundManager.Instance.ChangeVolume(val));
    }

    public void SetSlider(int vol)
    {
        slider.maxValue = vol;
        slider.value = vol;
    }

}
