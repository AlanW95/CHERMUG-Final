using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

//////////////////////////////////////////////////<summary>//////////////////////////////////////////////////// 
///                                   University of the West of Scotland                                    ///
///                                          SEX AND REWARD TOPIC                                           ///
///                               -------------------------------------------                               ///  
/// Script is attached to the Manager GameObject in the GR_MultipleChoice scene.                            ///
///                                                                                                         ///
//////////////////////////////////////////////////</summary>///////////////////////////////////////////////////

public class GR_MultipleChoice : MonoBehaviour
{
    public GameObject scoreBar;
    public GameObject nameBar;
    public GameObject scenarioObj;
    public GameObject scenarioCloseButton;
    public GameObject scenarioViewButton;
    public GameObject scenarioReadyButton;
    public GameObject scenarioButtonClickBlock;
    public GameObject questionObj;

    [SerializeField] private GameObject feedback;
    [SerializeField] private GameObject nextButton;
    [SerializeField] private GameObject nextButton2;
    [SerializeField] private GameObject nextButton3;

    private Button next;
    private Button next2;
    private Button next3;
    
    public Text q;
    public Text subq;
    public Text a1;
    public Text a2;
    public Text a3;
    public Text a4;
    public Text a5;
    public Text a6;
    public Text a7;
    public Text a8;

    public Toggle[] toggles;

    //Typing Text
    [SerializeField] private Text feedbackText;
    public string[] sentences;
    private int index;
    public float typingSpeed;
    [SerializeField] private GameObject continueButton;

    private bool q1Completed;
    private bool q2Completed;
    private bool q3Completed;

    public GameObject character;
    public GameObject fadeScreen;

    public AudioSource audioManager;

    public bool a1Correct;
    public bool a2Correct;
    public bool a3Correct;

    private string option1a, option1b, option2, option3;

    public GameObject retryButton;
    public GameObject passButton;

    // Start is called before the first frame update
    void Start()
    {
        character.gameObject.GetComponent<CharacterAnims>().states = 0;
        scenarioObj = GameObject.Find("ResearchScenario");
        scenarioObj.gameObject.GetComponent<ScenarioAnimations>().states = 1;
        nameBar = GameObject.Find("NameBar");
        scoreBar = GameObject.Find("ScoreBar");
        scenarioReadyButton = GameObject.Find("ScenarioButton_Ready");
        scenarioCloseButton = GameObject.Find("ScenarioButton_Close");
        scenarioViewButton = GameObject.Find("ScenarioButton_View");
        scenarioButtonClickBlock = GameObject.Find("GR_ButtonClickBlock");
        questionObj = GameObject.Find("QuestionBG");
        feedback = GameObject.Find("Feedback");
        feedbackText = GameObject.Find("FeedbackText").GetComponent<Text>();
        nextButton = GameObject.Find("NextButton");
        nextButton2 = GameObject.Find("NextButton2");
        nextButton3 = GameObject.Find("NextButton3");
        next = GameObject.Find("NextButton").GetComponent<Button>();
        next2 = GameObject.Find("NextButton2").GetComponent<Button>();
        next3 = GameObject.Find("NextButton3").GetComponent<Button>();
        continueButton = GameObject.Find("Continue_Button");
        toggles[0] = GameObject.Find("Option1").GetComponent<Toggle>();
        toggles[1] = GameObject.Find("Option2").GetComponent<Toggle>();
        toggles[2] = GameObject.Find("Option3").GetComponent<Toggle>();
        toggles[3] = GameObject.Find("Option4").GetComponent<Toggle>();
        toggles[4] = GameObject.Find("Option5").GetComponent<Toggle>();
        toggles[5] = GameObject.Find("Option6").GetComponent<Toggle>();
        toggles[6] = GameObject.Find("Option7").GetComponent<Toggle>();
        toggles[7] = GameObject.Find("Option8").GetComponent<Toggle>();

        retryButton = GameObject.Find("RetryButton");
        passButton = GameObject.Find("PassButton");

        ResetQuestion();
    }

    public void ResetQuestion()
    {
        scenarioButtonClickBlock.SetActive(false);
        feedback.SetActive(false);
        scenarioCloseButton.gameObject.SetActive(false);
        scenarioViewButton.gameObject.SetActive(false);
        questionObj.gameObject.SetActive(false);
        q1Completed = false;
        q2Completed = false;
        q3Completed = false;
        SpeechBubbleText();
        nextButton.SetActive(true);
        next.interactable = false;
        DefaultButtons();
    }

    public void ProgressToNextScene()
    {
        SceneManager.LoadScene("GR_QuestionsHM");
    }

    public void SpeechBubbleText()
    {
        sentences[0] = "Correct: The variables are \"Sex\" and \"Reward selected\".";
        sentences[1] = "Incorrect: Would you like to try again?";
    }

    // Update is called once per frame
    void Update()
    {
        //when typing text is typing, when the length is equal to the text the continue button will appear
        for (int i = 0; i < sentences.Length; i++)
        {
            continueButton.SetActive(false);
            retryButton.SetActive(false);
            passButton.SetActive(false);

            if (feedbackText.text == sentences[0])
            {
                continueButton.SetActive(true);
                retryButton.SetActive(false);
                passButton.SetActive(false);
            }
            if (feedbackText.text == sentences[1])
            {
                continueButton.SetActive(false);
                retryButton.SetActive(true);
                passButton.SetActive(true);
            }
        }
    }

