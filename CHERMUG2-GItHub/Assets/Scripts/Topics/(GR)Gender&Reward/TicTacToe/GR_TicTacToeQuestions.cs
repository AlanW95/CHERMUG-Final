using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

//////////////////////////////////////////////////<summary>//////////////////////////////////////////////////// 
///                                   University of the West of Scotland                                    ///
///                                          SEX AND REWARD TOPIC                                           ///
///                               -------------------------------------------                               ///  
/// Script is attached to the Manager GameObject in the GR_QuestionsTTT scene.                              ///
///                                                                                                         ///
//////////////////////////////////////////////////</summary>///////////////////////////////////////////////////

public class GR_TicTacToeQuestions : MonoBehaviour
{
    public BarAnimations animScript;
    public GameObject scoreBar;
    public GameObject nameBar;

    public GameObject scenarioCloseButton;
    public GameObject scenarioViewButton;
    public GameObject scenarioObj;
    public GameObject scenarioButtonClickBlock;

    public GameObject questions;
    public GameObject nextButton;
    public GameObject nextButton2;
    public GameObject feedback;

    private Button next;
    private Button next2;
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

    public GameObject character;

    public GameObject continueButtonQ2;
    public GameObject finish_ContinueButton;

    private bool finished;
    private bool question1, question2;

    // Start is called before the first frame update
    void Start()
    {
        Q1();
        
        scenarioObj = GameObject.Find("ResearchScenario");
        nameBar = GameObject.Find("NameBar");
        scoreBar = GameObject.Find("ScoreBar");
        scenarioCloseButton = GameObject.Find("ScenarioButton_Close");
        scenarioViewButton = GameObject.Find("ScenarioButton_View");
        scenarioButtonClickBlock = GameObject.Find("GR_ButtonClickBlock");

        feedback = GameObject.Find("Feedback");
        feedbackText = GameObject.Find("FeedbackText").GetComponent<Text>();

        SpeechBubbleText();

        option1Button = GameObject.Find("Option1").GetComponent<Button>();
        option2Button = GameObject.Find("Option2").GetComponent<Button>();

        next = GameObject.Find("NextButton").GetComponent<Button>();
        next2 = GameObject.Find("NextButton2").GetComponent<Button>();

        option1Button.interactable = true;
        option2Button.interactable = true;

        q1Answered = false;
        q2Answered = false;

        feedback.SetActive(false);

        nextButton2.SetActive(false);
        next.interactable = false;
        continueButtonQ2.SetActive(false);
        finish_ContinueButton.SetActive(false);
        finished = false;
        question1 = false;
        question2 = false;
        scenarioButtonClickBlock.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //when typing text is typing, when the length is equal to the text the continue button will appear
        for (int i = 0; i < sentences.Length; i++)
        {
            continueButtonQ2.SetActive(false);
            finish_ContinueButton.SetActive(false);

            if (feedbackText.text == sentences[index])
            {
                if (question1)
                {
                    continueButtonQ2.SetActive(true);
                }

                if (question2)
                {
                    finish_ContinueButton.SetActive(true);
                }
            }

            if (finished == true)
            {
                continueButtonQ2.SetActive(false);
                finish_ContinueButton.SetActive(true);
            }
        }
    }

    public void SpeechBubbleText()
    {
        sentences[0] = "Correct: Chi-square is the statistic for examining the relationship between nominal variables.";
        sentences[1] = "Incorrect: While you will want to find out the significance level, this is not the test statistic.";
        sentences[2] = "Correct: If the chi-square value is greater than the critical value then the chi-square value is significant. The calculated chi-square value (12.19) was greater than the critical value (3.84) and so it was significant suggesting that males and females choose different rewards.";
        sentences[3] = "Incorrect: If the chi-square value is greater than the critical value then the chi-square value is significant. The calculated chi-square value (12.19) was greater than the critical value (3.84) and so it was significant suggesting that males and females choose different rewards.";
    }

    public void ReadyToPlay()
    {
        scenarioObj.gameObject.GetComponent<ScenarioAnimations>().states = 2;
        scenarioViewButton.gameObject.SetActive(true);
        scenarioCloseButton.gameObject.SetActive(false);
        scenarioButtonClickBlock.SetActive(false);
        questions.SetActive(true);
    }
    
