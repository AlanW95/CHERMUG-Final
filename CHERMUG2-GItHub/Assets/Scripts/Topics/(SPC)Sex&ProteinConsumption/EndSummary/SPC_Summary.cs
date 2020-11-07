using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

//////////////////////////////////////////////////<summary>//////////////////////////////////////////////////// 
///                                   University of the West of Scotland                                    ///
///                                    SEX AND PROTEIN CONSUMPTION TOPIC                                    ///
///                               -------------------------------------------                               ///  
/// Script is attached to the SceneManager GameObject in the SPC_EndSummary scene.                          ///
///                                                                                                         ///
//////////////////////////////////////////////////</summary>///////////////////////////////////////////////////

public class SPC_Summary : MonoBehaviour
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
    [SerializeField] private string BASE_URL = "https://docs.google.com/forms/u/2/d/e/1FAIpQLSew6WIWP1dG6pYtTUBK_WH0hWBwd5ELnZRNEyVHcnr7vdZejw/formResponse";
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
       
        screenCapName = "CertificateSPC_";
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

        time = PlayerPrefs.GetString("spc_timer");
        score = PlayerPrefs.GetString("spc_scoreString");
        name = PlayerPrefs.GetString("name");
        
        scoreText.text = score;
        nameText.text = name;

        dateText.text = System.DateTime.Now.ToString("dd MMMM yyyy");
        topicText.text = "Sex and Protein Consumption";

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
        screenCapName = "CertificateSPC_" + System.DateTime.Now.ToString("dd-MM-yy") + "_" + (screenCaps+1) + ".png";
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
        timerText.text = PlayerPrefs.GetString("spc_timer");
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene("MainMenu");
    }

    //Google Forms data
    IEnumerator PostToGoogle(string nameAnswer, string scoreAnswer, string timeAnswer)
    {
        WWWForm form = new WWWForm();

        form.AddField("entry.1665981166", nameAnswer);
        form.AddField("entry.1376964923", scoreAnswer);
        form.AddField("entry.1172802240", timeAnswer);

        byte[] rawData = form.data;
        WWW www = new WWW(BASE_URL, rawData);

        yield return www;
    }

    public void Send()
    {
        nameAnswer = inputName.GetComponent<InputField>().text;
        scoreAnswer = PlayerPrefs.GetString("spc_scoreString");
        timeAnswer = PlayerPrefs.GetString("spc_timer");
        
        StartCoroutine(PostToGoogle(nameAnswer, scoreAnswer, timeAnswer));
    }
}