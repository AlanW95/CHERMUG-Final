using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

//////////////////////////////////////////////////<summary>//////////////////////////////////////////////////// 
///                                   University of the West of Scotland                                    ///
///                          EFFECTS OF AMOUNT OF EXERCISE ON SLEEP QUALITY TOPIC                           ///
///                               -------------------------------------------                               ///  
/// Script is attached to the Manager GameObject in the ESQ_MultipleChoice scene.                           ///
///                                                                                                         ///
//////////////////////////////////////////////////</summary>///////////////////////////////////////////////////

public class ESQ_MultipleChoice : MonoBehaviour
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

    private Button next;
    private Button next2;
    
    public Text q;
    public Text subq;
    public Text a1;
    public Text a2;
    public Text a3;
    public Text a4;
    public Text a5;
    public Text a6;

    public Toggle[] toggles;
    private bool q1Answered, q2Answered;

    //Typing Text
    [SerializeField] private Text feedbackText;
    public string[] sentences;
    private int index;
    public float typingSpeed;
    [SerializeField] private GameObject continueButton;

    private bool q1Completed;
    private bool q2Completed;

    public GameObject character;

    public AudioSource audioManager;

    public bool a1Correct;
    public bool a2Correct;

    private string option1a, option1b, option2, option3, option4;

    public GameObject RetryButton;
    public GameObject PassButton;

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
        scenarioButtonClickBlock = GameObject.Find("ScenarioButtonClickBlock");
        questionObj = GameObject.Find("QuestionBG");
        feedback = GameObject.Find("Feedback");
        feedbackText = GameObject.Find("FeedbackText").GetComponent<Text>();
        nextButton = GameObject.Find("NextButton");
        nextButton2 = GameObject.Find("NextButton2");
        next = GameObject.Find("NextButton").GetComponent<Button>();
        next2 = GameObject.Find("NextButton2").GetComponent<Button>();
        continueButton = GameObject.Find("Continue_Button");
        toggles[0] = GameObject.Find("Option1").GetComponent<Toggle>();
        toggles[1] = GameObject.Find("Option2").GetComponent<Toggle>();
        toggles[2] = GameObject.Find("Option3").GetComponent<Toggle>();
        toggles[3] = GameObject.Find("Option4").GetComponent<Toggle>();
        toggles[4] = GameObject.Find("Option5").GetComponent<Toggle>();
        toggles[5] = GameObject.Find("Option6").GetComponent<Toggle>();

        RetryButton = GameObject.Find("RetryButton");
        PassButton = GameObject.Find("PassButton");

        scenarioReadyButton.gameObject.SetActive(true);
        scenarioViewButton.gameObject.SetActive(false);
        scenarioCloseButton.gameObject.SetActive(false);
        scenarioButtonClickBlock.gameObject.SetActive(true);

        questionObj.gameObject.SetActive(false);

        ResetQ1();
    }
    
    public void ResetQ1()
    {
        SpeechBubbleText();

        feedback.SetActive(false);
        q1Completed = false;
        q2Completed = false;

        nextButton.SetActive(true);
        nextButton2.SetActive(false);
        next.interactable = false;

        RetryButton.SetActive(false);
        PassButton.SetActive(false);

        DefaultButtons();

        q.text = "In this <b>study</b> what are the variables?";
        subq.text = "Select from the answers below, remember there may be more than one answer." +
            " Click <b>submit answer</b> when you have made your choice.";
        a1.text = "Amount of exercise per week";
        a2.text = "Low exercise";
        a3.text = "Medium exercise";
        a4.text = "High exercise";
        a5.text = "Weight";
        a6.text = "Sleep quality";
    }

    public void ResetQ2()
    {
        SpeechBubbleText();

        feedback.SetActive(false);
        questionObj.gameObject.SetActive(true);
        q2Completed = false;

        nextButton.SetActive(true);
        nextButton2.SetActive(true);

        next.interactable = false;

        RetryButton.SetActive(false);
        PassButton.SetActive(false);

        DefaultButtons();

        //Question 2
        q.text = "In the <b>study</b> what is the independent variable?";
        subq.text = "Select from the answers below.\n" +
            "Click <b>submit answer</b> when you have made your choice.";
        a1.text = "Amount of exercise per week";
        a2.text = "Low exercise";
        a3.text = "Medium exercise";
        a4.text = "High exercise";
        a5.text = "Weight";
        a6.text = "Sleep quality";
    }

    public void SpeechBubbleText()
    {
        sentences[0] = "Correct: \"Amount of exercise per week\" and \"Sleep quality\" are the correct variables.";
        sentences[1] = "Incorrect: Would you like to try again?";
        sentences[2] = "Correct: \"Amount of exercise per week\" is the independent variable (IV).";
        sentences[3] = "Incorrect: Would you like to try again?";
    }

    // Update is called once per frame
    void Update()
    {
        //when typing text is typing, when the length is equal to the text the continue button will appear
        for (int i = 0; i < sentences.Length; i++)
        {
            if (feedbackText.text == sentences[0] || feedbackText.text == sentences[2])
            {
                RetryButton.SetActive(false);
                PassButton.SetActive(false);

                continueButton.SetActive(true);
            }

            if (feedbackText.text == sentences[1] || feedbackText.text == sentences[3])
            {
                RetryButton.SetActive(true);
                PassButton.SetActive(true);

                continueButton.SetActive(false);
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
        scenarioButtonClickBlock.gameObject.SetActive(false);
        feedback.SetActive(false);
        nextButton2.SetActive(false);
        next.interactable = false;
    }

    public void ViewStudy()
    {
        scenarioObj.gameObject.GetComponent<ScenarioAnimations>().states = 1;
        questionObj.gameObject.SetActive(false);
        scenarioCloseButton.gameObject.SetActive(true);
        scenarioViewButton.gameObject.SetActive(false);
        scenarioButtonClickBlock.gameObject.SetActive(true);
    }

    public void CloseStudy()
    {
        questionObj.gameObject.SetActive(true);
        scenarioObj.gameObject.GetComponent<ScenarioAnimations>().states = 2;
        scenarioViewButton.gameObject.SetActive(true);
        scenarioCloseButton.gameObject.SetActive(false);
        scenarioReadyButton.gameObject.SetActive(false);
        scenarioButtonClickBlock.gameObject.SetActive(false);
    }

    public void ButtonPress()
    {
        string name = EventSystem.current.currentSelectedGameObject.name;

        if(name == "RetryButton")
        {
            if (index == 1)
            {
                ResetQ1();
            }
            if (index == 3)
            {
                ResetQ2();
            }
        }
        if (name == "PassButton")
        {
            if (q1Completed)
            {
                DefaultButtons();
                nextButton2.SetActive(true);
                feedback.SetActive(false);

                //Question 2
                q.text = "In the same <b>study</b> what is the independent variable?";
                subq.text = "Select from the answers below.\n" +
                    "Click <b>submit answer</b> when you have made your choice.";
                a1.text = "Amount of exercise per week";
                a2.text = "Low exercise";
                a3.text = "Medium exercise";
                a4.text = "High exercise";
                a5.text = "Weight";
                a6.text = "Sleep quality";
            }
         
            if (q1Completed && q2Completed)
            {
                feedback.SetActive(true);
                nextButton.SetActive(false);
                nextButton2.SetActive(false);

                SceneManager.LoadScene("ESQ_Hangman");
            }
        }

        if (name == "ScenarioButton_Ready")
        {
            //Question 1
            q.text = "In this <b>study</b> what are the variables?";
            subq.text = "Select from the answers below, remember there may be more than one answer." +
                " Click <b>submit answer</b> when you have made your choice.";
            a1.text = "Amount of exercise per week";
            a2.text = "Low exercise";
            a3.text = "Medium exercise";
            a4.text = "High exercise";
            a5.text = "Weight";
            a6.text = "Sleep quality";

            scoreBar.gameObject.GetComponent<ScoreSystem>().SetESQScore();
        }
        
        if (name == "Continue_Button")
        {
            if (q1Completed)
            {
                DefaultButtons();
                nextButton2.SetActive(true);
                feedback.SetActive(false);

                //Question 2
                q.text = "In the <b>study</b> what is the independent variable?";
                subq.text = "Select from the answers below.\n" +
                    "Click <b>submit answer</b> when you have made your choice.";
                a1.text = "Amount of exercise per week";
                a2.text = "Low exercise";
                a3.text = "Medium exercise";
                a4.text = "High exercise";
                a5.text = "Weight";
                a6.text = "Sleep quality";
            }

            if (q1Completed && q2Completed)
            {
                feedback.SetActive(true);
                nextButton.SetActive(false);
                nextButton2.SetActive(false);

                SceneManager.LoadScene("ESQ_Hangman");
            }
        }
        //-------------------------------------------------------------------------------------------------------------------------
        //Next Button 1
        if (name == "NextButton")
        {
            if (toggles[0].isOn == true && toggles[5].isOn == true && toggles[1].isOn == false && toggles[2].isOn == false && toggles[3].isOn == false && toggles[4].isOn == false)
            {
                //positive
                character.gameObject.GetComponent<CharacterAnims>().states = 2;//Thumbs up anim
                nextButton.SetActive(false);
                index = 0;
                ActivateFeedback();
                q1Completed = true;
                a1Correct = true;
                scoreBar.gameObject.GetComponent<ScoreSystem>().AddESQScore();
            }
            else
            {
                //negative
                character.gameObject.GetComponent<CharacterAnims>().states = 3;//Shake head anim
                nextButton.SetActive(false);
                index = 1;
                ActivateFeedback();
                q1Completed = true;
                scoreBar.gameObject.GetComponent<ScoreSystem>().RemoveESQScore();
            }
        }
        //Next Button 2
        if (name == "NextButton2")
        {
            if (toggles[0].isOn == true && toggles[1].isOn == false && toggles[2].isOn == false && toggles[3].isOn == false && toggles[4].isOn == false && toggles[5].isOn == false)
            {
                character.gameObject.GetComponent<CharacterAnims>().states = 2;//Thumbs up anim
                nextButton2.SetActive(false);
                index = 2;
                ActivateFeedback();
                a2Correct = true;
                q2Completed = true;
                scoreBar.gameObject.GetComponent<ScoreSystem>().AddESQScore();
            }
            else
            {
                character.gameObject.GetComponent<CharacterAnims>().states = 3;//Shake head anim
                nextButton2.SetActive(false);
                index = 3;
                ActivateFeedback();
                q2Completed = true;
                scoreBar.gameObject.GetComponent<ScoreSystem>().RemoveESQScore();
            }
        }
        //---------------------------------------------------------------------------------------------------------------------------------

        if (q1Completed)
        {
            if (name == "Option1")
            {
            toggles[0].isOn = true;
            toggles[1].isOn = false;
            toggles[2].isOn = false;
            toggles[3].isOn = false;
            toggles[4].isOn = false;
            toggles[5].isOn = false;
            }
            if (name == "Option2")
            {
            toggles[0].isOn = false;
            toggles[1].isOn = true;
            toggles[2].isOn = false;
            toggles[3].isOn = false;
            toggles[4].isOn = false;
            toggles[5].isOn = false;
            }
            if (name == "Option3")
            {
            toggles[0].isOn = false;
            toggles[1].isOn = false;
            toggles[2].isOn = true;
            toggles[3].isOn = false;
            toggles[4].isOn = false;
            toggles[5].isOn = false;
            }
            if (name == "Option4")
            {
            toggles[0].isOn = false;
            toggles[1].isOn = false;
            toggles[2].isOn = false;
            toggles[3].isOn = true;
            toggles[4].isOn = false;
            toggles[5].isOn = false;
            }
            if (name == "Option5")
            {
            toggles[0].isOn = false;
            toggles[1].isOn = false;
            toggles[2].isOn = false;
            toggles[3].isOn = false;
            toggles[4].isOn = true;
            toggles[5].isOn = false;
            }
            if (name == "Option6")
            {
            toggles[0].isOn = false;
            toggles[1].isOn = false;
            toggles[2].isOn = false;
            toggles[3].isOn = false;
            toggles[4].isOn = false;
            toggles[5].isOn = true;
            }
        }
    }

    public void ActivateFeedback()
    {
        feedback.SetActive(true);
        feedbackText.text = "";
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
        }
    }

    IEnumerator Type()
    {
        if (feedback.gameObject.activeInHierarchy == true)
        {
            continueButton.SetActive(false);
            RetryButton.SetActive(false);
            PassButton.SetActive(false);
            nextButton.SetActive(false);
            nextButton2.SetActive(false);

            foreach (char letter in sentences[index].ToCharArray())
            {
                feedbackText.text += letter;
                yield return new WaitForSeconds(typingSpeed);
            }
        }
    }
}