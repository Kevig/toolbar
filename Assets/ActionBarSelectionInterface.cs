using UnityEngine;
using System.Collections;

public class ActionBarSelectionInterface : MonoBehaviour
{
    private ActionBarsCore core;

    public int activeBar;

	// Use this for initialization
	void Start ()
    {
        this.core = GameObject.Find("GUIActionBarsObj").GetComponent<ActionBarsCore>();
	}
	
    public void changeBar(int i)
    {
        this.core.saveSettings();
        this.setActiveBar(i);
        this.core.loadSettings(i);
    }

    private void setActiveBar(int i)
    {
        this.activeBar = i;
    }

    public int getActiveBar()
    {
        return this.activeBar;
    }
}
