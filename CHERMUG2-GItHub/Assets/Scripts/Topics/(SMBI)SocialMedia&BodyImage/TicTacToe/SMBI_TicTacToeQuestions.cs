using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

//////////////////////////////////////////////////<summary>//////////////////////////////////////////////////// 
///                                   University of the West of Scotland                                    ///
///                               SMBI: HAKUNA MATATA! WHAT A WONDERFUL PHRASE!                             ///
///                                   SOCIAL MEDIA AND BODY IMAGE TOPIC                                     ///
///                               -------------------------------------------                               ///  
/// Script is attached to the Manager GameObject in the SMBI_QuestionsTTT scene.                            ///
///                                                                                                         ///
//////////////////////////////////////////////////</summary>///////////////////////////////////////////////////

public class SMBI_TicTacToeQuestions : MonoBehaviour
{
    public BarAnimations animScript;
    public GameObject scoreBar;
    public GameObject nameBar;

    public GameObject scenarioCloseButton;
    public GameObject scenarioViewButton;
    public GameObject scenarioButtonClickBlock;
    public GameObject scenarioObj;
    
    public GameObject showTableButton;
    public GameObject spss;

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

    public Button option1ButtonQ3;
    public Button option2ButtonQ3;

    public GameObject option1ButtonQ1_obj;
    public GameObject option2ButtonQ1_obj;

    public GameObject option1ButtonQ2_obj;
    public GameObject option2ButtonQ2_obj;

    public GameObject option1ButtonQ3_obj;
    public GameObject option2ButtonQ3_obj;

    private bool q1Answered;
    private bool q2Answered;
    private bool q3Answered;

    public GameObject character;
    public GameObject fadeScreen;

    public GameObject continueButtonQ2;
    public GameObject continueButtonQ3;
    public GameObject finish_ContinueButton;

    public GameObject nextButtonQ1;

    private bool finished;
    private bool question1, question2, question3;

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

        option1ButtonQ3 = GameObject.Find("Option1Q3").GetComponent<Button>();
        option2ButtonQ3 = GameObject.Find("Option2Q3").GetComponent<Button>();

        next = GameObject.Find("NextButton").GetComponent<Button>();
        next2 = GameObject.Find("NextButton2").GetComponent<Button>();
        next3 = GameObject.Find("NextButton3").GetComponent<Button>();
        nextButtonQ1 = GameObject.Find("NextButton");

        option1ButtonQ2.interactable = true;
        option2ButtonQ2.interactable = true;

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

        scenarioButtonClickBlock.gameObject.SetActive(false);

        option1ButtonQ1_obj.SetActive(true);
        option2ButtonQ1_obj.SetActive(true);

        option1ButtonQ2_obj.SetActive(false);
        option2ButtonQ2_obj.SetActive(false);

        option1ButtonQ3_obj.SetActive(false);
        option2ButtonQ3_obj.SetActive(false);

        showTableButton.SetActive(true);

