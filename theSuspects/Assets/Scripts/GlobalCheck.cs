using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlobalCheck : MonoBehaviour
{
    public NewCharSetup setup;
    public int truthCounter,ansCounter;
    public GameObject comics;
    public GameObject truthometerText, notRight;
    private bool firstText=false; 

    public void Checking()
    {
        //Debug.Log(setup.buttonsList.Count);
        

        PreChecking();
        
        
        
            truthCounter = 0;
            foreach (GameObject button in setup.buttonsList)
            {
                ButtonClick click = button.GetComponent<ButtonClick>();
                if (click.position >= 0 && click.position < 4 && click.state == 2 && setup.chars[click.childOf].GetComponent<Character>().naming == click.imageName)
                {
                    
                    truthCounter++;
                    
                }
                if (click.position >= 4 && click.position < 8 && click.state == 2 && setup.chars[click.childOf].GetComponent<Character>().job == click.imageName)
                {
                    
                    truthCounter++;
                    
            }

                if (click.position >= 8 && click.position < 12 && click.state == 2 && setup.chars[click.childOf].GetComponent<Character>().hobby == click.imageName)
                {
                    
                    truthCounter++;
                   
            }

            }
            if (truthCounter == 12)
            {
                comics.SetActive(true);

            }
            if (truthCounter < 12)
            {
                StartCoroutine(NotRight());
            }
        


    }


    public void PreChecking()
    {
        ansCounter = 0;
        foreach (GameObject button in setup.buttonsList)
        {
            ButtonClick click = button.GetComponent<ButtonClick>();
            if (click.position >= 0 && click.position < 4 && click.state == 2)
            {
                ansCounter++;
            }
            if (click.position >= 4 && click.position < 8 && click.state == 2 )
            {

                ansCounter++;
            }

            if (click.position >= 8 && click.position < 12 && click.state == 2 )
            {

                ansCounter++;
            }
        }
        if (ansCounter > 3*setup.characters.Length || ansCounter < 3 * setup.characters.Length)
        {
            StartCoroutine(Warning());
        }
    }

    public IEnumerator Warning()
    {
        firstText = true;
        truthometerText.SetActive(true);

        yield return new WaitForSeconds(5);

        truthometerText.SetActive(false);
        firstText = false;
    }
    public IEnumerator NotRight()
    {
        if (!firstText)
        {
            notRight.SetActive(true);

            yield return new WaitForSeconds(5);

            notRight.SetActive(false);
        }
    }




}
