using UnityEngine;

//////////////////////////////////////////////////<summary>//////////////////////////////////////////////////// 
///                                   University of the West of Scotland                                    ///
///                               -------------------------------------------                               ///  
/// Script is attached to the ScoreBar and NameBar GameObjects - child of the Bars GameObject Prefab.       ///
///                                                                                                         ///
//////////////////////////////////////////////////</summary>///////////////////////////////////////////////////

public class BarAnimations : MonoBehaviour
{
    public Animator scoreAnim;
    public Animator nameAnim;
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
        switch(states)
        {
            default:
                scoreAnim.SetInteger("UI_States", 0);
                nameAnim.SetInteger("UI_States", 0);
                break;
            case 0:
                //Idle
                scoreAnim.SetInteger("UI_States", 0);
                nameAnim.SetInteger("UI_States", 0);
                break;
            case 1:
                //Slides UI bars into view
                scoreAnim.SetInteger("UI_States", 1);
                nameAnim.SetInteger("UI_States", 1);
                break;
        }
    }
}
