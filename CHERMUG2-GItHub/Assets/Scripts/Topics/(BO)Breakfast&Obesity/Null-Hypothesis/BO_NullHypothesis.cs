using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Xml.Serialization;
using UnityEngine.SceneManagement;

//////////////////////////////////////////////////<summary>//////////////////////////////////////////////////// 
///                                   University of the West of Scotland                                    ///
///                                      BREAKFAST AND OBESITY TOPIC                                        ///
///                               -------------------------------------------                               ///  
/// Script is attached to the Manager GameObject in the BO_NullHypothesis scene.                            ///
///                                                                                                         ///
//////////////////////////////////////////////////</summary>///////////////////////////////////////////////////

public class BO_NullHypothesis : MonoBehaviour
{
    public GameObject scoreBar;
    public GameObject nameBar;

    public GameObject scenarioCloseButton;
    public GameObject scenarioViewButton;
    public GameObject scenarioButtonClickBlock;
    public GameObject scenarioObj;

    //Part 1 buttons
    private Button q1Button1;//Correct button
    private Button q1Button2;//Wrong button
    //Part 2 buttons
    private Button q2Button1;//Correct button
    private Button q2Button2;//Wrong button
    private Button q2Button3;//Wrong button
    //Part 3 buttons
    private Button q3Button1;//Correct button
    private Button q3Button2;//Wrong button
    private Button q3Button3;//Wrong button

    private Button submitButton;
    private Button continueButton;

    //Answers that appear when buttons are pressed
    //Part 1 answers
    private Text q1Answer1;//Correct answer
    private Text q1Answer2;//Wrong answer
    //Part 2 answers
    private Text q2Answer1;//Correct answer
    private Text q2Answer2;//Wrong answer
    private Text q2Answer3;//Wrong answer
    //Part 3 answers
    private Text q3Answer1;//Correct answer
    private Text q3Answer2;//Wrong answer
    private Text q3Answer3;//Wrong answer

    //Feedback images (red/green background images)
    private GameObject part1_Feedback_BG_Wrong;
    private GameObject part1_Feedback_BG_Correct;
    private GameObject part2_Feedback_BG_Wrong;
    private GameObject part2_Feedback_BG_Correct;
    private GameObject part3_Feedback_BG_Wrong;
    private GameObject part3_Feedback_BG_Correct;

    //Text that displays when answers are correct/incorrect
    private Text part1_Incorrect;
    private Text part1_Correct;
    private Text part2_Incorrect;
    private Text part2_Correct;
    private Text part3_Incorrect;
    private Text part3_Correct;

    //Used to check if the questions have been answered
    private bool q1Answered;
    private bool q2Answered;
    private bool q3Answered;

    //Feedback sprites that are displayed when player doesn't select an answer from all sections
    private GameObject speechBubble;
    private Text feedback_SelectAnswer;

    //Buttons holders are the blank game objects that the child buttons are in
    [SerializeField] private List<GameObject> ButtonsHolders = new List<GameObject>();

    //Questions is the 3 sections/parts of the null hypothesis
    [SerializeField] private List<Answer> questions = new List<Answer>();

    private int CurrentSection;

    public Text feedback;
    public string[] sentences;
    private int index;
    public float typingSpeed;

    public GameObject character;
    public GameObject fadeScreen;

    public void Awake()
    {
        fadeScreen.gameObject.GetComponent<FadeOutTransition>().FadeImageOut();
    }

