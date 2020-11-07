using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using TMPro;

//////////////////////////////////////////////////<summary>//////////////////////////////////////////////////// 
///                                   University of the West of Scotland                                    ///
///                                    SKIPPING MEALS AND OBESITY TOPIC                                     ///
///                               -------------------------------------------                               ///  
/// Script is attached to the Manager GameObject in the SMO_QuestionsTTT scene.                             ///
///                                                                                                         ///
//////////////////////////////////////////////////</summary>///////////////////////////////////////////////////

public class SMO_TicTacToeQuestions : MonoBehaviour
{
    public BarAnimations animScript;
    public GameObject scoreBar;
    public GameObject nameBar;

    public GameObject scenarioCloseButton;
    public GameObject scenarioViewButton;
    public GameObject scenarioObj;
    public GameObject scenarioScreenBlock;
    public GameObject showTable;
    public GameObject showTableq5;
    public GameObject TableButton;
    public GameObject ContingencyTableButton;

    public GameObject questions;
    public GameObject nextButton, nextButton2, nextButton3, nextButton4, nextButton5;
    public GameObject feedback;

    public Button next;
    public Button next2;
    public Button next3;
    public Button next4;
    public Button next5;
    
    public TextMeshProUGUI q;
    public Text subq;
    public TextMeshProUGUI a1;
    public TextMeshProUGUI a2;
    public TextMeshProUGUI a3;
    public TextMeshProUGUI a4;
  
    //Typing Text
    public Text feedbackText;
    public string[] sentences;
    private int index;
    public float typingSpeed;

    public Button option1Button;
    public Button option2Button;
    public Button option3Button;
    public Button option4Button;

    public GameObject option3, option4;

    private bool q1Answered;
    private bool q2Answered;
    private bool q3Answered;
    private bool q4Answered;
    private bool q5Answered;

    public GameObject character;
    
    public GameObject finish_ContinueButton;

    private bool finished;
    private bool question1, question2, question3, question4, question5;

    public GameObject retryButton;
    public GameObject passButton;

    public int ButtonIndex;

    // Start is called before the first frame update
    void Start()
    {
        scenarioObj = GameObject.Find("ResearchScenario");
        nameBar = GameObject.Find("NameBar");
        scoreBar = GameObject.Find("ScoreBar");
        scenarioCloseButton = GameObject.Find("ScenarioButton_Close");
        scenarioViewButton = GameObject.Find("ScenarioButton_View");
        scenarioScreenBlock = GameObject.Find("ScenarioButtonClickBlock");

        feedback = GameObject.Find("Feedback");
        feedbackText = GameObject.Find("FeedbackText").GetComponent<Text>();

        option1Button = GameObject.Find("Option1").GetComponent<Button>();
        option2Button = GameObject.Find("Option2").GetComponent<Button>();
        option3Button = GameObject.Find("Option3").GetComponent<Button>();
        option4Button = GameObject.Find("Option4").GetComponent<Button>();

        option3 = GameObject.Find("Option3");
        option4 = GameObject.Find("Option4");

        TableButton = GameObject.Find("ShowTableButton");
        ContingencyTableButton = GameObject.Find("ShowContingencyTableButton");

        retryButton = GameObject.Find("RetryButton");
        passButton = GameObject.Find("PassButton");

        ResetQ1();
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
        q5Answered = false;

        nextButton.SetActive(true);
        nextButton2.SetActive(false);
        nextButton3.SetActive(false);
        nextButton4.SetActive(false);
        nextButton5.SetActive(false);

        feedback.SetActive(false);
        next.interactable = false;
        finish_ContinueButton.SetActive(false);
        finished = false;
        question1 = false;
        question2 = false;
        question3 = false;
        question4 = false;
        question5 = false;

        scenarioScreenBlock.SetActive(false);

        showTable.SetActive(false);
        showTableq5.SetActive(false);
        TableButton.SetActive(false);
        ContingencyTableButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //when typing text is typing, when the length is equal to the text the continue button will appear
        for (int i = 0; i < sentences.Length; i++)
        {
            if (feedbackText.text == sentences[1] || feedbackText.text == sentences[2] || feedbackText.text == sentences[3]
                || feedbackText.text == sentences[7] || feedbackText.text == sentences[8] || feedbackText.text == sentences[9])
            {
                retryButton.SetActive(true);
                passButton.SetActive(true);
                finish_ContinueButton.SetActive(false);
            }
            if (feedbackText.text == sentences[0] || feedbackText.text == sentences[4] || feedbackText.text == sentences[5]
                || feedbackText.text == sentences[6] || feedbackText.text == sentences[10] || feedbackText.text == sentences[11] || feedbackText.text == sentences[12] || feedbackText.text == sentences[13])
            {
                finish_ContinueButton.SetActive(true);
                retryButton.SetActive(false);
                passButton.SetActive(false);
            }
        }
    }

