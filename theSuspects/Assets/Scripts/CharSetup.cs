using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class CharSetup : MonoBehaviour
{
    //public List<string> names1 = new List<string>();
 
    public string[] names = new string[] {"Matt","John","Robert","Igor","Ivan"};
    public string[] jobs = new string[] { "Animator", "Builder", "Doctor","Programmer","Lawyer" };
    public string[] hobbys = new string[] { "Music", "Fishing", "Sing", "Dance","Paint" };
    public string[] alibis = new string[] { "Cinema", "Home", "Parents", "Whore","Hospital" };
    public string[] cars = new string[] { "Blue", "Yellow", "Black", "Grey","Green" };
    public string[] namesSource, jobsSource, hobbysSource, alibisSource, carsSource;
    public List<int> orderGenerator;
    private int rand;
    public GameObject[] characters;
    public float truthometer;
    public int sumCheckingLR;
    public GameObject score;
  
    
    public void Setup()
    {
        characters = GameObject.FindGameObjectsWithTag("character");
        namesSource = names;
        jobsSource = jobs;
        hobbysSource = hobbys;
        alibisSource = alibis;
        carsSource = cars;

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
            character.GetComponent<Draggable>().trueLeftNeighbor = crack.trueOrder - 1;
            character.GetComponent<Draggable>().trueRightNeighbor = crack.trueOrder + 1;
            if (character.GetComponent<Draggable>().trueLeftNeighbor < 0) character.GetComponent<Draggable>().trueLeftNeighbor = characters.Length - 1;
            if (character.GetComponent<Draggable>().trueRightNeighbor > characters.Length - 1) character.GetComponent<Draggable>().trueRightNeighbor = 0;

            orderGenerator.RemoveAt(rand);

        }


    }

    private void Start()
    {
        
        Setup();
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


}
