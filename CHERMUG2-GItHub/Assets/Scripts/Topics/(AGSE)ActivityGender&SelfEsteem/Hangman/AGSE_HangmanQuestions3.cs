﻿using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

//////////////////////////////////////////////////<summary>//////////////////////////////////////////////////// 
///                                   University of the West of Scotland                                    ///
///                                 ACTIVITY, GENDER AND SELF ESTEEM TOPIC                                  ///
///                               -------------------------------------------                               ///  
/// Script is attached to the Manager GameObject in the AGSE_QuestionsHM3 scene.                            ///
///                                                                                                         ///                    
//////////////////////////////////////////////////</summary>///////////////////////////////////////////////////

public class AGSE_HangmanQuestions3 : MonoBehaviour
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
    private Button next;
    private Button next2;
    private Button next3;
    
    public Text scenario;
    public Text q;
    public Text subq;
    public Text a1;
    public Text a2;
    public Text a3;
    public Text a4;
    
    public GameObject answer3;
    public GameObject answer4;

    public GameObject feedback;
    public Text feedbackText;

    public GameObject continueButton;
    public GameObject continueButton2;
    public GameObject finish_ContinueButton;

    //Typing Text
    public string[] sentences;
    private int index;
    public float typingSpeed;

    public Button option1Button;
    public Button option2Button;
    public Button option3Button;
    public Button option4Button;

    private bool q1Answered;
    private bool q2Answered;
    private bool q3Answered;
    private bool q4Answered;

    public GameObject character;
    private bool finished;

    public GameObject RetryButton;
    public GameObject PassButton;

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
        next3 = GameObject.Find("NextButton3").GetComponent<Button>();

        feedback = GameObject.Find("Feedback");
        feedbackText = GameObject.Find("FeedbackText").GetComponent<Text>();
        
        option1Button = GameObject.Find("Option1").GetComponent<Button>();
        option2Button = GameObject.Find("Option2").GetComponent<Button>();
        option3Button = GameObject.Find("Option3").GetComponent<Button>();
        option4Button = GameObject.Find("Option4").GetComponent<Button>();

        RetryButton = GameObject.Find("RetryButton");
        PassButton = GameObject.Find("PassButton");

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
            continueButton2.SetActive(false);
            finish_ContinueButton.SetActive(false);
            RetryButton.SetActive(false);
            PassButton.SetActive(false);

            if (index == 0)
            {
                continueButton.SetActive(true);
                continueButton2.SetActive(false);
                finish_ContinueButton.SetActive(false);

                RetryButton.SetActive(false);
                PassButton.SetActive(false);
            }
            if (index == 2)
            {
                continueButton.SetActive(false);
                continueButton2.SetActive(true);
                finish_ContinueButton.SetActive(false);

                RetryButton.SetActive(false);
                PassButton.SetActive(false);
            }
            if (index == 4 || index == 5)
            {
                continueButton.SetActive(false);
                continueButton2.SetActive(false);
                finish_ContinueButton.SetActive(true);

                RetryButton.SetActive(false);
                PassButton.SetActive(false);
            }
            if (index == 1 || index == 3)
            {
                RetryButton.SetActive(true);
                PassButton.SetActive(true);

                continueButton.SetActive(false);
                continueButton2.SetActive(false);
                finish_ContinueButton.SetActive(false);
            }
        }
    }

    public void ResetQ1()
    {
        Q1();

        SpeechBubbleText();

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

        nextButton.SetActive(true);
        nextButton2.SetActive(false);
        nextButton3.SetActive(false);
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

        q1Answered = false;
        q2Answered = false;
        q3Answered = false;
        q4Answered = false;

        feedback.SetActive(false);
        finish_ContinueButton.SetActive(false);
        finished = false;

        nextButton.SetActive(false);
        nextButton2.SetActive(true);
        nextButton3.SetActive(false);
        next2.interactable = false;

        RetryButton.SetActive(false);
        PassButton.SetActive(false);
    }

    public void SpeechBubbleText()
    {
        sentences[0] = "Correct: Well done!";
        sentences[1] = "Incorrect: Would you like to try again?";
        sentences[2] = "Correct: Well done!";
        sentences[3] = "Incorrect: Would you like to try again?";
        sentences[4] = "Correct: This study is looking for differences in body positivity for different groups of each independent variable.";
        sentences[5] = "Incorrect: This study is comparing groups.";
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
        if (q2Answered)
        {
            character.gameObject.GetComponent<CharacterAnims>().states = 2;//Thumbs up anim
            index = 0;
            ActivateFeedback();
            nextButton.SetActive(false);
            scoreBar.gameObject.GetComponent<ScoreSystem>().AddAGSEScore();
        }
        else
        {
            character.gameObject.GetComponent<CharacterAnims>().states = 3;//Shake head anim
            index = 1;
            ActivateFeedback();
            nextButton.SetActive(false);
            scoreBar.gameObject.GetComponent<ScoreSystem>().RemoveAGSEScore();
        }
    }

    public void Next2()
    {
        if (q3Answered)
        {
            character.gameObject.GetComponent<CharacterAnims>().states = 2;//Thumbs up anim
            index = 2;
            ActivateFeedback();
            nextButton2.SetActive(false);
            scoreBar.gameObject.GetComponent<ScoreSystem>().AddAGSEScore();
        }
        else
        {
            character.gameObject.GetComponent<CharacterAnims>().states = 3;//Shake head anim
            index = 3;
            ActivateFeedback();
            nextButton2.SetActive(false);
            scoreBar.gameObject.GetComponent<ScoreSystem>().RemoveAGSEScore();
        }
    }

    public void Next3()
    {
        if (q2Answered)
        {
            character.gameObject.GetComponent<CharacterAnims>().states = 2;//Thumbs up anim
            index = 4;
            ActivateFeedback();
            nextButton3.SetActive(false);
            finish_ContinueButton.SetActive(true);
            finished = true;
            scoreBar.gameObject.GetComponent<ScoreSystem>().AddAGSEScore();
        }
        else
        {
            character.gameObject.GetComponent<CharacterAnims>().states = 3;//Shake head anim
            index = 5;
            ActivateFeedback();
            nextButton3.SetActive(false);
            finish_ContinueButton.SetActive(true);
            scoreBar.gameObject.GetComponent<ScoreSystem>().RemoveAGSEScore();
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
        q.text = "In this <b>study</b> what is the level of measurement of the dependent variable, self esteem?";
        subq.text = "";
        a1.text = "Ratio";
        a2.text = "Interval";
        a3.text = "Ordinal";
        a4.text = "Nominal";
    }

    public void Q2()
    {
        questions.SetActive(true);
        option1Button.interactable = true;
        option2Button.interactable = true;
        option3Button.interactable = true;
        option4Button.interactable = true;
        nextButton2.SetActive(true);
        next2.interactable = false;
        feedback.SetActive(false);

        //Question 2
        q.text = "In this <b>study</b> what are the levels of the variable, self esteem?";
        subq.text = "";
        a1.text = "1-10";
        a2.text = "1-20";
        a3.text = "0-30";
        a4.text = "High, medium or low";

        next2.interactable = false;
    }

    public void Q3()
    {
        questions.SetActive(true);
        answer3.SetActive(false);
        answer4.SetActive(false);
        option1Button.interactable = true;
        option2Button.interactable = true;
        nextButton3.SetActive(true);
        feedback.SetActive(false);

        //Question 3
        q.text = "What kind of design is this study investigating?";
        subq.text = "";
        a1.text = "Investigating an association";
        a2.text = "Investigating differences between groups";

        next3.interactable = false;
    }
    //--------------------------------------------------------------------

    public void ButtonPress()
    {
        string name = EventSystem.current.currentSelectedGameObject.name;

        next.interactable = true;
        next2.interactable = true;
        next3.interactable = true;

        if (name == "RetryButton")
        {
            if (index == 1)
            {
                ResetQ1();
            }
            if (index == 3)
            {
                ResetQ2();
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
                Q3();
            }
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
            continueButton.SetActive(false);
            continueButton2.SetActive(false);
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
