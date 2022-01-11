using LootLocker.Requests;
using UnityEngine.UI;
using UnityEngine;

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


}
