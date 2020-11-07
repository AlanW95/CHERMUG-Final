using UnityEngine;

//////////////////////////////////////////////////<summary>//////////////////////////////////////////////////// 
///                                   University of the West of Scotland                                    ///               
///                               -------------------------------------------                               ///  
/// Script is attached to the NameBar GameObject in the Instructions scene.                                 ///                  
///                                                                                                         ///
//////////////////////////////////////////////////</summary>///////////////////////////////////////////////////

public class NameTutBar : MonoBehaviour
{
    public Animator nameAnim;
    public int nameStates;

    // Start is called before the first frame update
    void Start()
    {
        nameStates = 0;
    }

    // Update is called once per frame
    void Update()
    {
        NameAnimationStates();
    }

    public void NameAnimationStates()
    {
        switch (nameStates)
        {
            default:
                break;
            case 0:
                //Idle
                nameAnim.SetInteger("UI_States", 0);
                break;
            case 1:
                //Slides UI bars into view
                nameAnim.SetInteger("UI_States", 1);
                break;
        }
    }
}
