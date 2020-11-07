using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

//////////////////////////////////////////////////<summary>//////////////////////////////////////////////////// 
///                                   University of the West of Scotland                                    ///
///                                      MENTAL HEALTH SUPPORT TOPIC                                        ///
///                               -------------------------------------------                               ///  
/// Script is attached to the Manager GameObject in the MHS_QuestionsTTT scene.                             ///
///                                                                                                         ///
//////////////////////////////////////////////////</summary>///////////////////////////////////////////////////

public class MHS_TicTacToeQuestions : MonoBehaviour
{
    public BarAnimations animScript;
    public GameObject scoreBar;
    public GameObject nameBar;

    public GameObject scenarioCloseButton;
    public GameObject scenarioViewButton;
    public GameObject scenarioButtonClickBlock;
    public GameObject scenarioObj;

    public GameObject showTable;
    public GameObject showTableButton;

    public GameObject questions;
    public GameObject nextButton;
    public GameObject nextButton2;
    public GameObject nextButton3;
    public GameObject feedback;

    private Button next;
    private Button next2;
    private Button next3;
    
    public Text scenario;
    public Text q;
    public Text subq;
    public Text a1;
    public Text a2;
    public Text a3;

    //Typing Text
    public Text feedbackText;

    public string[] sentences;
    private int index;
    public float typingSpeed;

    public Button option1Button;
    public Button option2Button;
    public Button option3Button;
    public GameObject OptionButton3;

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

    [SerializeField] private GameObject retryButton;
    [SerializeField] private GameObject passButton;

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
        option3Button = GameObject.Find("Option3").GetComponent<Button>();

        next = GameObject.Find("NextButton").GetComponent<Button>();
        next2 = GameObject.Find("NextButton2").GetComponent<Button>();
        next3 = GameObject.Find("NextButton3").GetComponent<Button>();

        option1Button.interactable = true;
        option2Button.interactable = true;
        option3Button.interactable = true;

        q1Answered = false;
        q2Answered = false;
        q3Answered = false;

        feedback.SetActive(false);

        nextButton2.SetActive(false);
        nextButton3.SetActive(false);
        next.interactable = false;
        continueButtonQ2.SetActive(false);
        continueButtonQ3.SetActive(false);
        finish_ContinueButton.SetActive(false);
        finished = false;
        question1 = false;
        question2 = false;
        question3 = false;
        
        showTable.SetActive(false);

