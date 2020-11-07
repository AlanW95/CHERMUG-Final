using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

//////////////////////////////////////////////////<summary>//////////////////////////////////////////////////// 
///                                   University of the West of Scotland                                    ///
///                                 ACTIVITY, GENDER AND SELF ESTEEM TOPIC                                  ///
///                               -------------------------------------------                               ///  
/// Script is attached to the Manager GameObject in the AGSE_QuestionsTTT scene.                            ///
///                                                                                                         ///
//////////////////////////////////////////////////</summary>///////////////////////////////////////////////////

public class AGSE_TicTacToeQuestions : MonoBehaviour
{
    public BarAnimations animScript;
    public GameObject scoreBar;
    public GameObject nameBar;

    public GameObject scenarioCloseButton;
    public GameObject scenarioViewButton;
    public GameObject scenarioButtonClickBlock;
    public GameObject scenarioObj;

    public GameObject spss;
    public GameObject linegraph;
    public GameObject showTableButton;
    public GameObject showlinegraphButton;

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

    public Text a1q2;
    public Text a2q2;
    public Text a3q2;
    public Text a4q2;

    public Text a1q3;
    public Text a2q3;

    //Typing Text
    public Text feedbackText;

    public string[] sentences;
    private int index;
    public float typingSpeed;

    public Button option1ButtonQ1;
    public Button option2ButtonQ1;
    
    public Button option1ButtonQ2;
    public Button option2ButtonQ2;
    public Button option3ButtonQ2;
    public Button option4ButtonQ2;

    public Button option1ButtonQ3;
    public Button option2ButtonQ3;

    public GameObject option1ButtonQ1_obj;
    public GameObject option2ButtonQ1_obj;

    public GameObject option1ButtonQ2_obj;
    public GameObject option2ButtonQ2_obj;
    public GameObject option3ButtonQ2_obj;
    public GameObject option4ButtonQ2_obj;

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

        option1ButtonQ2 = GameObject.Find("Option1Q2").GetComponent<Button>();
        option2ButtonQ2 = GameObject.Find("Option2Q2").GetComponent<Button>();
        option3ButtonQ2 = GameObject.Find("Option3Q2").GetComponent<Button>();
        option4ButtonQ2 = GameObject.Find("Option4Q2").GetComponent<Button>();

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

        option1ButtonQ2_obj.SetActive(false);
        option2ButtonQ2_obj.SetActive(false);
        option3ButtonQ2_obj.SetActive(false);
        option4ButtonQ2_obj.SetActive(false);

        option1ButtonQ3_obj.SetActive(false);
        option2ButtonQ3_obj.SetActive(false);

        spss.SetActive(false);
        linegraph.SetActive(false);

