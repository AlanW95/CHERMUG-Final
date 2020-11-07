using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

//////////////////////////////////////////////////<summary>//////////////////////////////////////////////////// 
///                                   University of the West of Scotland                                    ///
///                                      BREAKFAST AND OBESITY TOPIC                                        ///
///                               -------------------------------------------                               ///  
/// Script is attached to the Manager GameObject in the BO_QuestionsHM scene.                               ///
///                                                                                                         ///                    
//////////////////////////////////////////////////</summary>///////////////////////////////////////////////////

public class BO_HangmanQuestions : MonoBehaviour
{
    public GameObject scoreBar;
    public GameObject nameBar;

    public GameObject scenarioObj;
    public GameObject scenarioCloseButton;
    public GameObject scenarioViewButton;
    public GameObject scenarioButtonClickBlock;

    public GameObject questionObj;
    public GameObject questions;
    public GameObject nextButton;
    public GameObject nextButton2;
    public GameObject nextButton3;
    public GameObject nextButton4;
    public Button next;
    public Button next2;
    public Button next3;
    public Button next4;
    
    public Text scenario;
    public Text q;
    public Text subq;
    public Text a1;
    public Text a2;
    public Text a3;
    public Text a4;

    public GameObject feedback;
    public Text feedbackText;

    public GameObject continueButton;
    public GameObject continueButton2;
    public GameObject continueButton3;
    public GameObject finish_ContinueButton;

    //Typing Text
    public string[] sentences;
    private int index;
    public float typingSpeed;

    public Button option1Button;
    public Button option2Button;
    public Button option3Button;
    public Button option4Button;

    public GameObject answer3;
    public GameObject answer4;

    private bool q1Answered;
    private bool q2Answered;
    private bool q3Answered;
    private bool q4Answered;

    public GameObject character;
    private bool finished;

    public GameObject RetryButton;
    public GameObject PassButton;

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

        option1Button = GameObject.Find("Option1").GetComponent<Button>();
        option2Button = GameObject.Find("Option2").GetComponent<Button>();
        option3Button = GameObject.Find("Option3").GetComponent<Button>();
        option4Button = GameObject.Find("Option4").GetComponent<Button>();

        RetryButton = GameObject.Find("RetryButton");
        PassButton = GameObject.Find("PassButton");