        spss.SetActive(false);
    }

    public void ResetQ1()
    {
        feedback.SetActive(false);
        continueButtonQ2.SetActive(true);
        nextButtonQ1.SetActive(true);
        next.interactable = false;

        option1ButtonQ1_obj.SetActive(true);
        option2ButtonQ1_obj.SetActive(true);

        option1ButtonQ1.interactable = true;
        option2ButtonQ1.interactable = true;

        questions.SetActive(true);
        showTableButton.SetActive(true);
    }

    public void ResetQ3()
    {
        feedback.SetActive(false);

        questions.SetActive(true);
        
        showTableButton.SetActive(true);

        option1ButtonQ2_obj.SetActive(false);
        option2ButtonQ2_obj.SetActive(false);

        option1ButtonQ3_obj.SetActive(true);
        option2ButtonQ3_obj.SetActive(true);

        option1ButtonQ3.interactable = true;
        option2ButtonQ3.interactable = true;

        nextButton3.SetActive(true);
        next3.interactable = false;
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
            }
            if (feedbackText.text == sentences[2] || feedbackText.text == sentences[3])
            {
                continueButtonQ2.SetActive(false);
                continueButtonQ3.SetActive(true);
                finish_ContinueButton.SetActive(false);
            }
            if (feedbackText.text == sentences[4] || feedbackText.text == sentences[5])
            {
                continueButtonQ2.SetActive(false);
                continueButtonQ3.SetActive(false);
                finish_ContinueButton.SetActive(true);
            }
        }
    }

    public void SpeechBubbleText()
    {
        //Question 1
        sentences[0] = "Correct: There is a statistically significant difference between social media groups on body dissatisfaction, F(2)=7.433, p=0.001. A Tukey post hoc showed statistically significant differences between Facebook and Instagram (p=0.008), and Instagram and no social media (p=0.002), but not between Facebook and no social media (p=0.732).";
        sentences[1] = "Incorrect: A p-value of 0.001 is significant, and the post hoc test shows significant differences.";
        //Question 2
        sentences[2] = "Correct: You found a statistically significant result.";
        sentences[3] = "Incorrect: You found a statistically significant result.";
        //Question 3
        sentences[4] = "Correct: Body dissatisfaction is higher for users of Instagram than Facebook, with Facebook user body dissatisfaction almost the same as that of participants in the no popular social media category. Instagram might have a negative influence on body dissatisfaction, whereas Facebook does not seem to have a noticeable effect.";
        sentences[5] = "Incorrect: Body dissatisfaction is higher for users of Instagram than Facebook, with Facebook user body dissatisfaction almost the same as that of participants in the no popular social media category. Instagram might have a negative influence on body dissatisfaction, whereas Facebook does not seem to have a noticeable effect.";
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
        SceneManager.LoadScene("SMBI_EndSummary");
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
            scoreBar.gameObject.GetComponent<ScoreSystem>().AddSMBIScore();
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
            scoreBar.gameObject.GetComponent<ScoreSystem>().RemoveSMBIScore();
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
            index = 2;
            ActivateFeedback();
            nextButton2.SetActive(false);
            scoreBar.gameObject.GetComponent<ScoreSystem>().AddSMBIScore();
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
            scoreBar.gameObject.GetComponent<ScoreSystem>().RemoveSMBIScore();
            question1 = false;
            question2 = true;
            question3 = false;
            StartCoroutine(Type());
        }
    }
    public void Next3()
    {
        if (q2Answered)
        {
            character.gameObject.GetComponent<CharacterAnims>().states = 2;//Thumbs up anim
            continueButtonQ3.SetActive(true);
            feedbackText.text = "";
            index = 4;
            ActivateFeedback();
            nextButton3.SetActive(false);
            finished = true;
            scoreBar.gameObject.GetComponent<ScoreSystem>().AddSMBIScore();
            question1 = false;
            question2 = false;
            question3 = true;
            StartCoroutine(Type());
        }
        if (q1Answered)
        {
            character.gameObject.GetComponent<CharacterAnims>().states = 3;//Shake head anim
            continueButtonQ3.SetActive(true);
            feedbackText.text = "";
            index = 5;
            ActivateFeedback();
            nextButton3.SetActive(false);
            finished = true;
            scoreBar.gameObject.GetComponent<ScoreSystem>().RemoveSMBIScore();
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
        a1q1.text = "There is a statistically significant difference between social media groups on body dissatisfaction, F(2)=7.433, p=0.001. A Tukey post hoc showed statistically significant differences between Facebook and Instagram (p=0.008), and Instagram and no social media (p=0.002), but not between Facebook and no social media (p=0.732).";
        a2q1.text = "There is not a statistically significant difference between social media groups on body dissatisfaction, F(2)=7.433, p=0.001. A Tukey post hoc showed no difference between groups.";
    }

    public void Q2()
    {  
        questions.SetActive(true);
        showTableButton.SetActive(false);
      
        option1ButtonQ1_obj.SetActive(false);
        option2ButtonQ1_obj.SetActive(false);

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
        q.text = "Which of the following is the most suitable explanation of the results?";
        subq.text = "";
        a1q3.text = "Body dissatisfaction is clearly linked to social media use, as both social networks in this study show much higher dissatisfaction compared to not using popular social media.";
        a2q3.text = "Body dissatisfaction is higher for users of Instagram than Facebook, with Facebook user body dissatisfaction almost the same as that of participants in the no popular social media category. Instagram might have a negative influence on body dissatisfaction, whereas Facebook does not seem to have a noticeable effect.";
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

            q1Answered = true;
            q2Answered = false;
            q3Answered = false;
        }
        if (name == "Option2Q1")
        {
            option1ButtonQ1.interactable = true;
            option2ButtonQ1.interactable = false;

            q1Answered = false;
            q2Answered = true;
            q3Answered = false;
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
            q3Answered = false;
        }
        if (name == "Option2Q3")
        {
            option1ButtonQ3.interactable = true;
            option2ButtonQ3.interactable = false;

            q1Answered = false;
            q2Answered = true;
            q3Answered = false;
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
            spss.SetActive(true);
        }

        if (name == "XButton")
        {
            spss.SetActive(false);
        }
    }

    IEnumerator Type()
    {
        continueButtonQ2.SetActive(false);
        continueButtonQ3.SetActive(false);
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