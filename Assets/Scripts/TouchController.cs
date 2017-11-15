using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Zenject;

public class TouchController {

    [Inject]
    private FigureController _figureController;

    private GameObject tmp;
    private Vector3 tmpVector = Vector3.zero;

    public void MoveObjects()
    {
#if UNITY_EDITOR
        if (Input.GetMouseButton(0))
        {
            Vector3 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            worldPoint.z = 0;
            RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector3.zero);

            if (hit.transform != null && hit.collider.CompareTag("Figure") && tmp == null)
            {
                tmp = hit.transform.gameObject;
                tmp.transform.position = hit.transform.position;
                tmp.transform.parent.localScale = new Vector3(1, 1, 1);
                //Debug.Log(tmp.transform.parent.position);
            }

            else if (tmp != null)
            {
                tmp.transform.parent.position = worldPoint - tmp.transform.parent.Find("Pivot").gameObject.transform.localPosition / 1.5f;
            }
        }

        else if (Input.GetMouseButtonUp(0))
        {
            tmp = null;
        }

#else
        if (Input.touchCount == 1)
        {
            Vector3 worldPoint = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
            worldPoint.z = 0;
            RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector3.zero);

            switch (Input.GetTouch(0).phase)
            {
                case (TouchPhase.Began):
                    if (hit.transform != null && hit.collider.CompareTag("Figure") && tmp == null)
                    {
                        tmp = hit.transform.gameObject;
                        tmp.transform.position = hit.transform.position;
                        tmp.transform.parent.localScale = new Vector3(1, 1, 1);
                        //Debug.Log(tmp.transform.parent.position);
                    }
                    break;
                case (TouchPhase.Moved):
                    if(tmp != null)
                        tmp.transform.parent.position = worldPoint - tmp.transform.parent.Find("Pivot").gameObject.transform.localPosition / 1.5f;
                    break;
                case (TouchPhase.Ended):
                    tmp = null;
                    break;
            }
        }
    }
#endif
    }

}
