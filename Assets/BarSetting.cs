using UnityEngine;
using System.Collections;

public class BarSetting
{
    public bool active;
    public int numBtns;
    public int width;
    public int height;
    public int margin;


    public BarSetting()
    {
        this.active = false;
        this.numBtns = 0;
        this.width = 0;
        this.height = 0;
        this.margin = 0;
    }

    public BarSetting(bool a, int b, int c, int d, int e)
    {
        this.active = a;
        this.numBtns = b;
        this.width = c;
        this.height = d;
        this.margin = e;
    }
}
