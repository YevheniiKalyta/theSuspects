using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class NewCharSetup : MonoBehaviour
{
    //public List<string> names1 = new List<string>();

    public string[] names = new string[] { "20:00", "21:00", "22:00" , "23:00", "00:00" };
    public string[] jobs = new string[] { "Bar", "Hospital", "Beach", "Club", "Airport" };
    public string[] hobbys = new string[] { "Knife", "Hammer", "Sword", "Gun", "Bomb" };
    public string[] alibis = new string[] { "Cinema", "Home", "Parents", "Whore", "Hospital" };
    public string[] cars = new string[] { "Blue", "Yellow", "Black", "Grey", "Green" };
    List<string> sourceNames = new List<string>();
    public List<int> orderGenerator;
    public List<GameObject> buttonsList;
    private int rand;
    public GameObject[] characters;
    public float truthometer;
    public int sumCheckingLR;
    public GameObject score;
    public GameObject buttonPrefab;
    public Transform canvas;
    
    public Sprite[] images;
    public Dictionary<string,Sprite> pairs = new Dictionary<string, Sprite>();
    public List<GameObject> chars;

    public int clickCount = 0 ;


    public void Setup()
    {
        int b = 0;
       
       

        for (int i = 0; i < characters.Length; i++)
        {
            orderGenerator.Add(i);
        }
        foreach (GameObject character in characters)
        {
            Character crack = character.GetComponent<Character>();

            rand = UnityEngine.Random.Range(0, names.Length);
            crack.naming = names[rand];
            names[rand] = names[names.Length - 1];
            Array.Resize(ref names, names.Length - 1);
            rand = UnityEngine.Random.Range(0, jobs.Length);
            crack.job = jobs[rand];
            jobs[rand] = jobs[jobs.Length - 1];
            Array.Resize(ref jobs, jobs.Length - 1);
            rand = UnityEngine.Random.Range(0, hobbys.Length);
            crack.hobby = hobbys[rand];
            hobbys[rand] = hobbys[hobbys.Length - 1];
            Array.Resize(ref hobbys, hobbys.Length - 1);
            rand = UnityEngine.Random.Range(0, alibis.Length);
            crack.alibi = alibis[rand];
            alibis[rand] = alibis[alibis.Length - 1];
            Array.Resize(ref alibis, alibis.Length - 1);
            rand = UnityEngine.Random.Range(0, cars.Length);
            crack.car = cars[rand];
            cars[rand] = cars[cars.Length - 1];
            Array.Resize(ref cars, cars.Length - 1);
            rand = UnityEngine.Random.Range(0, orderGenerator.Count);
            crack.trueOrder = orderGenerator[rand];

            orderGenerator.RemoveAt(rand);

            b = 0;
            foreach(Transform children in character.transform.GetComponentsInChildren<Transform>())
            {
                if (children != character.transform && children.GetSiblingIndex() < 12 )
                {
                    
                    GameObject button = Instantiate(buttonPrefab, character.transform.position, Quaternion.identity);
                    button.transform.SetParent(canvas);
                    button.transform.localScale = Vector3.one;
                    button.transform.position = children.transform.position;
                    button.name = "button" + children.transform.parent.GetSiblingIndex().ToString()+b.ToString();
                    button.GetComponent<ButtonClick>().position = b;
                    button.GetComponent<ButtonClick>().childOf = children.transform.parent.GetSiblingIndex();

                  
                    b++;
                    buttonsList.Add(button);
                    
                    
                }
              
            }

        }
        Imaging();



    }

    

    private void Update()
    {
        

    }

    public void SumCheck(Character character)
    {
        sumCheckingLR = 0;
        score.GetComponent<Text>().text = null;

        sumCheckingLR = character.GetComponent<Draggable>().checkLeft + character.GetComponent<Draggable>().checkRight;
        string textToWrite = ((sumCheckingLR * 100 / 4)).ToString();
        score.GetComponent<Text>().text += " " + textToWrite;

        // score.GetComponent<Text>().text = sumCheckingLR.ToString();


    }

    public void DictionaryCreation()
    {
        
        for (int i = 0; i < names.Length; i++)
        {
            //Character crack = characters[i].GetComponent<Character>();
            pairs.Add(names[i], images[i]);
            
        }
        for (int i = 0; i < jobs.Length; i++)
        {
            //Character crack = characters[i].GetComponent<Character>();
            pairs.Add(jobs[i], images[i+names.Length]);

        }
        for (int i = 0; i < hobbys.Length; i++)
        {
            //Character crack = characters[i].GetComponent<Character>();
            pairs.Add(hobbys[i], images[i + names.Length+jobs.Length]);

        }
    }

    public void Imaging()
    {

        List<GameObject> guys = new List<GameObject>();
        List<string> namings = new List<string>();
        

        guys.AddRange(characters);
        for (int i = 0; i < characters.Length; i++)
        {
            namings.Add(characters[i].GetComponent<Character>().naming);
        }

        for (int i = 0; i < sourceNames.Count; i++)
        {
            if (!namings.Contains(sourceNames[i]))
            {
                sourceNames.RemoveAt(i);
            }
        }
        
        


                for (int i = 0; i < 4; i++)           //ПОЛНАЯ ПОЕБЕНЬ 12 заменить бы
                {
                    int r = UnityEngine.Random.Range(0, guys.Count);

                    foreach (GameObject button in buttonsList)
                    {
                        int pos = button.GetComponent<ButtonClick>().position;
                        if (pos == i)
                        {                  
                            button.GetComponent<Image>().sprite = pairs[sourceNames[i]];
                            button.GetComponent<ButtonClick>().imageName = sourceNames[i];
                        }
                    }

                guys.RemoveAt(r);
                }


         guys.AddRange(characters);
                for (int i = 4; i < 8; i++)           //ПОЛНАЯ ПОЕБЕНЬ 12 заменить бы
                {
                    int r = UnityEngine.Random.Range(0, guys.Count);

                    foreach (GameObject button in buttonsList)
                    {
                        int pos = button.GetComponent<ButtonClick>().position;
                        if (pos == i)
                        {
                            button.GetComponent<Image>().sprite = pairs[guys[r].GetComponent<Character>().job];
                            button.GetComponent<ButtonClick>().imageName = guys[r].GetComponent<Character>().job;

                        }
                    }

            guys.RemoveAt(r);
        }


        guys.AddRange(characters);
        for (int i = 8; i < 12; i++)           //ПОЛНАЯ ПОЕБЕНЬ 12 заменить бы
                {
                    int r = UnityEngine.Random.Range(0, guys.Count);

                    foreach (GameObject button in buttonsList)
                    {
                        int pos = button.GetComponent<ButtonClick>().position;
                        if (pos == i)
                        {
                            button.GetComponent<Image>().sprite = pairs[guys[r].GetComponent<Character>().hobby];
                            button.GetComponent<ButtonClick>().imageName = guys[r].GetComponent<Character>().hobby;
                        }
                    }

            guys.RemoveAt(r);
        }
            
















        
        
    }

    private void Start()
    {
        
        sourceNames.AddRange(names);
        DictionaryCreation();
        Setup();
        chars.AddRange(characters);
        Debug.Log(chars[1]);
    }

    public void Reload()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }

    public void Leave()
    {
        Application.Quit();
    }


}