    public void SpeechBubbleText()
    {
        //Question 1
        sentences[0] = "Correct: This is the statistic for chi-square.";
        sentences[1] = "Incorrect: A t-test is not appropriate as you do not have an interval or ratio dependent variable.";
        sentences[2] = "Incorrect: A correlation is not appropriate for nominal data.";
        sentences[3] = "Incorrect: The p-value is not a test statistic.";
        //Question 2
        sentences[4] = "Correct: If the chi-square value is greater than the critical value then the chi-square value is significant. The calculated chi-square value (12.983) was greater than the critical value (5.99) and so it was significant suggesting that there was an association between skipping meals and weight.";
        sentences[5] = "Incorrect: If the chi-square value is greater than the critical value then the chi-square value is significant. The calculated chi-square value (12.983) was greater than the critical value (5.99) and so it was significant suggesting that there was an association between skipping meals and weight.";
        //Question 3
        sentences[6] = "Correct: This is the correct interpretation of the results.";
        sentences[7] = "Incorrect: Check your degrees of freedom.";
        sentences[8] = "Incorrect: Check your chi-square value.";
        sentences[9] = "Incorrect: Check your p-value.";
        //Question 4
        sentences[10] = "Correct: You found a statistically significant result.";
        sentences[11] = "Incorrect: You found a statistically significant result.";
        //Question 5
        sentences[12] = "Correct: The relationship between skipping meals and weight suggests that people who do not skip meals are much more likely to be a healthy weight.";
        sentences[13] = "Incorrect: The contingency table shows that many more participants who said ‘yes’ to skipping meals are overweight compared to being a healthy weight.";
    }

    public void ReadyToPlay()
    {
        scenarioObj.gameObject.GetComponent<ScenarioAnimations>().states = 2;
        scenarioViewButton.gameObject.SetActive(true);
        scenarioCloseButton.gameObject.SetActive(false);
        questions.SetActive(true);
        scenarioScreenBlock.SetActive(false);
    }
    
    public void ViewStudy()
    {
        scenarioObj.gameObject.GetComponent<ScenarioAnimations>().states = 1;
        scenarioCloseButton.gameObject.SetActive(true);
        scenarioViewButton.gameObject.SetActive(false);
        questions.SetActive(true);
        scenarioScreenBlock.SetActive(true);
    }
    
    public void CloseStudy()
    {
        scenarioObj.gameObject.GetComponent<ScenarioAnimations>().states = 2;
        scenarioViewButton.gameObject.SetActive(true);
        scenarioCloseButton.gameObject.SetActive(false);
        questions.SetActive(true);
        scenarioScreenBlock.SetActive(false);
    }

    public void ProgressToNextScene()
    {
        SceneManager.LoadScene("SMO_EndSummary");
    }

    public void ActivateFeedback()
    {
        feedback.SetActive(true);
        feedbackText.gameObject.SetActive(true);
        feedbackText.text = "";
        questions.SetActive(true);
    }
    
