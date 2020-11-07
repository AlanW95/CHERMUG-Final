﻿using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

//////////////////////////////////////////////////<summary>//////////////////////////////////////////////////// 
///                                   University of the West of Scotland                                    ///
///                               WITHIN PARTICIPANTS MEDITATION STRESS TOPIC                               ///
///                               -------------------------------------------                               ///  
/// Script is attached to the Manager GameObject in the MS_QuestionsHM scene.                               ///
///                                                                                                         ///                    
//////////////////////////////////////////////////</summary>///////////////////////////////////////////////////

public class MS_HangmanQuestions : MonoBehaviour
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
    public Text a3;
    public Text a4;
    public Text a5;

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
    public Button option3Button;
    public Button option4Button;
    public Button option5Button;

    public GameObject Option5Button;

    private bool q1Answered;
    private bool q2Answered;
    private bool q3Answered;
    private bool q4Answered;
    private bool q5Answered;

    public GameObject character;
    private bool finished;

    public GameObject RetryButton;
    public GameObject PassButton;

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
        option3Button = GameObject.Find("Option3").GetComponent<Button>();
        option4Button = GameObject.Find("Option4").GetComponent<Button>();
        option5Button = GameObject.Find("Option5").GetComponent<Button>();
        Option5Button = GameObject.Find("Option5");

        RetryButton = GameObject.Find("RetryButton");
        PassButton = GameObject.Find("PassButton");

        scenarioButtonClickBlock.gameObject.SetActive(false);

        ResetButton();
    }

    // Update is called once per frame
    void Update()
    {
        //when typing text is typing, when the length is equal to the text the continue button will appear
        for (int i = 0; i < sentences.Length; i++)
        {
            continueButton.SetActive(false);
            finish_ContinueButton.SetActive(false);
            RetryButton.SetActive(false);
            PassButton.SetActive(false);

            if (feedbackText.text == sentences[0] || feedbackText.text == sentences[2])
            {
                continueButton.SetActive(true);
                finish_ContinueButton.SetActive(false);

                RetryButton.SetActive(false);
                PassButton.SetActive(false);
            }
            if (feedbackText.text == sentences[2])
            {
                continueButton.SetActive(false);
                finish_ContinueButton.SetActive(true);

                RetryButton.SetActive(false);
                PassButton.SetActive(false);
            }
            if (feedbackText.text == sentences[1] || feedbackText.text == sentences[3])
            {
                continueButton.SetActive(false);
                finish_ContinueButton.SetActive(false);

                RetryButton.SetActive(true);
                PassButton.SetActive(true);
            }
        }
    }

    public void ResetButton()
    {
        Q1();

        SpeechBubbleText();

        option1Button.interactable = true;
        option2Button.interactable = true;
        option3Button.interactable = true;
        option4Button.interactable = true;
        option5Button.interactable = false;

        q1Answered = false;
        q2Answered = false;
        q3Answered = false;
        q4Answered = false;
        q5Answered = false;

        feedback.SetActive(false);
        finish_ContinueButton.SetActive(false);
        finished = false;

        nextButton.SetActive(true);
        nextButton2.SetActive(false);
        next.interactable = false;

        RetryButton.SetActive(false);
        PassButton.SetActive(false);
    }

    public void ResetQ2()
    {
        Q2();

        SpeechBubbleText();

        option1Button.interactable = true;
        option2Button.interactable = true;
        option3Button.interactable = true;
        option4Button.interactable = true;
        option5Button.interactable = true;

        q1Answered = false;
        q2Answered = false;
        q3Answered = false;
        q4Answered = false;
        q5Answered = false;

        feedback.SetActive(false);
        finish_ContinueButton.SetActive(false);
        finished = false;

        nextButton.SetActive(false);
        nextButton2.SetActive(true);
        next2.interactable = false;

        RetryButton.SetActive(false);
        PassButton.SetActive(false);
    }

    public void SpeechBubbleText()
    {
        sentences[0] = "Correct: The levels of this variable are two categories.";
        sentences[1] = "Incorrect: Would you like to try again?";
        sentences[2] = "Correct: Before meditating and after meditating are the levels of the independent variable.";
        sentences[3] = "Incorrect: Would you like to try again?";
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
            scoreBar.gameObject.GetComponent<ScoreSystem>().AddMSScore();
        }
        else
        {
            character.gameObject.GetComponent<CharacterAnims>().states = 3;//Shake head anim
            index = 1;
            ActivateFeedback();
            nextButton.SetActive(false);
            scoreBar.gameObject.GetComponent<ScoreSystem>().RemoveMSScore();
        }
    }

    public void Next2()
    {
        if (q5Answered)
        {
            character.gameObject.GetComponent<CharacterAnims>().states = 2;//Thumbs up anim
            index = 2;
            ActivateFeedback();
            nextButton2.SetActive(false);
            finish_ContinueButton.SetActive(true);
            finished = true;
            scoreBar.gameObject.GetComponent<ScoreSystem>().AddMSScore();
        }
        else
        {
            character.gameObject.GetComponent<CharacterAnims>().states = 3;//Shake head anim
            index = 3;
            ActivateFeedback();
            nextButton2.SetActive(false);
            finished = true;
            scoreBar.gameObject.GetComponent<ScoreSystem>().RemoveMSScore();
        }
    }

    public void ProgressToNextScene()
    {
        SceneManager.LoadScene("MS_MultipleChoice2");
    }

    //------------------------QUESTIONS-------------------------------

    public void Q1()
    {
        questions.SetActive(true);
        Option5Button.SetActive(false);

        //Question 1
        q.text = "In this <b>study</b> what level of measurement is the variable Before and after meditation?";
        subq.text = "";
        a1.text = "     Nominal";
        a2.text = "     Ordinal";
        a3.text = "     Interval";
        a4.text = "     Ratio";
    }

    public void Q2()
    {
        option1Button.interactable = true;
        option2Button.interactable = true;
        option3Button.interactable = true;
        option4Button.interactable = true;
        option5Button.interactable = true;

        q1Answered = false;
        q2Answered = false;
        q3Answered = false;
        q4Answered = false;
        q5Answered = false;

        questions.SetActive(true);
        Option5Button.SetActive(true);
        nextButton2.SetActive(true);
        feedback.SetActive(false);

        //Question 2
        q.text = "In this same <b>study</b>, what are the levels of the independent variable?";
        subq.text = "";
        a1.text = "     Before work and after work";
        a2.text = "     Males and Females";
        a3.text = "     Men in one office and men in another office";
        a4.text = "     Meditation and Yoga";
        a5.text = "     Before meditating and after meditating";

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
                ResetButton();
            }
            if (index == 3)
            {
                ResetQ2();
            }
            
        }
        if(name == "PassButton")
        {
            if(index == 1)
            {
                ResetQ2();
            }
            if(index == 3)
            {
                ProgressToNextScene();
            }
        }

        if(name == "ContinueButton")
        {
            if(index == 0)
            {
                ResetQ2();
            }
            if(index == 2)
            {
                ProgressToNextScene();
            }
        }
        
        if (name == "Option1")
        {
            option1Button.interactable = false;
            option2Button.interactable = true;
            option3Button.interactable = true;
            option4Button.interactable = true;
            option5Button.interactable = true;

            q1Answered = true;
            q2Answered = false;
            q3Answered = false;
            q4Answered = false;
            q5Answered = false;
        }
        if (name == "Option2")
        {
            option1Button.interactable = true;
            option2Button.interactable = false;
            option3Button.interactable = true;
            option4Button.interactable = true;
            option5Button.interactable = true;

            q1Answered = false;
            q2Answered = true;
            q3Answered = false;
            q4Answered = false;
            q5Answered = false;
        }
        if (name == "Option3")
        {
            option1Button.interactable = true;
            option2Button.interactable = true;
            option3Button.interactable = false;
            option4Button.interactable = true;
            option5Button.interactable = true;

            q1Answered = false;
            q2Answered = false;
            q3Answered = true;
            q4Answered = false;
            q5Answered = false;
        }
        if (name == "Option4")
        {
            option1Button.interactable = true;
            option2Button.interactable = true;
            option3Button.interactable = true;
            option4Button.interactable = false;
            option5Button.interactable = true;

            q1Answered = false;
            q2Answered = false;
            q3Answered = false;
            q4Answered = true;
            q5Answered = false;
        }
        if (name == "Option5")
        {
            option1Button.interactable = true;
            option2Button.interactable = true;
            option3Button.interactable = true;
            option4Button.interactable = true;
            option5Button.interactable = false;

            q1Answered = false;
            q2Answered = false;
            q3Answered = false;
            q4Answered = false;
            q5Answered = true;
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