    // Start is called before the first frame update
    void Start()
    {
        //The correct buttons to press to answer correctly
        //Adds the correct button answer to the ButtonHolder list
        //(0,1) < for example, this 0 is the first section, 1 is the second button answer.
        questions.Add(new Answer(0,1, ButtonsHolders));//first section, second button answer 
        questions.Add(new Answer(1,1, ButtonsHolders));//second section, second button answer 
        questions.Add(new Answer(2,0, ButtonsHolders));//third section, first button answer 

        character.gameObject.GetComponent<CharacterAnims>().states = 0;

        speechBubble = GameObject.Find("SpeechBubble");
        feedback_SelectAnswer = GameObject.Find("Feedback_SelectAnswer").GetComponent<Text>();

        submitButton = GameObject.Find("SubmitButton").GetComponent<Button>();
        continueButton = GameObject.Find("ContinueButton").GetComponent<Button>();

        q1Button1 = GameObject.Find("Q1_Button1").GetComponent<Button>();
        q1Button2 = GameObject.Find("Q1_Button2").GetComponent<Button>();
        q2Button1 = GameObject.Find("Q2_Button1").GetComponent<Button>();
        q2Button2 = GameObject.Find("Q2_Button2").GetComponent<Button>();
        q2Button3 = GameObject.Find("Q2_Button3").GetComponent<Button>();
        q3Button1 = GameObject.Find("Q3_Button1").GetComponent<Button>();
        q3Button2 = GameObject.Find("Q3_Button2").GetComponent<Button>();
        q3Button3 = GameObject.Find("Q3_Button3").GetComponent<Button>();

        q1Answer1 = GameObject.Find("Answer1_Correct").GetComponent<Text>();
        q1Answer2 = GameObject.Find("Answer1_Wrong").GetComponent<Text>();
        q2Answer1 = GameObject.Find("Answer2_Correct").GetComponent<Text>();
        q2Answer2 = GameObject.Find("Answer2_Wrong_1").GetComponent<Text>();
        q2Answer3 = GameObject.Find("Answer2_Wrong_2").GetComponent<Text>();
        q3Answer1 = GameObject.Find("Answer3_Correct").GetComponent<Text>();
        q3Answer2 = GameObject.Find("Answer3_Wrong_1").GetComponent<Text>();
        q3Answer3 = GameObject.Find("Answer3_Wrong_2").GetComponent<Text>();

        part1_Feedback_BG_Wrong = GameObject.Find("Part1_Feeback_BG_Wrong");
        part1_Feedback_BG_Correct = GameObject.Find("Part1_Feeback_BG_Correct");
        part2_Feedback_BG_Wrong = GameObject.Find("Part2_Feeback_BG_Wrong");
        part2_Feedback_BG_Correct = GameObject.Find("Part2_Feeback_BG_Correct");
        part3_Feedback_BG_Wrong = GameObject.Find("Part3_Feeback_BG_Wrong");
        part3_Feedback_BG_Correct = GameObject.Find("Part3_Feeback_BG_Correct");

        part1_Incorrect = GameObject.Find("Part1_Incorrect").GetComponent<Text>();
        part1_Correct = GameObject.Find("Part1_Correct").GetComponent<Text>();
        part2_Incorrect = GameObject.Find("Part2_Incorrect").GetComponent<Text>();
        part2_Correct = GameObject.Find("Part2_Correct").GetComponent<Text>();
        part3_Incorrect = GameObject.Find("Part3_Incorrect").GetComponent<Text>();
        part3_Correct = GameObject.Find("Part3_Correct").GetComponent<Text>();

        scenarioCloseButton = GameObject.Find("ScenarioButton_Close");
        scenarioViewButton = GameObject.Find("ScenarioButton_View");
        scenarioButtonClickBlock = GameObject.Find("ScenarioButtonClickBlock");
        scenarioObj = GameObject.Find("ResearchScenario");

        nameBar = GameObject.Find("NameBar");
        scoreBar = GameObject.Find("ScoreBar");

        nameBar.gameObject.GetComponent<BarAnimations>().states = 1;
        scoreBar.gameObject.GetComponent<BarAnimations>().states = 1;

        q1Answer1.gameObject.SetActive(false);
        q1Answer2.gameObject.SetActive(false);

        q2Answer1.gameObject.SetActive(false);
        q2Answer2.gameObject.SetActive(false);
        q2Answer3.gameObject.SetActive(false);

        q3Answer1.gameObject.SetActive(false);
        q3Answer2.gameObject.SetActive(false);
        q3Answer3.gameObject.SetActive(false);

        part1_Feedback_BG_Wrong.gameObject.SetActive(false);
        part1_Feedback_BG_Correct.gameObject.SetActive(false);
        part2_Feedback_BG_Wrong.gameObject.SetActive(false);
        part2_Feedback_BG_Correct.gameObject.SetActive(false);
        part3_Feedback_BG_Wrong.gameObject.SetActive(false);
        part3_Feedback_BG_Correct.gameObject.SetActive(false);

        part1_Incorrect.gameObject.SetActive(false);
        part1_Correct.gameObject.SetActive(false);
        part2_Incorrect.gameObject.SetActive(false);
        part2_Correct.gameObject.SetActive(false);
        part3_Incorrect.gameObject.SetActive(false);
        part3_Correct.gameObject.SetActive(false);

        scenarioCloseButton.gameObject.SetActive(false);
        scenarioViewButton.gameObject.SetActive(true);
        scenarioButtonClickBlock.gameObject.SetActive(false);

        continueButton.gameObject.SetActive(false);
        submitButton.gameObject.SetActive(true);

        speechBubble.gameObject.SetActive(false);
        feedback_SelectAnswer.gameObject.SetActive(false);

        q1Answered = false;
        q2Answered = false;
        q3Answered = false;

        SpeechBubbleText();
    }

