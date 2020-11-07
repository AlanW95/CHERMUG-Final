using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

//////////////////////////////////////////////////<summary>//////////////////////////////////////////////////// 
///                                   University of the West of Scotland                                    ///
///                                    SKIPPING MEALS AND OBESITY TOPIC                                     ///
///                               -------------------------------------------                               ///  
/// Script is attached to the Manager GameObject in the SMO_MultipleChoice2 scene.                          ///
///                                                                                                         ///
//////////////////////////////////////////////////</summary>///////////////////////////////////////////////////

public class SMO_MultipleChoice2 : MonoBehaviour
{
    public BarAnimations animScript;
    public GameObject scoreBar;
    public GameObject nameBar;

    public GameObject scenarioObj;
    public GameObject scenarioCloseButton;
    public GameObject scenarioViewButton;
    public GameObject scenarioButtonClickBlock;

    public GameObject question1;
    public GameObject question2;
    public GameObject feedback;

    public Button q1a1;
    public Button q1a2;
    public Button q1a3;
    public Button q1a4;
    
    //Typing Text
    public Text feedbackText;
    public string[] sentences;
    private int index;
    public float typingSpeed;

    [SerializeField] private GameObject continueButton;//Button on the feedback speech bubble
    public GameObject buttonContinue;//Submit button

    private bool q1Completed;
    private Button q1Continue;
    private bool q1a1Answered; 
    private bool q1a2Answered;
    private bool q1a3Answered;
    private bool q1a4Answered;

    public GameObject character;
    public GameObject fadeScreen;

    public GameObject RetryButton;
    public GameObject PassButton;

    // Start is called before the first frame update
    void Start()
    {
        character.gameObject.GetComponent<CharacterAnims>().states = 0;
        nameBar.gameObject.GetComponent<BarAnimations>().states = 1;
        scoreBar.gameObject.GetComponent<BarAnimations>().states = 1;
        scenarioObj = GameObject.Find("ResearchScenario");
        nameBar = GameObject.Find("NameBar");
        scoreBar = GameObject.Find("ScoreBar");
        scenarioCloseButton = GameObject.Find("ScenarioButton_Close");
        scenarioViewButton = GameObject.Find("ScenarioButton_View");
        scenarioButtonClickBlock = GameObject.Find("ScenarioButtonClickBlock");
        feedback = GameObject.Find("Feedback");
        feedbackText = GameObject.Find("FeedbackText").GetComponent<Text>();
        continueButton = GameObject.Find("Continue_Button");
        buttonContinue = GameObject.Find("Button_Continue");
        q1Continue = GameObject.Find("Button_Continue").GetComponent<Button>();
        
        RetryButton = GameObject.Find("RetryButton");
        PassButton = GameObject.Find("PassButton");

        SpeechBubbleText();
        
        ResetQ1();
    }

    public void SpeechBubbleText()
    {
        sentences[0] = "Correct: Yes, sometimes and no is the correct answer.";
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
            }
            if (feedbackText.text == sentences[1])
            {
                continueButton.SetActive(false);
                RetryButton.SetActive(true);
                PassButton.SetActive(true);
            }
        }
        
    }

    public void ResetQ1()
    {
        buttonContinue.SetActive(true);
        q1Continue.interactable = false;
        question1.SetActive(true);
        feedback.SetActive(false);
        q1Completed = false;
        RetryButton.SetActive(false);
        PassButton.SetActive(false);
        scenarioButtonClickBlock.gameObject.SetActive(false);

        SpeechBubbleText();
    }

    public void ViewStudy()
    {
        scenarioObj.gameObject.GetComponent<ScenarioAnimations>().states = 1;
        scenarioCloseButton.gameObject.SetActive(true);
        scenarioViewButton.gameObject.SetActive(false);
        scenarioButtonClickBlock.gameObject.SetActive(true);
    }
    
    public void CloseStudy()
    {
        scenarioObj.gameObject.GetComponent<ScenarioAnimations>().states = 2;
        scenarioViewButton.gameObject.SetActive(true);
        scenarioCloseButton.gameObject.SetActive(false);
        scenarioButtonClickBlock.gameObject.SetActive(false);
    }

    public void ActivateFeedback()
    {
        feedback.SetActive(true);
        feedbackText.text = "";
        continueButton.SetActive(false);
        StartCoroutine(Type());
    }

    public void ButtonPress()
    {
        string name = EventSystem.current.currentSelectedGameObject.name;
        
        if (name == "RetryButton")
        {
            if (index == 1)
            {
                ResetQ1();
            }
        }
        if (name == "PassButton")
        {
            if(index == 1)
            {
                SceneManager.LoadScene("SMO_Hangman");
            }
        }
        //QUESTION 1
        if (name == "Q1A1")
        {
            index = 1;

            q1Continue.interactable = true;
            q1a1Answered = true;
            q1a2Answered = false;
            q1a3Answered = false;
            q1a4Answered = false;
        }

        if (name == "Q1A2")
        {   
            index = 0;

            q1Continue.interactable = true;
            q1a1Answered = false;
            q1a2Answered = true;
            q1a3Answered = false;
            q1a4Answered = false;
        }
        if (name == "Q1A3")
        {
            index = 1;

            q1Continue.interactable = true;
            q1a1Answered = false;
            q1a2Answered = false;
            q1a3Answered = true;
            q1a4Answered = false;
        }
        if (name == "Q1A4")
        {
            index = 1;

            q1Continue.interactable = true;
            q1a1Answered = false;
            q1a2Answered = false;
            q1a3Answered = false;
            q1a4Answered = true;
        }
       
        if (name == "Button_Continue")
        {
            if (q1a1Answered)
            {
                character.gameObject.GetComponent<CharacterAnims>().states = 3;//Shake head anim
                q1Completed = true;
                ActivateFeedback();
                scoreBar.gameObject.GetComponent<ScoreSystem>().RemoveSMOScore();
            }
            if (q1a2Answered)
            {
                character.gameObject.GetComponent<CharacterAnims>().states = 2;//Thumbs up anim
                q1Completed = true;
                ActivateFeedback();
                scoreBar.gameObject.GetComponent<ScoreSystem>().AddSMOScore();
            }
            if (q1a3Answered)
            {
                character.gameObject.GetComponent<CharacterAnims>().states = 3;//Shake head anim
                q1Completed = true;
                ActivateFeedback();
                scoreBar.gameObject.GetComponent<ScoreSystem>().RemoveSMOScore();
            }
            if (q1a4Answered)
            {
                character.gameObject.GetComponent<CharacterAnims>().states = 3;//Shake head anim
                q1Completed = true;
                ActivateFeedback();
                scoreBar.gameObject.GetComponent<ScoreSystem>().RemoveSMOScore();
            }
        }

        if (name == "Continue_Button")
        {
            if (q1Completed)
            {
                SceneManager.LoadScene("SMO_Hangman");
            }
        }
    }

    IEnumerator Type()
    {
        if (feedback.gameObject.activeInHierarchy == true)
        {
            continueButton.SetActive(false);
            buttonContinue.SetActive(false);
            q1Continue.interactable = false;
            RetryButton.SetActive(false);
            PassButton.SetActive(false);

            foreach (char letter in sentences[index].ToCharArray())
            {
                feedbackText.text += letter;
                yield return new WaitForSeconds(typingSpeed);
            }
        }
    }
}