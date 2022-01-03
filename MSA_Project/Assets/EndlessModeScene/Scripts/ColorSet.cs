using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class ColorSet
{
    public Color32  lightest;
    public Color32  light;
    public Color32  dark;
    public Color32  darkest;

    public ColorSet(Color32 lightest, Color32 light, Color32  dark, Color32  darkest)
    {
        this.lightest = lightest;
        this.light = light;
        this.dark = dark;
        this.darkest = darkest;
    }



}