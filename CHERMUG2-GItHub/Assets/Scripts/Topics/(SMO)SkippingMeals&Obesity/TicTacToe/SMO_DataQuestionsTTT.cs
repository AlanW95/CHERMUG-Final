using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

//////////////////////////////////////////////////<summary>//////////////////////////////////////////////////// 
///                                   University of the West of Scotland                                    ///
///                                    SKIPPING MEALS AND OBESITY TOPIC                                     ///
///                               -------------------------------------------                               ///  
/// Script is attached to the Manager GameObject in the SMO_AorB scene.                                     ///
///                                                                                                         ///
//////////////////////////////////////////////////</summary>///////////////////////////////////////////////////

public class SMO_DataQuestionsTTT : MonoBehaviour
{
    public BarAnimations animScript;
    public GameObject scoreBar;
    public GameObject nameBar;

    public GameObject scenarioObj;
    public GameObject scenarioCloseButton;
    public GameObject scenarioViewButton;
    public GameObject scenarioButtonClickBlock;

    public GameObject question1;
    public GameObject question2;
    public GameObject feedback;

    public Button q1a1;
    public Button q1a2;

    public Button q2a1;
    public Button q2a2;
    
    private GameObject q2Button;
    private GameObject dataset1Button_q1;
    private GameObject dataset2Button_q1;

    private GameObject q3Button;
    private GameObject dataset1Button_q2;
    private GameObject dataset2Button_q2;
    
    private GameObject submit_button;

    //Typing Text
    public Text feedbackText;
    public string[] sentences;
    private int index;
    public float typingSpeed;

    [SerializeField] private GameObject continueButton;

    private bool q1Completed;
    private bool q2Completed;

    private Button q2Continue;

    private bool q1a1Answered; 
    private bool q1a2Answered;

    private bool q2a1Answered;
    private bool q2a2Answered;

    public GameObject character;
    public GameObject fadeScreen;

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
        feedback = GameObject.Find("Feedback");
        feedbackText = GameObject.Find("FeedbackText").GetComponent<Text>();
        continueButton = GameObject.Find("Continue_Button");
        dataset1Button_q1 = GameObject.Find("Q1A1");
        dataset2Button_q1 = GameObject.Find("Q1A2");
        dataset1Button_q2 = GameObject.Find("Q2A1");
        dataset2Button_q2 = GameObject.Find("Q2A2");

        submit_button = GameObject.Find("Submit_Button");

        question1.SetActive(true);
        question2.SetActive(false);

        feedback.SetActive(false);

        q1Completed = false;
        q2Completed = false;

        scenarioButtonClickBlock.gameObject.SetActive(false);

        SpeechBubbleText();
    }

    public void SpeechBubbleText()
    {   //QUESTION 1 FEEDBACK
        sentences[0] = "Incorrect: This table does not show the expected frequencies.";
        sentences[1] = "Correct: This table shows the expected frequencies.";
        //QUESTION 2 FEEDBACK
        sentences[2] = "Correct: This table shows the observed frequencies.";
        sentences[3] = "Incorrect: This table does not show the observed frequencies.";
    }
    
    // Update is called once per frame
    void Update()
    {
        //when typing text is typing, when the length is equal to the text the continue button will appear
        for (int i = 0; i < sentences.Length; i++)
        {
            if (feedbackText.text == sentences[i])
            {
                continueButton.SetActive(true);
            }
        }
    }
    
    public void ViewStudy()
    {
        scenarioObj.gameObject.GetComponent<ScenarioAnimations>().states = 1;
        scenarioCloseButton.gameObject.SetActive(true);
        scenarioViewButton.gameObject.SetActive(false);
        scenarioButtonClickBlock.gameObject.SetActive(true);
    }
    
    public void CloseStudy()
    {
        scenarioObj.gameObject.GetComponent<ScenarioAnimations>().states = 2;
        scenarioViewButton.gameObject.SetActive(true);
        scenarioCloseButton.gameObject.SetActive(false);
        scenarioButtonClickBlock.gameObject.SetActive(false);
    }

    public void ActivateFeedback()
    {
        feedback.SetActive(true);
        feedbackText.text = "";
        continueButton.SetActive(false);
        dataset1Button_q1.SetActive(false);
        dataset2Button_q1.SetActive(false);
        dataset1Button_q2.SetActive(false);
        dataset2Button_q2.SetActive(false);

        StartCoroutine(Type());
    }

    public void ButtonPress()
    {
        string name = EventSystem.current.currentSelectedGameObject.name;

        if (name == "Q1A1")
        {
            character.gameObject.GetComponent<CharacterAnims>().states = 3;//Shake head anim
            index = 0;
            q1Completed = true;
            ActivateFeedback();
            scoreBar.gameObject.GetComponent<ScoreSystem>().RemoveSMOScore();
        }

        if (name == "Q1A2")
        {
            character.gameObject.GetComponent<CharacterAnims>().states = 2;//Thumbs up anim
            index = 1;
            q1Completed = true;
            ActivateFeedback();
            scoreBar.gameObject.GetComponent<ScoreSystem>().AddSMOScore();
        }

        if (name == "Q2A1")
        {
            character.gameObject.GetComponent<CharacterAnims>().states = 2;//Thumbs up anim
            index = 2;
            q2Completed = true;
            ActivateFeedback();
            question1.SetActive(false);
            scoreBar.gameObject.GetComponent<ScoreSystem>().AddSMOScore();
        }

        if (name == "Q2A2")
        {
            character.gameObject.GetComponent<CharacterAnims>().states = 3;//Shake head anim
            index = 3;
            q2Completed = true;
            ActivateFeedback();
            question1.SetActive(false);
            scoreBar.gameObject.GetComponent<ScoreSystem>().RemoveSMOScore();
        }
        
        if (name == "Submit_Button")
        {
            q2Completed = true;
            submit_button.SetActive(false);
            ActivateFeedback();

            //Checks if the correct answer was selected
            if (index == 2)
            {
                character.gameObject.GetComponent<CharacterAnims>().states = 2;//Thumbs up anim
                scoreBar.gameObject.GetComponent<ScoreSystem>().AddSMOScore();
            }
            if(index == 3 || index == 8)
            {
                character.gameObject.GetComponent<CharacterAnims>().states = 3;//Shake head anim
                scoreBar.gameObject.GetComponent<ScoreSystem>().RemoveSMOScore();
            }
        }

        if (name == "Continue_Button")
        {
            if (q1Completed)
            {
                feedback.SetActive(false);
                question1.SetActive(false);
                question2.SetActive(true);

                dataset1Button_q2.SetActive(true);
                dataset2Button_q2.SetActive(true);
            }
            if (q2Completed)
            {
                dataset1Button_q2.SetActive(false);
                dataset2Button_q2.SetActive(false);
                fadeScreen.gameObject.GetComponent<FadeInTransition>().FadeImageIn();
            }
        }
    }

    IEnumerator Type()
    {
        if (feedback.gameObject.activeInHierarchy == true)
        {
            foreach (char letter in sentences[index].ToCharArray())
            {
                feedbackText.text += letter;
                yield return new WaitForSeconds(typingSpeed);
            }
        }
    }
}