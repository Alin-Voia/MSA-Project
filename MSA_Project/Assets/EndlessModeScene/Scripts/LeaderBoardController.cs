using LootLocker.Requests;
using UnityEngine.UI;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class LeaderBoardController : MonoBehaviour
{
    public InputField MemberID;

    public Text PlayerCurrentScore;

    public GameObject SubmitButton;

    
    public GameObject leaderboardPanel;
    public int ID;
    
    public int maxScores = 5;
    public Text Entries;
    
    public Text warningText;
    private GameController myGameController;
    void Start()
    {
        myGameController = GameObject.FindObjectOfType<GameController>();
        leaderboardPanel.SetActive(false);
        LootLockerSDKManager.StartSession("Player", (response) =>
        {
            if(response.success)
            {
                Debug.Log("Success");
                ShowScores();
            }
            else
            {
                Debug.Log("Failed");
            }
        }
        );
    }

    public void ShowLeaderboard()
    {
        
        PlayerCurrentScore.text = PlayerCurrentScore.text + " " +  PlayerPrefs.GetInt("CurrentPlayerScore", 0);
        myGameController.ClosePanel();
        leaderboardPanel.SetActive(true);
        StartCoroutine(fadeInAndOut(leaderboardPanel,true,1.2f));
    }

    public void ShowScores()
    {
        LootLockerSDKManager.GetScoreList(ID, maxScores, (response) =>
        {
            if(response.success)
            {
                Entries.text="";
                for(int i =0; i< response.items.Length; i++)
                {
                    if(i==0) Entries.text +=  (response.items[i].rank + ".   "+ response.items[i].member_id + ":  " + response.items[i].score);
                    else Entries.text +="\n" + (response.items[i].rank + ".   "+ response.items[i].member_id + ":  " + response.items[i].score);
                }

                if(response.items.Length < maxScores)
                {
                    for(int i = response.items.Length; i <maxScores; i++)
                    {
                        if(i==0) Entries.text+=   (i+1).ToString() + ".   none";
                        else Entries.text+= "\n" +  (i+1).ToString() + ".   none";
                    }
                }



            }
            else
            {
                Debug.Log("Failed");
            }
        }
        );
    }


    private void CheckNameValidity()
    {
        if(MemberID.text.Length < 5){
            MyShowWarning("Name must be longer \nthan 6 characters");
            return;
        }

        if(MemberID.text.Length >10){
            MyShowWarning("Name must be shorter \nthan 10 characters");
            return;
        }

        LootLockerSDKManager.GetScoreList(ID, 100, (response) =>
        {
            if(response.success)
            {
                if(response.items.Length==0) warningText.text="";
                for(int i =0; i< response.items.Length; i++)
                {
                    if(response.items[i].member_id.Equals(MemberID.text))
                    {
                        MyShowWarning("Name already in use");
                        break;
                    }
                    else{
                        warningText.text="";
                    }
                }



            }
            else
            {
                Debug.Log("Failed");
            }
        }
        );

    }

    public void checkSubmit()
    {
        CheckNameValidity();
        Invoke("SubmitScore",1.5f);
    }


    public void SubmitScore()
    {
        if(warningText.text!="") return;

        LootLockerSDKManager.SubmitScore(MemberID.text, PlayerPrefs.GetInt("CurrentPlayerScore", 0), ID, (response) =>
        {
            if(response.success)
            {
                MyShowSuccess("Saved successfully\nYour rank is: "+ response.rank);
            }
            else
            {
                Debug.Log("Failed");
            }
        }
        );

        SubmitButton.SetActive(false);
        Invoke("ShowScores",1.0f);
    }


    public void MyShowWarning(string text)
    {
        this.warningText.text ="- " + text + " -";
        this.warningText.enabled = true;
        this.warningText.CrossFadeAlpha(0.0f, 0.0f, false);
        this.warningText.CrossFadeAlpha(1.0f, 1.5f, false);

        Invoke("disableWarning", 2f);
    }

    public void MyShowSuccess(string text)
    {
        this.warningText.text ="- " + text + " -";
        this.warningText.enabled = true;
        this.warningText.CrossFadeAlpha(0.0f, 0.0f, false);
        this.warningText.CrossFadeAlpha(1.0f, 1.5f, false);
    }

    private void disableWarning()
    {
        this.warningText.CrossFadeAlpha(0.0f, 1.5f, false);
    }

    IEnumerator fadeInAndOut(GameObject objectToFade, bool fadeIn, float duration)
    {
        float counter = 0f;

        //Set Values depending on if fadeIn or fadeOut
        float a, b;
        if (fadeIn)
        {
            a = 0;
            b = 1;
        }
        else
        {
            a = 1;
            b = 0;
        }

        int mode = 0;
        Color currentColor = Color.clear;

        SpriteRenderer tempSPRenderer = objectToFade.GetComponent<SpriteRenderer>();
        Image tempImage = objectToFade.GetComponent<Image>();
        RawImage tempRawImage = objectToFade.GetComponent<RawImage>();
        MeshRenderer tempRenderer = objectToFade.GetComponent<MeshRenderer>();
        Text tempText = objectToFade.GetComponent<Text>();
        CanvasGroup tempGroup = objectToFade.GetComponent<CanvasGroup>();

        //Check if this is a Sprite
        if (tempSPRenderer != null)
        {
            currentColor = tempSPRenderer.color;
            mode = 0;
        }
        //Check if Image
        else if (tempImage != null)
        {
            currentColor = tempImage.color;
            mode = 1;
        }
        //Check if RawImage
        else if (tempRawImage != null)
        {
            currentColor = tempRawImage.color;
            mode = 2;
        }
        //Check if Text 
        else if (tempText != null)
        {
            currentColor = tempText.color;
            mode = 3;
        }

        //Check if 3D Object
        else if (tempRenderer != null)
        {
            currentColor = tempRenderer.material.color;
            mode = 4;

            //ENABLE FADE Mode on the material if not done already
            tempRenderer.material.SetFloat("_Mode", 2);
            tempRenderer.material.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
            tempRenderer.material.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
            tempRenderer.material.SetInt("_ZWrite", 0);
            tempRenderer.material.DisableKeyword("_ALPHATEST_ON");
            tempRenderer.material.EnableKeyword("_ALPHABLEND_ON");
            tempRenderer.material.DisableKeyword("_ALPHAPREMULTIPLY_ON");
            tempRenderer.material.renderQueue = 3000;
        }
        else
        {
            yield break;
        }

        if (tempGroup != null)
        {
            mode = 5;
        }
        else
        {
            yield break;
        }

        while (counter < duration)
        {
            counter += Time.deltaTime;
            float alpha = Mathf.Lerp(a, b, counter / duration);

            switch (mode)
            {
                case 0:
                    tempSPRenderer.color = new Color(currentColor.r, currentColor.g, currentColor.b, alpha);
                    break;
                case 1:
                    tempImage.color = new Color(currentColor.r, currentColor.g, currentColor.b, alpha);
                    break;
                case 2:
                    tempRawImage.color = new Color(currentColor.r, currentColor.g, currentColor.b, alpha);
                    break;
                case 3:
                    tempText.color = new Color(currentColor.r, currentColor.g, currentColor.b, alpha);
                    break;
                case 4:
                    tempRenderer.material.color = new Color(currentColor.r, currentColor.g, currentColor.b, alpha);
                    break;
                case 5:
                    tempGroup.alpha = alpha;
                    break;    
            }
            yield return null;
        }
    }

}
