using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interpolation : MonoBehaviour
{
    public float dotProduct;

    public float number1;
    public float number2;
    public float handle;
    public float interpolationValue;

    public Transform pos1;
    public Transform pos2;

    public Slider slider;
    public Image healthBarImage;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // if handle = 1, interp value = num2; if handle = 0, interp val = num1
        interpolationValue = Mathf.Lerp(number1, number2, handle);

        //transform.position = Vector2.Lerp(transform.position, pos2.position, Time.deltaTime);

        healthBarImage.color = Color.Lerp(Color.red, Color.green, slider.value / slider.maxValue);

        dotProduct = Vector2.Dot(pos1.up, pos2.position);
    }
}
