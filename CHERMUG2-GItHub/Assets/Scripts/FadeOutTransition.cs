using System.Collections;
using UnityEngine;
using UnityEngine.UI;

//////////////////////////////////////////////////<summary>///////////////////////////////////////////////////// 
///                                   University of the West of Scotland                                     ///
///                               -------------------------------------------                                ///  
/// Script is attached to the FadeScreen GameObject (child of the TransitionCanvas)                          ///
///                                                                                                          ///
/// The scenes it is in should be the one AFTER the scenes that have the FadeInTransition in it.             ///
/// Ensure the FadeScreen is set at 1f alpha in the Inspector at the start of the level.                     ///   
///                                                                                                          ///
/// This fades the transition image from 1f to 0f alpha (making it go transparent) when the scene loads.     ///
///                                                                                                          ///
//////////////////////////////////////////////////</summary>////////////////////////////////////////////////////

public class FadeOutTransition : MonoBehaviour
{
    public Image fadeScreen;
    public int level;

    public void FadeImageOut()
    {
        StartCoroutine(FadeOut());
    }

    //Fades the loading screen out (after the new scene has loaded)
    IEnumerator FadeOut()
    {
        for (float alpha = 1f; alpha > -1f; alpha -= Time.deltaTime)
        {
            fadeScreen.color = new Color(fadeScreen.color.r, fadeScreen.color.b, fadeScreen.color.g, alpha);
            yield return null;
        }
    }
}