    public void ReadyToPlay()
    {
        scenarioObj.gameObject.GetComponent<ScenarioAnimations>().states = 2;
        nameBar.gameObject.GetComponent<BarAnimations>().states = 1;
        scoreBar.gameObject.GetComponent<BarAnimations>().states = 1;
        questionObj.gameObject.SetActive(true);
        scenarioViewButton.gameObject.SetActive(true);
        scenarioCloseButton.gameObject.SetActive(false);
        scenarioReadyButton.gameObject.SetActive(false);
        scenarioButtonClickBlock.SetActive(false);
        feedback.SetActive(false);
        nextButton2.SetActive(false);
        nextButton3.SetActive(false);
        next.interactable = false;
    }

    public void ViewStudy()
    {
        scenarioObj.gameObject.GetComponent<ScenarioAnimations>().states = 1;
        questionObj.gameObject.SetActive(false);
        scenarioCloseButton.gameObject.SetActive(true);
        scenarioViewButton.gameObject.SetActive(false);
        scenarioButtonClickBlock.SetActive(true);
    }

    public void CloseStudy()
    {
        questionObj.gameObject.SetActive(true);
        scenarioObj.gameObject.GetComponent<ScenarioAnimations>().states = 2;
        scenarioViewButton.gameObject.SetActive(true);
        scenarioCloseButton.gameObject.SetActive(false);
        scenarioReadyButton.gameObject.SetActive(false);
        scenarioButtonClickBlock.SetActive(false);
    }

    public void ButtonPress()
    {
        string name = EventSystem.current.currentSelectedGameObject.name;

        if (name == "RetryButton")
        {
            ResetQuestion();
            ReadyToPlay();
        }

        if (name == "PassButton")
        {
            SceneManager.LoadScene("GR_QuestionsHM");
        }
        
        if (name == "ScenarioButton_Ready")
        {
            //Question 1
            q.text = "In this <b>study</b> what are the variables?";
            subq.text = "Select from the answers below, remember there may be more than one answer." +
                " Click <b>submit answer</b> when you have made your choice.";
            a1.text = "     Kind of diet";
            a2.text = "     Weight loss";
            a3.text = "     Sex";
            a4.text = "     Male";
            a5.text = "     Female";
            a6.text = "     Reward selected";
            a7.text = "     Chocolate";
            a8.text = "     Crisps";

            scoreBar.gameObject.GetComponent<ScoreSystem>().SetGRScore();
        }
        
        if (name == "Continue_Button")
        {
            if (q1Completed)
            {
                nextButton.SetActive(false);
                nextButton2.SetActive(false);
                nextButton3.SetActive(false);
                feedback.SetActive(false);
                
                ProgressToNextScene();
            }
        }
        //-------------------------------------------------------------------------------------------------------------------------------------------------
        
        //Next Button 1
        if (name == "NextButton")
        {
            if (toggles[0].isOn == false && toggles[1].isOn == false && toggles[2].isOn == true && toggles[3].isOn == false && toggles[4].isOn == false &&
                toggles[5].isOn == true && toggles[6].isOn == false && toggles[7].isOn == false)
            {
                //positive
                character.gameObject.GetComponent<CharacterAnims>().states = 2;//Thumbs up anim
                nextButton.SetActive(false);
                index = 0;
                ActivateFeedback();
                q1Completed = true;
                a1Correct = true;
                continueButton.SetActive(true);
                retryButton.SetActive(false);
                passButton.SetActive(false);
                scoreBar.gameObject.GetComponent<ScoreSystem>().AddGRScore();
            }
            else
            {
                //negative
                character.gameObject.GetComponent<CharacterAnims>().states = 3;//Shake head anim
                nextButton.SetActive(false);
                index = 1;
                ActivateFeedback();
                q1Completed = true;
                continueButton.SetActive(false);
                retryButton.SetActive(true);
                passButton.SetActive(true);
                scoreBar.gameObject.GetComponent<ScoreSystem>().RemoveGRScore();
            }
        }
    }

    public void ActivateFeedback()
    {
        feedback.SetActive(true);
        feedbackText.text = "";
        continueButton.SetActive(false);
        StartCoroutine(Type());
    }

    //Toggle Script used for each answer
    public void ToggleButton()
    {
        for (int t = 0; t < toggles.Length; t++)
        {
            if (toggles[t].isOn)
            {
                ColorBlock b1Color = toggles[t].colors;
                b1Color.normalColor = new Color32(149, 195, 212, 200); //green
                b1Color.highlightedColor = new Color32(210, 210, 210, 250);
                b1Color.selectedColor = new Color32(149, 195, 212, 200);
                toggles[t].colors = b1Color;
                next.interactable = true;
                next2.interactable = true;
                next3.interactable = true;
            }

            if (!toggles[t].isOn)
            {
                ColorBlock b1Color = toggles[t].colors;
                b1Color.normalColor = Color.white;
                b1Color.highlightedColor = new Color32(210, 210, 210, 250);
                b1Color.selectedColor = Color.white;
                toggles[t].colors = b1Color;
            }
        }
    }
    //Used to reset buttons after each question
    public void DefaultButtons()
    {

        for (int t = 0; t < toggles.Length; t++)
        {
            toggles[t].isOn = false;
            next2.interactable = false;
            next3.interactable = false;
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