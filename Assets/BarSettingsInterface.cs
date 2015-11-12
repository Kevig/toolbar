using UnityEngine;
using UnityEngine.UI;

public class BarSettingsInterface : MonoBehaviour
{
    private ActionBarsCore core;

    private Toggle toggle;
    private Slider slider;
    private InputField input;

    public void Start()
    {
        this.core = GameObject.Find("GUIActionBarsObj").GetComponent<ActionBarsCore>();

        this.toggle = GameObject.Find("BarSettingsActiveToggle").GetComponent<Toggle>();
        this.slider = GameObject.Find("BarSettingsSliderNumBtns").GetComponent<Slider>();
        this.input = GameObject.Find("BarSettingsInputField").GetComponent<InputField>();
    }

    public Toggle getToggle()
    {
        return this.toggle;
    }

    public void setActive(bool b)
    {
        this.toggle.isOn = b;
    }

    public bool getActive()
    {
        return this.toggle.isOn;
    }

    public void setValue(int i)
    {
        this.slider.value = i;
        this.input.text = i.ToString();
    }

    public int getValue()
    {
        return System.Convert.ToInt16(this.slider.value);
    }

    public void sliderValueChange()
    {
        this.input.text = this.slider.value.ToString();
        this.core.valueChange();
        this.core.numberOfButtonsChange();
    }

    public void inputValueChange()
    {
        this.slider.value = System.Convert.ToInt16(this.input.text);
        this.core.valueChange();
        this.core.numberOfButtonsChange();
    }
}
