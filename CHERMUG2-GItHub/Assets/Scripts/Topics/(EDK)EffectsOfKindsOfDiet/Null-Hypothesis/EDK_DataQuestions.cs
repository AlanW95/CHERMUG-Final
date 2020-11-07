using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

//////////////////////////////////////////////////<summary>//////////////////////////////////////////////////// 
///                                   University of the West of Scotland                                    ///
///                         EFFECTS OF DIFFERENT KINDS OF DIET ON WEIGHT LOSS TOPIC                         ///
///                               -------------------------------------------                               ///  
/// Script is attached to the Manager GameObject in the EDK_QuestionsData scene.                            ///
///                                                                                                         ///
//////////////////////////////////////////////////</summary>///////////////////////////////////////////////////

public class EDK_DataQuestions : MonoBehaviour
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
    public GameObject question3;
    public GameObject question4;
    public GameObject feedback;

    public Button q1a1;
    public Button q1a2;
    public Button q2a1;
    public Button q2a2;
    public Button q2a3;
    public Button q3a1;
    public Button q3a2;
    public Button q4a1;
    public Button q4a2;
    public Button q4a3;

    private GameObject q2Button;
    private GameObject q4Button;
    private GameObject dataset1Button;
    private GameObject dataset2Button;

    private GameObject boxplot1Button;
    private GameObject boxplot2Button;

    //Typing Text
    public Text feedbackText;
    public string[] sentences;
    private int index;
    public float typingSpeed;

    [SerializeField] private GameObject continueButton;

    private bool q1Completed;
    private bool q2Completed;
    private bool q3Completed;
    private bool q4Completed;
    private Button q2Continue;
    private Button q4Continue;
    private bool q1a1Answered; 
    private bool q1a2Answered;
    private bool q2a1Answered;
    private bool q2a2Answered;
    private bool q2a3Answered;
    private bool q3a1Answered;
    private bool q3a2Answered;
    private bool q4a1Answered;
    private bool q4a2Answered;
    private bool q4a3Answered;

    public GameObject character;
    public GameObject fadeScreen;

    [SerializeField] private GameObject retryButton;
    [SerializeField] private GameObject passButton;

    public GameObject showTable;
    public GameObject showTableButton;

    // Start is called before the first frame update
    void Start()
    {
        character.gameObject.GetComponent<CharacterAnims>().states = 0;
        nameBar.gameObject.GetComponent<BarAnimations>().states = 1;
        scoreBar.gameObject.GetComponent<BarAnimations>().states = 1;
        scenarioObj = GameObject.Find("ResearchScenario");
        nameBar = GameObject.Find("NameBar");
        scoreBar = GameObject.Find("ScoreBar");
        scenarioCloseButton = GameObject.Find("ScenarioButton_Close");
        scenarioViewButton = GameObject.Find("ScenarioButton_View");
        scenarioButtonClickBlock = GameObject.Find("ScenarioButtonClickBlock");
        feedback = GameObject.Find("Feedback");
        feedbackText = GameObject.Find("FeedbackText").GetComponent<Text>();
        continueButton = GameObject.Find("Continue_Button");
        q2Continue = GameObject.Find("Button_ContinueQ2").GetComponent<Button>();
        q2Button = GameObject.Find("Button_ContinueQ2");
        q4Continue = GameObject.Find("Button_ContinueQ4").GetComponent<Button>();
        q4Button = GameObject.Find("Button_ContinueQ4");
        dataset1Button = GameObject.Find("Q1A1");
        dataset2Button = GameObject.Find("Q1A2");
        boxplot1Button = GameObject.Find("Q3A1");
        boxplot2Button = GameObject.Find("Q3A2");

        retryButton = GameObject.Find("RetryButton");
        passButton = GameObject.Find("PassButton");

        q4Button.SetActive(false);
        q4Continue.interactable = false;
        q2Continue.interactable = false;
        question1.SetActive(true);
        question2.SetActive(false);
        question3.SetActive(false);
        question4.SetActive(false);
        feedback.SetActive(false);
        q1Completed = false;
        q2Completed = false;
        q3Completed = false;
        q4Completed = false;
        scenarioButtonClickBlock.gameObject.SetActive(false);

        showTable.SetActive(false);
        showTableButton.SetActive(false);
        SpeechBubbleText();
    }

    public void RetryQ4()
    {
        feedback.SetActive(false);
        question1.SetActive(false);
        question2.SetActive(false);
        question3.SetActive(false);
        question4.SetActive(true);
        q4Completed = false;

        q4Button.SetActive(true);
        q4Continue.interactable = false;

        q4a1.interactable = true;
        q4a2.interactable = true;
        q4a3.interactable = true;

        q4a1Answered = false;
        q4a2Answered = false;
        q4a3Answered = false;
    }

    public void SpeechBubbleText()
    {
        //Question 1
        sentences[0] = "Correct: This dataset shows that each participant only took part in one diet.";
        sentences[1] = "Incorrect: This data suggests participants took part in both diets.";
        //Question 2
        sentences[2] = "Correct: Histograms are useful here as they provide visual impressions of the distribution of data. Box plots are also useful.";
        sentences[3] = "Incorrect: Scatter diagrams show the relationship between two variables.";
        sentences[4] = "Correct: Box plots provide five number summaries of the data including the median; they display the spread and skew of the data and identify outliers. Histograms are also useful.";
        //Question 3
        sentences[5] = "Correct: This has negative values for low carb.";
        sentences[6] = "Incorrect: This doesn’t show any negative values.";
        //Question 4
        sentences[7] = "Correct: Independent samples t tests test for differences between two groups; the box plots suggest that the data are not skewed and have no outliers.";
        sentences[8] = "Incorrect: Would you like to try again?";
        sentences[9] = "Incorrect: Would you like to try again?";
    }

    // Update is called once per frame
    void Update()
    {
        //when typing text is typing, when the length is equal to the text the continue button will appear
        for (int i = 0; i < sentences.Length; i++)
        {
            if (feedbackText.text == sentences[0] || feedbackText.text == sentences[1] || feedbackText.text == sentences[2] || feedbackText.text == sentences[3] || 
                feedbackText.text == sentences[4] || feedbackText.text == sentences[5] || feedbackText.text == sentences[6] || feedbackText.text == sentences[7])
            {
                continueButton.SetActive(true);
                passButton.SetActive(false);
                retryButton.SetActive(false);
            }

            if (feedbackText.text == sentences[8])
            {
                continueButton.SetActive(false);
                passButton.SetActive(true);
                retryButton.SetActive(true);
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
        continueButton.SetActive(false);
        feedbackText.text = "";
        continueButton.SetActive(false);
        dataset1Button.SetActive(false);
        dataset2Button.SetActive(false);
        StartCoroutine(Type());
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

        if (name == "Q1A1")
        {
            character.gameObject.GetComponent<CharacterAnims>().states = 2;//Thumbs up anim
            index = 0;
            q1Completed = true;
            ActivateFeedback();
            scoreBar.gameObject.GetComponent<ScoreSystem>().AddEDKScore();
        }

        if (name == "Q1A2")
        {
            character.gameObject.GetComponent<CharacterAnims>().states = 3;//Shake head anim
            index = 1;
            q1Completed = true;
            ActivateFeedback();
            scoreBar.gameObject.GetComponent<ScoreSystem>().RemoveEDKScore();
        }

        if (name == "Q2A1")
        {
            q2a1.interactable = false;
            q2a2.interactable = true;
            q2a3.interactable = true;

            q1a1Answered = false;
            q1a2Answered = false;
            q2a1Answered = true;
            q2a2Answered = false;
            q2a3Answered = false;
            
            q2Continue.interactable = true;
        }

        if (name == "Q2A2")
        {
            q2a1.interactable = true;
            q2a2.interactable = false;
            q2a3.interactable = true;

            q1a1Answered = false;
            q1a2Answered = false;
            q2a1Answered = false;
            q2a2Answered = true;
            q2a3Answered = false;

            q2Continue.interactable = true;
        }

        if (name == "Q2A3")
        {
            q2a1.interactable = true;
            q2a2.interactable = true;
            q2a3.interactable = false;

            q1a1Answered = false;
            q1a2Answered = false;
            q2a1Answered = false;
            q2a2Answered = false;
            q2a3Answered = true;
            
            q2Continue.interactable = true;
        }
        if (name == "Q3A1")
        {
            character.gameObject.GetComponent<CharacterAnims>().states = 2;//Thumbs up anim
            index = 5;
            q3Completed = true;
            ActivateFeedback();
            scoreBar.gameObject.GetComponent<ScoreSystem>().AddEDKScore();
            boxplot1Button.SetActive(false);
            boxplot2Button.SetActive(false);
        }

        if (name == "Q3A2")
        {
            character.gameObject.GetComponent<CharacterAnims>().states = 3;//Shake head anim
            index = 6;
            q3Completed = true;
            ActivateFeedback();
            scoreBar.gameObject.GetComponent<ScoreSystem>().RemoveEDKScore();
            boxplot1Button.SetActive(false);
            boxplot2Button.SetActive(false);
        }
        if (name == "Q4A1")
        {
            q4a1.interactable = false;
            q4a2.interactable = true;
            q4a3.interactable = true;
            
            q4a1Answered = true;
            q4a2Answered = false;
            q4a3Answered = false;
            
            q4Continue.interactable = true;
        }

        if (name == "Q4A2")
        {
            q4a1.interactable = true;
            q4a2.interactable = false;
            q4a3.interactable = true;
            
            q4a1Answered = false;
            q4a2Answered = true;
            q4a3Answered = false;
            
            q4Continue.interactable = true;
        }

        if (name == "Q4A3")
        {
            q4a1.interactable = true;
            q4a2.interactable = true;
            q4a3.interactable = false;
            
            q4a1Answered = false;
            q4a2Answered = false;
            q4a3Answered = true;
            
            q4Continue.interactable = true;
        }
        if (name == "Button_ContinueQ2")
        {
            if (q2a1Answered)
            {
                character.gameObject.GetComponent<CharacterAnims>().states = 2;//Thumbs up anim
                index = 2;
                q2Completed = true;
                ActivateFeedback();
                q2Button.SetActive(false);
                scoreBar.gameObject.GetComponent<ScoreSystem>().AddEDKScore();
            }

            if (q2a2Answered)
            {
                character.gameObject.GetComponent<CharacterAnims>().states = 3;//Shake head anim
                index = 3;
                q2Completed = true;
                ActivateFeedback();
                q2Button.SetActive(false);
                scoreBar.gameObject.GetComponent<ScoreSystem>().RemoveEDKScore();
            }

            if (q2a3Answered)
            {
                character.gameObject.GetComponent<CharacterAnims>().states = 2;//Thumbs up anim
                index = 4;
                q2Completed = true;
                ActivateFeedback();
                q2Button.SetActive(false);
                scoreBar.gameObject.GetComponent<ScoreSystem>().AddEDKScore();
            }
        }
        if (name == "Button_ContinueQ4")
        {
            if (q4a1Answered)
            {
                character.gameObject.GetComponent<CharacterAnims>().states = 2;//Thumbs up anim
                index = 7;
                q4Completed = true;
                ActivateFeedback();
                q4Button.SetActive(false);
                scoreBar.gameObject.GetComponent<ScoreSystem>().AddEDKScore();
            }

            if (q4a2Answered)
            {
                character.gameObject.GetComponent<CharacterAnims>().states = 3;//Shake head anim
                index = 8;
                q4Completed = true;
                ActivateFeedback();
                q4Button.SetActive(false);
                scoreBar.gameObject.GetComponent<ScoreSystem>().RemoveEDKScore();
            }

            if (q4a3Answered)
            {
                character.gameObject.GetComponent<CharacterAnims>().states = 3;//Shake head anim
                index = 9;
                q4Completed = true;
                ActivateFeedback();
                q4Button.SetActive(false);
                scoreBar.gameObject.GetComponent<ScoreSystem>().RemoveEDKScore();
            }
        }

        if (name == "Continue_Button")
        {
            if (q1Completed)
            {
                feedback.SetActive(false);
                question1.SetActive(false);
                question2.SetActive(true);
            }
            if(q2Completed)
            {
                feedback.SetActive(false);
                question1.SetActive(false);
                question2.SetActive(false);
                question3.SetActive(true);
                showTable.SetActive(false);
                showTableButton.SetActive(true);
            }
            if (q3Completed)
            {
                feedback.SetActive(false);
                question1.SetActive(false);
                question2.SetActive(false);
                question3.SetActive(false);
                question4.SetActive(true);
                showTable.SetActive(false);
                showTableButton.SetActive(false);
                q4Button.SetActive(true);
                q4Continue.interactable = true;
            }
            if (q4Completed)
            {
                feedback.SetActive(false);
                question1.SetActive(false);
                question2.SetActive(false);
                question3.SetActive(false);
                question4.SetActive(true);
                q4Button.SetActive(false);
            }

            if (q1Completed && q2Completed && q3Completed && q4Completed)
            {
                feedback.SetActive(false);
                //transition to next scene
                fadeScreen.gameObject.GetComponent<FadeInTransition>().FadeImageIn();
            }
        }

        if (name == "RetryButton")
        {
            RetryQ4();
        }

        if (name == "PassButton")
        {
            feedback.SetActive(true);
            //transition to next scene
            fadeScreen.gameObject.GetComponent<FadeInTransition>().FadeImageIn();
        }
    }

    IEnumerator Type()
    {
        if (feedback.gameObject.activeInHierarchy == true)
        {
            continueButton.SetActive(false);
            retryButton.SetActive(false);
            passButton.SetActive(false);

            foreach (char letter in sentences[index].ToCharArray())
            {
                feedbackText.text += letter;
                yield return new WaitForSeconds(typingSpeed);
            }
        }
    }
}