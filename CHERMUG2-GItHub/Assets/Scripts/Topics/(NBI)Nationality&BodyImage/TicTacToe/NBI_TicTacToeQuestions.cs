using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using TMPro;

//////////////////////////////////////////////////<summary>//////////////////////////////////////////////////// 
///                                   University of the West of Scotland                                    ///
///                                    NATIONALITY AND BODY IMAGE TOPIC                                     ///
///                               -------------------------------------------                               ///  
/// Script is attached to the Manager GameObject in the NBI_QuestionsTTT scene.                             ///
///                                                                                                         ///
//////////////////////////////////////////////////</summary>///////////////////////////////////////////////////

public class NBI_TicTacToeQuestions : MonoBehaviour
{
    public BarAnimations animScript;
    public GameObject scoreBar;
    public GameObject nameBar;

    public GameObject scenarioCloseButton;
    public GameObject scenarioViewButton;
    public GameObject scenarioObj;
    public GameObject scenarioScreenBlock;
    public GameObject showTable;
    public GameObject TableButton;

    public GameObject questions;
    public GameObject nextButton, nextButton2, nextButton3, nextButton4;
    public GameObject feedback;

    public Button next;
    public Button next2;
    public Button next3;
    public Button next4;
    
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

    public GameObject character;
    
    public GameObject finish_ContinueButton;

    private bool finished;
    private bool question1, question2, question3, question4;

    public GameObject retryButton;
    public GameObject passButton;

    public int ButtonIndex;

    // Start is called before the first frame update
    void Start()
    {
        Q1();

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

        retryButton = GameObject.Find("RetryButton");
        passButton = GameObject.Find("PassButton");
        
        option3.SetActive(false);
        option4.SetActive(false);

        SpeechBubbleText();

        option1Button.interactable = true;
        option2Button.interactable = true;
        option3Button.interactable = true;
        option4Button.interactable = true;

        q1Answered = false;
        q2Answered = false;
        q3Answered = false;
        q4Answered = false;

        nextButton.SetActive(true);
        nextButton2.SetActive(false);
        nextButton3.SetActive(false);
        nextButton4.SetActive(false);

        feedback.SetActive(false);
        next.interactable = false;
        finish_ContinueButton.SetActive(false);
        finished = false;
        question1 = false;
        question2 = false;
        question3 = false;
        question4 = false;

        scenarioScreenBlock.SetActive(false);

        showTable.SetActive(false);
        TableButton.SetActive(true);
    }

    public void ResetQ2()
    {
        Q2();

        option1Button.interactable = true;
        option2Button.interactable = true;
        option3Button.interactable = true;
        option4Button.interactable = true;

        q1Answered = false;
        q2Answered = false;
        q3Answered = false;
        q4Answered = false;
        
        nextButton2.SetActive(true);
        question2 = false;
   
        scenarioScreenBlock.SetActive(false);

        showTable.SetActive(false);
        TableButton.SetActive(true);
        feedback.SetActive(false);

        DefaultButtons();

        nextButton.SetActive(false);
        nextButton2.SetActive(true);
        next2.interactable = false;
    }