    //Question 1
    public void Next()
    {
        if(q4Answered)
        {
            character.gameObject.GetComponent<CharacterAnims>().states = 2;//Thumbs up anim
            feedbackText.text = "";
            index = 0;
            ActivateFeedback();
            nextButton.SetActive(false);
            finish_ContinueButton.SetActive(false);
            retryButton.SetActive(false);
            passButton.SetActive(false);
            scoreBar.gameObject.GetComponent<ScoreSystem>().AddSMOScore();
            question1 = true;
            StartCoroutine(Type());
        } 
        else
        {
            if (q1Answered)
            {
                index = 1;
            }
            if (q2Answered)
            {
                index = 2;
            }
            if (q3Answered)
            {
                index = 3;
            }

            character.gameObject.GetComponent<CharacterAnims>().states = 3;//Shake head anim
            feedbackText.text = "";
            ActivateFeedback();
            nextButton.SetActive(false);
            finish_ContinueButton.SetActive(false);
            retryButton.SetActive(false);
            passButton.SetActive(false);
            scoreBar.gameObject.GetComponent<ScoreSystem>().RemoveSMOScore();
            question1 = true;
            StartCoroutine(Type());
        }
    }
    
    //Question 2
    public void Next2()
    {
        if (q1Answered)
        {
            character.gameObject.GetComponent<CharacterAnims>().states = 2;//Thumbs up anim
            feedbackText.text = "";
            index = 4;
            ActivateFeedback();
            nextButton.SetActive(false);
            finish_ContinueButton.SetActive(false);
            retryButton.SetActive(false);
            passButton.SetActive(false);
            scoreBar.gameObject.GetComponent<ScoreSystem>().AddSMOScore();
            question2 = true;
            StartCoroutine(Type());
        }
        if (q2Answered)
        {
            character.gameObject.GetComponent<CharacterAnims>().states = 3;//Shake head anim
            feedbackText.text = "";
            index = 5;
            ActivateFeedback();
            nextButton.SetActive(false);
            finish_ContinueButton.SetActive(false);
            retryButton.SetActive(false);
            passButton.SetActive(false);
            scoreBar.gameObject.GetComponent<ScoreSystem>().RemoveSMOScore();
            question2 = true;
            StartCoroutine(Type());
        }
    }
    
    //Question 3
    public void Next3()
    {
        if (q1Answered)
        {
            character.gameObject.GetComponent<CharacterAnims>().states = 2;//Thumbs up anim
            feedbackText.text = "";
            index = 6;
            ActivateFeedback();
            nextButton.SetActive(false);
            finish_ContinueButton.SetActive(false);
            retryButton.SetActive(false);
            passButton.SetActive(false);
            scoreBar.gameObject.GetComponent<ScoreSystem>().AddSMOScore();
            question3 = true;
            StartCoroutine(Type());
        } 
        else
        {
            if (q2Answered)
            {
                index = 7;
            }
            if (q3Answered)
            {
                index = 8;
            }
            if (q4Answered)
            {
                index = 9;
            }

            character.gameObject.GetComponent<CharacterAnims>().states = 3;//Shake head anim
            feedbackText.text = "";
            ActivateFeedback();
            nextButton.SetActive(false);
            finish_ContinueButton.SetActive(false);
            retryButton.SetActive(false);
            passButton.SetActive(false);
            scoreBar.gameObject.GetComponent<ScoreSystem>().RemoveSMOScore();
            question3 = true;
            StartCoroutine(Type());
        }
    }
    
