using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

//////////////////////////////////////////////////<summary>//////////////////////////////////////////////////// 
///                                   University of the West of Scotland                                    ///
///                                NATIONALITY AND MEDITERRANEAN FOODS TOPIC                                ///
///                               -------------------------------------------                               ///  
/// Script is attached to the Manager GameObject in the NMF_QuestionsTTT scene.                             ///
///                                                                                                         ///
//////////////////////////////////////////////////</summary>///////////////////////////////////////////////////

public class NMF_TicTacToeQuestions : MonoBehaviour
{
    public BarAnimations animScript;
    public GameObject scoreBar;
    public GameObject nameBar;

    public GameObject scenarioCloseButton;
    public GameObject scenarioViewButton;
    public GameObject scenarioButtonClickBlock;
    public GameObject scenarioObj;

    public GameObject questions;
    public GameObject nextButton;
    public GameObject feedback;

    private Button next;
    
    public Text scenario;
    public Text q;
    public Text subq;
    public Text a1;
    public Text a2;

    //Typing Text
    public Text feedbackText;

    public string[] sentences;
    private int index;
    public float typingSpeed;

    public Button option1Button;
    public Button option2Button;

    private bool q1Answered;
    private bool q2Answered;
    private bool q3Answered;

    public GameObject character;
    public GameObject fadeScreen;

    public GameObject continueButtonQ2;
    public GameObject continueButtonQ3;
    public GameObject finish_ContinueButton;

    private bool finished;
    private bool question1, question2, question3;

    // Start is called before the first frame update
    void Start()
    {
        Q1();
        
        scenarioObj = GameObject.Find("ResearchScenario");
        nameBar = GameObject.Find("NameBar");
        scoreBar = GameObject.Find("ScoreBar");
        scenarioCloseButton = GameObject.Find("ScenarioButton_Close");
        scenarioViewButton = GameObject.Find("ScenarioButton_View");
        scenarioButtonClickBlock = GameObject.Find("ScenarioButtonClickBlock");

        feedback = GameObject.Find("Feedback");
        feedbackText = GameObject.Find("FeedbackText").GetComponent<Text>();

        SpeechBubbleText();

        option1Button = GameObject.Find("Option1").GetComponent<Button>();
        option2Button = GameObject.Find("Option2").GetComponent<Button>();

        next = GameObject.Find("NextButton").GetComponent<Button>();

        option1Button.interactable = true;
        option2Button.interactable = true;

        q1Answered = false;
        q2Answered = false;
        q3Answered = false;

        feedback.SetActive(false);

        next.interactable = false;
        continueButtonQ2.SetActive(false);
        continueButtonQ3.SetActive(false);
        finish_ContinueButton.SetActive(false);
        finished = false;
        question1 = false;
        question2 = false;
        question3 = false;

        scenarioButtonClickBlock.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //when typing text is typing, when the length is equal to the text the continue button will appear
        for (int i = 0; i < sentences.Length; i++)
        {
            if (feedbackText.text == sentences[index])
            {
                if (question1)
                {
                    finish_ContinueButton.SetActive(true);
                }

                if (question2)
                {
                    continueButtonQ3.SetActive(true);
                }

                if (question3)
                {
                    finish_ContinueButton.SetActive(true);
                }
            }

            if (finished == true)
            {
                continueButtonQ2.SetActive(false);
                continueButtonQ3.SetActive(false);
                finish_ContinueButton.SetActive(true);
            }
        }
    }

    public void SpeechBubbleText()
    {
        sentences[0] = "Correct: This is the right test since independent samples t tests look at differences between two groups; the box plots suggest the data is not skewed and have no outliers.";
        sentences[1] = "Incorrect: The Paired Samples t Test compares two means that are taken from the same individual, for example measurements taken at 2 different points in time or under 2 different conditions.";
    }

    public void ReadyToPlay()
    {
        scenarioObj.gameObject.GetComponent<ScenarioAnimations>().states = 2;
        scenarioViewButton.gameObject.SetActive(true);
        scenarioCloseButton.gameObject.SetActive(false);
        questions.SetActive(true);
        scenarioButtonClickBlock.gameObject.SetActive(false);
    }
    
