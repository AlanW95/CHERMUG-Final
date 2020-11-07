using System.Collections;
using UnityEngine;
using UnityEngine.UI;

//////////////////////////////////////////////////<summary>//////////////////////////////////////////////////// 
///                                   University of the West of Scotland                                    ///
///                                 -------------------------------------------                             ///  
/// Script is attached to the QualitativeArea GameObject in the DragDrop Quantitative VS Qualitative scene. ///
///                                                                                                         ///  
//////////////////////////////////////////////////</summary>///////////////////////////////////////////////////

public class DragQual : MonoBehaviour
{
    public GameObject[] checkButtons;
    
    public GameObject finishedText;
    public GameObject item4, item5, item6;
    public bool checkPressed;
    public bool isAllowedToTrigger;
    public bool answer4, answer5, answer6;
    public Text[] statements;
    public bool allTrue1;
    //round 2
    public GameObject item11, item12, item13;
    public bool answer12, answer13, answer14;
    public bool allTrue2;
    public bool checkPressed2;
    public bool isAllowedToTrigger2;
    //round 3
    public GameObject item19, item20, item21;
    public bool answer19, answer20, answer21;
    public bool allTrue3;
    public bool checkPressed3;
    public bool isAllowedToTrigger3;
    //round 4
    public GameObject item26, item27, item28;
    public bool answer26, answer27, answer28;
    public bool allTrue4;
    public bool checkPressed4;
    public bool isAllowedToTrigger4;

    private bool check1, check2, check3, check4, check5, check6;

    // Start is called before the first frame update
    void Start()
    {
        item4 = GameObject.Find("Item1-4");
        item5 = GameObject.Find("Item1-5");
        item6 = GameObject.Find("Item1-6");

        //round 2
        item11 = GameObject.Find("Item2-2");
        item12 = GameObject.Find("Item2-4");
        item13 = GameObject.Find("Item2-6");

        //round 3
        item19 = GameObject.Find("Item3-1");
        item20 = GameObject.Find("Item3-6");
        item21 = GameObject.Find("Item3-7");

        //round 4
        item26 = GameObject.Find("Item4-2");
        item27 = GameObject.Find("Item4-3");
        item28 = GameObject.Find("Item4-4");

        checkPressed = false;
        isAllowedToTrigger = false;
        answer4 = false;
        answer5 = false;
        answer6 = false;
        allTrue1 = false;

        checkPressed2 = false;
        isAllowedToTrigger2 = false;
        item11.SetActive(false);
        item12.SetActive(false);
        item13.SetActive(false);

        answer12 = false;
        answer13 = false;
        answer14 = false;
        allTrue2 = false;

        checkPressed3 = false;
        isAllowedToTrigger3 = false;
        item19.SetActive(false);
        item20.SetActive(false);
        item21.SetActive(false);
        answer19 = false;
        answer20 = false;
        answer21 = false;
        allTrue3 = false;

        checkPressed4 = false;
        isAllowedToTrigger4 = false;
        item26.SetActive(false);
        item27.SetActive(false);
        item28.SetActive(false);
    
        answer26 = false;
        answer27 = false;
        answer28 = false;
        allTrue4 = false;

        checkButtons[1].SetActive(false);
        checkButtons[2].SetActive(false);
        checkButtons[3].SetActive(false);

        check1 = false;
        check2 = false;
        check3 = false;
        check4 = false;
        check5 = false;
        check6 = false;

        Statements();
    }

    public void Statements()
    {
        //Round 1 of Statements
        statements[0].text = "More likely to ask how much? how many? how often? to what extent?"; //incorrect
        statements[1].text = "More concerned with analysing and summarising data"; //incorrect
        statements[2].text = "More concerned with testing theories"; //incorrect
        statements[3].text = "More concerned with interpretation of data"; //correct
        statements[4].text = "More concerned with theory building"; //correct
        statements[5].text = "More likely to ask why? how? in what way?"; //correct
        //Round 2 of Statements
        statements[6].text = "Presented in numerical form and interpreted using the correct statistical analysis for the data"; //incorrect
        statements[7].text = "Typically adopts a deductive approach"; //incorrect
        statements[8].text = "Adopts a subjective approach"; //correct
        statements[9].text = "Typically adopts an inductive approach"; //correct
        statements[10].text = "Adopts an objective approach"; //incorrect
        statements[11].text = "Presented in a variety of forms and interpreted based on a variety of underlying philosophies and traditions from a variety of different disciplines"; //correct
        //Round 3 of Statements
        statements[12].text = "Deals with descriptions"; //correct
        statements[13].text = "Deals with phenomena that must be measured"; //incorrect
        statements[14].text = "Data can be observed, measured and quantified"; //incorrect
        statements[15].text = "Deals with numbers"; //incorrect
        statements[16].text = "Deals with phenomena that cannot be measured, only experienced"; //correct
        statements[17].text = "Data can be observed but not measured"; //correct
        //Round 4 of Statements
        statements[18].text = "Data analysis involves statistical testing"; //incorrect
        statements[19].text = "Examples of analysis include grounded theory, phenomenological analysis, thematic analysis"; //correct
        statements[20].text = "Data analysis involves coding"; //correct
        statements[21].text = "Looks at the meaning individuals or groups ascribe to a social or human problem"; //correct
        statements[22].text = "Examples of analysis would include chi-square, t-test, correlation"; //incorrect
        statements[23].text = "Involves the study of relationships between variables"; //incorrect
    }

