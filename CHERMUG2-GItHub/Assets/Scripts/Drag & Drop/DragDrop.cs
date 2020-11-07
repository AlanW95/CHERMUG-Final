using UnityEngine;

//////////////////////////////////////////////////<summary>////////////////////////////////////////////////////// 
///                                   University of the West of Scotland                                      ///
///                                 -------------------------------------------                               ///  
/// Script is attached to each of the draggable GameObjects in the DragDrop Quantitative VS Qualitative scene.///
///                                                                                                           ///
/// Each draggable item needs to be tagged as Draggable in the Inspector.                                     /// 
///                                                                                                           ///  
//////////////////////////////////////////////////</summary>/////////////////////////////////////////////////////

public class DragDrop : MonoBehaviour
{
    private bool draggingObject = false;
    private GameObject draggedObject;
    private Vector2 touchOffset;

    void Update()
    {
        if (HasInput)
        {
            DragObject();
        }
        else
        {
            if (draggingObject)
            {
                DropObject();
            }             
        }
    }

    Vector2 CurrentTouchPosition
    {
        get
        {
            Vector2 inputPos;
            inputPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            return inputPos;
        }
    }

    private void DragObject()
    {
        var inputPosition = CurrentTouchPosition;

        if (draggingObject)
        {
            draggedObject.transform.position = inputPosition + touchOffset;
        }
        else
        {
            RaycastHit2D[] touches = Physics2D.RaycastAll(inputPosition, inputPosition, 0.5f);

            if (touches.Length > 0)
            {
                var hit = touches[0];
           
                if (hit.transform != null && hit.transform.CompareTag("Draggable"))
                {
                    draggingObject = true;
                    draggedObject = hit.transform.gameObject;
                    touchOffset = (Vector2)hit.transform.position - inputPosition;
                    draggedObject.transform.localScale = new Vector3(0.0095f, 0.0095f, 0.0095f);
                }
            }
        }       
    }

    private bool HasInput
    {
        get
        {
            return Input.GetMouseButton(0);
        }
    }

    void DropObject()
    {
        draggingObject = false;
        draggedObject.transform.localScale = new Vector3(0.009259259f, 0.009259259f, 0.009259259f);
    }
}
