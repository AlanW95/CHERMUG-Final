﻿using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

//////////////////////////////////////////////////<summary>//////////////////////////////////////////////////// 
///                                   University of the West of Scotland                                    ///
///                                       SPIRITUALITY HEALTH TOPIC                                         ///
///                               -------------------------------------------                               ///  
/// Script is attached to the SceneManager GameObject in the SH_EndSummary scene.                           ///
///                                                                                                         ///
//////////////////////////////////////////////////</summary>///////////////////////////////////////////////////

public class SH_Summary : MonoBehaviour
{
    public GameObject particleSpawner_L;
    public GameObject particleSpawner_R;
    private GameObject returnButton;
    private GameObject saveButton;
    public Text timerText;
    public Text scoreText;
    public Text nameText;
    public Text dateText;
    public Text topicText;
    public string name;
    public string score;
    public string time;
    //Collecting Data and sending to Google Forms
    public InputField inputName;
    public InputField inputScore;
    public InputField inputTime;
    public string nameAnswer;
    public string scoreAnswer;
    public string timeAnswer;
    [SerializeField] private string BASE_URL = "https://docs.google.com/forms/u/2/d/e/1FAIpQLSd3Fn_PnstcaEVjwItKiYHBAQ7H-SvbhV8t_H22bLTVjdzCig/formResponse";
    //Screen Capture Stuff
    public string screenCapDir;
    private int screenCaps;
    public string screenCapName;
    private int count;

    // Start is called before the first frame update
    void Start()
    {
        //---------------START Screen Capture Stuff-----------------
        screenCapDir = Application.persistentDataPath + "/Certificates/";

        if (!Directory.Exists(screenCapDir))
        {
            Directory.CreateDirectory(screenCapDir);
        }
       
        screenCapName = "CertificateSH_";
        screenCaps = 1;
        //---------------END Screen Capture Stuff-----------------

        particleSpawner_L = GameObject.Find("ParticleSpawner_L");
        particleSpawner_R = GameObject.Find("ParticleSpawner_R");

        //for sending Google Forms data
        inputName = GameObject.Find("NameField").GetComponent<InputField>();
        inputScore = GameObject.Find("ScoreField").GetComponent<InputField>();
        inputTime = GameObject.Find("TimeField").GetComponent<InputField>();
        //------------------------

        returnButton = GameObject.Find("Button_Return");
        saveButton = GameObject.Find("Button_Save");

        time = PlayerPrefs.GetString("sh_timer");
        score = PlayerPrefs.GetString("sh_scoreString"); 
        name = PlayerPrefs.GetString("name");
        
        scoreText.text = score;
        nameText.text = name;

        dateText.text = System.DateTime.Now.ToString("dd MMMM yyyy");
        topicText.text = "Health Behaviour and Spirituality";

        //Google forms
        inputName.text = name;
        inputScore.text = score;

        returnButton.SetActive(false);

        SaveCertificateImage();
    }
    //---------------START Screen Capture Stuff-----------------
    public void SaveCertificateImage()
    {
        screenCaps = (FindScreenCaptures(screenCapDir));
        StartCoroutine(ScreenshotReturn());

        //SAVES THE SCREENSHOT
        screenCapName = "CertificateSH_" + System.DateTime.Now.ToString("dd-MM-yy") + "_" + (screenCaps+1) + ".png";
        ScreenCapture.CaptureScreenshot(Path.Combine(screenCapDir, screenCapName));
        screenCaps++;
        StartCoroutine(OpenFolder());
    }

    IEnumerator OpenFolder()
    {
        yield return new WaitForSeconds(1);

        Send(); //send leaderboard data to Google Drive
        Application.OpenURL(screenCapDir);//Opens folder directory location
    }

    int FindScreenCaptures(string DirectoryPath)
    {
        count = 0;
        screenCaps = 0;

        DirectoryInfo dir = new DirectoryInfo(screenCapDir);
        FileInfo[] info = dir.GetFiles();

        foreach (FileInfo f in info)
        {
            count += 1;
        }
        return count;      
    }

    IEnumerator ScreenshotReturn()
    {  
        yield return new WaitForSeconds(0.5f);
        returnButton.SetActive(true);
        particleSpawner_L.gameObject.GetComponent<CertificateParticles>().ActivateParticles();
        particleSpawner_R.gameObject.GetComponent<CertificateParticles>().ActivateParticles();
    }
    //---------------END Screen Capture Stuff-----------------

    // Update is called once per frame
    void Update()
    {
        timerText.text = PlayerPrefs.GetString("sh_timer");
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene("MainMenu");
    }

    //Google Forms data
    IEnumerator PostToGoogle(string nameAnswer, string scoreAnswer, string timeAnswer)
    {
        WWWForm form = new WWWForm();

        form.AddField("entry.1841845786", nameAnswer);
        form.AddField("entry.1884244967", scoreAnswer);
        form.AddField("entry.1265607477", timeAnswer);

        byte[] rawData = form.data;
        WWW www = new WWW(BASE_URL, rawData);

        yield return www;
    }

    public void Send()
    {
        nameAnswer = inputName.GetComponent<InputField>().text;
        scoreAnswer = PlayerPrefs.GetString("sh_scoreString");
        timeAnswer = PlayerPrefs.GetString("sh_timer");

        StartCoroutine(PostToGoogle(nameAnswer, scoreAnswer, timeAnswer));
    }
}