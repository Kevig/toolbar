using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ActionBarInterface : MonoBehaviour {

    private ActionBarsCore core;

    public int numBtns;

    private GameObject[] buttons;

    void Awake()
    {
        this.core = GameObject.Find("GUIActionBarsObj").GetComponent<ActionBarsCore>();
    }

    void Start()
    {
        Draggable drag = this.gameObject.AddComponent<Draggable>();
    }

    public void setNumberOfButtons(int n)
    {
        this.numBtns = n;
        this.buttons = new GameObject[n];

        this.removeButtons();

        for(int i = 0; i < n; i++)
        {
            createButton(i);
        }
        this.updateButtonPositions();
    }

    private void removeButtons()
    {
        foreach(Transform btn in this.transform)
        {
            GameObject obj = btn.gameObject;
            Destroy(obj);
        }
    }

    private void createButton(int i)
    {
        GameObject obj = new GameObject();
        this.buttons[i] = obj;

        obj.name = "Button_" + i;
        obj.layer = 5;
        obj.transform.SetParent(this.transform, false);

        obj.AddComponent<RectTransform>();
        obj.AddComponent<CanvasRenderer>();
        Image img = obj.AddComponent<Image>();
        obj.AddComponent<Button>();

        img.sprite = this.core.getBtnImg();
        img.type = Image.Type.Sliced;
        this.core.resizeButtons();
    }

    public void resizeButton(float x, float y)
    {
        foreach(GameObject obj in this.buttons)
        {
            if(obj != null)
            {
                obj.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, x);
                obj.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, y);
            }
        }
    }

    public void updateButtonPositions()
    {
        int margin = this.core.getMargin();
        float startX = (-(this.gameObject.GetComponent<RectTransform>().sizeDelta.x / 2) + margin) + (this.core.getButtonWidth() / 2);
        float step = this.core.getButtonWidth() + (margin*2);

        int i = 0;
        foreach(GameObject obj in this.buttons)
        {
            if(obj != null)
            {
                obj.GetComponent<RectTransform>().localPosition = new Vector3(startX + (step * i), 0f, 0f);
                i++;
            }
        }
    }
}