    public void SpeechBubbleText()
    {
        sentences[0] = "Please select an answer for all three parts of the null hypothesis.";
    }

    public void LoadNextScene()
    {        
        SceneManager.LoadScene("BO_QuestionsData");
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
        scenarioCloseButton.gameObject.SetActive(false);
        scenarioViewButton.gameObject.SetActive(true);
        scenarioButtonClickBlock.gameObject.SetActive(false);
    }

    public bool CheckIfAllAnsweredCorrect()
    {
        bool IsAllCorrect = true;
        foreach (Answer asw in questions)
        {
            if (!asw.GetIsAnswerRight())
            {
                IsAllCorrect = false;
            }
        }
        return IsAllCorrect;
    }
    //Called from the CheckIfAnswered method
    public bool CheckIfAllAnswered()
    {
        bool isDone = true;
        foreach(Answer asw in questions)
        {
            if (!asw.GetHasBeenAnswered())
            {               
                isDone = false;
            }
        }
        return isDone;
    }
    public void SetCurrentSection(int Sec)
    {
        CurrentSection = Sec;
    }
    public void CallAnswered(int Ref)
    {      
        foreach (Answer asw in questions)
        {          
            if (Ref == asw.GetQuestionID())
            {
                asw.SetHasBeenAnswered(true);
            }
        }                 
    }
    //Called from the SubmitAnswer method when the player presses the submit button
    public void CheckIfAnswered()
    {   //Checks if the player has selected an answer for all parts
        if (CheckIfAllAnswered())
        {
            continueButton.gameObject.SetActive(true);
            submitButton.gameObject.SetActive(false);
            speechBubble.gameObject.SetActive(false);
            feedback_SelectAnswer.gameObject.SetActive(false);
        }
        else
        {
            //Enables feedback to let player know they need to answer all questions before submitting answer
            speechBubble.gameObject.SetActive(true);
            feedback_SelectAnswer.gameObject.SetActive(true);
            feedback.text = "";
            StartCoroutine(Type());
        }
    }

    public void CheckCorrectAnswer(int AnswerID)
    {
        foreach (Answer aws in questions)
        {
            foreach (Button but in aws.buttons)
            {
                if (CurrentSection == aws.GetQuestionID())
                {
                    if (aws.GetAnswerID() == AnswerID)
                    {
                        aws.SetIsRight(true);
                    }
                    else
                    {
                        aws.SetIsRight(false);
                    }
                }
            }
        }
    }
    //Called from the OnClick function in the Inspector
    public void SubmitAnswer()
    {   
        CheckIfAnswered();

        if (!CheckIfAllAnswered())
        {
            return;
        }

        string name = EventSystem.current.currentSelectedGameObject.name;
       
        //PART 1
        if(name == "SubmitButton" && questions[0].GetIsAnswerRight() == true)
        {
            part1_Feedback_BG_Correct.gameObject.SetActive(true);
            part1_Correct.gameObject.SetActive(true);
            scoreBar.gameObject.GetComponent<ScoreSystem>().AddBOScore();
        }
        else
        {
            part1_Feedback_BG_Wrong.gameObject.SetActive(true);
            part1_Incorrect.gameObject.SetActive(true);
            scoreBar.gameObject.GetComponent<ScoreSystem>().RemoveBOScore();
        }
        //PART 2
        if (name == "SubmitButton" && questions[1].GetIsAnswerRight() == true)
        {
            part2_Feedback_BG_Correct.gameObject.SetActive(true);
            part2_Correct.gameObject.SetActive(true);
            scoreBar.gameObject.GetComponent<ScoreSystem>().AddBOScore();
        }
        else
        {
            part2_Feedback_BG_Wrong.gameObject.SetActive(true);
            part2_Incorrect.gameObject.SetActive(true);
            scoreBar.gameObject.GetComponent<ScoreSystem>().RemoveBOScore();
        }
        //PART 3
        if (name == "SubmitButton" && questions[2].GetIsAnswerRight() == true)
        {
            part3_Feedback_BG_Correct.gameObject.SetActive(true);
            part3_Correct.gameObject.SetActive(true);
            scoreBar.gameObject.GetComponent<ScoreSystem>().AddBOScore();
        }
        else
        {
            part3_Feedback_BG_Wrong.gameObject.SetActive(true);
            part3_Incorrect.gameObject.SetActive(true);
            scoreBar.gameObject.GetComponent<ScoreSystem>().RemoveBOScore();
        }

        if (questions[0].GetIsAnswerRight() == true && questions[1].GetIsAnswerRight() == true && questions[2].GetIsAnswerRight() == true)
        {
            AchievementManager.instance.Unlock("BO_achievement_02");
        }
    }
    //Called from the OnClick function in the Inspector
    public void ButtonPress()
    {
        string name = EventSystem.current.currentSelectedGameObject.name;

        //---------PART 1 ANSWERS----------//
        if (name == "Q1_Button1")
        {
            q1Answer1.gameObject.SetActive(false);
            q1Answer2.gameObject.SetActive(true);

            q1Button1.interactable = false;
            q1Button2.interactable = true;
        }
        if (name == "Q1_Button2")
        {
            q1Answer1.gameObject.SetActive(true);
            q1Answer2.gameObject.SetActive(false);

            q1Button1.interactable = true;
            q1Button2.interactable = false;
        }

        //---------PART 2 ANSWERS----------//
        if (name == "Q2_Button1")
        {
            q2Answer1.gameObject.SetActive(false);
            q2Answer2.gameObject.SetActive(true);
            q2Answer3.gameObject.SetActive(false);

            q2Button1.interactable = false;
            q2Button2.interactable = true;
            q2Button3.interactable = true;
        }
        if (name == "Q2_Button2")
        {         
            q2Answer1.gameObject.SetActive(true);
            q2Answer2.gameObject.SetActive(false);
            q2Answer3.gameObject.SetActive(false);

            q2Button1.interactable = true;
            q2Button2.interactable = false;
            q2Button3.interactable = true;
        }
        if (name == "Q2_Button3")
        {
            q2Answer1.gameObject.SetActive(false);
            q2Answer2.gameObject.SetActive(false);
            q2Answer3.gameObject.SetActive(true);

            q2Button1.interactable = true;
            q2Button2.interactable = true;
            q2Button3.interactable = false;
        }

        //---------PART 3 ANSWERS----------//
        if (name == "Q3_Button1")
        {
            q3Answer1.gameObject.SetActive(true);
            q3Answer2.gameObject.SetActive(false);
            q3Answer3.gameObject.SetActive(false);

            q3Button1.interactable = false;
            q3Button2.interactable = true;
            q3Button3.interactable = true;
        }
        if (name == "Q3_Button2")
        {
            q3Answer1.gameObject.SetActive(false);
            q3Answer2.gameObject.SetActive(true);
            q3Answer3.gameObject.SetActive(false);

            q3Button1.interactable = true;
            q3Button2.interactable = false;
            q3Button3.interactable = true;
        }
        if (name == "Q3_Button3")
        {
            q3Answer1.gameObject.SetActive(false);
            q3Answer2.gameObject.SetActive(false);
            q3Answer3.gameObject.SetActive(true);

            q3Button1.interactable = true;
            q3Button2.interactable = true;
            q3Button3.interactable = false;
        }
    }