    public void ViewStudy()
    {
        scenarioObj.gameObject.GetComponent<ScenarioAnimations>().states = 1;
        scenarioCloseButton.gameObject.SetActive(true);
        scenarioViewButton.gameObject.SetActive(false);
        scenarioButtonClickBlock.SetActive(true);
        questions.SetActive(true);
    }
    
    public void CloseStudy() {
        scenarioObj.gameObject.GetComponent<ScenarioAnimations>().states = 2;
        scenarioViewButton.gameObject.SetActive(true);
        scenarioCloseButton.gameObject.SetActive(false);
        scenarioButtonClickBlock.SetActive(false);
        questions.SetActive(true);
    }

    public void ProgressToNextScene()
    {
        SceneManager.LoadScene("GR_QuestionsTTT2");
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
        if(q2Answered)
        {
            character.gameObject.GetComponent<CharacterAnims>().states = 2;//Thumbs up anim
            continueButtonQ2.SetActive(true);
            feedbackText.text = "";
            index = 0;
            ActivateFeedback();
            nextButton.SetActive(false);
            scoreBar.gameObject.GetComponent<ScoreSystem>().AddGRScore();
            question1 = true;
            question2 = false;
            StartCoroutine(Type());
        }
        if(q1Answered)
        {
            character.gameObject.GetComponent<CharacterAnims>().states = 3;//Shake head anim
            continueButtonQ2.SetActive(true);
            feedbackText.text = "";
            index = 1;
            ActivateFeedback();
            nextButton.SetActive(false);
            scoreBar.gameObject.GetComponent<ScoreSystem>().RemoveGRScore();
            question1 = true;
            question2 = false;
            StartCoroutine(Type());
        }
    }
    public void Next2()
    {
        if(q1Answered)
        {
            character.gameObject.GetComponent<CharacterAnims>().states = 2;//Thumbs up anim
            feedbackText.text = "";
            index = 2;
            ActivateFeedback();
            nextButton2.SetActive(false);
            scoreBar.gameObject.GetComponent<ScoreSystem>().AddGRScore();
            question1 = false;
            question2 = true;
            StartCoroutine(Type());
        }
        else
        {
            character.gameObject.GetComponent<CharacterAnims>().states = 3;//Shake head anim
            feedbackText.text = "";
            index = 3;
            ActivateFeedback();
            nextButton2.SetActive(false);
            scoreBar.gameObject.GetComponent<ScoreSystem>().RemoveGRScore();
            question1 = false;
            question2 = true;
            StartCoroutine(Type());
        }
    }

    //------------------------QUESTIONS-------------------------------

    public void Q1()
    {
        questions.SetActive(true);

        //Question 1
        q.text = "Which test statistic would you expect to see from your chosen statistical test?";
        subq.text = "";
        a1.text = "     p value";
        a2.text = "     Chi-squared value";
    }

    public void Q2()
    {
        questions.SetActive(true);
        option1Button.interactable = true;
        option2Button.interactable = true;
        nextButton2.SetActive(true);
        continueButtonQ2.SetActive(false);
        feedback.SetActive(false);
        next2.interactable = false;

        //Question 2
        q.text = "The critical value of chi-square for a 2*2 contingency table at .05 level of significance for a two tailed test is 3.84. \n\nThe calculated chi-square value =12.19. Is this chi-square value significant?";
        subq.text = "";
        a1.text = "     Yes";
        a2.text = "     No";
    }

    public void CheckButtonPress()
    {
        string name = EventSystem.current.currentSelectedGameObject.name;

        next.interactable = true;
        next2.interactable = true;

        if (name == "Option1")
        {
            option1Button.interactable = false;
            option2Button.interactable = true;

            q1Answered = true;
            q2Answered = false;
        }
        if (name == "Option2")
        {
            option1Button.interactable = true;
            option2Button.interactable = false;

            q1Answered = false;
            q2Answered = true;
        }
        if (name == "Finish_ContinueButton")
        {
            ProgressToNextScene();
        }
    }

    public void ButtonPress()
    {
        string name = EventSystem.current.currentSelectedGameObject.name;
    }

    IEnumerator Type()
    {
        continueButtonQ2.SetActive(false);
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
    }
}