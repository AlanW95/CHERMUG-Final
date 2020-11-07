using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

//////////////////////////////////////////////////<summary>//////////////////////////////////////////////////// 
///                                   University of the West of Scotland                                    ///
///                              INTERVENTION, TIME AND BODY POSITIVITY TOPIC                               ///
///                               -------------------------------------------                               ///  
/// Script is attached to the Manager GameObject in the ITBP_QuestionsData scene.                           ///
///                                                                                                         ///
//////////////////////////////////////////////////</summary>///////////////////////////////////////////////////

public class ITBP_DataQuestions : MonoBehaviour
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
    public GameObject question3;
    public GameObject feedback;

    public Button q1a1;
    public Button q1a2;
    public Button q2a1;
    public Button q2a2;
    public Button q3a1;
    public Button q3a2;
    public Button q3a3;

    private GameObject q2Button;
    private GameObject q3Button;
    private GameObject dataset1Button;
    private GameObject dataset2Button;

    private GameObject boxplot1Button;
    private GameObject boxplot2Button;

    //Typing Text
    public Text feedbackText;
    public string[] sentences;
    private int index;
    public float typingSpeed;

    [SerializeField] private GameObject continueButton;

    private bool q1Completed;
    private bool q2Completed;
    private bool q3Completed;
    private Button q2Continue;
    private Button q3Continue;
    private bool q1a1Answered; 
    private bool q1a2Answered;
    private bool q2a1Answered;
    private bool q2a2Answered;
    private bool q3a1Answered;
    private bool q3a2Answered;
    private bool q3a3Answered;

    public GameObject character;
    public GameObject fadeScreen;

    [SerializeField] private GameObject retryButton;
    [SerializeField] private GameObject passButton;

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
        q2Continue = GameObject.Find("Button_ContinueQ2").GetComponent<Button>();
        q2Button = GameObject.Find("Button_ContinueQ2");
        q3Button = GameObject.Find("Button_ContinueQ3");
        dataset1Button = GameObject.Find("Q1A1");
        dataset2Button = GameObject.Find("Q1A2");
        boxplot1Button = GameObject.Find("Q3A1");
        boxplot2Button = GameObject.Find("Q3A2");

        retryButton = GameObject.Find("RetryButton");
        passButton = GameObject.Find("PassButton");

        q3Button.SetActive(false);
        q2Continue.interactable = false;
        question1.SetActive(true);
        question2.SetActive(false);
        question3.SetActive(false);
        feedback.SetActive(false);
        q1Completed = false;
        q2Completed = false;
        q3Completed = false;
        scenarioButtonClickBlock.gameObject.SetActive(false);
        
        SpeechBubbleText();
    }

    public void RetryQ3()
    {
        feedback.SetActive(false);
        question1.SetActive(false);
        question2.SetActive(false);
        question3.SetActive(true);
        q3Completed = false;

        q3Button.SetActive(true);
        q3Continue.interactable = false;

        q3a1.interactable = true;
        q3a2.interactable = true;
        q3a3.interactable = true;

        q3a1Answered = false;
        q3a2Answered = false;
        q3a3Answered = false;
    }

    public void SpeechBubbleText()
    {
        //Question 1
        sentences[0] = "Correct: All three variables are clear here.";
        sentences[1] = "Incorrect: Only one independent variable is shown here.";
        //Question 2
        sentences[2] = "Correct: Well done!";
        sentences[3] = "Incorrect: You don’t have a pair of numeric variables for a scatter plot.";
        //Question 3
        sentences[4] = "Correct: You have two independent variables in this study: one is between and one is within.";
        sentences[5] = "Incorrect: Would you like to try again?";
        sentences[6] = "Incorrect: Would you like to try again?";
    }

    // Update is called once per frame
    void Update()
    {
        //when typing text is typing, when the length is equal to the text the continue button will appear
        for (int i = 0; i < sentences.Length; i++)
        {
            if (feedbackText.text == sentences[0] || feedbackText.text == sentences[1] || feedbackText.text == sentences[2] || feedbackText.text == sentences[3] || feedbackText.text == sentences[4])
            {
                continueButton.SetActive(true);
                passButton.SetActive(false);
                retryButton.SetActive(false);
            }

            if (feedbackText.text == sentences[5] || feedbackText.text == sentences[6])
            {
                continueButton.SetActive(false);
                passButton.SetActive(true);
                retryButton.SetActive(true);
            }
        }
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
        continueButton.SetActive(false);
        feedbackText.text = "";
        continueButton.SetActive(false);
        dataset1Button.SetActive(false);
        dataset2Button.SetActive(false);
        StartCoroutine(Type());
    }

    public void ButtonPress()
    {
        string name = EventSystem.current.currentSelectedGameObject.name;
        
        if (name == "Q1A1")
        {
            character.gameObject.GetComponent<CharacterAnims>().states = 2;//Thumbs up anim
            index = 0;
            q1Completed = true;
            ActivateFeedback();
            scoreBar.gameObject.GetComponent<ScoreSystem>().AddITBPScore();
        }

        if (name == "Q1A2")
        {
            character.gameObject.GetComponent<CharacterAnims>().states = 3;//Shake head anim
            index = 1;
            q1Completed = true;
            ActivateFeedback();
            scoreBar.gameObject.GetComponent<ScoreSystem>().RemoveITBPScore();
        }

        if (name == "Q2A1")
        {
            q2a1.interactable = false;
            q2a2.interactable = true;

            q1a1Answered = false;
            q1a2Answered = false;
            q2a1Answered = true;
            q2a2Answered = false;
            
            q2Continue.interactable = true;
        }

        if (name == "Q2A2")
        {
            q2a1.interactable = true;
            q2a2.interactable = false;

            q1a1Answered = false;
            q1a2Answered = false;
            q2a1Answered = false;
            q2a2Answered = true;

            q2Continue.interactable = true;
        }

        if (name == "Q2A3")
        {
            q2a1.interactable = true;
            q2a2.interactable = true;

            q1a1Answered = false;
            q1a2Answered = false;
            q2a1Answered = false;
            q2a2Answered = false;
            
            q2Continue.interactable = true;
        }

        if (name == "Q3A1")
        {
            q3a1.interactable = false;
            q3a2.interactable = true;
            q3a3.interactable = true;
            
            q3a1Answered = true;
            q3a2Answered = false;
            q3a3Answered = false;
            
            q3Button.SetActive(true);
            q3Continue.interactable = true;
        }

        if (name == "Q3A2")
        {
            q3a1.interactable = true;
            q3a2.interactable = false;
            q3a3.interactable = true;
            
            q3a1Answered = false;
            q3a2Answered = true;
            q3a3Answered = false;

            q3Button.SetActive(true);
            q3Continue.interactable = true;
        }

        if (name == "Q3A3")
        {
            q3a1.interactable = true;
            q3a2.interactable = true;
            q3a3.interactable = false;
            
            q3a1Answered = false;
            q3a2Answered = false;
            q3a3Answered = true;

            q3Button.SetActive(true);
            q3Continue.interactable = true;
        }
        if (name == "Button_ContinueQ2")
        {
            if (q2a1Answered)
            {
                character.gameObject.GetComponent<CharacterAnims>().states = 2;//Thumbs up anim
                index = 2;
                q2Completed = true;
                ActivateFeedback();
                q2Button.SetActive(false);
                scoreBar.gameObject.GetComponent<ScoreSystem>().AddITBPScore();
            }

            if (q2a2Answered)
            {
                character.gameObject.GetComponent<CharacterAnims>().states = 3;//Shake head anim
                index = 3;
                q2Completed = true;
                ActivateFeedback();
                q2Button.SetActive(false);
                scoreBar.gameObject.GetComponent<ScoreSystem>().RemoveITBPScore();
            }
        }
        if (name == "Button_ContinueQ3")
        {
            if (q3a3Answered)
            {
                character.gameObject.GetComponent<CharacterAnims>().states = 2;//Thumbs up anim
                index = 4;
                q3Completed = true;
                ActivateFeedback();
                q3Button.SetActive(false);
                scoreBar.gameObject.GetComponent<ScoreSystem>().AddITBPScore();
            }

            if (q3a2Answered)
            {
                character.gameObject.GetComponent<CharacterAnims>().states = 3;//Shake head anim
                index = 5;
                q3Completed = true;
                ActivateFeedback();
                q3Button.SetActive(false);
                scoreBar.gameObject.GetComponent<ScoreSystem>().RemoveITBPScore();
            }

            if (q3a1Answered)
            {
                character.gameObject.GetComponent<CharacterAnims>().states = 3;//Shake head anim
                index = 6;
                q3Completed = true;
                ActivateFeedback();
                q3Button.SetActive(false);
                scoreBar.gameObject.GetComponent<ScoreSystem>().RemoveITBPScore();
            }
        }

        if (name == "Continue_Button")
        {
            if (q1Completed)
            {
                feedback.SetActive(false);
                question1.SetActive(false);
                question2.SetActive(true);
            }
            if(q2Completed)
            {
                feedback.SetActive(false);
                question1.SetActive(false);
                question2.SetActive(false);
                question3.SetActive(true);
            }
            if (q3Completed)
            {
                feedback.SetActive(false);
                question1.SetActive(false);
                question2.SetActive(false);
                question3.SetActive(false);
                q3Button.SetActive(false);
            }

            if (q1Completed && q2Completed && q3Completed)
            {
                feedback.SetActive(false);
                //transition to next scene
                fadeScreen.gameObject.GetComponent<FadeInTransition>().FadeImageIn();
            }
        }

        if (name == "RetryButton")
        {
            RetryQ3();
        }

        if (name == "PassButton")
        {
            feedback.SetActive(true);
            //transition to next scene
            fadeScreen.gameObject.GetComponent<FadeInTransition>().FadeImageIn();
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