    public void Check()
    {
        isAllowedToTrigger = true;
        checkPressed = true;
        Timer();
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

    IEnumerator Timer()
    {
        yield return new WaitForSeconds(3);
        isAllowedToTrigger = false;
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (isAllowedToTrigger)
        {
            if (collision.gameObject.name == "Item1-1")
            {
                statements[0].GetComponent<Text>().color = Color.red; // change colour to red
            }

            if (collision.gameObject.name == "Item1-2")
            {
                statements[1].GetComponent<Text>().color = Color.red; // change colour to red
            }

            if (collision.gameObject.name == "Item1-3")
            {
                statements[2].GetComponent<Text>().color = Color.red; // change colour to red
            }

            if (collision.gameObject.name == "Item1-4")
            {
                statements[3].GetComponent<Text>().color = Color.green; //change colour to green
                answer4 = true;
            }

            if (collision.gameObject.name == "Item1-5")
            {
                statements[4].GetComponent<Text>().color = Color.green; //change colour to green
                answer5 = true;
            }

            if (collision.gameObject.name == "Item1-6")
            {
                statements[5].GetComponent<Text>().color = Color.green; //change colour to green
                answer6 = true;
            }
        }

        if (isAllowedToTrigger2)
        {
            //Second set of Statements
            if (collision.gameObject.name == "Item2-1")
            {
                statements[6].GetComponent<Text>().color = Color.red; //change colour to red
            }

            if (collision.gameObject.name == "Item2-2")
            {
                statements[7].GetComponent<Text>().color = Color.red; //change colour to red
            }

            if (collision.gameObject.name == "Item2-3")
            {
                statements[8].GetComponent<Text>().color = Color.green; //change colour to green
                answer14 = true;
            }

            if (collision.gameObject.name == "Item2-4")
            {
                statements[9].GetComponent<Text>().color = Color.green; //change colour to green
                answer12 = true;
            }

            if (collision.gameObject.name == "Item2-5")
            {
                statements[10].GetComponent<Text>().color = Color.red; //change colour to red
            }

            if (collision.gameObject.name == "Item2-6")
            {
                statements[11].GetComponent<Text>().color = Color.green; //change colour to green
                answer13 = true;
            }
        }

        if (isAllowedToTrigger3)
        {
            //Third set of Statements
            if (collision.gameObject.name == "Item3-1")
            {
                statements[12].GetComponent<Text>().color = Color.green; //change colour to green
                answer19 = true;
            }

            if (collision.gameObject.name == "Item3-2")
            {
                statements[13].GetComponent<Text>().color = Color.red; //change colour to red
            }

            if (collision.gameObject.name == "Item3-3")
            {
                statements[14].GetComponent<Text>().color = Color.red; //change colour to red
            }

            if (collision.gameObject.name == "Item3-4")
            {
                statements[15].GetComponent<Text>().color = Color.red; //change colour to red
            }

            if (collision.gameObject.name == "Item3-6")
            {
                statements[16].GetComponent<Text>().color = Color.green; //change colour to green
                answer20 = true;
            }

            if (collision.gameObject.name == "Item3-7")
            {
                statements[17].GetComponent<Text>().color = Color.green; //change colour to green
                answer21 = true;
            }
        }

        if (isAllowedToTrigger4)
        {
            //Fourth set of Statements
            if (collision.gameObject.name == "Item4-1")
            {
                statements[18].GetComponent<Text>().color = Color.red; //change colour to red
            }

            if (collision.gameObject.name == "Item4-2")
            {
                statements[19].GetComponent<Text>().color = Color.green; //change colour to green
                answer26 = true;
            }

            if (collision.gameObject.name == "Item4-3")
            {
                statements[20].GetComponent<Text>().color = Color.green; //change colour to green
                answer27 = true;
            }

            if (collision.gameObject.name == "Item4-4")
            {
                statements[21].GetComponent<Text>().color = Color.green; //change colour to green
                answer28 = true;
            }

            if (collision.gameObject.name == "Item4-5")
            {
                statements[22].GetComponent<Text>().color = Color.red; //change colour to red
            }

            if (collision.gameObject.name == "Item4-7")
            {
                statements[23].GetComponent<Text>().color = Color.red; //change colour to red
            }
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        for (int i = 0; i < statements.Length; i++)
        {
            statements[i].GetComponent<Text>().color = Color.black; // change colour back to black

            if (answer4) { answer4 = false; }
            if (answer5) { answer5 = false; }
            if (answer6) { answer6 = false; }
            if (answer12) { answer12 = false; }
            if (answer13) { answer13 = false; }
            if (answer14) { answer14 = false; }
            if (answer19) { answer19 = false; }
            if (answer20) { answer20 = false; }
            if (answer21) { answer21 = false; }
            if (answer26) { answer26 = false; }
            if (answer27) { answer27 = false; }
            if (answer28) { answer28 = false; }
        }
    }
}
