using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//////////////////////////////////////////////////<summary>//////////////////////////////////////////////////// 
///                                   University of the West of Scotland                                    ///
///                                 -------------------------------------------                             ///  
/// Script is attached to the QuantitativeArea GameObject in the DragDrop Quantitative VS Qualitative scene.///
///                                                                                                         ///  
//////////////////////////////////////////////////</summary>///////////////////////////////////////////////////

public class DragQuan : MonoBehaviour
{
    public GameObject item1, item2, item3;
    private bool checkPressed;
    private bool isAllowedToTrigger;
    public bool answer1, answer2, answer3;
    public Text[] statements;
    public bool allTrue1;
    //round 2
    public GameObject item7, item8, item9;
    public bool answer7, answer8, answer9;
    public bool allTrue2;
    private bool checkPressed2;
    private bool isAllowedToTrigger2;
    //round 3
    public GameObject item15, item16, item17;
    public bool answer15, answer16, answer17;
    public bool allTrue3;
    private bool checkPressed3;
    private bool isAllowedToTrigger3;
    //round 4
    public GameObject item22, item23, item24;
    public bool answer22, answer23, answer24;
    public bool allTrue4;
    private bool checkPressed4;
    private bool isAllowedToTrigger4;

    public GameObject[] submitAnswers;
    public GameObject playerResponse;
    public GameObject[] continueButtons;

    public GameObject correctPopupUI;

    private bool random;

    // Start is called before the first frame update
    void Start()
    {
        playerResponse = GameObject.Find("PlayerResponse");
        
        item1 = GameObject.Find("Item1-1");
        item2 = GameObject.Find("Item1-2");
        item3 = GameObject.Find("Item1-3");

        //round 2
        item7 = GameObject.Find("Item2-1");
        item8 = GameObject.Find("Item2-3");
        item9 = GameObject.Find("Item2-5");

        //round 3
        item15 = GameObject.Find("Item3-2");
        item16 = GameObject.Find("Item3-3");
        item17 = GameObject.Find("Item3-4");

        //round 4
        item22 = GameObject.Find("Item4-1");
        item23 = GameObject.Find("Item4-5");
        item24 = GameObject.Find("Item4-7");

        checkPressed = false;
        isAllowedToTrigger = false;
        answer1 = false;
        answer2 = false;
        answer3 = false;
        allTrue1 = false;

        checkPressed2 = false;
        isAllowedToTrigger2 = false;
        item7.SetActive(false);
        item8.SetActive(false);
        item9.SetActive(false);
        answer7 = false;
        answer8 = false;
        answer9 = false;
        allTrue2 = false;

        checkPressed3 = false;
        isAllowedToTrigger3 = false;
        item15.SetActive(false);
        item16.SetActive(false);
        item17.SetActive(false);
        answer15 = false;
        answer16 = false;
        allTrue3 = false;

        checkPressed4 = false;
        isAllowedToTrigger4 = false;
        item22.SetActive(false);
        item23.SetActive(false);
        item24.SetActive(false);
        answer22 = false;
        answer23 = false;
        answer24 = false;
        allTrue4 = false;

        submitAnswers[0].SetActive(true);
        submitAnswers[1].SetActive(false);
        submitAnswers[2].SetActive(false);
        submitAnswers[3].SetActive(false);

        continueButtons[0].SetActive(false);
        continueButtons[1].SetActive(false);
        continueButtons[2].SetActive(false);
        continueButtons[3].SetActive(false);
        playerResponse.SetActive(false);

        random = false;

        Statements();
    }


