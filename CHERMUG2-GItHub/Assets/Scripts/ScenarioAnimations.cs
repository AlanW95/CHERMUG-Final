using UnityEngine;

//////////////////////////////////////////////////<summary>//////////////////////////////////////////////////// 
///                                   University of the West of Scotland                                    ///
///                               -------------------------------------------                               ///  
/// Script is attached to the ResearchScenario child of the ResearchScenarioObj GameObject.                 ///
///                                                                                                         ///
//////////////////////////////////////////////////</summary>///////////////////////////////////////////////////

public class ScenarioAnimations : MonoBehaviour
{
    public Animator scenarioAnim;
    public int states;

    void Awake()
    {
        states = 0;
    }

    // Update is called once per frame
    void Update()
    {
        AnimationStates();
    }

    public void AnimationStates()
    {
        switch (states)
        {
            default:
                break;
            case 0:
                break;
            case 1:
                //Scenario down anim
                scenarioAnim.SetInteger("Scenario_States", 1);
                break;
            case 2:
                //Scenario up anim
                scenarioAnim.SetInteger("Scenario_States", 2);
                break;
        }
    }
}
