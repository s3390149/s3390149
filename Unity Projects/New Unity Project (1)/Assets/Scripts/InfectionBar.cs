using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class InfectionBar : MonoBehaviour
{
    public Slider slider;
    // Start is called before the first frame update
    public void changeInfection(float amount)
    {
        slider.value = amount;
    }

    public void setMax(float maxAmount, float amount)
    {
        slider.maxValue = maxAmount;
        slider.minValue = amount;
        slider.value = amount;
    }
}
//YouTube. 2020. How To Make A HEALTH BAR In Unity!. [online] Available at: <https://www.youtube.com/watch?v=BLfNP4Sc_iA> [Accessed 20 May 2020].