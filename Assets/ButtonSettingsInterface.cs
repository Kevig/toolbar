using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ButtonSettingsInterface : MonoBehaviour
{
    private ActionBarsCore core;

    private Slider widthSlider;
    private Slider heightSlider;
    private Slider marginSlider;

    private InputField widthInput;
    private InputField heightInput;
    private InputField marginInput;

	void Start ()
    {
        this.core = GameObject.Find("GUIActionBarsObj").GetComponent<ActionBarsCore>();

        this.widthSlider = GameObject.Find("SliderWidth").GetComponent<Slider>();
        this.heightSlider = GameObject.Find("SliderHeight").GetComponent<Slider>();
        this.marginSlider = GameObject.Find("SliderMargin").GetComponent<Slider>();

        this.widthInput = GameObject.Find("InputFieldWidth").GetComponent<InputField>();
        this.heightInput = GameObject.Find("InputFieldHeight").GetComponent<InputField>();
        this.marginInput = GameObject.Find("InputFieldMargin").GetComponent<InputField>();
    }


    // Width Attribute Methods

   // Set the slider control and inputfield of width to the value of i
    public void setWidth(int i)
    {
        this.widthSlider.value = i;
        this.widthInput.text = i.ToString();
    }

    // Return the value of the slider control for width
    public int getWidth()
    {
        return System.Convert.ToInt16(this.widthSlider.value);
    }

    // On width slider value change, update width inputfield text to match
    public void widthSliderChange()
    {
        this.widthInput.text = this.widthSlider.value.ToString();
        this.core.valueChange();
        this.core.resizeButtons();
    }

    // On width inputfield change, update width slider value to match
    public void widthInputChange()
    {
        this.widthSlider.value = System.Convert.ToInt16(this.widthInput.text);
        this.core.valueChange();
        this.core.resizeButtons();
    }

    // Height Attribute Methods

    public void setHeight(int i)
    {
        this.heightSlider.value = i;
        this.heightInput.text = i.ToString();
    }

    public int getHeight()
    {
        return System.Convert.ToInt16(this.heightSlider.value);
    }

    // On height slider value change, update width inputfield text to match
    public void heightSliderChange()
    {
        this.heightInput.text = this.heightSlider.value.ToString();
        this.core.valueChange();
        this.core.resizeButtons();
    }

    // On height inputfield change, update width slider value to match
    public void heightInputChange()
    {
        this.heightSlider.value = System.Convert.ToInt16(this.heightInput.text);
        this.core.valueChange();
        this.core.resizeButtons();
    }

    // Margin Attribute Methods

    public void setMargin(int i)
    {
        this.marginSlider.value = i;
        this.marginInput.text = i.ToString();
    }

    public int getMargin()
    {
        return System.Convert.ToInt16(this.marginSlider.value);
    }

    // On margin slider value change, update width inputfield text to match
    public void marginSliderChange()
    {
        this.marginInput.text = this.marginSlider.value.ToString();
        this.core.valueChange();
        this.core.resizeButtons();
    }

    // On margin inputfield change, update width slider value to match
    public void marginInputChange()
    {
        this.marginSlider.value = System.Convert.ToInt16(this.marginInput.text);
        this.core.valueChange();
        this.core.resizeButtons();
    }
}
