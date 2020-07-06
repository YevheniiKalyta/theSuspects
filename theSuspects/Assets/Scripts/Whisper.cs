using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Whisper : MonoBehaviour
{
    public int rand, truth;
    public Text yourText, nextText;
    public Character character;
    public Character rightNeighbor;
    public NewCharSetup setup;
    public List<GameObject> others;
    public int a, cooldown;
    public GameObject truthometerImage;
    public Sprite[] tomImages;

    public string[] cooldownStrings = new string[] {"I don't want to talk to you anymore...","Won't tell you anything..."};

    // Start is called before the first frame update
    void Start()
    {
        a = transform.GetSiblingIndex() + 1;
        others.AddRange(GameObject.FindGameObjectsWithTag("character"));
        others.Remove(this.gameObject);
        character = this.GetComponent<Character>();

        if (a >= others.Count+1)
        {
            rightNeighbor = this.transform.parent.GetChild(0).GetComponent<Character>();
        }
        else rightNeighbor = this.transform.parent.GetChild(a).GetComponent<Character>();
        InvokeRepeating("Minusing", 0f, 15f);
    }


    void Minusing()
    {
        if (cooldown > 0)
        {
            cooldown--;
        }
        else cooldown = 0;
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void Say()
    {
        cooldown++;
        yourText.text = null;
        nextText.text = null;
        truth = 0;
        int trueCount = 0;

        rand = Random.Range(0, 101);
        if (rand <= 10) trueCount = 0;
        if (rand > 10 && rand <= 40) trueCount = 1;
        if (rand > 40 && rand <= 70) trueCount = 2;
        if (rand > 70 && rand <= 100) trueCount = 3;

        yourText.gameObject.GetComponentInChildren<SpriteRenderer>().enabled = true;

        int lastRandProperty = 5000;


        if (cooldown < 4)
        {
            for (int i = 0; i < 2; i++)
            {

                int randProperty = 0;
                randProperty = Random.Range(0, 3);

                if (randProperty == lastRandProperty)
                {
                    i--;

                }
                else
                {
                    if (randProperty == 0)
                    {
                        rand = Random.Range(0, 2);
                        if ((trueCount == 4 - i) || (rand == 1 && trueCount > 0))
                        {
                            yourText.text += "It was at " + character.naming + ". \n";
                            truth++;
                            trueCount--;
                        }
                        else
                        {
                            int randomizer = Random.Range(0, others.Count);

                            {
                                yourText.text += "It was at " + others[randomizer].GetComponent<Character>().naming + ". \n";
                            }
                        }
                    }

                    if (randProperty == 1)
                    {
                        if ((trueCount >= 4 - i) || (rand == 1 && trueCount > 0))
                        {

                            yourText.text += "I was at the " + character.job + ". \n";
                            truth++;
                            trueCount--;
                        }
                        else
                        {
                            int randomizer = Random.Range(0, others.Count);

                            {
                                yourText.text += "I was at the " + others[randomizer].GetComponent<Character>().job + ". \n";
                            }
                        }
                    }

                    if (randProperty == 2)
                    {
                        if ((trueCount >= 4 - i) || (rand == 1 && trueCount > 0))
                        {

                            yourText.text += "I've had a " + character.hobby + ". \n";
                            truth++;
                            trueCount--;
                        }
                        else
                        {
                            int randomizer = Random.Range(0, others.Count);

                            {
                                yourText.text += "I've had a " + others[randomizer].GetComponent<Character>().hobby + ". \n";
                            }
                        }
                    }
                }
                lastRandProperty = randProperty;
            }

           

            lastRandProperty = 5000;
            nextText.gameObject.GetComponentInChildren<SpriteRenderer>().enabled = true;

            for (int i = 0; i < 2; i++)
            {

                int randProperty = 0;
                randProperty = Random.Range(0, 3);

                if (randProperty == lastRandProperty)
                {
                    i--;


                }
                else
                {
                    if (randProperty == 0)
                    {
                        rand = Random.Range(0, 2);
                        if ((trueCount >= 2 - i) || (rand == 1 && trueCount > 0))
                        {
                            nextText.text += "He was at " + rightNeighbor.naming + ". \n";
                            truth++;
                            trueCount--;
                        }
                        else
                        {
                            int randomizer = Random.Range(0, others.Count);

                            {
                                others.Add(this.gameObject);
                                others.Remove(rightNeighbor.gameObject);
                                nextText.text += "He was at " + others[randomizer].GetComponent<Character>().naming + ". \n";
                                others.Remove(this.gameObject);
                                others.Add(rightNeighbor.gameObject);
                            }
                        }
                    }

                    if (randProperty == 1)
                    {
                        if ((trueCount >= 2 - i) || (rand == 1 && trueCount > 0))
                        {

                            nextText.text += "He was at the " + rightNeighbor.job + ". \n";
                            truth++;
                            trueCount--;
                        }
                        else
                        {
                            int randomizer = Random.Range(0, others.Count);

                            {
                                others.Add(this.gameObject);
                                others.Remove(rightNeighbor.gameObject);
                                nextText.text += "He was at the " + others[randomizer].GetComponent<Character>().job + ". \n";
                                others.Remove(this.gameObject);
                                others.Add(rightNeighbor.gameObject);
                            }
                        }
                    }

                    if (randProperty == 2)
                    {
                        if ((trueCount >= 2 - i) || (rand == 1 && trueCount > 0))
                        {

                            nextText.text += "He's had a " + rightNeighbor.hobby + ". \n";
                            truth++;
                            trueCount--;
                        }
                        else
                        {
                            int randomizer = Random.Range(0, others.Count);

                            {
                                others.Add(this.gameObject);
                                others.Remove(rightNeighbor.gameObject);
                                nextText.text += "He's had a " + others[randomizer].GetComponent<Character>().hobby + ". \n";
                                others.Remove(this.gameObject);
                                others.Add(rightNeighbor.gameObject);
                            }
                        }
                    }
                }

                lastRandProperty = randProperty;
            }
            
            
            int trus = 0;
            trus = (truth * 100 / 4) / 25;
            truthometerImage.GetComponent<SpriteRenderer>().sprite = tomImages[trus];
            truthometerImage.GetComponent<Animation>().Play();
            


            var newY = yourText.gameObject.GetComponent<RectTransform>().transform.position;
            newY.x = this.gameObject.transform.position.x;
            yourText.gameObject.GetComponent<RectTransform>().transform.position = newY;

            newY = nextText.gameObject.GetComponent<RectTransform>().transform.position;
            newY.x = rightNeighbor.gameObject.transform.position.x;
            nextText.gameObject.GetComponent<RectTransform>().transform.position = newY;



            setup.clickCount++;
        }
        else StartCoroutine(Cooldown());

    }


    public IEnumerator Cooldown()
    {
        this.GetComponent<BoxCollider2D>().enabled = false;
        Color sourceColor;
        float h, s, v;
        sourceColor = this.transform.GetChild(12).GetComponentInChildren<SpriteRenderer>().color;
        Color.RGBToHSV(sourceColor,out h,out s,out v);

        nextText.gameObject.GetComponentInChildren<SpriteRenderer>().enabled = false;

        yourText.text = cooldownStrings[Random.Range(0, cooldownStrings.Length)];
        for (float i = 1; i > 0.5f; i-=0.01f)
        {
            this.GetComponentInChildren<SpriteRenderer>().color = Color.HSVToRGB(h, s, i);
            yield return new WaitForSeconds(0.007f);
        }
       
        
        yield return new WaitForSeconds(10);
        cooldown = 0;
        this.GetComponent<BoxCollider2D>().enabled = true ;
        for (float i = 0.5f; i <= 1f; i += 0.01f)
        {
            this.GetComponentInChildren<SpriteRenderer>().color = Color.HSVToRGB(h, s, i);
            yield return new WaitForSeconds(0.007f);
        }
    }
    

}