    // Update is called once per frame
    void Update()
    {
        //when typing text is typing, when the length is equal to the text the continue button will appear
        for (int i = 0; i < sentences.Length; i++)
        {
            if (feedbackText.text == sentences[3])
            {
                retryButton.SetActive(true);
                passButton.SetActive(true);
                finish_ContinueButton.SetActive(false);
            }
            if (feedbackText.text == sentences[0] || feedbackText.text == sentences[1] || feedbackText.text == sentences[2] || feedbackText.text == sentences[4] || feedbackText.text == sentences[5] || feedbackText.text == sentences[6] || feedbackText.text == sentences[7])
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
        sentences[0] = "Correct: If the chi-square value is greater than the critical value then the chi-square value is significant. The calculated chi-square value (12.638) was greater than the critical value (5.99) and so it was significant, suggesting that there is a relationship between nationality and body image.";
        sentences[1] = "Incorrect: If the chi-square value is greater than the critical value then the chi-square value is significant. The calculated chi-square value (12.638) was greater than the critical value (5.99) and so it was significant suggesting that there is a relationship between nationality and body image.";
        //Question 2
        sentences[2] = "Correct: Well done!";
        sentences[3] = "Incorrect: Would you like to try again?";
        //Question 3
        sentences[4] = "Correct: You found a statistically significant result.";
        sentences[5] = "Incorrect: You found a statistically significant result.";
        //Question 4
        sentences[6] = "Correct: The results suggest that there is a relationship between nationality and perception of attractiveness, with Danish people most likely to identify themselves as below average and British people most likely to identify themselves as average or above average.";
        sentences[7] = "Incorrect: The results suggest that there is a relationship between nationality and perception of attractiveness, with Danish people most likely to identify themselves as below average and British people most likely to identify themselves as average or above average.";
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
        SceneManager.LoadScene("NBI_EndSummary");
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
        if(q1Answered)
        {
            character.gameObject.GetComponent<CharacterAnims>().states = 2;//Thumbs up anim
            feedbackText.text = "";
            index = 0;
            ActivateFeedback();
            nextButton.SetActive(false);
            finish_ContinueButton.SetActive(false);
            retryButton.SetActive(false);
            passButton.SetActive(false);
            scoreBar.gameObject.GetComponent<ScoreSystem>().AddNBIScore();
            question1 = true;
            StartCoroutine(Type());
        } 
        else
        {
            character.gameObject.GetComponent<CharacterAnims>().states = 3;//Shake head anim
            feedbackText.text = "";
            index = 1;
            ActivateFeedback();
            nextButton.SetActive(false);
            finish_ContinueButton.SetActive(false);
            retryButton.SetActive(false);
            passButton.SetActive(false);
            scoreBar.gameObject.GetComponent<ScoreSystem>().RemoveNBIScore();
            question1 = true;
            StartCoroutine(Type());
        }
    }
    
    //Question 2
    public void Next2()
    {
        if (q4Answered)
        {
            character.gameObject.GetComponent<CharacterAnims>().states = 2;//Thumbs up anim
            feedbackText.text = "";
            index = 2;
            ActivateFeedback();
            nextButton.SetActive(false);
            finish_ContinueButton.SetActive(false);
            retryButton.SetActive(false);
            passButton.SetActive(false);
            scoreBar.gameObject.GetComponent<ScoreSystem>().AddNBIScore();
            question2 = true;
            StartCoroutine(Type());
        }
        else
        {
            character.gameObject.GetComponent<CharacterAnims>().states = 3;//Shake head anim
            feedbackText.text = "";
            index = 3;
            ActivateFeedback();
            nextButton.SetActive(false);
            finish_ContinueButton.SetActive(false);
            scoreBar.gameObject.GetComponent<ScoreSystem>().RemoveNBIScore();
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
            index = 4;
            ActivateFeedback();
            nextButton.SetActive(false);
            finish_ContinueButton.SetActive(false);
            retryButton.SetActive(false);
            passButton.SetActive(false);
            scoreBar.gameObject.GetComponent<ScoreSystem>().AddNBIScore();
            question3 = true;
            StartCoroutine(Type());
        } 
        else
        {
            character.gameObject.GetComponent<CharacterAnims>().states = 3;//Shake head anim
            feedbackText.text = "";
            index = 5;
            ActivateFeedback();
            nextButton.SetActive(false);
            finish_ContinueButton.SetActive(false);
            retryButton.SetActive(false);
            passButton.SetActive(false);
            scoreBar.gameObject.GetComponent<ScoreSystem>().RemoveNBIScore();
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
            index = 6;
            ActivateFeedback();
            nextButton.SetActive(false);
            finish_ContinueButton.SetActive(false);
            retryButton.SetActive(false);
            passButton.SetActive(false);
            scoreBar.gameObject.GetComponent<ScoreSystem>().AddNBIScore();
            question4 = true;
            StartCoroutine(Type());
        }
        if (q2Answered)
        {
            character.gameObject.GetComponent<CharacterAnims>().states = 3;//Shake head anim
            feedbackText.text = "";
            index = 7;
            ActivateFeedback();
            nextButton.SetActive(false);
            finish_ContinueButton.SetActive(false);
            retryButton.SetActive(false);
            passButton.SetActive(false);
            scoreBar.gameObject.GetComponent<ScoreSystem>().RemoveNBIScore();
            question4 = true;
            StartCoroutine(Type());
        }
    }

    public void Q1()
    {
        questions.SetActive(true);
        TableButton.SetActive(true);
        nextButton.SetActive(true);
        next.interactable = false;
        nextButton2.SetActive(false);
        nextButton3.SetActive(false);
        nextButton4.SetActive(false);

        q.text = "The critical value of chi-square for a 3*2 contingency table at .05 level of significance is 5.99.\n\nThe calculated chi-square value =12.638. Is this chi-square value statistically significant?";
        subq.text = "";
        a1.text = "  Yes";
        a2.text = "  No";
    }

    public void Q2()
    {
        feedback.SetActive(false);

        DefaultButtons();

        nextButton.SetActive(false);
        nextButton2.SetActive(true);
        next2.interactable = false;
        option3.SetActive(true);
        option4.SetActive(true);

        q.text = "Which of the following is the correct interpretation of the results?";
        subq.text = "";
        a1.text = "  There is a statistically significant relationship between nationality and body image, X<sup>2</sup>(3)=12.638, p<0.05.";
        a2.text = "  There is a statistically significant relationship between nationality and body image, X<sup>2</sup>(2)=1.2983, p<0.05.";
        a3.text = "  There is a statistically significant relationship between nationality and body image, X<sup>2</sup>(2)=12.638, p=0.5.";
        a4.text = "  There is a statistically significant relationship between nationality and body image, X<sup>2</sup>(2)=12.638, p<0.05.";
    }

    public void Q3()
    {
        feedback.SetActive(false);

        DefaultButtons();

        TableButton.SetActive(false);
        nextButton2.SetActive(false);
        nextButton3.SetActive(true);
        next3.interactable = false;

        option3.SetActive(false);
        option4.SetActive(false);

        q.text = "Can the null hypothesis be rejected?";
        subq.text = "";
        a1.text = "Yes";
        a2.text = "No";
    }

    public void Q4()
    {
        feedback.SetActive(false);
        DefaultButtons();
        nextButton3.SetActive(false);
        nextButton4.SetActive(true);
        next4.interactable = false;
        TableButton.SetActive(true);
        
        option3.SetActive(false);
        option4.SetActive(false);

        q.text = "Which of the following is the most appropriate explanation of the results?";
        subq.text = "";
        a1.text = "  The results suggest that there is a relationship between nationality and perception of attractiveness,\n  with Danish people most likely to identify themselves as below average and British people most likely to identify\n  themselves as average or above average.";
        a2.text = "  The results suggest that there is a relationship between nationality and perception of attractiveness,\n  with Danish people rating themselves as above average most of the time.";
    }
    
    public void CheckButtonPress()
    {
        string name = EventSystem.current.currentSelectedGameObject.name;

        next.interactable = true;
        next2.interactable = true;
        next3.interactable = true;
        next4.interactable = true;

        if (name == "RetryButton")
        {
            if (index == 3)
            {
                ResetQ2();
            }
        }

        if (name == "PassButton")
        {
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
                nextButton4.SetActive(false);
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
        }

        if (name == "XButton")
        {
            showTable.SetActive(false);

            if(ButtonIndex == 0)
            {
                TableButton.SetActive(true);
            }
            if (ButtonIndex == 1)
            {
                TableButton.SetActive(false);
            }
        }
    }

    IEnumerator Type()
    {
        finish_ContinueButton.SetActive(false);
        nextButton.SetActive(false);
        nextButton2.SetActive(false);
        nextButton3.SetActive(false);
        nextButton4.SetActive(false);

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