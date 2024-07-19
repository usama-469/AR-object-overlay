using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrolController : MonoBehaviour
{
    public GameObject scrollBar;
    Vector3 currentPosition = new Vector3(0f, 0f, 0f);
    Vector3 newPosition = new Vector3(0f, 0f, 0f);
    public bool scrollVisibility = false;

    public void buildingButtonPress()
    {
        scrollVisibility = !scrollVisibility;           //toggle button

        if (scrollVisibility)
        {
            scrollBar.SetActive(true);
            currentPosition = scrollBar.transform.position;
            newPosition = currentPosition;
            newPosition.y = 0.0f;                       //show it

            StartCoroutine(scrollAnim_Up(scrollBar));

        }

        else 
        {

            currentPosition = scrollBar.transform.position;
            newPosition = currentPosition;
            newPosition.y = -213.55f;                     
            StartCoroutine(scrollAnim_Down(scrollBar));
            scrollBar.SetActive(false);         //hide it
        }


    }

    private IEnumerator scrollAnim_Up(GameObject scroll)
    {
        while (Vector3.Distance(currentPosition, newPosition) > 0.1)
        {
           // Debug.Log("scroll bar ---- moving up" + Vector3.Distance(currentPosition, newPosition));
            scroll.transform.position = Vector3.MoveTowards(scroll.transform.position, newPosition, Time.deltaTime * 5000);         //slow moving script
            yield return new WaitForSeconds(0.02f);
        }
        yield return null;


    }

    private IEnumerator scrollAnim_Down(GameObject scroll)
    {
        while (Vector3.Distance(currentPosition, newPosition) > 0.1)
        {
           // Debug.Log("scroll bar ---- moving down" + Vector3.Distance(currentPosition, newPosition));
            scroll.transform.position = Vector3.MoveTowards(scroll.transform.position, newPosition, Time.deltaTime * 5000);         //slow moving script
            yield return new WaitForSeconds(0.02f);
        }

        yield return null;


    }


}
