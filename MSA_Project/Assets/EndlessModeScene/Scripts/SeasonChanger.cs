using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeasonChanger : MonoBehaviour
{

    private ColorSet[] colorSet;

    public Camera mainCam;
    public SpriteRenderer player;

    public SpriteRenderer floor;


    private int oldSeason;
    private int newSeason;

    private bool change;







    void Start()
    {
        setColors();
        oldSeason=0;
        newSeason=0;
        change=false;

        


    }

    // Update is called once per frame
    void Update()
    {
        if(change)
        {
            StartCoroutine(UpdateSeason());
        }
    }

     private IEnumerator UpdateSeason()
    {
        float timer = 0.0f;
        float time = 1.0f;
        
        while(timer <= time)
            {
            timer += Time.deltaTime;
            float lerp_Percentage = timer / time;
            
            player.color = Color.Lerp(colorSet[0].darkest, colorSet[3].darkest,lerp_Percentage);
            mainCam.backgroundColor = Color.Lerp(colorSet[0].lightest, colorSet[3].lightest,lerp_Percentage);
            yield return null;
        }
        change = false;
    }


    private void setColors()
    {
        colorSet = new ColorSet[4];
        colorSet[0] = new ColorSet(hexToColor("f5c6a5"),
                                   hexToColor("ff7777"),
                                   hexToColor("a2416b"),
                                   hexToColor("852747"));
        
        colorSet[1] = new ColorSet(hexToColor("f5e8c7"),
                                   hexToColor("deba9d"),
                                   hexToColor("9e7777"),
                                   hexToColor("6f4c5b"));

        colorSet[2] = new ColorSet(hexToColor("d9e4dd"),
                                   hexToColor("fbf7f0"),
                                   hexToColor("cdc9c3"),
                                   hexToColor("555555"));
                                    

        colorSet[3] = new ColorSet(hexToColor("e8ded2"),
                                   hexToColor("a3d2ca"),
                                   hexToColor("5eaaa8"),
                                   hexToColor("056676"));
                                   

    }

    public void changeSeason(int newS)
    {
        oldSeason = newSeason;
        newSeason = newS;
        change = true;
        
    }

    public void setSeason(int i)
    {

    }


    private void myLerpColor()
    {

    }

    private Color32 hexToColor(string hex)
     {
         hex = hex.Replace ("0x", "");//in case the string is formatted 0xFFFFFF
         hex = hex.Replace ("#", "");//in case the string is formatted #FFFFFF
         byte a = 255;//assume fully visible unless specified in hex
         byte r = byte.Parse(hex.Substring(0,2), System.Globalization.NumberStyles.HexNumber);
         byte g = byte.Parse(hex.Substring(2,2), System.Globalization.NumberStyles.HexNumber);
         byte b = byte.Parse(hex.Substring(4,2), System.Globalization.NumberStyles.HexNumber);
         //Only use alpha if the string has enough characters
         if(hex.Length == 8){
             a = byte.Parse(hex.Substring(6,2), System.Globalization.NumberStyles.HexNumber);
         }
         return new Color32(r,g,b,a);
     }

}
