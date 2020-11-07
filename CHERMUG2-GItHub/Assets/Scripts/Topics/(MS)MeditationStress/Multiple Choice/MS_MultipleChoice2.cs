using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering;

//////////////////////////////////////////////////<summary>//////////////////////////////////////////////////// 
///                                   University of the West of Scotland                                    ///
///                               WITHIN PARTICIPANTS MEDITATION STRESS TOPIC                               ///
///                               -------------------------------------------                               ///  
/// Script is attached to the Manager GameObject in the MS_MultipleChoice2 scene.                           ///
///                                                                                                         ///
//////////////////////////////////////////////////</summary>///////////////////////////////////////////////////

public class MS_MultipleChoice2 : MonoBehaviour
{
    public GameObject scoreBar;
    public GameObject nameBar;
    public GameObject scenarioObj;
    public GameObject scenarioCloseButton;
    public GameObject scenarioViewButton;
    public GameObject scenarioButtonClickBlock;
    public GameObject questionObj;

    [SerializeField] private GameObject feedback;
    [SerializeField] private GameObject nextButton;

    private Button next;
    
    public Text q;
    public Text subq;
    public Text a1;
    public Text a2;
    public Text a3; 
    public Text a4;
    public Text a5;
    public Text a6;

    [SerializeField] private GameObject[] a;

    public Toggle[] toggles;
    [SerializeField] private GameObject finalButton1, finalButton2;
    public Button fb1, fb2;
    private bool q1Answered, q2Answered;

    //Typing Text
    [SerializeField] private Text feedbackText;
    public string[] sentences;
    private int index;
    public float typingSpeed;
    [SerializeField] private GameObject continueButton;

    private bool q1Completed;

    public GameObject character;
    public GameObject fadeScreen;

    public AudioSource audioManager;

    public bool a1Correct;

    private string option1a, option1b, option2, option3, option4;

    [SerializeField] private GameObject retryButton;
    [SerializeField] private GameObject passButton;

    // Start is called before the first frame update
    void Start()
    {
        character.gameObject.GetComponent<CharacterAnims>().states = 0;
        scenarioObj = GameObject.Find("ResearchScenario");
        nameBar = GameObject.Find("NameBar");
        scoreBar = GameObject.Find("ScoreBar");
        scenarioCloseButton = GameObject.Find("ScenarioButton_Close");
        scenarioViewButton = GameObject.Find("ScenarioButton_View");
        scenarioButtonClickBlock = GameObject.Find("ScenarioButtonClickBlock");
        questionObj = GameObject.Find("QuestionBG");
        feedback = GameObject.Find("Feedback");
        feedbackText = GameObject.Find("FeedbackText").GetComponent<Text>();
        nextButton = GameObject.Find("NextButton");
        next = GameObject.Find("NextButton").GetComponent<Button>();
        continueButton = GameObject.Find("Continue_Button");
        toggles[0] = GameObject.Find("Option1").GetComponent<Toggle>();
        toggles[1] = GameObject.Find("Option2").GetComponent<Toggle>();
        toggles[2] = GameObject.Find("Option3").GetComponent<Toggle>();
        toggles[3] = GameObject.Find("Option4").GetComponent<Toggle>();

        finalButton1 = GameObject.Find("Option1Final");
        finalButton2 = GameObject.Find("Option2Final");
        fb1 = GameObject.Find("Option1Final").GetComponent<Button>();
        fb2 = GameObject.Find("Option2Final").GetComponent<Button>();
        
        a[0] = GameObject.Find("Option1");
        a[1] = GameObject.Find("Option2");
        a[2] = GameObject.Find("Option3");
        a[3] = GameObject.Find("Option4");
        a[4] = GameObject.Find("Option5");
        a[5] = GameObject.Find("Option6");

        retryButton = GameObject.Find("RetryButton");
        passButton = GameObject.Find("PassButton");

        ResetGame();
    }