    public void ViewStudy()
    {
        scenarioObj.gameObject.GetComponent<ScenarioAnimations>().states = 1;
        scenarioCloseButton.gameObject.SetActive(true);
        scenarioViewButton.gameObject.SetActive(false);
        questions.SetActive(true);
        scenarioButtonClickBlock.gameObject.SetActive(true);
    }
    
    public void CloseStudy()
    {
        scenarioObj.gameObject.GetComponent<ScenarioAnimations>().states = 2;
        scenarioViewButton.gameObject.SetActive(true);
        scenarioCloseButton.gameObject.SetActive(false);
        questions.SetActive(true);
        scenarioButtonClickBlock.gameObject.SetActive(false);
    }

    public void ProgressToNextScene()
    {
        fadeScreen.gameObject.GetComponent<FadeInTransition>().FadeImageIn();
    }

    public void ActivateFeedback()
    {
        feedback.SetActive(true);
        feedbackText.gameObject.SetActive(true);
        feedbackText.text = "";
        questions.SetActive(true);
    }
    
    public void Next()
    {
        if(q1Answered)
        {
            character.gameObject.GetComponent<CharacterAnims>().states = 2;//Thumbs up anim
            continueButtonQ2.SetActive(true);
            feedbackText.text = "";
            index = 0;
            ActivateFeedback();
            nextButton.SetActive(false);
            scoreBar.gameObject.GetComponent<ScoreSystem>().AddScore();
            question1 = true;
            question2 = false;
            question3 = false;
            StartCoroutine(Type());
        }
        if(q2Answered)
        {
            character.gameObject.GetComponent<CharacterAnims>().states = 3;//Shake head anim
            continueButtonQ2.SetActive(true);
            feedbackText.text = "";
            index = 1;
            ActivateFeedback();
            nextButton.SetActive(false);
            scoreBar.gameObject.GetComponent<ScoreSystem>().RemoveScore();
            question1 = true;
            question2 = false;
            question3 = false;
            StartCoroutine(Type());
        }
    }

    //------------------------QUESTIONS-------------------------------

    public void Q1()
    {
        questions.SetActive(true);

        //Question 1
        scenario.text = "The \"Mediterranean\" diet traditionally eaten by Southern Europeans is rich in fruit, vegetables, beans, olive oil, nuts and fish." +
            "Recently it has been suggested that this kind of diet helps to prevent obesity. It seems likely that Northern Europeans eat fewer of these Mediterranean foods." +
            "In the current study 60 British children and 60 Spanish children were presented with a checklist of 30 Mediterranean foods and they were asked to indicate" +
            "which of these foods they had eaten in the previous week. Each child was given a score from 0 to 30.";
        q.text = "Which statistical test should we use to test the hypothesis?";
        subq.text = "";
        a1.text = "     t test for independent samples";
        a2.text = "     Paired samples t test";
    }
    //----------------------------------------------------------------------------------------------------------------------------------------------------------

    public void CheckButtonPress()
    {
        string name = EventSystem.current.currentSelectedGameObject.name;

        next.interactable = true;

        if (name == "Option1")
        {
            option1Button.interactable = false;
            option2Button.interactable = true;

            q1Answered = true;
            q2Answered = false;
            q3Answered = false;
        }
        if (name == "Option2")
        {
            option1Button.interactable = true;
            option2Button.interactable = false;

            q1Answered = false;
            q2Answered = true;
            q3Answered = false;
        }
        if (name == "Finish_ContinueButton")
        {
            ProgressToNextScene();
        }
    }

    IEnumerator Type()
    {
        continueButtonQ2.SetActive(false);
        continueButtonQ3.SetActive(false);
        finish_ContinueButton.SetActive(false);

        if (question1)
        {           
            foreach (char letter in sentences[index].ToCharArray())
            {
                feedbackText.text += letter;
                yield return new WaitForSeconds(typingSpeed);
            }
        }

        if (question2)
        {           
            foreach (char letter in sentences[index].ToCharArray())
            {
                feedbackText.text += letter;
                yield return new WaitForSeconds(typingSpeed);
            }
        }

        if (question3)
        {            
            foreach (char letter in sentences[index].ToCharArray())
            {
                feedbackText.text += letter;
                yield return new WaitForSeconds(typingSpeed);
            }
        }
    }
}