using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

//////////////////////////////////////////////////<summary>//////////////////////////////////////////////////// 
///                                   University of the West of Scotland                                    ///
///                         EFFECTS OF DIFFERENT KINDS OF DIET ON WEIGHT LOSS TOPIC                         ///
///                               -------------------------------------------                               ///  
/// Script is attached to the Manager GameObject in the EDK_QuestionsTTT scene.                             ///
///                                                                                                         ///
//////////////////////////////////////////////////</summary>///////////////////////////////////////////////////

public class EDK_TicTacToeQuestions : MonoBehaviour
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
    public Text a1q1;
    public Text a2q1;
    public Text a3q1;
    public Text a4q1;

    public Text a1q2;
    public Text a2q2;

    public Text a1q3;
    public Text a2q3;

    //Typing Text
    public Text feedbackText;
    public string[] sentences;
    private int index;
    public float typingSpeed;

    public Button option1ButtonQ1;
    public Button option2ButtonQ1;
    public Button option3ButtonQ1;
    public Button option4ButtonQ1;
    
    public Button option1ButtonQ2;
    public Button option2ButtonQ2;

    public Button option1ButtonQ3;
    public Button option2ButtonQ3;

    public GameObject option1ButtonQ1_obj;
    public GameObject option2ButtonQ1_obj;
    public GameObject option3ButtonQ1_obj;
    public GameObject option4ButtonQ1_obj;

    public GameObject option1ButtonQ2_obj;
    public GameObject option2ButtonQ2_obj;

    public GameObject option1ButtonQ3_obj;
    public GameObject option2ButtonQ3_obj;

    private bool q1Answered;
    private bool q2Answered;
    private bool q3Answered;
    private bool q4Answered;

    public GameObject character;
    public GameObject fadeScreen;

    public GameObject continueButtonQ2;
    public GameObject continueButtonQ3;
    public GameObject finish_ContinueButton;

    public GameObject nextButtonQ1;

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

        option1ButtonQ1 = GameObject.Find("Option1Q1").GetComponent<Button>();
        option2ButtonQ1 = GameObject.Find("Option2Q1").GetComponent<Button>();
        option3ButtonQ1 = GameObject.Find("Option3Q1").GetComponent<Button>();
        option4ButtonQ1 = GameObject.Find("Option4Q1").GetComponent<Button>();

        option1ButtonQ2 = GameObject.Find("Option1Q2").GetComponent<Button>();
        option2ButtonQ2 = GameObject.Find("Option2Q2").GetComponent<Button>();

        option1ButtonQ3 = GameObject.Find("Option1Q3").GetComponent<Button>();
        option2ButtonQ3 = GameObject.Find("Option2Q3").GetComponent<Button>();

        next = GameObject.Find("NextButton").GetComponent<Button>();
        next2 = GameObject.Find("NextButton2").GetComponent<Button>();
        next3 = GameObject.Find("NextButton3").GetComponent<Button>();
        nextButtonQ1 = GameObject.Find("NextButton");

        retryButton = GameObject.Find("RetryButton");
        passButton = GameObject.Find("PassButton");

        option1ButtonQ2.interactable = true;
        option2ButtonQ2.interactable = true;

        q1Answered = false;
        q2Answered = false;
        q3Answered = false;
        q4Answered = false;

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

        scenarioButtonClickBlock.gameObject.SetActive(false);

         option1ButtonQ1_obj.SetActive(true);
         option2ButtonQ1_obj.SetActive(true);
         option3ButtonQ1_obj.SetActive(true);
         option4ButtonQ1_obj.SetActive(true);

         option1ButtonQ2_obj.SetActive(false);
         option2ButtonQ2_obj.SetActive(false);

         option1ButtonQ3_obj.SetActive(false);
         option2ButtonQ3_obj.SetActive(false);

         showTable.SetActive(false);

         retryButton.SetActive(false);
         passButton.SetActive(false);
    }

    public void ResetQ1()
    {
        feedback.SetActive(false);
        continueButtonQ2.SetActive(true);
        nextButtonQ1.SetActive(true);
        next.interactable = false;

        option1ButtonQ1_obj.SetActive(true);
        option2ButtonQ1_obj.SetActive(true);
        option3ButtonQ1_obj.SetActive(true);
        option4ButtonQ1_obj.SetActive(true);

        option1ButtonQ1.interactable = true;
        option2ButtonQ1.interactable = true;
        option3ButtonQ1.interactable = true;
        option4ButtonQ1.interactable = true;

        questions.SetActive(true);
        showTableButton.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        //when typing text is typing, when the length is equal to the text the continue button will appear
        for (int i = 0; i < sentences.Length; i++)
        {
            if (feedbackText.text == sentences[0])
            {
                continueButtonQ2.SetActive(true);
                continueButtonQ3.SetActive(false);
                finish_ContinueButton.SetActive(false);

                passButton.SetActive(false);
                retryButton.SetActive(false);
            }
            if (feedbackText.text == sentences[1] || feedbackText.text == sentences[2] || feedbackText.text == sentences[3])
            {
                continueButtonQ2.SetActive(false);
                continueButtonQ3.SetActive(false);
                finish_ContinueButton.SetActive(false);

                passButton.SetActive(true);
                retryButton.SetActive(true);
            }
            if (feedbackText.text == sentences[4] || feedbackText.text == sentences[5])
            {
                continueButtonQ2.SetActive(false);
                continueButtonQ3.SetActive(true);
                finish_ContinueButton.SetActive(false);

                passButton.SetActive(false);
                retryButton.SetActive(false);
            }
            if (feedbackText.text == sentences[6] || feedbackText.text == sentences[7])
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
        sentences[0] = "Correct: There is a statistically significant relationship between type of diet and weight loss, t(58)=2.027, p=0.047. The Fat Buster diet resulted in more weight loss (M=4.837kgs, SD=0.9428) compared to the LoCarb diet (M=3.217, SD=4.3030).";
        sentences[1] = "Incorrect: Check your degrees of freedom. Would you like to try again?";
        sentences[2] = "Incorrect: Check which diet was more successful. Would you like to try again?";
        sentences[3] = "Incorrect: Check your t-statistic and p-value. Would you like to try again?";
        //Question 2
        sentences[4] = "Correct: You found a statistically significant result.";
        sentences[5] = "Incorrect: You found a statistically significant result.";
        //Question 3
        sentences[6] = "Correct: There appears to be a significant difference between the two diets in the study, with the FatBuster diet resulting in more weight loss, on average, than the Lo Carb diet. The FatBuster may be a better approach to weight loss.";
        sentences[7] = "Incorrect: Check which diet resulted in more weight loss.";
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
        SceneManager.LoadScene("EDK_EndSummary");
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
        if(q1Answered)
        {
            character.gameObject.GetComponent<CharacterAnims>().states = 2;//Thumbs up anim
            continueButtonQ2.SetActive(true);
            feedbackText.text = "";
            index = 0;
            ActivateFeedback();
            nextButton.SetActive(false);
            scoreBar.gameObject.GetComponent<ScoreSystem>().AddEDKScore();
            question1 = true;
            question2 = false;
            question3 = false;
            StartCoroutine(Type());
        }
        if(q2Answered)
        {
            character.gameObject.GetComponent<CharacterAnims>().states = 3;//Shake head anim
            continueButtonQ2.SetActive(true);
            feedbackText.text = "";
            index = 1;
            ActivateFeedback();
            nextButton.SetActive(false);
            scoreBar.gameObject.GetComponent<ScoreSystem>().RemoveEDKScore();
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
            scoreBar.gameObject.GetComponent<ScoreSystem>().RemoveEDKScore();
            question1 = true;
            question2 = false;
            question3 = false;
            StartCoroutine(Type());
        }
        if (q4Answered)
        {
            character.gameObject.GetComponent<CharacterAnims>().states = 3;//Shake head anim
            continueButtonQ2.SetActive(true);
            feedbackText.text = "";
            index = 3;
            ActivateFeedback();
            nextButton.SetActive(false);
            scoreBar.gameObject.GetComponent<ScoreSystem>().RemoveEDKScore();
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
            index = 4;
            ActivateFeedback();
            nextButton2.SetActive(false);
            scoreBar.gameObject.GetComponent<ScoreSystem>().AddEDKScore();
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
            index = 5;
            ActivateFeedback();
            nextButton2.SetActive(false);
            scoreBar.gameObject.GetComponent<ScoreSystem>().RemoveEDKScore();
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
            index = 6;
            ActivateFeedback();
            nextButton3.SetActive(false);
            finished = true;
            scoreBar.gameObject.GetComponent<ScoreSystem>().AddEDKScore();
            question1 = false;
            question2 = false;
            question3 = true;
            StartCoroutine(Type());
        }
        else
        {
            character.gameObject.GetComponent<CharacterAnims>().states = 3;//Shake head anim
            feedbackText.text = "";
            index = 7;
            ActivateFeedback();
            nextButton3.SetActive(false);
            finished = true;
            scoreBar.gameObject.GetComponent<ScoreSystem>().RemoveEDKScore();
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

        //Question 1
        q.text = "Which of the following is the correct interpretation of the results?";
        subq.text = "";
        a1q1.text = "There is a statistically significant relationship between type of diet and weight loss, t(58)=2.027, p=0.047. The Fat Buster diet resulted in more weight loss (M=4.847kgs, SD=0.9428) compared to the LoCarb diet (M=3.217, SD=4.3030).";
        a2q1.text = "There is a statistically significant relationship between type of diet and weight loss, t(2)=2.027, p=0.047. The Fat Buster diet resulted in more weight loss (M=4.837kgs, SD=0.9428) compared to the LoCarb diet (M=3.217, SD=4.3030).";
        a3q1.text = "There is a statistically significant relationship between type of diet and weight loss, t(58)=2.027, p<0.05. The LoCarb diet resulted in more weight loss (M=4.837kgs, SD=0.9428) compared to the Fat Buster diet (M=3.217, SD=4.3030).";
        a4q1.text = "There is a statistically significant relationship between type of diet and weight loss, t(58)=1.63, p<0.01. The Fat Buster diet resulted in more weight loss (M=4.837kgs, SD=0.9428) compared to the LoCarb diet (M=3.217, SD=4.3030).";
    }

    public void Q2()
    {  
       
        questions.SetActive(true);
        showTableButton.SetActive(false);
      
        option1ButtonQ1_obj.SetActive(false);
        option2ButtonQ1_obj.SetActive(false);
        option3ButtonQ1_obj.SetActive(false);
        option4ButtonQ1_obj.SetActive(false);

        option1ButtonQ2_obj.SetActive(true);
        option2ButtonQ2_obj.SetActive(true);
       
        option1ButtonQ2.interactable = true;
        option2ButtonQ2.interactable = true;

        nextButton2.SetActive(true);
        continueButtonQ3.SetActive(true);
        continueButtonQ2.SetActive(false);
        feedback.SetActive(false);
        next2.interactable = false;

        //Question 2
        q.text = "Can the null hypothesis be rejected?";
        subq.text = "";
        a1q2.text = "     Yes";
        a2q2.text = "     No";
    }

    public void Q3()
    { 
        questions.SetActive(true);
        showTableButton.SetActive(true);

        option1ButtonQ2_obj.SetActive(false);
        option2ButtonQ2_obj.SetActive(false);

        option1ButtonQ3_obj.SetActive(true);
        option2ButtonQ3_obj.SetActive(true);
      
        option1ButtonQ3.interactable = true;
        option2ButtonQ3.interactable = true;
        
        nextButton3.SetActive(true);
        feedback.SetActive(false);
        next3.interactable = false;

        //Question 3
        q.text = "Which of the following is an appropriate explanation of the results?";
        subq.text = "";
        a1q3.text = "There appears to be a significant difference between the two diets in the study, with the LoCarb diet resulting in more weight loss, on average, than the FatBuster diet. The LoCarb diet may be a better approach to weight loss.";
        a2q3.text = "There appears to be a significant difference between the two diets in the study, with the FatBuster diet resulting in more weight loss, on average, than the Lo Carb diet. The FatBuster may be a better approach to weight loss.";
    }
    //----------------------------------------------------------------------------------------------------------------------------------------------------------

    public void CheckButtonPress()
    {
        string name = EventSystem.current.currentSelectedGameObject.name;

        next.interactable = true;
        next2.interactable = true;
        next3.interactable = true;

        if (name == "Option1Q1")
        {
            option1ButtonQ1.interactable = false;
            option2ButtonQ1.interactable = true;
            option3ButtonQ1.interactable = true;
            option4ButtonQ1.interactable = true;

            q1Answered = true;
            q2Answered = false;
            q3Answered = false;
            q4Answered = false;
        }
        if (name == "Option2Q1")
        {
            option1ButtonQ1.interactable = true;
            option2ButtonQ1.interactable = false;
            option3ButtonQ1.interactable = true;
            option4ButtonQ1.interactable = true;

            q1Answered = false;
            q2Answered = true;
            q3Answered = false;
            q4Answered = false;
        }
        if (name == "Option3Q1")
        {
            option1ButtonQ1.interactable = true;
            option2ButtonQ1.interactable = true;
            option3ButtonQ1.interactable = false;
            option4ButtonQ1.interactable = true;

            q1Answered = false;
            q2Answered = false;
            q3Answered = true;
            q4Answered = false;
        }
        if (name == "Option4Q1")
        {
            option1ButtonQ1.interactable = true;
            option2ButtonQ1.interactable = true;
            option3ButtonQ1.interactable = true;
            option4ButtonQ1.interactable = false;

            q1Answered = false;
            q2Answered = false;
            q3Answered = false;
            q4Answered = true;
        }
        if (name == "Option1Q2")
        {
            option1ButtonQ2.interactable = false;
            option2ButtonQ2.interactable = true;

            q1Answered = true;
            q2Answered = false;
        }
        if (name == "Option2Q2")
        {
            option1ButtonQ2.interactable = true;
            option2ButtonQ2.interactable = false;

            q1Answered = false;
            q2Answered = true;
        }
        if (name == "Option1Q3")
        {
            option1ButtonQ3.interactable = false;
            option2ButtonQ3.interactable = true;

            q1Answered = true;
            q2Answered = false;
        }
        if (name == "Option2Q3")
        {
            option1ButtonQ3.interactable = true;
            option2ButtonQ3.interactable = false;

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

        if (name == "RetryButton")
        {
            ResetQ1();
        }

        if (name == "PassButton")
        {
            feedback.SetActive(true);
            Q2();
        }

        if (name == "ShowTableButton")
        {
            showTable.SetActive(true);
        }

        if (name == "XButton")
        {
            showTable.SetActive(false);
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