        scenarioButtonClickBlock.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //when typing text is typing, when the length is equal to the text the continue button will appear
        for (int i = 0; i < sentences.Length; i++)
        {
            if (index == 0)
            {
                continueButtonQ2.SetActive(true);
                continueButtonQ3.SetActive(false);
                finish_ContinueButton.SetActive(false);
                passButton.SetActive(false);
                retryButton.SetActive(false);
            }
            if (index == 1 || index == 2)
            {
                continueButtonQ2.SetActive(false);
                continueButtonQ3.SetActive(false);
                finish_ContinueButton.SetActive(false);
                passButton.SetActive(true);
                retryButton.SetActive(true);
            }
            if (index == 3 || index == 4)
            {
                continueButtonQ2.SetActive(false);
                continueButtonQ3.SetActive(true);
                finish_ContinueButton.SetActive(false);
                passButton.SetActive(false);
                retryButton.SetActive(false);
            }
            if (index == 5 || index == 6)
            {
                continueButtonQ2.SetActive(false);
                continueButtonQ3.SetActive(false);
                finish_ContinueButton.SetActive(true);
                passButton.SetActive(false);
                retryButton.SetActive(false);
            }
        }
    }

    public void SpeechBubbleText()
    {
        //Question 1
        sentences[0] = "Correct: Well done!";
        sentences[1] = "Incorrect: Check how you have interpreted the results.";
        sentences[2] = "Incorrect: Check your correlation value.";
        //Question 2
        sentences[3] = "Correct: Well done!";
        sentences[4] = "Incorrect: The null hypothesis can be rejected.";
        //Question 3
        sentences[5] = "Correct: Well done!";
        sentences[6] = "Incorrect: This would be a negative correlation and is not what the study found.";
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
        SceneManager.LoadScene("MHS_EndSummary");
    }

    public void ActivateFeedback()
    {
        feedback.SetActive(true);
        feedbackText.gameObject.SetActive(true);
        feedbackText.text = "";
        questions.SetActive(true);
    }
    
    public void RetryQ1()
    {
        option1Button.interactable = true;
        option2Button.interactable = true;
        option3Button.interactable = true;

        q1Answered = false;
        q2Answered = false;
        q3Answered = false;

        feedback.SetActive(false);

        nextButton.SetActive(true);
        nextButton2.SetActive(false);
        nextButton3.SetActive(false);
        next.interactable = false;
        continueButtonQ2.SetActive(true);
        continueButtonQ3.SetActive(false);
        finish_ContinueButton.SetActive(false);
        finished = false;
        question1 = false;
        question2 = false;
        question3 = false;

        //Question 1
        q.text = "Which of the following is the correct interpretation of the results?";
        a1.text = "There is a statistically significant negative correlation between perceived social support and mental health, r = -0.35.";
        a2.text = "There is a statistically significant positive correlation between perceived social support and mental health, r = 0.352.";
        a3.text = "There is a statistically significant positive correlation between perceived social support and mental health, r = 0.0352.";
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
            scoreBar.gameObject.GetComponent<ScoreSystem>().AddMHSScore();
            question1 = true;
            question2 = false;
            question3 = false;
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
            scoreBar.gameObject.GetComponent<ScoreSystem>().RemoveMHSScore();
            question1 = true;
            question2 = false;
            question3 = false;
            StartCoroutine(Type());
        }
        if (q3Answered)
        {
            character.gameObject.GetComponent<CharacterAnims>().states = 3;//Shake head anim
            continueButtonQ2.SetActive(true);
            feedbackText.text = "";
            index = 2;
            ActivateFeedback();
            nextButton.SetActive(false);
            scoreBar.gameObject.GetComponent<ScoreSystem>().RemoveMHSScore();
            question1 = true;
            question2 = false;
            question3 = false;
            StartCoroutine(Type());
        }
    }
    public void Next2()
    {
        if(q1Answered)
        {
            character.gameObject.GetComponent<CharacterAnims>().states = 2;//Thumbs up anim
            continueButtonQ3.SetActive(true);
            feedbackText.text = "";
            index = 3;
            ActivateFeedback();
            nextButton2.SetActive(false);
            scoreBar.gameObject.GetComponent<ScoreSystem>().AddMHSScore();
            question1 = false;
            question2 = true;
            question3 = false;
            StartCoroutine(Type());
        }
        else
        {
            character.gameObject.GetComponent<CharacterAnims>().states = 3;//Shake head anim
            continueButtonQ3.SetActive(true);
            feedbackText.text = "";
            index = 4;
            ActivateFeedback();
            nextButton2.SetActive(false);
            scoreBar.gameObject.GetComponent<ScoreSystem>().RemoveMHSScore();
            question1 = false;
            question2 = true;
            question3 = false;
            StartCoroutine(Type());
        }
    }
    public void Next3()
    {
        if(q2Answered)
        {
            character.gameObject.GetComponent<CharacterAnims>().states = 2;//Thumbs up anim
            feedbackText.text = "";
            index = 5;
            ActivateFeedback();
            nextButton3.SetActive(false);
            finished = true;
            scoreBar.gameObject.GetComponent<ScoreSystem>().AddMHSScore();
            question1 = false;
            question2 = false;
            question3 = true;
            StartCoroutine(Type());
        }
        else
        {
            character.gameObject.GetComponent<CharacterAnims>().states = 3;//Shake head anim
            feedbackText.text = "";
            index = 6;
            ActivateFeedback();
            nextButton3.SetActive(false);
            finished = true;
            scoreBar.gameObject.GetComponent<ScoreSystem>().RemoveMHSScore();
            question1 = false;
            question2 = false;
            question3 = true;
            StartCoroutine(Type());
        }
    }

    //------------------------QUESTIONS-------------------------------

    public void Q1()
    {
        questions.SetActive(true);
        showTableButton.SetActive(true);
        OptionButton3.SetActive(true);
        continueButtonQ2.SetActive(true);
        nextButton.SetActive(true);

        //Question 1
        q.text = "Which of the following is the correct interpretation of the results?";
        a1.text = "There is a statistically significant negative correlation between perceived social support and mental health, r = -0.35";
        a2.text = "There is a statistically significant positive correlation between perceived social support and mental health, r = 0.352.";
        a3.text = "There is a statistically significant positive correlation between perceived social support and mental health, r = 0.0352.";
    }

    public void Q2()
    {
        questions.SetActive(true);
        showTableButton.SetActive(false);
        option1Button.interactable = true;
        option2Button.interactable = true;
        OptionButton3.SetActive(false);
        nextButton2.SetActive(true);
        continueButtonQ3.SetActive(false);
        continueButtonQ2.SetActive(false);
        feedback.SetActive(false);
        next2.interactable = false;

        //Question 2
        q.text = "Can the null hypothesis be rejected?";
        subq.text = "";
        a1.text = "Yes";
        a2.text = "No";
    }

    public void Q3()
    {
        questions.SetActive(true);
        showTableButton.SetActive(false);
        option1Button.interactable = true;
        option2Button.interactable = true;
        OptionButton3.SetActive(false);
        nextButton3.SetActive(true);
        feedback.SetActive(false);
        next3.interactable = false;

        //Question 3
        q.text = "Which of the following is the most suitable explanation of the results?";
        subq.text = "";
        a1.text = "There is a positive correlation between the two variables, suggesting that as social support increases, mental health decreases.";
        a2.text = "There is a positive correlation between the two variables, suggesting that as social support increases, so does mental health. ";
    }
    //----------------------------------------------------------------------------------------------------------------------------------------------------------

    public void CheckButtonPress()
    {
        string name = EventSystem.current.currentSelectedGameObject.name;

        next.interactable = true;
        next2.interactable = true;
        next3.interactable = true;

        if (name == "Option1")
        {
            option1Button.interactable = false;
            option2Button.interactable = true;
            option3Button.interactable = true;

            q1Answered = true;
            q2Answered = false;
            q3Answered = false;
        }
        if (name == "Option2")
        {
            option1Button.interactable = true;
            option2Button.interactable = false;
            option3Button.interactable = true;

            q1Answered = false;
            q2Answered = true;
            q3Answered = false;
        }
        if (name == "Option3")
        {
            option1Button.interactable = true;
            option2Button.interactable = true;
            option3Button.interactable = false;

            q1Answered = false;
            q2Answered = false;
            q3Answered = true;
        }
        if (name == "Finish_ContinueButton")
        {
            ProgressToNextScene();
        }
    }

    public void ButtonPress()
    {
        string name = EventSystem.current.currentSelectedGameObject.name;

        if (name == "ShowTableButton")
        {
            showTable.SetActive(true);
        }

        if (name == "XButton")
        {
            showTable.SetActive(false);
        }

        if (name == "RetryButton")
        {
            if (index == 1 || index == 2)
            {
                RetryQ1();
            }
        }

        if (name == "PassButton")
        {
            if (index == 1 || index == 2)
            {
                feedback.SetActive(false);
                Q2();
            }
        }
    }

    IEnumerator Type()
    {
        continueButtonQ2.SetActive(false);
        continueButtonQ3.SetActive(false);
        finish_ContinueButton.SetActive(false);
        retryButton.SetActive(false);
        passButton.SetActive(false);

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