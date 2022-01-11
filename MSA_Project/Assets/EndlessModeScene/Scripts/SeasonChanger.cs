using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SeasonChanger : MonoBehaviour
{

    private ColorSet[] colorSet;

    public Camera mainCam;
    public SpriteRenderer player;
    public SpriteRenderer floor;

    public Image pause;
    public Image menu;
    public Image header;
    public Image saveScore;
    public Image restart;
    public Image exit;
    public Text headerText;

    public Text saveScoreText;
    public Text restartText;
    public Text exitText;
    public Text topScore;
    public Text currentScore;

    public Text score;
    public Text musicTitle;

    private int oldSeason;
    private int newSeason;

    private bool change;

    public float warpTime;

    
    public SpriteRenderer backgroundRenderer;
    public Sprite[] backgroundSprites;



    void Start()
    {
        setColors();
        oldSeason=0;
        newSeason=0;
        backgroundRenderer.sprite = backgroundSprites[newSeason];
        change=false;
        


    }

    // Update is called once per frame
    void Update()
    {
        if(change)
        {
            StartCoroutine(UpdateSeason());
            StartCoroutine(fadeOut());
        }
    }

    private IEnumerator UpdateSeason()
    {
        float timer = 0.0f;
        
        
        while(timer <= warpTime)
            {
            timer += Time.deltaTime;
            float lerp_Percentage = timer / warpTime;
            
            player.color = Color.Lerp(colorSet[oldSeason].darkest, colorSet[newSeason].darkest,lerp_Percentage);

            mainCam.backgroundColor = Color.Lerp(colorSet[oldSeason].lightest, colorSet[newSeason].lightest,lerp_Percentage);

            floor.color = Color.Lerp(colorSet[oldSeason].light, colorSet[newSeason].light,lerp_Percentage);

            menu.color = Color.Lerp(colorSet[oldSeason].lightest, colorSet[newSeason].lightest,lerp_Percentage);

            pause.color = Color.Lerp(colorSet[oldSeason].darkest, colorSet[newSeason].darkest,lerp_Percentage);

            header.color = Color.Lerp(colorSet[oldSeason].dark, colorSet[newSeason].dark,lerp_Percentage);

            saveScore.color = Color.Lerp(colorSet[oldSeason].light, colorSet[newSeason].light,lerp_Percentage);

            restart.color = Color.Lerp(colorSet[oldSeason].light, colorSet[newSeason].light,lerp_Percentage);

            exit.color = Color.Lerp(colorSet[oldSeason].light, colorSet[newSeason].light,lerp_Percentage);

            headerText.color = Color.Lerp(colorSet[oldSeason].lightest, colorSet[newSeason].lightest,lerp_Percentage);

            saveScoreText.color = Color.Lerp(colorSet[oldSeason].darkest, colorSet[newSeason].darkest,lerp_Percentage);

            restartText.color = Color.Lerp(colorSet[oldSeason].darkest, colorSet[newSeason].darkest,lerp_Percentage);

            exitText.color = Color.Lerp(colorSet[oldSeason].darkest, colorSet[newSeason].darkest,lerp_Percentage);

            topScore.color = Color.Lerp(colorSet[oldSeason].darkest, colorSet[newSeason].darkest,lerp_Percentage);

            currentScore.color = Color.Lerp(colorSet[oldSeason].darkest, colorSet[newSeason].darkest,lerp_Percentage);

            score.color = Color.Lerp(colorSet[oldSeason].dark, colorSet[newSeason].dark,lerp_Percentage);

            musicTitle.color = Color.Lerp(colorSet[oldSeason].dark, colorSet[newSeason].dark,lerp_Percentage);



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
        
        colorSet[1] = new ColorSet(hexToColor("ffdf91"),
                                   hexToColor("eaac7f"),
                                   hexToColor("91684a"),
                                   hexToColor("493323"));

        colorSet[2] = new ColorSet(hexToColor("fbf7f0"),
                                   hexToColor("d9e4dd"),
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


    IEnumerator fadeOut()
    {
        float counter = 0;
        float duration = warpTime/2;
        //Get current color
        Color spriteColor = backgroundRenderer.material.color;

        while (counter < duration)
        {
            counter += Time.deltaTime;
            //Fade from 1 to 0
            float alpha = Mathf.Lerp(1, 0.3f, counter / duration);

            //Change alpha only
            backgroundRenderer.color = new Color(spriteColor.r, spriteColor.g, spriteColor.b, alpha);
            //Wait for a frame
            yield return null;
        }
        StartCoroutine(fadeIn());

    }


    IEnumerator fadeIn( )
    {
        float counter = 0;
        backgroundRenderer.sprite = backgroundSprites[newSeason];
        float duration = warpTime/2;
        Color spriteColor = backgroundRenderer.material.color;

        while (counter < duration)
        {
            counter += Time.deltaTime;
            //Fade from 1 to 0
            float alpha = Mathf.Lerp(0.3f, 1, counter / duration);

            //Change alpha only
            backgroundRenderer.color = new Color(spriteColor.r, spriteColor.g, spriteColor.b, alpha);
            //Wait for a frame
            yield return null;
        }
    }
}