    //Question 4
    public void Next4()
    {
        if (q1Answered)
        {
            character.gameObject.GetComponent<CharacterAnims>().states = 2;//Thumbs up anim
            feedbackText.text = "";
            index = 10;
            ActivateFeedback();
            nextButton.SetActive(false);
            finish_ContinueButton.SetActive(false);
            retryButton.SetActive(false);
            passButton.SetActive(false);
            scoreBar.gameObject.GetComponent<ScoreSystem>().AddSMOScore();
            question4 = true;
            StartCoroutine(Type());
        }
        if (q2Answered)
        {
            character.gameObject.GetComponent<CharacterAnims>().states = 3;//Shake head anim
            feedbackText.text = "";
            index = 11;
            ActivateFeedback();
            nextButton.SetActive(false);
            finish_ContinueButton.SetActive(false);
            retryButton.SetActive(false);
            passButton.SetActive(false);
            scoreBar.gameObject.GetComponent<ScoreSystem>().RemoveSMOScore();
            question4 = true;
            StartCoroutine(Type());
        }
    }
    //Question 5
    public void Next5()
    {
        nextButton5.SetActive(false);

        if (q1Answered)
        {
            character.gameObject.GetComponent<CharacterAnims>().states = 2;//Thumbs up anim
            feedbackText.text = "";
            index = 12;
            ActivateFeedback();
            nextButton5.SetActive(false);
            finish_ContinueButton.SetActive(false);
            retryButton.SetActive(false);
            passButton.SetActive(false);
            scoreBar.gameObject.GetComponent<ScoreSystem>().AddSMOScore();
            question5 = true;
            StartCoroutine(Type());
        }
        if (q2Answered)
        {
            character.gameObject.GetComponent<CharacterAnims>().states = 3;//Shake head anim
            feedbackText.text = "";
            index = 13;
            ActivateFeedback();
            nextButton5.SetActive(false);
            finish_ContinueButton.SetActive(false);
            retryButton.SetActive(false);
            passButton.SetActive(false);
            scoreBar.gameObject.GetComponent<ScoreSystem>().RemoveSMOScore();
            question5 = true;
            StartCoroutine(Type());
        }
    }

    public void Q1()
    {
        questions.SetActive(true);

        nextButton.SetActive(true);
        next.interactable = false;
        nextButton2.SetActive(false);
        nextButton3.SetActive(false);
        nextButton4.SetActive(false);
        nextButton5.SetActive(false);

        q.text = "What test statistic do you expect to calculate?";
        subq.text = "";
        a1.text = "  t (a t-test)";
        a2.text = "  r (a correlation)";
        a3.text = "  p (a p-value)";
        a4.text = "  x<sup>2</sup> (a chi-square)";
    }

    public void Q2()
    {
        feedback.SetActive(false);
        questions.SetActive(true);
        TableButton.SetActive(true);
        ContingencyTableButton.SetActive(false);

        DefaultButtons();

        nextButton.SetActive(false);
        nextButton2.SetActive(true);
        next2.interactable = false;
        nextButton3.SetActive(false);
        nextButton4.SetActive(false);
        nextButton5.SetActive(false);

        q.text = "The critical value of chi-square for a 3*2 contingency table at .05 level of significance for a two tailed test is 5.99.\n\nThe calculated chi-square value = 12.983. Is this chi-square value significant?";
        subq.text = "";
        a1.text = "  Yes";
        a2.text = "  No";
        option3.SetActive(false);
        option4.SetActive(false);
    }

    public void Q3()
    {
        feedback.SetActive(false);
        questions.SetActive(true);
        TableButton.SetActive(true);
        ContingencyTableButton.SetActive(false);

        DefaultButtons();

        nextButton.SetActive(false);
        nextButton2.SetActive(false);
        nextButton3.SetActive(true);
        next3.interactable = false;
        nextButton4.SetActive(false);
        nextButton5.SetActive(false);

        option3.SetActive(true);
        option4.SetActive(true);

        q.text = "Which of the following is the correct interpretation of the results?";
        subq.text = "";
        a1.text = "There is a statistically significant relationship between skipping meals and weight,\nX<sup>2</sup>(2)=12.983, p=0.002.";
        a2.text = "There is a statistically significant relationship between skipping meals and weight,\nX<sup>2</sup>(6)=12.983, p=0.002.";
        a3.text = "There is a statistically significant relationship between skipping meals and weight,\nX<sup>2</sup>(2)=1.2983, p=0.002.";
        a4.text = "There is a statistically significant relationship between skipping meals and weight,\nX<sup>2</sup>(2)=12.983, p=0.02.";
    }