    [System.Serializable]
    public class Answer : MonoBehaviour
    {
        protected int quesitonID;
        protected int answerID;
        protected bool Answered;
        protected bool IsRight;
        [XmlAttribute("Buttons")]
        [SerializeField] public List<Button> buttons = new List<Button>();

        public Answer(int QuestionID, int AnswerID, List<GameObject> ButtonHolders)
        {
            this.quesitonID = QuestionID;
            this.answerID = AnswerID;
            Answered = false;
            IsRight = false;
            //The GameObject obj in ButtonHolders is the buttons the player presses to answer the question in each section
            foreach (GameObject obj in ButtonHolders)
            {   
                for (int i = 0; i < ButtonHolders.Count; i++)
                {   
                    if (i == QuestionID)
                    {   //Get child of the button holders (the buttons the player can press in each section)   
                        for (int p = 0; p < ButtonHolders[i].transform.childCount; p++)
                        {                           
                            buttons.Add(ButtonHolders[i].transform.GetChild(p).GetComponent<Button>());
                            if (p == ButtonHolders[i].transform.childCount-1)
                            {
                                return;
                            }                               
                        }
                    }
                }
            }
        }

        public bool GetIsAnswerRight()
        {
            return IsRight;
        }

        public int GetQuestionID()
        {
            return quesitonID;
        }

        public bool GetHasBeenAnswered()
        {
            return Answered;
        }

        public int GetAnswerID()
        {
            return answerID;
        }

        public void SetHasBeenAnswered(bool NewAnswer)
        {
            Answered = NewAnswer;
        }

        public void SetIsRight(bool NewIsRight)
        {
            IsRight = NewIsRight;
        }
    }

    IEnumerator Type()
    {
        if (speechBubble.gameObject.activeInHierarchy == true)
        {
            foreach (char letter in sentences[0].ToCharArray())
            {
                submitButton.interactable = false;
                feedback.text += letter;
                yield return new WaitForSeconds(typingSpeed);
            }
            submitButton.interactable = true;
        }
    }
}