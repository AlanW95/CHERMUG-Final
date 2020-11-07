using UnityEngine;

public class FeedbackPopup : MonoBehaviour
{
    public Animator correctAnim;
    public Animator incorrectAnim;
    public int correct_states;
    public int incorrect_states;

    // Update is called once per frame
    void Update()
    {
        AnimationCorrectStates();
        AnimationIncorrectStates();
    }

    public void AnimationCorrectStates()
    {
        switch (correct_states)
        {
            default:
                break;
            case 0:
                break;
            case 1:
                //Correct UI pops in
                correctAnim.SetInteger("States", 1);
                break;
            case 2:
                //Correct UI pops out
                correctAnim.SetInteger("States", 2);
                break;
        }
    }
    public void AnimationIncorrectStates()
    {
        switch (incorrect_states)
        {
            default:
                break;
            case 0:
                break;
            case 1:
                //UI pops in
                incorrectAnim.SetInteger("States", 1);
                break;
            case 2:
                //UI pops out
                incorrectAnim.SetInteger("States", 2);
                break;
        }
    }
}