    public void Q4()
    {
        feedback.SetActive(false);
        questions.SetActive(true);
        TableButton.SetActive(true);
        ContingencyTableButton.SetActive(false);

        DefaultButtons();

        nextButton.SetActive(false);
        nextButton2.SetActive(false);
        nextButton3.SetActive(false);
        nextButton4.SetActive(true);
        nextButton5.SetActive(false);
        next4.interactable = false;

        q.text = "Can the null hypothesis be rejected?";
        subq.text = "";
        a1.text = "  Yes";
        a2.text = "  No";
        option3.SetActive(false);
        option4.SetActive(false);
    }

    public void Q5()
    {
        feedback.SetActive(false);
        questions.SetActive(true);
        TableButton.SetActive(false);
        ContingencyTableButton.SetActive(true);

        DefaultButtons();

        nextButton.SetActive(false);
        nextButton2.SetActive(false);
        nextButton3.SetActive(false);
        nextButton4.SetActive(false);
        nextButton5.SetActive(true);
        next5.interactable = false;

        q.text = "How can these results be explained?";
        subq.text = "";
        a1.text = "The relationship between skipping meals and weight suggests that people who do not skip meals are much more likely to be a healthy weight than people who skip meals, although this difference is less noticeable for those who ‘sometimes’ skip meals.";
        a2.text = "The relationship between skipping meals and weight suggests that skipping meals (responding ‘yes’ in this study) is likely to result in being a healthy weight instead of overweight.";
        option3.SetActive(false);
        option4.SetActive(false);
    }


    public void CheckButtonPress()
    {
        string name = EventSystem.current.currentSelectedGameObject.name;

        next.interactable = true;
        next2.interactable = true;
        next3.interactable = true;
        next4.interactable = true;
        next5.interactable = true;

        if (name == "RetryButton")
        {
            if (index == 1 || index == 2 || index == 3)
            {
                ResetQ1();
            }

            if (index == 7 || index == 8 || index == 9)
            {
                Q3();
            }
        }

        if (name == "PassButton")
        {
            if (index == 1 || index == 2 || index == 3)
            {
                Q2();
            }

            if (index == 7 || index == 8 || index == 9)
            {
                Q4();
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
        if (name == "Finish_ContinueButton")
        {
            if (question1)
            {
                Q2();
            }
            if (question1 && question2)
            {
                Q3();
            }
            if (question1 && question2 && question3)
            {
                Q4();
            }
            if (question1 && question2 && question3 && question4)
            {
                Q5();
            }
            if (question1 && question2 && question3 && question4 && question5)
            {
                nextButton5.SetActive(false);
                ProgressToNextScene();
            }
        }
    }

    public void DefaultButtons()
    {
        option1Button.interactable = true;
        option2Button.interactable = true;
        option3Button.interactable = true;
        option4Button.interactable = true;

        q1Answered = false;
        q2Answered = false;
        q3Answered = false;
        q4Answered = false;
    }
    
    public void ButtonPress()
    {
        string name = EventSystem.current.currentSelectedGameObject.name;

        if (name == "ShowTableButton")
        {
            ButtonIndex = 0;

            showTable.SetActive(true);
            TableButton.SetActive(false);
            ContingencyTableButton.SetActive(false);
        }

        if (name == "XButton")
        {
            showTable.SetActive(false);
            showTableq5.SetActive(false);

            if(ButtonIndex == 0)
            {
                ContingencyTableButton.SetActive(false);
                TableButton.SetActive(true);
            }
            if (ButtonIndex == 1)
            {
                TableButton.SetActive(false);
                ContingencyTableButton.SetActive(true);
            }
        }

        if (name == "ShowContingencyTableButton")
        {
            ButtonIndex = 1;

            showTableq5.SetActive(true);
            TableButton.SetActive(false);
            ContingencyTableButton.SetActive(false);
        }
    }

    IEnumerator Type()
    {
        finish_ContinueButton.SetActive(false);
        nextButton.SetActive(false);
        nextButton2.SetActive(false);
        nextButton3.SetActive(false);
        nextButton4.SetActive(false);
        nextButton5.SetActive(false);

        if (question1)
        {           
            foreach (char letter in sentences[index].ToCharArray())
            {
                feedbackText.text += letter;
                yield return new WaitForSeconds(typingSpeed);
            }
        }
    }
}