    // Update is called once per frame
    void Update()
    {
        //Set 1 of Statements
        if (answer1 && answer2 && answer3 &&
                GameObject.Find("QualitativeArea").GetComponent<DragQual>().answer4 == true &&
                GameObject.Find("QualitativeArea").GetComponent<DragQual>().answer5 == true &&
                GameObject.Find("QualitativeArea").GetComponent<DragQual>().answer6 == true)
        {
            playerResponse.SetActive(true);
            continueButtons[0].SetActive(true);
            continueButtons[1].SetActive(false);
            continueButtons[2].SetActive(false);
            continueButtons[3].SetActive(false);

            submitAnswers[0].SetActive(false);
            submitAnswers[1].SetActive(false);
            submitAnswers[2].SetActive(false);
            submitAnswers[3].SetActive(false);

            correctPopupUI.gameObject.GetComponent<FeedbackPopup>().correct_states = 1;
        }

        //Set 2 of Statements
        if (answer7 && answer8 && answer9 && 
                                           
                GameObject.Find("QualitativeArea").GetComponent<DragQual>().answer12 == true &&
                GameObject.Find("QualitativeArea").GetComponent<DragQual>().answer13 == true &&
                GameObject.Find("QualitativeArea").GetComponent<DragQual>().answer14 == true)
        {
            playerResponse.SetActive(true);
            continueButtons[0].SetActive(false);
            continueButtons[1].SetActive(true);
            continueButtons[2].SetActive(false);
            continueButtons[3].SetActive(false);

            submitAnswers[0].SetActive(false);
            submitAnswers[1].SetActive(false);
            submitAnswers[2].SetActive(false);
            submitAnswers[3].SetActive(false);

            correctPopupUI.gameObject.GetComponent<FeedbackPopup>().correct_states = 1;
        }

        //Set 3 of Statements
        if (answer15 && answer16 && answer17 && 
                GameObject.Find("QualitativeArea").GetComponent<DragQual>().answer19 == true &&
                GameObject.Find("QualitativeArea").GetComponent<DragQual>().answer20 == true &&
                GameObject.Find("QualitativeArea").GetComponent<DragQual>().answer21 == true)
        {
            playerResponse.SetActive(true);
            continueButtons[0].SetActive(false);
            continueButtons[1].SetActive(false);
            continueButtons[2].SetActive(true);
            continueButtons[3].SetActive(false);

            submitAnswers[0].SetActive(false);
            submitAnswers[1].SetActive(false);
            submitAnswers[2].SetActive(false);
            submitAnswers[3].SetActive(false);

            correctPopupUI.gameObject.GetComponent<FeedbackPopup>().correct_states = 1;
        }

        if (answer22 && answer23 && answer24 && 
                GameObject.Find("QualitativeArea").GetComponent<DragQual>().answer26 == true &&
                GameObject.Find("QualitativeArea").GetComponent<DragQual>().answer27 == true &&
                GameObject.Find("QualitativeArea").GetComponent<DragQual>().answer28 == true)
        {
            allTrue4 = true;
            GameObject.Find("QualitativeArea").GetComponent<DragQual>().allTrue4 = true;

            if (GameObject.Find("QualitativeArea").GetComponent<DragQual>().allTrue4 == true)
            {
                playerResponse.SetActive(true);
                continueButtons[0].SetActive(false);
                continueButtons[1].SetActive(false);
                continueButtons[2].SetActive(false);
                continueButtons[3].SetActive(true);

                submitAnswers[0].SetActive(false);
                submitAnswers[1].SetActive(false);
                submitAnswers[2].SetActive(false);
                submitAnswers[3].SetActive(false);

                correctPopupUI.gameObject.GetComponent<FeedbackPopup>().correct_states = 1;
            }
        }
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Statements()
    {
        //Round 1 of Statements
        statements[0].text = "More likely to ask how much? how many? how often? to what extent?"; //correct
        statements[1].text = "More concerned with analysing and summarising data"; //correct
        statements[2].text = "More concerned with testing theories"; //correct
        statements[3].text = "More concerned with interpretation of data"; //incorrect
        statements[4].text = "More concerned with theory building"; //incorrect
        statements[5].text = "More likely to ask why? how? in what way?"; //incorrect
        //Round 2 of Statements
        statements[6].text = "Presented in numerical form and interpreted using the correct statistical analysis for the data"; //correct
        statements[7].text = "Typically adopts a deductive approach"; //correct
        statements[8].text = "Adopts a subjective approach"; //incorrect
        statements[9].text = "Typically adopts an inductive approach"; //incorrect
        statements[10].text = "Adopts an objective approach"; //correct
        statements[11].text = "Presented in a variety of forms and interpreted based on a variety of underlying philosophies and traditions from a variety of different disciplines"; //incorrect
        //Round 3 of Statements
        statements[12].text = "Deals with descriptions"; //incorrect
        statements[13].text = "Deals with phenomena that must be measured"; //correct
        statements[14].text = "Data can be observed, measured and quantified"; //correct
        statements[15].text = "Deals with numbers"; //correct
        statements[16].text = "Deals with phenomena that cannot be measured, only experienced"; //incorrect
        statements[17].text = "Data can be observed but not measured"; //incorrect
        //Round 4 of Statements
        statements[18].text = "Data analysis involves statistical testing"; //correct
        statements[19].text = "Examples of analysis include grounded theory, phenomenological analysis, thematic analysis"; //incorrect
        statements[20].text = "Data analysis involves thematic coding"; //incorrect
        statements[21].text = "Looks at the meaning individuals or groups ascribe to a social or human problem"; //incorrect
        statements[22].text = "Examples of analysis would include chi-square, t-test, correlation"; //correct
        statements[23].text = "Involves the study of relationships between variables"; //correct
    }

    public void Check()
    {
        isAllowedToTrigger = true;
        checkPressed = true;
    }

    public void Check2()
    {
        isAllowedToTrigger = false;
        isAllowedToTrigger2 = true;
        checkPressed2 = true;
        isAllowedToTrigger3 = false;
        isAllowedToTrigger4 = false;
    }

    public void Check3()
    {
        isAllowedToTrigger = false;
        isAllowedToTrigger2 = false;
        isAllowedToTrigger3 = true;
        checkPressed3 = true;
        isAllowedToTrigger4 = false;
    }

    public void Check4()
    {
        isAllowedToTrigger = false;
        isAllowedToTrigger2 = false;
        isAllowedToTrigger3 = false;
        isAllowedToTrigger4 = true;
        checkPressed4 = true;
    }

    public void Progress1()
    {        
        allTrue1 = true;
        GameObject.Find("QualitativeArea").GetComponent<DragQual>().allTrue1 = true;

        if (GameObject.Find("QualitativeArea").GetComponent<DragQual>().allTrue1 == true)
        {
            correctPopupUI.gameObject.GetComponent<FeedbackPopup>().correct_states = 2;

            item1.SetActive(false);
            item2.SetActive(false);
            item3.SetActive(false);
            GameObject.Find("QualitativeArea").GetComponent<DragQual>().item4.SetActive(false);
            GameObject.Find("QualitativeArea").GetComponent<DragQual>().item5.SetActive(false);
            GameObject.Find("QualitativeArea").GetComponent<DragQual>().item6.SetActive(false);

            item7.SetActive(true);
            item8.SetActive(true);
            item9.SetActive(true);
            GameObject.Find("QualitativeArea").GetComponent<DragQual>().item11.SetActive(true);
            GameObject.Find("QualitativeArea").GetComponent<DragQual>().item12.SetActive(true);
            GameObject.Find("QualitativeArea").GetComponent<DragQual>().item13.SetActive(true);

            checkPressed = false;
            GameObject.Find("QualitativeArea").GetComponent<DragQual>().checkPressed = false;

            isAllowedToTrigger = false;
            GameObject.Find("QualitativeArea").GetComponent<DragQual>().isAllowedToTrigger = false;
            
            submitAnswers[0].SetActive(false);
            submitAnswers[1].SetActive(true);

            answer1 = false;
            answer2 = false;
            answer3 = false;

            playerResponse.SetActive(false);
            continueButtons[0].SetActive(false);
            continueButtons[1].SetActive(false);
            continueButtons[2].SetActive(false);
        }
    }

    public void Progress2()
    {
        allTrue2 = true;
        GameObject.Find("QualitativeArea").GetComponent<DragQual>().allTrue2 = true;
        
        if (GameObject.Find("QualitativeArea").GetComponent<DragQual>().allTrue2 == true)
        {
            correctPopupUI.gameObject.GetComponent<FeedbackPopup>().correct_states = 2;

            item7.SetActive(false);
            item8.SetActive(false);
            item9.SetActive(false);
            GameObject.Find("QualitativeArea").GetComponent<DragQual>().item11.SetActive(false);
            GameObject.Find("QualitativeArea").GetComponent<DragQual>().item12.SetActive(false);
            GameObject.Find("QualitativeArea").GetComponent<DragQual>().item13.SetActive(false);

            item15.SetActive(true);
            item16.SetActive(true);
            item17.SetActive(true);
            GameObject.Find("QualitativeArea").GetComponent<DragQual>().item19.SetActive(true);
            GameObject.Find("QualitativeArea").GetComponent<DragQual>().item20.SetActive(true);
            GameObject.Find("QualitativeArea").GetComponent<DragQual>().item21.SetActive(true);

            checkPressed2 = false;
            GameObject.Find("QualitativeArea").GetComponent<DragQual>().checkPressed2 = false;

            isAllowedToTrigger2 = false;
            GameObject.Find("QualitativeArea").GetComponent<DragQual>().isAllowedToTrigger2 = false;
            
            submitAnswers[1].SetActive(false);
            submitAnswers[2].SetActive(true);

            answer7 = false;
            answer8 = false;
            answer9 = false;

            playerResponse.SetActive(false);
            continueButtons[0].SetActive(false);
            continueButtons[1].SetActive(false);
            continueButtons[2].SetActive(false);
        }
    }

    public void Progress3()
    {
        allTrue3 = true;
        GameObject.Find("QualitativeArea").GetComponent<DragQual>().allTrue3 = true;
        
        if (GameObject.Find("QualitativeArea").GetComponent<DragQual>().allTrue3 == true)
        {
            correctPopupUI.gameObject.GetComponent<FeedbackPopup>().correct_states = 2;

            item15.SetActive(false);
            item16.SetActive(false);
            item17.SetActive(false);
            GameObject.Find("QualitativeArea").GetComponent<DragQual>().item19.SetActive(false);
            GameObject.Find("QualitativeArea").GetComponent<DragQual>().item20.SetActive(false);
            GameObject.Find("QualitativeArea").GetComponent<DragQual>().item21.SetActive(false);

            item22.SetActive(true);
            item23.SetActive(true);
            item24.SetActive(true);
            GameObject.Find("QualitativeArea").GetComponent<DragQual>().item26.SetActive(true);
            GameObject.Find("QualitativeArea").GetComponent<DragQual>().item27.SetActive(true);
            GameObject.Find("QualitativeArea").GetComponent<DragQual>().item28.SetActive(true);

            checkPressed3 = false;
            GameObject.Find("QualitativeArea").GetComponent<DragQual>().checkPressed3 = false;

            isAllowedToTrigger3 = false;
            GameObject.Find("QualitativeArea").GetComponent<DragQual>().checkPressed3 = false;
            
            submitAnswers[2].SetActive(false);
            submitAnswers[3].SetActive(true);

            answer15 = false;
            answer16 = false;
            answer17 = false;

            playerResponse.SetActive(false);
            continueButtons[0].SetActive(false);
            continueButtons[1].SetActive(false);
            continueButtons[2].SetActive(false);
        }
    }

    public void Progress4()
    {
        GameObject.Find("Part2Manager").GetComponent<QuanOrQualQuestions>().EnablePart2();
        correctPopupUI.SetActive(false);
        playerResponse.SetActive(false);
        continueButtons[0].SetActive(false);
        continueButtons[1].SetActive(false);
        continueButtons[2].SetActive(false);
        continueButtons[3].SetActive(false);
    }

    IEnumerator TextTimer()
    {
        yield return new WaitForSeconds(3);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (!random)
        {
            if (collision.gameObject.tag == "Draggable")
            {
                random = true;
                StartCoroutine(TextTimer());
            }
        }
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (isAllowedToTrigger)
        {
            //First set of Statements
            if (collision.gameObject.name == "Item1-1")
            {
                statements[0].GetComponent<Text>().color = Color.green; // change colour to green
                answer1 = true;
            }

            if (collision.gameObject.name == "Item1-2")
            {
                statements[1].GetComponent<Text>().color = Color.green; // change colour to green
                answer2 = true;
            }

            if (collision.gameObject.name == "Item1-3")
            {
                statements[2].GetComponent<Text>().color = Color.green; // change colour to green
                answer3 = true;
            }

            if (collision.gameObject.name == "Item1-4")
            {
                statements[3].GetComponent<Text>().color = Color.red; //change colour to red
            }

            if (collision.gameObject.name == "Item1-5")
            {
                statements[4].GetComponent<Text>().color = Color.red; //change colour to red
            }

            if (collision.gameObject.name == "Item1-6")
            {
                statements[5].GetComponent<Text>().color = Color.red; //change colour to red
            }
        }

        if (isAllowedToTrigger2)
        {
            //Second set of Statements
            if (collision.gameObject.name == "Item2-1")
            {
                statements[6].GetComponent<Text>().color = Color.green; //change colour to green
                answer7 = true;
            }

            if (collision.gameObject.name == "Item2-2")
            {
                statements[7].GetComponent<Text>().color = Color.green; //change colour to green
                answer9 = true;
            }

            if (collision.gameObject.name == "Item2-3")
            {
                statements[8].GetComponent<Text>().color = Color.red; //change colour to red
            }

            if (collision.gameObject.name == "Item2-4")
            {
                statements[9].GetComponent<Text>().color = Color.red; //change colour to red
            }

            if (collision.gameObject.name == "Item2-5")
            {
                statements[10].GetComponent<Text>().color = Color.green; //change colour to green
                answer8 = true;
            }

            if (collision.gameObject.name == "Item2-6")
            {
                statements[11].GetComponent<Text>().color = Color.red; //change colour to red
            }
        }

        if (isAllowedToTrigger3)
        {
            //Third set of Statements
            if (collision.gameObject.name == "Item3-1")
            {
                statements[12].GetComponent<Text>().color = Color.red; //change colour to red
            }

            if (collision.gameObject.name == "Item3-2")
            {
                statements[13].GetComponent<Text>().color = Color.green; //change colour to green
                answer15 = true;
            }

            if (collision.gameObject.name == "Item3-3")
            {
                statements[14].GetComponent<Text>().color = Color.green; //change colour to green
                answer16 = true;
            }

            if (collision.gameObject.name == "Item3-4")
            {
                statements[15].GetComponent<Text>().color = Color.green; //change colour to green
                answer17 = true;
            }

            if (collision.gameObject.name == "Item3-6")
            {
                statements[16].GetComponent<Text>().color = Color.red; //change colour to red
            }

            if (collision.gameObject.name == "Item3-7")
            {
                statements[17].GetComponent<Text>().color = Color.red; //change colour to red
            }
        }

        if (isAllowedToTrigger4)
        {
            //Fourth set of Statements
            if (collision.gameObject.name == "Item4-1")
            {
                statements[18].GetComponent<Text>().color = Color.green; //change colour to green
                answer22 = true;
            }

            if (collision.gameObject.name == "Item4-2")
            {
                statements[19].GetComponent<Text>().color = Color.red; //change colour to red
            }

            if (collision.gameObject.name == "Item4-3")
            {
                statements[20].GetComponent<Text>().color = Color.red; //change colour to red
            }

            if (collision.gameObject.name == "Item4-4")
            {
                statements[21].GetComponent<Text>().color = Color.red; //change colour to red
            }

            if (collision.gameObject.name == "Item4-5")
            {
                statements[22].GetComponent<Text>().color = Color.green; //change colour to green
                answer23 = true;
            }

            if (collision.gameObject.name == "Item4-7")
            {
                statements[23].GetComponent<Text>().color = Color.green; //change colour to green
                answer24 = true;
            }
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        for (int i = 0; i < statements.Length; i++)
        {
            statements[i].GetComponent<Text>().color = Color.black; //change colour back to black

            if (answer1) { answer1 = false; }
            if (answer2) { answer2 = false; }
            if (answer3) { answer3 = false; }
            if (answer7) { answer7 = false; }
            if (answer8) { answer8 = false; }
            if (answer9) { answer9 = false; }
            if (answer15) { answer15 = false; }
            if (answer16) { answer16 = false; }
            if (answer17) { answer17 = false; }
            if (answer22) { answer22 = false; }
            if (answer23) { answer23 = false; }
            if (answer24) { answer24 = false; }
        }
    }
}
