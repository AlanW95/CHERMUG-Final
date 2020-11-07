using UnityEngine;

//////////////////////////////////////////////////<summary>//////////////////////////////////////////////////// 
///                                   University of the West of Scotland                                    ///
///                               -------------------------------------------                               ///  
/// Script attached to the characters in the NameEntry scene.                                               ///
///                                                                                                         ///
//////////////////////////////////////////////////</summary>///////////////////////////////////////////////////

public class NE_Animations : MonoBehaviour
{
    public Animator anim;
    public int states;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        states = 0;
    }

    // Update is called once per frame
    void Update()
    {
        CharacterAnims();
    }

    public void CharacterAnims()
    {
        switch (states)
        {
            default:
                break;
            //INTO ANIM
            case 0:
                anim.SetInteger("Character_Anim", 0);
                break;
            //IDLE
            case 1:
                anim.SetInteger("Character_Anim", 1);
                break;
        }
    }

    //Called from the Animation Event on the Intro anim so that it automatically goes back to Idle at the end of the anim
    public void ResetToIdleAnim()
    {
        states = 1;
    }
}
