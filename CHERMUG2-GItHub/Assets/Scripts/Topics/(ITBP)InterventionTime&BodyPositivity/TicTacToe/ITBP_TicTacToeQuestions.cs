using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

//////////////////////////////////////////////////<summary>//////////////////////////////////////////////////// 
///                                   University of the West of Scotland                                    ///
///                              INTERVENTION, TIME AND BODY POSITIVITY TOPIC                               ///
///                               -------------------------------------------                               ///  
/// Script is attached to the Manager GameObject in the ITBP_QuestionsTTT scene.                            ///
///                                                                                                         ///
//////////////////////////////////////////////////</summary>///////////////////////////////////////////////////

public class ITBP_TicTacToeQuestions : MonoBehaviour
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

        showTable.SetActive(false);

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
        sentences[0] = "Correct: A 2 x 2 mixed ANOVA found statistically significant main effects of Intervention Type (F(1,88)=1707.278, p=0.002) and Time Point (F(1,88)=21.004, p=0.000) on Body Positivity. A significant interaction was also found, F(1,88) = 8.043, p=0.006.";
        sentences[1] = "Incorrect: A 2 x 2 mixed ANOVA found statistically significant main effects of Intervention Type (F(1,88)=1707.278, p=0.002) and Time Point (F(1,88)=21.004, p=0.000) on Body Positivity. A significant interaction was also found, F(1,88) = 8.043, p=0.006.";
        //Question 2
        sentences[2] = "Correct: All three null hypotheses can be rejected.";
        sentences[3] = "Incorrect: Would you like to try again?";
        //Question 3
        sentences[4] = "Correct: The modern intervention appears to be more successful than the traditional intervention, as it leads to a larger increase in body positivity. This is a better intervention option for participants.";
        sentences[5] = "Incorrect: The modern intervention appears to be more successful than the traditional intervention, as it leads to a larger increase in body positivity. This is a better intervention option for participants.";
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
        SceneManager.LoadScene("ITBP_EndSummary");
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
        if(q1Answered)
        {
            character.gameObject.GetComponent<CharacterAnims>().states = 2;//Thumbs up anim
            continueButtonQ2.SetActive(true);
            feedbackText.text = "";
            index = 0;
            ActivateFeedback();
            nextButton.SetActive(false);
            scoreBar.gameObject.GetComponent<ScoreSystem>().AddITBPScore();
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
            scoreBar.gameObject.GetComponent<ScoreSystem>().RemoveITBPScore();
            question1 = true;
            question2 = false;
            question3 = false;
            StartCoroutine(Type());
        }
    }
    public void Next2()
    {
        if(q4Answered)
        {
            character.gameObject.GetComponent<CharacterAnims>().states = 2;//Thumbs up anim
            continueButtonQ3.SetActive(true);
            feedbackText.text = "";
            index = 2;
            ActivateFeedback();
            nextButton2.SetActive(false);
            scoreBar.gameObject.GetComponent<ScoreSystem>().AddITBPScore();
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
            scoreBar.gameObject.GetComponent<ScoreSystem>().RemoveITBPScore();
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
            index = 4;
            ActivateFeedback();
            nextButton3.SetActive(false);
            finished = true;
            scoreBar.gameObject.GetComponent<ScoreSystem>().AddITBPScore();
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
            scoreBar.gameObject.GetComponent<ScoreSystem>().RemoveITBPScore();
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
        a1q1.text = "A 2 x 2 mixed ANOVA found statistically significant main effects of Intervention Type (F(1,88)=1707.278, p=0.002) and Time Point (F(1,88)=21.004, p=0.000) on Body Positivity. A significant interaction was also found, F(1,88) = 8.043, p=0.006.";
        a2q1.text = "A 2 x 2 mixed ANOVA found statistically significant main effects of Intervention Type (F(1,88)=1707.278, p=0.002) and Time Point (F(1,88)=21.004, p=0.000) on Body Positivity. The interaction was not statistically significant, F(1,88) = 8.043, p=0.06.";
    }

    public void Q2()
    {  
        questions.SetActive(true);
        showTableButton.SetActive(false);
      
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
        a2q2.text = "     Only the interaction null hypothesis";
        a3q2.text = "     Only the two main effects null hypotheses";
        a4q2.text = "     All three null hypotheses can be rejected";
    }

    public void Q3()
    {   
        questions.SetActive(true);
        showTableButton.SetActive(true);

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
        a1q3.text = "As both interventions lead to an increase in mean body positivity, they are both equally useful interventions that should be used to help participants in the future.";
        a2q3.text = "The modern intervention appears to be more successful than the traditional intervention, as it leads to a larger increase in body positivity. This is a better intervention option for participants.";
    }
    //----------------------------------------------------------------

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