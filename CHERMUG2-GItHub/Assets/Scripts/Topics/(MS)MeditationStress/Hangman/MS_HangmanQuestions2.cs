using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

//////////////////////////////////////////////////<summary>//////////////////////////////////////////////////// 
///                                   University of the West of Scotland                                    ///
///                               WITHIN PARTICIPANTS MEDITATION STRESS TOPIC                               ///
///                               -------------------------------------------                               ///  
/// Script is attached to the Manager GameObject in the MS_QuestionsHM2 scene.                              ///
///                                                                                                         ///                    
//////////////////////////////////////////////////</summary>///////////////////////////////////////////////////

public class MS_HangmanQuestions2 : MonoBehaviour
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
    public GameObject nextButton3;

    public Button next;
    public Button next2;
    public Button next3;
    
    public Text scenario;
    public Text q;
    public Text subq;
    public Text a1;
    public Text a2;
    public Text a3;
    public Text a4;

    public GameObject feedback;
    public Text feedbackText;

    public GameObject finish_ContinueButton;
    public GameObject ContinueButton;

    //Typing Text
    public string[] sentences;
    private int index;
    public float typingSpeed;

    public Button option1Button;
    public Button option2Button;
    public Button option3Button;
    public Button option4Button;

    public GameObject Option3button;
    public GameObject Option4button;

    private bool q1Answered;
    private bool q2Answered;
    private bool q3Answered;
    private bool q4Answered;

    public GameObject character;
    public GameObject fadeScreen;
    private bool finished;

    public GameObject RetryButton;
    public GameObject PassButton;

    public bool question1;
    public bool question2;
    public bool question3;


    // Start is called before the first frame update
    void Start()
    {
        Q1();
        character.gameObject.GetComponent<CharacterAnims>().states = 0;

        scenarioObj = GameObject.Find("ResearchScenario");
        nameBar = GameObject.Find("NameBar");
        scoreBar = GameObject.Find("ScoreBar");
        scenarioCloseButton = GameObject.Find("ScenarioButton_Close");
        scenarioViewButton = GameObject.Find("ScenarioButton_View");
        scenarioButtonClickBlock = GameObject.Find("ScenarioButtonClickBlock");
        scenarioButtonClickBlock.gameObject.SetActive(false);

        SpeechBubbleText();

        option1Button = GameObject.Find("Option1").GetComponent<Button>();
        option2Button = GameObject.Find("Option2").GetComponent<Button>();
        option3Button = GameObject.Find("Option3").GetComponent<Button>();
        option4Button = GameObject.Find("Option4").GetComponent<Button>();

        Option3button = GameObject.Find("Option3");
        Option4button = GameObject.Find("Option4");


        Option3button.SetActive(false);
        Option4button.SetActive(false);

        option1Button.interactable = true;
        option2Button.interactable = true;
        option3Button.interactable = true;
        option4Button.interactable = true;

        q1Answered = false;
        q2Answered = false;
        q3Answered = false;
        q4Answered = false;

        feedback.SetActive(false);
        finish_ContinueButton.SetActive(false);
        finished = false;

        next.interactable = false;
        next2.interactable = false;
        next3.interactable = false;

        question1 = false;
        question2 = false;
        question3 = false;
    }

    // Update is called once per frame
    void Update()
    {
        //when typing text is typing, when the length is equal to the text the continue button will appear
        for (int i = 0; i < sentences.Length; i++)
        {
            ContinueButton.SetActive(false);
            finish_ContinueButton.SetActive(false);
            RetryButton.SetActive(false);
            PassButton.SetActive(false);

            if (feedbackText.text == sentences[0] || feedbackText.text == sentences[1] ||
                feedbackText.text == sentences[2])
            {
                ContinueButton.SetActive(true);
                finish_ContinueButton.SetActive(false);
                RetryButton.SetActive(false);
                PassButton.SetActive(false);
            }
            if (feedbackText.text == sentences[4] || feedbackText.text == sentences[5])
            {
                ContinueButton.SetActive(false);
                finish_ContinueButton.SetActive(true);
                RetryButton.SetActive(false);
                PassButton.SetActive(false);
            }
            if (feedbackText.text == sentences[3])
            {
                ContinueButton.SetActive(false);
                finish_ContinueButton.SetActive(false);
                RetryButton.SetActive(true);
                PassButton.SetActive(true);
            }
        }
    }

    public void ResetQ2()
    {
        Option3button.SetActive(true);
        Option4button.SetActive(true);
        option1Button.interactable = true;
        option2Button.interactable = true;
        option3Button.interactable = true;
        option4Button.interactable = true;
        questions.SetActive(true);
        feedback.SetActive(false);

        //Question 2
        q.text = "What are the values of the dependent variable stress?";
        subq.text = "";
        a1.text = "     Scores from 0-100";
        a2.text = "     Scores from 0-12";//Correct answer
        a3.text = "     Male or Female";
        a4.text = "     Before and after meditating";
        
        nextButton2.SetActive(true);
        next2.interactable = false;
    }

    public void SpeechBubbleText()
    {
        //QUESTION 1 FEEDBACK
        sentences[0] = "Correct: This study is a within participants variable.";
        sentences[1] = "Incorrect: The participants are measured at both time points for the independent variable so this is a within participants study.";
        //QUESTION 2 FEEDBACK
        sentences[2] = "Correct: Scores from 0-12 are the values of the dependent variable stress.";
        sentences[3] = "Incorrect: Would you like to try again?";
        //QUESTION 3 FEEDBACK
        sentences[4] = "Correct: This study is looking at the difference in stress between two different time points.";
        sentences[5] = "Incorrect: This study is looking at the difference in stress between two different time points.";
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

        if (index == 0 || index == 2 || index == 4)
        {
            ContinueButton.SetActive(true);
        }
        if (index == 5)
        {
            finish_ContinueButton.SetActive(true);
        }

        if (index == 1 || index == 3)
        {
            RetryButton.SetActive(true);
            PassButton.SetActive(true);

            ContinueButton.SetActive(false);
        }
        StartCoroutine(Type());
    }

    public void Next()
    {
        if (q2Answered)
        {
            character.gameObject.GetComponent<CharacterAnims>().states = 2;//Thumbs up anim
            index = 0;
            ActivateFeedback();
            scoreBar.gameObject.GetComponent<ScoreSystem>().AddMSScore();
        }
        else
        {
            character.gameObject.GetComponent<CharacterAnims>().states = 3;//Shake head anim
            index = 1;
            ActivateFeedback();
            scoreBar.gameObject.GetComponent<ScoreSystem>().RemoveMSScore();
        }
    }
    public void Next2()
    {

        if (q2Answered)
        {
            character.gameObject.GetComponent<CharacterAnims>().states = 2;//Thumbs up anim
            index = 2;
            ActivateFeedback();
            scoreBar.gameObject.GetComponent<ScoreSystem>().AddMSScore();
        }
        else
        {
            character.gameObject.GetComponent<CharacterAnims>().states = 3;//Shake head anim
            index = 3;
            ActivateFeedback();
            scoreBar.gameObject.GetComponent<ScoreSystem>().RemoveMSScore();
        }
    }
    public void Next3()
    {
        if (q2Answered)
        {
            character.gameObject.GetComponent<CharacterAnims>().states = 2;//Thumbs up anim
            index = 4;
            ActivateFeedback();
            finish_ContinueButton.SetActive(true);
            finished = true;
            scoreBar.gameObject.GetComponent<ScoreSystem>().AddMSScore();
        }
        else
        {
            character.gameObject.GetComponent<CharacterAnims>().states = 3;//Shake head anim
            index = 5;
            ActivateFeedback();
            finish_ContinueButton.SetActive(true);
            finished = true;
            scoreBar.gameObject.GetComponent<ScoreSystem>().RemoveMSScore();
        }
    }

    public void ProgressToNextScene()
    {
        fadeScreen.gameObject.GetComponent<FadeInTransition>().FadeImageIn();
    }

    //------------------------QUESTIONS-------------------------------

    public void Q1()
    {
        question1 = true;
        questions.SetActive(true);
        option1Button.interactable = true;
        option2Button.interactable = true;
        feedback.SetActive(false);

        //Question 1
        q.text = "In this study, is before and after meditation a between or within participants variable?";
        subq.text = "";
        a1.text = "     Between participants";
        a2.text = "     Within participants";//Correct answer

        nextButton.SetActive(true);
        nextButton2.SetActive(false);
        nextButton3.SetActive(false);
        next.interactable = false;
        next2.interactable = false;
        next3.interactable = false;
    }
    public void Q2()
    {
        question2 = true;

        Option3button.SetActive(true);
        Option4button.SetActive(true);
        option1Button.interactable = true;
        option2Button.interactable = true;
        option3Button.interactable = true;
        option4Button.interactable = true;
        questions.SetActive(true);
        feedback.SetActive(false);

        //Question 2
        q.text = "What are the values of the dependent variable stress?";
        subq.text = "";
        a1.text = "     Scores from 0-100";
        a2.text = "     Scores from 0-12";//Correct answer
        a3.text = "     Male or Female";
        a4.text = "     Before and after meditating";
        
        nextButton.SetActive(false);
        nextButton2.SetActive(true);
        nextButton3.SetActive(false);
        next2.interactable = false;
    }
    public void Q3()
    {
        question2 = true;

        Option3button.SetActive(false);
        Option4button.SetActive(false);
        option1Button.interactable = true;
        option2Button.interactable = true;
        questions.SetActive(true);
        feedback.SetActive(false);

        //Question 3
        q.text = "What kind of design is this study investigating?";
        subq.text = "";
        a1.text = "     Investigating an association";
        a2.text = "     Investigating differences between groups";

        nextButton.SetActive(false);
        nextButton2.SetActive(false);
        nextButton3.SetActive(true);

        next.interactable = false;
        next2.interactable = false;
        next3.interactable = false;
    }
    //---------------------------------------------------------------------------------------------------

    public void ButtonPress()
    {
        string name = EventSystem.current.currentSelectedGameObject.name;

        next.interactable = true;
        next2.interactable = true;
        next3.interactable = true;

        if (name == "RetryButton")
        {
            Q2();
        }
        if (name == "PassButton")
        {
            if (index == 1)
            {
                ResetQ2();
            }
            if (index == 3)
            {
                Q3();
            }
            if (index == 5)
            {
                ProgressToNextScene();
            }
        }

        if (name == "ContinueButton")
        {
            if(index == 0 || index == 1)
            {
                Q2();
            }
            if (index == 2)
            {
                Q3();
            }
            if (index == 4 || index == 5)
            {
                ProgressToNextScene();
            }
        }

        if(name == "NextButton")
        {
            Q2();
        }
        if (name == "NextButton2")
        {
            Q3();
        }
        if (name == "NextButton3")
        {
            ProgressToNextScene();
        }

        if (name == "Option1")
        {
            option1Button.interactable = false;
            option2Button.interactable = true;
            option3Button.interactable = true;
            option4Button.interactable = true;

            q1Answered = true;
            q2Answered = false;
            q3Answered = false;
            q4Answered = false;
        }
        if (name == "Option2")
        {
            option1Button.interactable = true;
            option2Button.interactable = false;
            option3Button.interactable = true;
            option4Button.interactable = true;
            
            q1Answered = false;
            q2Answered = true;
            q3Answered = false;
            q4Answered = false;
        }
        if (name == "Option3")
        {
            option1Button.interactable = true;
            option2Button.interactable = true;
            option3Button.interactable = false;
            option4Button.interactable = true;
            
            q1Answered = false;
            q2Answered = false;
            q3Answered = true;
            q4Answered = false;
        }
        if (name == "Option4")
        {
            option1Button.interactable = true;
            option2Button.interactable = true;
            option3Button.interactable = true;
            option4Button.interactable = false;

            q1Answered = false;
            q2Answered = false;
            q3Answered = false;
            q4Answered = true;
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
            finish_ContinueButton.SetActive(false);
            ContinueButton.SetActive(false);
            nextButton.SetActive(false);
            nextButton2.SetActive(false);
            nextButton3.SetActive(false);
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