        ResetQ1();
    }

    // Update is called once per frame
    void Update()
    {
        //when typing text is typing, when the length is equal to the text the continue button will appear
        for (int i = 0; i < sentences.Length; i++)
        {
            continueButton.SetActive(false);
            continueButton2.SetActive(false);
            continueButton3.SetActive(false);
            finish_ContinueButton.SetActive(false);
            RetryButton.SetActive(false);
            PassButton.SetActive(false);

            if (feedbackText.text == sentences[0])
            {
                continueButton.SetActive(true);
                continueButton2.SetActive(false);
                continueButton3.SetActive(false);
                finish_ContinueButton.SetActive(false);

                RetryButton.SetActive(false);
                PassButton.SetActive(false);
            }
            if (feedbackText.text == sentences[2])
            {
                continueButton.SetActive(false);
                continueButton2.SetActive(true);
                continueButton3.SetActive(false);
                finish_ContinueButton.SetActive(false);

                RetryButton.SetActive(false);
                PassButton.SetActive(false);
            }
            if (feedbackText.text == sentences[4] || feedbackText.text == sentences[5])
            {
                continueButton.SetActive(false);
                continueButton2.SetActive(false);
                continueButton3.SetActive(true);
                finish_ContinueButton.SetActive(false);

                RetryButton.SetActive(false);
                PassButton.SetActive(false);
            }
            if (feedbackText.text == sentences[6])
            {
                continueButton.SetActive(false);
                continueButton2.SetActive(false);
                continueButton3.SetActive(false);
                finish_ContinueButton.SetActive(true);

                RetryButton.SetActive(false);
                PassButton.SetActive(false);
            }

            if (feedbackText.text == sentences[1] || feedbackText.text == sentences[3] || feedbackText.text == sentences[7])
            {
                RetryButton.SetActive(true);
                PassButton.SetActive(true);

                continueButton.SetActive(false);
                continueButton2.SetActive(false);
                continueButton3.SetActive(false);
                finish_ContinueButton.SetActive(false);
            }
        }
    }

    public void ResetQ1()
    {
        Q1();

        SpeechBubbleText();

        option1Button.interactable = true;
        option2Button.interactable = true;
        option3Button.interactable = true;
        option4Button.interactable = true;

        q1Answered = false;
        q2Answered = false;
        q3Answered = false;
        q4Answered = false;

        feedback.SetActive(false);
        continueButton.SetActive(false);
        finish_ContinueButton.SetActive(false);
        finished = false;

        nextButton.SetActive(true);
        next.interactable = false;
        nextButton2.SetActive(false);
        next2.interactable = false;
        nextButton3.SetActive(false);
        next3.interactable = false;
        nextButton4.SetActive(false);
        next4.interactable = false;

        RetryButton.SetActive(false);
        PassButton.SetActive(false);

        scenarioButtonClickBlock.gameObject.SetActive(false);
    }

    public void ResetQ2()
    {
        Q2();

        SpeechBubbleText();

        option1Button.interactable = true;
        option2Button.interactable = true;
        option3Button.interactable = true;
        option4Button.interactable = true;

        q1Answered = false;
        q2Answered = false;
        q3Answered = false;
        q4Answered = false;

        feedback.SetActive(false);
        continueButton.SetActive(false);
        finish_ContinueButton.SetActive(false);
        finished = false;

        nextButton.SetActive(false);
        next.interactable = false;
        nextButton2.SetActive(true);
        next2.interactable = false;
        nextButton3.SetActive(false);
        next3.interactable = false;
        nextButton4.SetActive(false);
        next4.interactable = false;

        RetryButton.SetActive(false);
        PassButton.SetActive(false);

        scenarioButtonClickBlock.gameObject.SetActive(false);
    }

    public void ResetQ4()
    {
        Q4();

        SpeechBubbleText();

        option1Button.interactable = true;
        option2Button.interactable = true;
        option3Button.interactable = true;
        option4Button.interactable = true;

        q1Answered = false;
        q2Answered = false;
        q3Answered = false;
        q4Answered = false;

        feedback.SetActive(false);
        continueButton.SetActive(false);
        finish_ContinueButton.SetActive(false);
        finished = false;

        nextButton.SetActive(false);
        next.interactable = false;
        nextButton2.SetActive(false);
        next2.interactable = false;
        nextButton3.SetActive(false);
        next3.interactable = false;
        nextButton4.SetActive(true);
        next4.interactable = false;

        RetryButton.SetActive(false);
        PassButton.SetActive(false);

        scenarioButtonClickBlock.gameObject.SetActive(false);
    }

    public void SpeechBubbleText()
    {
        sentences[0] = "Correct: Breakfast habit and a nominal variable are the correct independent variable and level of measurement.";
        sentences[1] = "Incorrect: Would you like to try again?";
        sentences[2] = "Correct: Eats breakfast and doesn't eat breakfast are the levels of the variable Breakfast habit.";
        sentences[3] = "Incorrect: Would you like to try again?";
        sentences[4] = "Correct: Breakfast habit is a between participants variable.";
        sentences[5] = "Incorrect: Participants only belongs to one category of the variable.";
        sentences[6] = "Correct: BMI value is the dependent variable.";
        sentences[7] = "Incorrect: Would you like to try again?";
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

    public void ActivateFeedback()
    {
        feedback.SetActive(true);
        feedbackText.gameObject.SetActive(true);
        feedbackText.text = "";
        questions.SetActive(true);

        StartCoroutine(Type());
    }

    public void Next()
    {
        if (q3Answered)
        {
            character.gameObject.GetComponent<CharacterAnims>().states = 2;//Thumbs up anim
            index = 0;
            ActivateFeedback();
            nextButton.SetActive(false);
            continueButton.SetActive(true);
            finish_ContinueButton.SetActive(false);
            finished = true;
            scoreBar.gameObject.GetComponent<ScoreSystem>().AddBOScore();
        }
        else
        {
            character.gameObject.GetComponent<CharacterAnims>().states = 3;//Shake head anim
            index = 1;
            ActivateFeedback();
            nextButton.SetActive(false);
            continueButton.SetActive(true);
            finish_ContinueButton.SetActive(false);
            finished = true;
            scoreBar.gameObject.GetComponent<ScoreSystem>().RemoveBOScore();
        }
    }

    public void Next2()
    {
        if (q4Answered)
        {
            character.gameObject.GetComponent<CharacterAnims>().states = 2;//Thumbs up anim
            index = 2;
            ActivateFeedback();
            nextButton2.SetActive(false);
            continueButton.SetActive(false);
            finish_ContinueButton.SetActive(false);
            finished = false;
            scoreBar.gameObject.GetComponent<ScoreSystem>().AddBOScore();
        }
        else
        {
            character.gameObject.GetComponent<CharacterAnims>().states = 3;//Shake head anim
            index = 3;
            ActivateFeedback();
            nextButton2.SetActive(false);
            continueButton.SetActive(false);
            finish_ContinueButton.SetActive(false);
            finished = false;
            scoreBar.gameObject.GetComponent<ScoreSystem>().RemoveBOScore();
        }
    }

    public void Next3()
    {
        if (q1Answered)
        {
            character.gameObject.GetComponent<CharacterAnims>().states = 2;//Thumbs up anim
            index = 4;
            ActivateFeedback();
            nextButton3.SetActive(false);
            continueButton.SetActive(false);
            finish_ContinueButton.SetActive(false);
            finished = false;
            scoreBar.gameObject.GetComponent<ScoreSystem>().AddBOScore();
        }
        else
        {
            character.gameObject.GetComponent<CharacterAnims>().states = 3;//Shake head anim
            index = 5;
            ActivateFeedback();
            nextButton3.SetActive(false);
            continueButton.SetActive(false);
            finish_ContinueButton.SetActive(false);
            finished = false;
            scoreBar.gameObject.GetComponent<ScoreSystem>().RemoveBOScore();
        }
    }

    public void Next4()
    {
        if (q3Answered)
        {
            character.gameObject.GetComponent<CharacterAnims>().states = 2;//Thumbs up anim
            index = 6;
            ActivateFeedback();
            nextButton4.SetActive(false);
            continueButton.SetActive(false);
            finish_ContinueButton.SetActive(true);
            finished = true;
            scoreBar.gameObject.GetComponent<ScoreSystem>().AddBOScore();
        }
        else
        {
            character.gameObject.GetComponent<CharacterAnims>().states = 3;//Shake head anim
            index = 7;
            ActivateFeedback();
            nextButton4.SetActive(false);
            continueButton.SetActive(false);
            finish_ContinueButton.SetActive(true);
            finished = true;
            scoreBar.gameObject.GetComponent<ScoreSystem>().RemoveBOScore();
        }
    }

    public void ProgressToNextScene()
    {
        SceneManager.LoadScene("BO_Hangman");
    }

    //------------------------QUESTIONS-------------------------------

    public void Q1()
    {
        questions.SetActive(true);
        option1Button.interactable = true;
        option2Button.interactable = true;
        option3Button.interactable = true;
        option4Button.interactable = true;
        feedback.SetActive(false);

        //Question 1
        q.text = "What is the independent variable in this study and what is the level of measurement?";
        subq.text = "";
        a1.text = "Breakfast habit, a ratio variable";
        a2.text = "BMI, a nominal variable";
        a3.text = "Breakfast habit, a nominal variable";
        a4.text = "BMI, a ratio variable";

        next.interactable = false;
    }

    public void Q2()
    {
        questions.SetActive(true);
        option1Button.interactable = true;
        option2Button.interactable = true;
        option3Button.interactable = true;
        option4Button.interactable = true;
        nextButton2.SetActive(true);
        feedback.SetActive(false);

        //Question 2
        q.text = "In this <b>study</b>, what are the levels of the variable Breakfast habit?";
        subq.text = "";
        a1.text = "Eats at 8am and eats at 10am";
        a2.text = "Prefer breakfast and prefer dinner";
        a3.text = "Cereal and toast";
        a4.text = "Eats breakfast and doesn't eat breakfast";

        next2.interactable = false;
    }

    public void Q3()
    {
        questions.SetActive(true);
        answer3.SetActive(false);
        answer4.SetActive(false);
        option1Button.interactable = true;
        option2Button.interactable = true;
        nextButton3.SetActive(true);
        feedback.SetActive(false);

        //Question 1
        q.text = "In this <b>study</b>, is Breakfast habit a within or between participants variable?";
        subq.text = "";
        a1.text = "Between participants";
        a2.text = "Within participants";

        next3.interactable = false;
    }

    public void Q4()
    {
        questions.SetActive(true);
        answer3.SetActive(true);
        answer4.SetActive(true);
        option1Button.interactable = true;
        option2Button.interactable = true;
        option3Button.interactable = true;
        option4Button.interactable = true;
        nextButton4.SetActive(true);
        feedback.SetActive(false);

        //Question 4
        q.text = "In this <b>study</b>, what is the dependent variable?";
        subq.text = "";
        a1.text = "Breakfast habit (regular or not)";
        a2.text = "Gender";
        a3.text = "BMI value";
        a4.text = "Weight";

        next4.interactable = false;
    }
    //---------------------------------------------------------------------------------------------------

    public void ButtonPress()
    {
        string name = EventSystem.current.currentSelectedGameObject.name;

        next.interactable = true;
        next2.interactable = true;
        next3.interactable = true;
        next4.interactable = true;

        if (name == "RetryButton")
        {
            if (index == 1)
            {
                ResetQ1();
            }
            if (index == 3)
            {
                Q2();
            }
            if (index == 7)
            {
                Q4();
            }
        }

        if (name == "PassButton")
        {
            if (index == 1)
            {
                Q2();
            }
            if (index == 3)
            {
                Q3();
            }
            if (index == 7)
            {
                ProgressToNextScene();
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
        if (name == "Finished_ContinueButton")
        {
            ProgressToNextScene();
        }
    }

    IEnumerator Type()
    {
        if (feedback)
        {
            continueButton.SetActive(false);
            continueButton2.SetActive(false);
            continueButton3.SetActive(false);
            finish_ContinueButton.SetActive(false);
            RetryButton.SetActive(false);
            PassButton.SetActive(false);

            foreach (char letter in sentences[index].ToCharArray())
            {
                feedbackText.text += letter;
                yield return new WaitForSeconds(typingSpeed);
            }
        }
    }
}
