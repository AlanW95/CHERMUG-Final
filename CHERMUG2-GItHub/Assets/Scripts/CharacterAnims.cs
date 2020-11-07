using UnityEngine;

//////////////////////////////////////////////////<summary>//////////////////////////////////////////////////// 
///                                   University of the West of Scotland                                    ///
///                               -------------------------------------------                               ///  
/// Script attached to the characters in all scenes with characters, except the NameEntry scene.            ///
/// NameEntry scene uses different animations (walk in and wave anims)                                      ///
///                                                                                                         ///
//////////////////////////////////////////////////</summary>///////////////////////////////////////////////////

public class CharacterAnims: MonoBehaviour
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
        CharacterAnimations();
    }

    public void CharacterAnimations()
    {
        switch (states)
        {
            default:
                break;
            //IDLE
            case 0:
                anim.SetInteger("Character_Anim", 0);
                break;
            //TALKING
            case 1:
                anim.SetInteger("Character_Anim", 1);
                break;
            //THUMBS UP
            case 2:
                anim.SetInteger("Character_Anim", 2);
                break;
            //SHAKE HEAD
            case 3:
                anim.SetInteger("Character_Anim", 3);
                break;
        }
    }

    //Called from the Animation Event on the Intro anim so that it automatically goes back to Idle at the end of the anim
    public void ResetToIdleAnim()
    {
        states = 0;
    }
}
