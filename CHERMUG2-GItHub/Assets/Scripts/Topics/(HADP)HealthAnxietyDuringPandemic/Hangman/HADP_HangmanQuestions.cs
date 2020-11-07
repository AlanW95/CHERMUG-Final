using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

//////////////////////////////////////////////////<summary>//////////////////////////////////////////////////// 
///                                   University of the West of Scotland                                    ///
///                                 HEALTH ANXIETY DURING A PANDEMIC TOPIC                                  ///
///                               -------------------------------------------                               ///  
/// Script is attached to the Manager GameObject in the HADP_QuestionsHM scene.                             ///
///                                                                                                         ///                    
//////////////////////////////////////////////////</summary>///////////////////////////////////////////////////

public class HADP_HangmanQuestions : MonoBehaviour
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
    public Button next;
    public Button next2;
    
    public Text scenario;
    public Text q;
    public Text subq;
    public Text a1;
    public Text a2;
    public Text a3;
    public Text a4;

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

    public GameObject answer3;
    public GameObject answer4;

    private bool q1Answered;
    private bool q2Answered;
    private bool q3Answered;
    private bool q4Answered;

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

        option1Button = GameObject.Find("Option1").GetComponent<Button>();
        option2Button = GameObject.Find("Option2").GetComponent<Button>();
        option3Button = GameObject.Find("Option3").GetComponent<Button>();
        option4Button = GameObject.Find("Option4").GetComponent<Button>();

        RetryButton = GameObject.Find("RetryButton");
        PassButton = GameObject.Find("PassButton");

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
            RetryButton.SetActive(false);
            PassButton.SetActive(false);

            if (feedbackText.text == sentences[0])
            {
                continueButton.SetActive(true);
                finish_ContinueButton.SetActive(false);

                RetryButton.SetActive(false);
                PassButton.SetActive(false);
            }
            if (feedbackText.text == sentences[2] || feedbackText.text == sentences[3])
            {
                continueButton.SetActive(false);
                finish_ContinueButton.SetActive(true);

                RetryButton.SetActive(false);
                PassButton.SetActive(false);
            }

            if (feedbackText.text == sentences[1])
            {
                RetryButton.SetActive(true);
                PassButton.SetActive(true);

                continueButton.SetActive(false);
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
        continueButton.SetActive(false);
        finish_ContinueButton.SetActive(false);
        finished = false;

        nextButton.SetActive(true);
        next.interactable = false;
        nextButton2.SetActive(false);
        next2.interactable = false;

        RetryButton.SetActive(false);
        PassButton.SetActive(false);

        scenarioButtonClickBlock.gameObject.SetActive(false);
    }

    public void SpeechBubbleText()
    {
        sentences[0] = "Correct: One week and three months later are the levels of the variable Time point during the pandemic.";
        sentences[1] = "Incorrect: Would you like to try again?";
        sentences[2] = "Correct: Well done!";
        sentences[3] = "Incorrect: The participants are measured at both time points for the independent variable so this is a within participants study.";
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
            continueButton.SetActive(true);
            finish_ContinueButton.SetActive(false);
            finished = true;
            scoreBar.gameObject.GetComponent<ScoreSystem>().AddHADPScore();
        }
        else
        {
            character.gameObject.GetComponent<CharacterAnims>().states = 3;//Shake head anim
            index = 1;
            ActivateFeedback();
            nextButton.SetActive(false);
            continueButton.SetActive(true);
            finish_ContinueButton.SetActive(false);
            finished = true;
            scoreBar.gameObject.GetComponent<ScoreSystem>().RemoveHADPScore();
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
            continueButton.SetActive(false);
            finish_ContinueButton.SetActive(true);
            finished = true;
            scoreBar.gameObject.GetComponent<ScoreSystem>().AddHADPScore();
        }
        else
        {
            character.gameObject.GetComponent<CharacterAnims>().states = 3;//Shake head anim
            index = 3;
            ActivateFeedback();
            nextButton2.SetActive(false);
            continueButton.SetActive(false);
            finish_ContinueButton.SetActive(true);
            finished = true;
            scoreBar.gameObject.GetComponent<ScoreSystem>().RemoveHADPScore(); 
        }
    }

    public void ProgressToNextScene()
    {
        SceneManager.LoadScene("HADP_MultipleChoice2");
    }

    //------------------------QUESTIONS-------------------------------

    public void Q1()
    {
        questions.SetActive(true);
        option1Button.interactable = true;
        option2Button.interactable = true;
        option3Button.interactable = true;
        option4Button.interactable = true;
        feedback.SetActive(false);

        //Question 1
        q.text = "What are the levels of the variable Time point during the pandemic?";
        subq.text = "";
        a1.text = "Before and after the pandemic";
        a2.text = "One week and three months later";
        a3.text = "Group A and Group B";
        a4.text = "Day 1 and Day 100";

        next.interactable = false;
    }

    public void Q2()
    {
        questions.SetActive(true);
        answer3.SetActive(false);
        answer4.SetActive(false);
        option1Button.interactable = true;
        option2Button.interactable = true;
        nextButton2.SetActive(true);
        feedback.SetActive(false);

        //Question 1
        q.text = "In this <b>study</b>, is Time point during the pandemic a between or within participants variable?";
        subq.text = "";
        a1.text = "Between participants";
        a2.text = "Within participants";

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

        if (name == "PassButton")
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
