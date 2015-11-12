using UnityEngine;
using UnityEngine.UI;

public class SelectionButtonInterface : MonoBehaviour {

    private ActionBarSelectionInterface selectionInterface;

    public bool isActive = false;

    public delegate void updateActive(string s);
    public static event updateActive OnChangeActive;

    // Use this for initialization
    void Start ()
    {
        SelectionButtonInterface.OnChangeActive += setInActive;

        selectionInterface = GameObject.Find("ActionBarSelectionContainer").
                                GetComponent<ActionBarSelectionInterface>();
    }

    // Called upon a button click event, informs selection interface
    // which bar reference button is active
    public void OnClick()
    {
        int id = int.Parse(this.name.Substring(this.name.IndexOf("_") + 1));
        this.setActive();
        this.selectionInterface.changeBar(id);
        OnChangeActive(this.gameObject.name);
    }

    private void setActive()
    {
        this.isActive = true;
    }

    public bool getIsActive()
    {
        return this.isActive;
    }

    // Called upon a button click event, used to set non-clicked button
    // elements isActive boolean to false;
    private void setInActive(string s)
    {
        if(s != this.gameObject.name)
        {
            this.isActive = false;
        }
        this.setColour();
    }

    private void setColour()
    {
        Selectable e = this.gameObject.GetComponent<Button>();

        if(isActive)
        {
            e.image.color = Color.green;
        }
        else
        {
            e.image.color = Color.white;
        }
    }
}