    public void ResetGame()
    {
        finalButton1.SetActive(false);
        finalButton2.SetActive(false);

        fb1.interactable = true;
        fb2.interactable = true;

        retryButton.SetActive(false);
        passButton.SetActive(false);

        feedback.SetActive(false);
        scenarioCloseButton.gameObject.SetActive(false);
        scenarioViewButton.gameObject.SetActive(false);
        questionObj.gameObject.SetActive(false);
        q1Completed = false;
        SpeechBubbleText();

        next.interactable = false;
        nextButton.SetActive(true);
        DefaultButtons();

        scenarioButtonClickBlock.gameObject.SetActive(false);

        ReadyToPlay();
    }

    public void SpeechBubbleText()
    {
        sentences[0] = "Correct: The dependent variable (DV) is \"Stress\".";
        sentences[1] = "Incorrect: Would you like to try again?";
    }

    // Update is called once per frame
    void Update()
    {
        //when typing text is typing, when the length is equal to the text the continue button will appear
        for (int i = 0; i < sentences.Length; i++)
        {
            if (feedbackText.text == sentences[0])
            {
                continueButton.SetActive(true);
                passButton.SetActive(false);
                retryButton.SetActive(false);
            }

            if (feedbackText.text == sentences[1])
            {
                continueButton.SetActive(false);
                passButton.SetActive(true);
                retryButton.SetActive(true);
            }
        }
    }

    public void ReadyToPlay()
    {
        passButton.SetActive(false);
        retryButton.SetActive(false);
        
        questionObj.gameObject.SetActive(true);
        scenarioViewButton.gameObject.SetActive(true);
        scenarioCloseButton.gameObject.SetActive(false);
        feedback.SetActive(false);
        next.interactable = false;
        scenarioButtonClickBlock.gameObject.SetActive(false);

        //Question 1
        q.text = "In the <b>study</b> what is the dependent variable?";
        subq.text = "Click <b>submit answer</b> when you have made your choice.";
        a1.text = "     Before and after meditation";
        a2.text = "     Stress";//correct answer
        a3.text = "     Anxiety";
        a4.text = "     Hours of work";
        a5.text = "     Not meditating";
        a6.text = "     Job satisfaction";
    }

    public void ViewStudy()
    {
        scenarioObj.gameObject.GetComponent<ScenarioAnimations>().states = 1;
        questionObj.gameObject.SetActive(false);
        scenarioCloseButton.gameObject.SetActive(true);
        scenarioViewButton.gameObject.SetActive(false);
        scenarioButtonClickBlock.gameObject.SetActive(true);
    }

    public void CloseStudy()
    {
        questionObj.gameObject.SetActive(true);
        scenarioObj.gameObject.GetComponent<ScenarioAnimations>().states = 2;
        scenarioViewButton.gameObject.SetActive(true);
        scenarioCloseButton.gameObject.SetActive(false);
        scenarioButtonClickBlock.gameObject.SetActive(false);
    }

