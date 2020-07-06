using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    public BoxCollider2D guy1, guy2, guy3, guy4;
    public Text tutText;
    public NewCharSetup setup;
    public int counter;
    public Queue<string> tuts = new Queue<string>();
    // Start is called before the first frame update
    void Start()
    {
        guy1.enabled = true;
        guy2.enabled = true;
        guy3.enabled = true;
        guy4.enabled = true;

        counter=setup.clickCount;
       
        tuts.Enqueue("Ok, now look at the upper right corner.This is your Truth - o - meter! It shows how many percent of the truth does respondent say!    <color=green> Click here to continue...</color> ");
        tuts.Enqueue("Your goal is to find out all the details of the crime for each suspect and mark it with green icons under them...      <color=green>Click here to continue...</color>");
        tuts.Enqueue("When you're done - press the red button on the Truth-o-meter to check your results! Good luck!     <color=green>Click here to close...</color>");
    }

    // Update is called once per frame
    void Update()
    {
        if (counter < setup.clickCount)
        {
            tutText.text = tuts.Dequeue();
            this.GetComponentInChildren<BoxCollider2D>().enabled = true;
            counter = 9000;
        }


        if (Input.GetMouseButtonDown(0))
        {
           
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);
            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);

            if (tuts.Count == 0)
            {
                this.gameObject.SetActive(false);
            }
            else if (hit.collider == this.GetComponentInChildren<BoxCollider2D>())
            {
                
                
                
                    StartCoroutine(BoxDisabler());
                    tutText.text = tuts.Dequeue();
                    
                
                

            }
        }


    }

    public IEnumerator BoxDisabler()
    {
        this.GetComponentInChildren<BoxCollider2D>().enabled=false;
        yield return new WaitForSeconds(0.3f);
        this.GetComponentInChildren<BoxCollider2D>().enabled = true;
    }



}
