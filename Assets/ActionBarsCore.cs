using System;
using UnityEngine;
using UnityEngine.UI;

public class ActionBarsCore : MonoBehaviour {

    public BarSetting[] barSettings;
    public GameObject[] actionBar;

    private ActionBarSelectionInterface barSelect;
    private BarSettingsInterface bars;
    private ButtonSettingsInterface buttons;

    public Sprite backGround;
    public Sprite buttonImg;

    void Awake()
    {
        this.barSettings = new BarSetting[12];
        for(int i = 0; i < 12; i++)
        {
            this.barSettings[i] = new BarSetting(false, 1, 10, 10, 0);
        }
    }

	// Use this for initialization
	void Start ()
    {
        this.barSelect = GameObject.Find("ActionBarSelectionContainer").GetComponent<ActionBarSelectionInterface>();
        this.bars = GameObject.Find("BarSettingsContainer").GetComponent<BarSettingsInterface>();
        this.buttons = GameObject.Find("ButtonSettingsContainer").GetComponent<ButtonSettingsInterface>();

        this.actionBar = new GameObject[12];
	}

    public void loadSettings(int i)
    {
        this.bars.setActive(this.barSettings[i].active);
        this.bars.setValue(this.barSettings[i].numBtns);
        this.buttons.setWidth(this.barSettings[i].width);
        this.buttons.setHeight(this.barSettings[i].height);
        this.buttons.setMargin(this.barSettings[i].margin);
    }

    public void saveSettings()
    {
        int i = this.barSelect.getActiveBar();
        this.barSettings[i].active = this.bars.getActive();
        this.barSettings[i].numBtns = this.bars.getValue();
        this.barSettings[i].width = this.buttons.getWidth();
        this.barSettings[i].height = this.buttons.getHeight();
        this.barSettings[i].margin = this.buttons.getMargin();
    }

    public Sprite getBtnImg()
    {
        return this.buttonImg;
    }

    public int getMargin()
    {
        return this.buttons.getMargin();
    }

    public int getButtonWidth()
    {
        return this.buttons.getWidth();
    }

    // Determines action taken upon an active toggle change
    public void activeToggle()
    {
        Toggle t = bars.getToggle();
        bool b = t.isOn;
        int i = this.barSelect.getActiveBar();
        GameObject obj = GameObject.Find("ActionBar_" + i);

        if(obj == null && b == true)
        {
            this.createActionBar(i);
        }
        
        if(obj != null && b == false)
        {
            this.removeActionBar(i);
        }
    }

    // Create new actionbar gameobject, name, position and add required components
    private void createActionBar(int id)
    {
        GameObject obj = new GameObject();
        this.actionBar[id] = obj;
        obj.name = "ActionBar_" + id;
        obj.layer = 5;
        obj.transform.SetParent(GameObject.Find("ActionBarsCanvas").transform, false);

        obj.AddComponent<ActionBarInterface>();
        obj.AddComponent<RectTransform>();
        obj.AddComponent<CanvasRenderer>();
        Image img = obj.AddComponent<Image>();
        
        obj.transform.localPosition = new Vector3(0f, -320f, 0f);

        img.sprite = this.backGround;
        img.type = Image.Type.Tiled;

        Color color = new Color(0f, 0f, 0f, .6f);
        img.color = color;
       
        this.valueChange();
        this.numberOfButtonsChange();
    }

    // Removes the actionbar game object referenced with Id
    private void removeActionBar(int id)
    {
        GameObject obj = GameObject.Find("ActionBar_" + id);
        Destroy(obj);
    }

    public void valueChange()
    {
        int id = this.barSelect.getActiveBar();
        GameObject obj = GameObject.Find("ActionBar_" + id);

        if(obj != null)
        {
            this.resizeActionBar();
        }
    }

    public void numberOfButtonsChange()
    {
        int id = this.barSelect.getActiveBar();
        GameObject obj = GameObject.Find("ActionBar_" + id);

        if(obj != null)
        {
            ActionBarInterface objInt = this.actionBar[id].GetComponent<ActionBarInterface>();
            int n = bars.getValue();
            objInt.setNumberOfButtons(n);
            objInt.updateButtonPositions();
        }
    }

    public void resizeActionBar()
    {
        int id = this.barSelect.getActiveBar();
        
        float x = (this.bars.getValue() * this.buttons.getWidth()) + ((this.buttons.getMargin() * 2) * this.bars.getValue());
        float y = (this.buttons.getHeight() + (this.buttons.getMargin() * 2));

        this.actionBar[id].GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, x);
        this.actionBar[id].GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, y);
    }

    public void resizeButtons()
    {
        int id = this.barSelect.getActiveBar();
        GameObject obj = GameObject.Find("ActionBar_" + id);

        if(obj != null)
        {
            ActionBarInterface objInt = this.actionBar[id].GetComponent<ActionBarInterface>();
            objInt.resizeButton(this.getButtonWidth(), this.buttons.getHeight());
            objInt.updateButtonPositions();
        }
    }
}