        retryButton.SetActive(false);
        passButton.SetActive(false);

    }

    public void ResetQ2()
    {
        feedback.SetActive(false);
        continueButtonQ2.SetActive(true);
        nextButton2.SetActive(true);
        next2.interactable = false;

        option1ButtonQ2_obj.SetActive(true);
        option2ButtonQ2_obj.SetActive(true);
        option3ButtonQ2_obj.SetActive(true);
        option4ButtonQ2_obj.SetActive(true);

        option1ButtonQ2.interactable = true;
        option2ButtonQ2.interactable = true;
        option3ButtonQ2.interactable = true;
        option4ButtonQ2.interactable = true;

        questions.SetActive(true);
        showTableButton.SetActive(true);
        showlinegraphButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //when typing text is typing, when the length is equal to the text the continue button will appear
        for (int i = 0; i < sentences.Length; i++)
        {
            if (feedbackText.text == sentences[0] || feedbackText.text == sentences[1])
            {
                continueButtonQ2.SetActive(true);
                continueButtonQ3.SetActive(false);
                finish_ContinueButton.SetActive(false);

                passButton.SetActive(false);
                retryButton.SetActive(false);
            }
            if (feedbackText.text == sentences[2])
            {
                continueButtonQ2.SetActive(false);
                continueButtonQ3.SetActive(true);
                finish_ContinueButton.SetActive(false);

                passButton.SetActive(false);
                retryButton.SetActive(false);
            }
            if (feedbackText.text == sentences[3])
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
        sentences[0] = "Correct: A two-way (2x2) ANOVA found a statistically significant interaction effect of Gender and Activity Level on Self-Esteem, F(1,66)=5.112, p=0.027. The main effect of Activity Level was also statistically significant, F(1,66)=13.022, p=0.001. The main effect of Gender was not statistically significant, F(1,66)=0.691, p=0.409.";
        sentences[1] = "Incorrect: p=0.409 is not statistically significant.";
        //Question 2
        sentences[2] = "Correct: The interaction null hypothesis, and the null hypothesis for activity level can be rejected.";
        sentences[3] = "Incorrect: Would you like to try again?";
        //Question 3
        sentences[4] = "Correct: Being active appears to have a positive influence on self-esteem compared to being sedentary, although this effect is much more noticeable in males than females.";
        sentences[5] = "Incorrect: Being active appears to have a positive influence on self-esteem compared to being sedentary, although this effect is much more noticeable in males than females.";
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
        SceneManager.LoadScene("AGSE_EndSummary");
    }

    public void ActivateFeedback()
    {
        feedback.SetActive(true);
        feedbackText.gameObject.SetActive(true);
        feedbackText.text = "";
        questions.SetActive(true);
    }

    //Next buttons for after each question after a necessary question is answered
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
            scoreBar.gameObject.GetComponent<ScoreSystem>().AddAGSEScore();
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
            scoreBar.gameObject.GetComponent<ScoreSystem>().RemoveAGSEScore();
            question1 = true;
            question2 = false;
            question3 = false;
            StartCoroutine(Type());
        }
    }
    public void Next2()
    {
        if(q3Answered)
        {
            character.gameObject.GetComponent<CharacterAnims>().states = 2;//Thumbs up anim
            continueButtonQ3.SetActive(true);
            feedbackText.text = "";
            index = 2;
            ActivateFeedback();
            nextButton2.SetActive(false);
            scoreBar.gameObject.GetComponent<ScoreSystem>().AddAGSEScore();
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
            index = 3;
            ActivateFeedback();
            nextButton2.SetActive(false);
            scoreBar.gameObject.GetComponent<ScoreSystem>().RemoveAGSEScore();
            question1 = false;
            question2 = true;
            question3 = false;
            StartCoroutine(Type());
        }
    }
    public void Next3()
    {
        if(q1Answered)
        {
            character.gameObject.GetComponent<CharacterAnims>().states = 2;//Thumbs up anim
            feedbackText.text = "";
            index = 4;
            ActivateFeedback();
            nextButton3.SetActive(false);
            finished = true;
            scoreBar.gameObject.GetComponent<ScoreSystem>().AddAGSEScore();
            question1 = false;
            question2 = false;
            question3 = true;
            StartCoroutine(Type());
        }
        else
        {
            character.gameObject.GetComponent<CharacterAnims>().states = 3;//Shake head anim
            feedbackText.text = "";
            index = 5;
            ActivateFeedback();
            nextButton3.SetActive(false);
            finished = true;
            scoreBar.gameObject.GetComponent<ScoreSystem>().RemoveAGSEScore();
            question1 = false;
            question2 = false;
            question3 = true;
            StartCoroutine(Type());
        }
    }

    //-------------------------QUESTIONS-----------------------------------

    public void Q1()
    {
        questions.SetActive(true);
        showTableButton.SetActive(true);
        showlinegraphButton.SetActive(false);

        //Question 1
        q.text = "Which of the following is the correct interpretation of the results?";
        subq.text = "";
        a1q1.text = "A two-way (2x2) ANOVA found a statistically significant interaction effect of Gender and Activity Level on Self-Esteem, F(1,66)=5.112, p=0.027. The main effect of Activity Level was also statistically significant, F(1,66)=13.022, p=0.001, and so was the main effect of Gender, F(1,66)=0.691, p=0.409.";
        a2q1.text = "A two-way (2x2) ANOVA found a statistically significant interaction effect of Gender and Activity Level on Self-Esteem, F(1,66)=5.112, p=0.027. The main effect of Activity Level was also statistically significant, F(1,66)=13.022, p=0.001. The main effect of Gender was not statistically significant, F(1,66)=0.691, p=0.409.";
    }

    public void Q2()
    {  
        questions.SetActive(true);
        showlinegraphButton.SetActive(false);
        showTableButton.SetActive(true);
      
        option1ButtonQ1_obj.SetActive(false);
        option2ButtonQ1_obj.SetActive(false);

        option1ButtonQ2_obj.SetActive(true);
        option2ButtonQ2_obj.SetActive(true);
        option3ButtonQ2_obj.SetActive(true);
        option4ButtonQ2_obj.SetActive(true);

        option1ButtonQ2.interactable = true;
        option2ButtonQ2.interactable = true;
        option3ButtonQ2.interactable = true;
        option4ButtonQ2.interactable = true;

        nextButton2.SetActive(true);
        continueButtonQ2.SetActive(true);
        feedback.SetActive(false);
        next2.interactable = false;

        //Question 2
        q.text = "Which, if any, null hypothesis can be rejected?";
        subq.text = "";
        a1q2.text = "     None of them";
        a2q2.text = "     The interaction null hypothesis, and the null hypothesis for gender";
        a3q2.text = "     The interaction null hypothesis, and the null hypothesis for activity level";
        a4q2.text = "     All three null hypotheses can be rejected";
    }

    public void Q3()
    {   
        questions.SetActive(true);
        showTableButton.SetActive(false);
        showlinegraphButton.SetActive(true);

        option1ButtonQ2_obj.SetActive(false);
        option2ButtonQ2_obj.SetActive(false);
        option3ButtonQ2_obj.SetActive(false);
        option4ButtonQ2_obj.SetActive(false);

        option1ButtonQ3_obj.SetActive(true);
        option2ButtonQ3_obj.SetActive(true);
      
        option1ButtonQ3.interactable = true;
        option2ButtonQ3.interactable = true;
        
        nextButton3.SetActive(true);
        feedback.SetActive(false);
        next3.interactable = false;

        //Question 3
        q.text = "Which of the following is the most appropriate explanation of the results?";
        subq.text = "";
        a1q3.text = "Being active appears to have a positive influence on self-esteem compared to being sedentary, although this effect is much more noticeable in males than females.";
        a2q3.text = "Being active appears to have a positive influence on self-esteem, compared to being sedentary, and this does not seem to differ by gender.";
    }
    //---------------------------------------------------------------------------------------

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

            q1Answered = true;
            q2Answered = false;
        }
        if (name == "Option2Q1")
        {
            option1ButtonQ1.interactable = true;
            option2ButtonQ1.interactable = false;

            q1Answered = false;
            q2Answered = true;
        }
        if (name == "Option1Q2")
        {
            option1ButtonQ2.interactable = false;
            option2ButtonQ2.interactable = true;
            option3ButtonQ2.interactable = true;
            option4ButtonQ2.interactable = true;

            q1Answered = true;
            q2Answered = false;
            q3Answered = false;
            q4Answered = false;
        }
        if (name == "Option2Q2")
        {
            option1ButtonQ2.interactable = true;
            option2ButtonQ2.interactable = false;
            option3ButtonQ2.interactable = true;
            option4ButtonQ2.interactable = true;

            q1Answered = false;
            q2Answered = true;
            q3Answered = false;
            q4Answered = false;
        }
        if (name == "Option3Q2")
        {
            option1ButtonQ2.interactable = true;
            option2ButtonQ2.interactable = true;
            option3ButtonQ2.interactable = false;
            option4ButtonQ2.interactable = true;

            q1Answered = false;
            q2Answered = false;
            q3Answered = true;
            q4Answered = false;
        }
        if (name == "Option4Q2")
        {
            option1ButtonQ2.interactable = true;
            option2ButtonQ2.interactable = true;
            option3ButtonQ2.interactable = true;
            option4ButtonQ2.interactable = false;

            q1Answered = false;
            q2Answered = false;
            q3Answered = false;
            q4Answered = true;
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
            ResetQ2();
        }

        if (name == "PassButton")
        {
            feedback.SetActive(true);
            Q3();
        }

        if (name == "ShowTableButton")
        {
            spss.SetActive(true);
        }

        if (name == "ShowLineGraphButton")
        {
            linegraph.SetActive(true);
        }

        if (name == "XButton")
        {
            spss.SetActive(false);
            linegraph.SetActive(false);
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