    public void ButtonPress()
    {
        string name = EventSystem.current.currentSelectedGameObject.name;

        if (name == "Continue_Button")
        {
            if (q1Completed)
            {
                feedback.SetActive(true);
                nextButton.SetActive(false);

                SceneManager.LoadScene("MS_Hangman");
            }
        }
        //-------------------------------------------------------------------------------------------------------------------------------------------------
        
        //Next Button 1
        if (name == "NextButton")
        {
            {
                if (toggles[4].isOn == false && toggles[0].isOn == false && toggles[1].isOn == true && toggles[2].isOn == false && toggles[3].isOn == false && toggles[5].isOn == false)
                {
                    character.gameObject.GetComponent<CharacterAnims>().states = 2;//Thumbs up anim           
                    nextButton.SetActive(false);
                    index = 0;
                    ActivateFeedback();
                    a1Correct = true;
                    q1Completed = true;
                    scoreBar.gameObject.GetComponent<ScoreSystem>().AddMSScore();
                }
                else
                {
                    character.gameObject.GetComponent<CharacterAnims>().states = 3;//Shake head anim
                    nextButton.SetActive(false);
                    index = 1;
                    ActivateFeedback();
                    q1Completed = true;
                    scoreBar.gameObject.GetComponent<ScoreSystem>().RemoveMSScore();
                }
            }
        }

        if (name == "Option1Final")
        {
            fb1.interactable = false;
            fb2.interactable = true;

            q1Answered = true;
            q2Answered = false;
        }

        if (name == "Option2Final")
        {
            fb1.interactable = true;
            fb2.interactable = false;

            q1Answered = false;
            q2Answered = true;
        }
        //--------------------------------------------------------------------------

        if (name == "Option1")
        {
            toggles[0].isOn = true;
            toggles[1].isOn = false;
            toggles[2].isOn = false;
            toggles[3].isOn = false;
            toggles[4].isOn = false;
            toggles[5].isOn = false;
        }
        if (name == "Option2")
        {
            toggles[0].isOn = false;
            toggles[1].isOn = true;
            toggles[2].isOn = false;
            toggles[3].isOn = false;
            toggles[4].isOn = false;
            toggles[5].isOn = false;
        }
        if (name == "Option3")
        {
            toggles[0].isOn = false;
            toggles[1].isOn = false;
            toggles[2].isOn = true;
            toggles[3].isOn = false;
            toggles[4].isOn = false;
            toggles[5].isOn = false;
        }
        if (name == "Option4")
        {
            toggles[0].isOn = false;
            toggles[1].isOn = false;
            toggles[2].isOn = false;
            toggles[3].isOn = true;
            toggles[4].isOn = false;
            toggles[5].isOn = false;
        }
        if (name == "Option5")
        {
            toggles[0].isOn = false;
            toggles[1].isOn = false;
            toggles[2].isOn = false;
            toggles[3].isOn = false;
            toggles[4].isOn = true;
            toggles[5].isOn = false;
        }
        if (name == "Option6")
        {
            toggles[0].isOn = false;
            toggles[1].isOn = false;
            toggles[2].isOn = false;
            toggles[3].isOn = false;
            toggles[4].isOn = false;
            toggles[5].isOn = true;
        }

        //------------------------------------------------------------------------------------------

        if (name == "RetryButton")
        {
            ResetGame();
        }

        if (name == "PassButton")
        {
            SceneManager.LoadScene("MS_Hangman");
        }
    }

    public void ActivateFeedback()
    {
        feedback.SetActive(true);
        feedbackText.text = "";
        continueButton.SetActive(false);
        StartCoroutine(Type());
    }

    //Toggle Script used for each answer
    public void ToggleButton()
    {
        for (int t = 0; t < toggles.Length; t++)
        {
            if (toggles[t].isOn)
            {
                ColorBlock b1Color = toggles[t].colors;
                b1Color.normalColor = new Color32(149, 195, 212, 200); //green
                b1Color.highlightedColor = new Color32(210, 210, 210, 250);
                b1Color.selectedColor = new Color32(149, 195, 212, 200);
                toggles[t].colors = b1Color;
                next.interactable = true;
            }

            if (!toggles[t].isOn)
            {
                ColorBlock b1Color = toggles[t].colors;
                b1Color.normalColor = Color.white;
                b1Color.highlightedColor = new Color32(210, 210, 210, 250);
                b1Color.selectedColor = Color.white;
                toggles[t].colors = b1Color;
            }
        }
    }
    //Used to reset buttons after each question
    public void DefaultButtons()
    {

        for (int t = 0; t < toggles.Length; t++)
        {
            toggles[t].isOn = false;
        }
    }

    IEnumerator Type()
    {
        if (feedback.gameObject.activeInHierarchy == true)
        {
            continueButton.SetActive(false);
            retryButton.SetActive(false);
            passButton.SetActive(false);

            foreach (char letter in sentences[index].ToCharArray())
            {
                feedbackText.text += letter;
                yield return new WaitForSeconds(typingSpeed);
            }
        }
    }
}