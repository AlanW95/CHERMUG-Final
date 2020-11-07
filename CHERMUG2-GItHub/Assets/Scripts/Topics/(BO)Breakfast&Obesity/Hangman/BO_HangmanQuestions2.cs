using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

//////////////////////////////////////////////////<summary>//////////////////////////////////////////////////// 
///                                   University of the West of Scotland                                    ///
///                                      BREAKFAST AND OBESITY TOPIC                                        ///
///                               -------------------------------------------                               ///  
/// Script is attached to the Manager GameObject in the BO_QuestionsHM2 scene.                              ///
///                                                                                                         ///                    
//////////////////////////////////////////////////</summary>///////////////////////////////////////////////////

public class BO_HangmanQuestions2 : MonoBehaviour
{
    public GameObject scoreBar;
    public GameObject nameBar;

    public GameObject scenarioObj;
    public GameObject scenarioCloseButton;
    public GameObject scenarioViewButton;
    public GameObject scenarioButtonClickBlock;

    public GameObject questionObj;
    public GameObject questions;
    public GameObject nextButton;
    public GameObject nextButton2;
    private Button next;
    private Button next2;
    
    public Text scenario;
    public Text q;
    public Text subq;
    public Text a1;
    public Text a2;

    public GameObject feedback;
    public Text feedbackText;

    public GameObject continueButton;
    public GameObject finish_ContinueButton;

    //Typing Text
    public string[] sentences;
    private int index;
    public float typingSpeed;

    public Button option1Button;
    public Button option2Button;

    private bool q1Answered;
    private bool q2Answered;
    private bool q3Answered;
    private bool q4Answered;

    public GameObject character;
    private bool finished;

    public GameObject fadeScreen;

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
        finish_ContinueButton = GameObject.Find("Finished_ContinueButton");

        next = GameObject.Find("NextButton").GetComponent<Button>();
        next2 = GameObject.Find("NextButton2").GetComponent<Button>();

        feedback = GameObject.Find("Feedback");
        feedbackText = GameObject.Find("FeedbackText").GetComponent<Text>();
        
        option1Button = GameObject.Find("Option1").GetComponent<Button>();
        option2Button = GameObject.Find("Option2").GetComponent<Button>();

        scenarioButtonClickBlock.gameObject.SetActive(false);

        ResetQ1();
    }

    // Update is called once per frame
    void Update()
    {
        //when typing text is typing, when the length is equal to the text the continue button will appear
        for (int i = 0; i < sentences.Length; i++)
        {
            continueButton.SetActive(false);
            finish_ContinueButton.SetActive(false);

            if (feedbackText.text == sentences[0] || feedbackText.text == sentences[1])
            {
                continueButton.SetActive(true);
                finish_ContinueButton.SetActive(false);
            }
            if (feedbackText.text == sentences[2] || feedbackText.text == sentences[3])
            {
                continueButton.SetActive(false);
                finish_ContinueButton.SetActive(true);
            }
        }
    }

    public void ResetQ1()
    {
        Q1();

        SpeechBubbleText();

        option1Button.interactable = true;
        option2Button.interactable = true;

        q1Answered = false;
        q2Answered = false;
        q3Answered = false;
        q4Answered = false;

        feedback.SetActive(false);
        finish_ContinueButton.SetActive(false);
        finished = false;

        nextButton.SetActive(true);
        nextButton2.SetActive(false);
        next.interactable = false;
    }

    public void SpeechBubbleText()
    {
        sentences[0] = "Correct: Well done!";
        sentences[1] = "Incorrect: Not for this study - BMI numbers can be turned into categorical data, but are being kept as numbers here.";
        sentences[2] = "Correct: This study is comparing women who eat breakfast and women who do not.";
        sentences[3] = "Incorrect: This study is comparing two groups.";
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

    public void ActivateFeedback()
    {
        feedback.SetActive(true);
        feedbackText.gameObject.SetActive(true);
        feedbackText.text = "";
        questions.SetActive(true);
        StartCoroutine(Type());
    }
    
    public void Next()
    {
        if (q1Answered)
        {
            character.gameObject.GetComponent<CharacterAnims>().states = 2;//Thumbs up anim
            index = 0;
            ActivateFeedback();
            nextButton.SetActive(false);
            scoreBar.gameObject.GetComponent<ScoreSystem>().AddBOScore();
        }
        else
        {
            character.gameObject.GetComponent<CharacterAnims>().states = 3;//Shake head anim
            index = 1;
            ActivateFeedback();
            nextButton.SetActive(false);
            scoreBar.gameObject.GetComponent<ScoreSystem>().RemoveBOScore();
        }
    }

    public void Next2()
    {
        if (q2Answered)
        {
            character.gameObject.GetComponent<CharacterAnims>().states = 2;//Thumbs up anim
            index = 2;
            ActivateFeedback();
            nextButton2.SetActive(false);
            finish_ContinueButton.SetActive(true);
            finished = true;
            scoreBar.gameObject.GetComponent<ScoreSystem>().AddBOScore();
        }
        else
        {
            character.gameObject.GetComponent<CharacterAnims>().states = 3;//Shake head anim
            index = 3;
            ActivateFeedback();
            nextButton2.SetActive(false);
            finish_ContinueButton.SetActive(true);
            scoreBar.gameObject.GetComponent<ScoreSystem>().RemoveBOScore();
        }
    }

    public void ProgressToNextScene()
    {
        fadeScreen.gameObject.GetComponent<FadeInTransition>().FadeImageIn();
    }

    //------------------------QUESTIONS-------------------------------

    public void Q1()
    {
        questions.SetActive(true);

        //Question 1
        q.text = "In this <b>study</b> what type of data is BMI?";
        subq.text = "";
        a1.text = "Numbers";
        a2.text = "Categories";
    }

    public void Q2()
    {
        questions.SetActive(true);
        option1Button.interactable = true;
        option2Button.interactable = true;
        nextButton.SetActive(false);
        nextButton2.SetActive(true);
        feedback.SetActive(false);

        //Question 2
        q.text = "What kind of design is this study investigating?";
        subq.text = "";
        a1.text = "Investigating an association";
        a2.text = "Investigating differences between groups";

        next2.interactable = false;
    }
    //---------------------------------------------------------------------------------------------------

    public void ButtonPress()
    {
        string name = EventSystem.current.currentSelectedGameObject.name;

        next.interactable = true;
        next2.interactable = true;

        if (name == "RetryButton")
        {
            if (index == 1)
            {
                ResetQ1();
            }
            if (index == 3)
            {
                Q2();
            }
        }
        if(name == "PassButton")
        {
            if (index == 1)
            {
                Q2();
            }
            if (index == 3)
            {
                ProgressToNextScene();
            }
        }
        
        if (name == "Option1")
        {
            option1Button.interactable = false;
            option2Button.interactable = true;

            q1Answered = true;
            q2Answered = false;
            q3Answered = false;
            q4Answered = false;
        }
        if (name == "Option2")
        {
            option1Button.interactable = true;
            option2Button.interactable = false;

            q1Answered = false;
            q2Answered = true;
            q3Answered = false;
            q4Answered = false;
        }
        if (name == "Finished_ContinueButton")
        {
            ProgressToNextScene();
        }
    }

    IEnumerator Type()
    {
        if (feedback)
        {
            continueButton.SetActive(false);
            finish_ContinueButton.SetActive(false);

            foreach (char letter in sentences[index].ToCharArray())
            {
                feedbackText.text += letter;
                yield return new WaitForSeconds(typingSpeed);
            }
        }
    }
}
