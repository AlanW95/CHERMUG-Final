using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

//////////////////////////////////////////////////<summary>//////////////////////////////////////////////////// 
///                                   University of the West of Scotland                                    ///
///                                          SEX AND REWARD TOPIC                                           ///
///                               -------------------------------------------                               ///  
/// Script is attached to the Manager GameObject in the GR_QuestionsTTT2 scene.                              ///
///                                                                                                         ///
//////////////////////////////////////////////////</summary>///////////////////////////////////////////////////

public class GR_TicTacToeQuestions2 : MonoBehaviour
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

    public GameObject showTable;
    public GameObject showTableButton;

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

        showTable.SetActive(false);
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
        sentences[0] = "Correct: There is a statistically significant relationship between sex and reward choice. The null hypothesis can be rejected.";
        sentences[1] = "Incorrect: You calculated a significant chi-square value of 12.19 when p < 0.05.";
        sentences[2] = "Correct: Reward choices appear to differ by sex. Females have a noticeable preference for chocolate compared to crisps, which is not shown to the same extent in males.";
        sentences[3] = "Incorrect: The data suggests that in females there is a clear preference for chocolate.";
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
        SceneManager.LoadScene("GR_EndSummary");
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
        q.text = "Which of the following is the correct interpretation of the results?";
        subq.text = "";
        a1.text = "There is not a statistically significant relationship between sex and reward choice.\nThe null hypothesis cannot be rejected.";
        a2.text = "There is a statistically significant relationship between sex and reward choice.\nThe null hypothesis can be rejected.";
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
        q.text = "How can these results be explained?";
        subq.text = "";
        a1.text = "Reward choices appear to differ by sex.\nFemales have a noticeable preference for chocolate compared to crisps, which is not shown to the same extent in males.";
        a2.text = "Reward choices do not appear to differ by sex.\nPicking chocolate or crisps appears to be a random decision.";
    }

    public void CheckButtonPress()
    {
        string name = EventSystem.current.currentSelectedGameObject.name;

        next.interactable = true;
        next2.interactable = true;

        if (name == "ShowTableButton")
        {
            showTable.SetActive(true);
        }

        if (name == "XButton")
        {
            showTable.SetActive(false);
            next.interactable = false;
            next2.interactable = false;
        }

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