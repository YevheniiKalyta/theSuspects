﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class NonDraggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Transform parentToReturnTo = null;
    private CanvasGroup canvasGroup;
    GameObject placeHolder = null;
    public float trueLeftNeighbor, trueRightNeighbor;
    public CharSetup setup;
    public Character leftNeighbor = null;
    public Character rightNeighbor = null;

    public int currentIndex, leftCurrIndex, rightCurrIndex;
    public GameObject panel;





    private void Start()
    {


        canvasGroup = GetComponent<CanvasGroup>();
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        placeHolder = new GameObject();
        placeHolder.transform.parent = this.transform.parent;
        LayoutElement le = placeHolder.AddComponent<LayoutElement>();
        le.preferredWidth = this.GetComponent<LayoutElement>().preferredWidth;
        le.preferredHeight = this.GetComponent<LayoutElement>().preferredHeight;
        le.minWidth = this.GetComponent<LayoutElement>().preferredWidth;
        le.minHeight = this.GetComponent<LayoutElement>().preferredHeight;
        le.flexibleWidth = 0;
        le.flexibleHeight = 0;
        placeHolder.transform.SetSiblingIndex(this.transform.GetSiblingIndex());



        parentToReturnTo = this.transform.parent;
        this.transform.SetParent(this.transform.parent.parent);
        this.canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        // Debug.Log("drag");
        this.transform.position = eventData.position;

        int newSiblingIndex = parentToReturnTo.childCount;

        for (int i = 0; i < parentToReturnTo.childCount; i++)
        {
            if (eventData.position.x < parentToReturnTo.GetChild(i).transform.position.x)
            {
                newSiblingIndex = i;
                if (placeHolder.transform.GetSiblingIndex() < newSiblingIndex)
                {
                    newSiblingIndex--;
                }
                break;
            }
        }
        placeHolder.transform.SetSiblingIndex(newSiblingIndex);


    }

    public void OnEndDrag(PointerEventData eventData)
    {

        this.transform.SetParent(parentToReturnTo);
        this.canvasGroup.blocksRaycasts = true;
        this.transform.SetSiblingIndex(placeHolder.transform.GetSiblingIndex());
        Destroy(placeHolder);
        /*foreach(GameObject character in setup.characters)
        {
            if (character.name != "Character{150}" || character.name !=this.name)
            {
                character.GetComponent<Draggable>().CheckTheRules();
            }
        }*/

        CheckingRules(currentIndex);


    }

    private void CheckNeighbor()
    {

        if (this.name == "Player") currentIndex = 0;
        else currentIndex = this.transform.GetSiblingIndex() + 1;
        if (currentIndex > 0 && currentIndex < setup.characters.Length - 1)
        {
            leftCurrIndex = currentIndex - 1;
            rightCurrIndex = currentIndex + 1;
        }
        if (currentIndex == 0)
        {
            leftCurrIndex = setup.characters.Length - 1;
            rightCurrIndex = currentIndex + 1;
        }
        if (currentIndex == setup.characters.Length - 1)
        {
            leftCurrIndex = currentIndex - 1;
            rightCurrIndex = 0;
        }

        CheckingRules(currentIndex);
    }

    private void CheckingRules(int currentIndex)
    {


        if (leftCurrIndex == 0)
        {
            if (GameObject.Find("Player").GetComponent<Character>().trueOrder == trueLeftNeighbor)
            {
                bool once = true;
                if (once)
                {
                    Debug.Log(this.name + " yes LEFT");
                    once = false;

                }
            }
        }
        else
        {
            if (panel.transform.GetChild(leftCurrIndex - 1).GetComponent<Character>().trueOrder == trueLeftNeighbor)
            {
                bool once = true;
                if (once)
                {
                    Debug.Log(this.name + " yes LEFT");
                    once = false;

                }

            }
        }

        if (rightCurrIndex == 0)
        {
            if (GameObject.Find("Player").GetComponent<Character>().trueOrder == trueRightNeighbor)
            {
                bool once = true;
                if (once)
                {
                    Debug.Log(this.name + " yes LEFT");
                    once = false;

                }
            }
        }
        else
        {
            if (this.transform.parent.GetChild(rightCurrIndex - 1).GetComponent<Character>().trueOrder == trueRightNeighbor)
            {
                bool once = true;
                if (once)
                {
                    Debug.Log(this.name + " yes RIGHT");
                    once = false;

                }

            }


        }
    }



    private void CheckTheRules()
    {
        int index = this.transform.GetSiblingIndex();
        // Character leftNeighbor = null;
        //Character rightNeighbor = null;
        //Character currentChar = this.GetComponent<Character>();

        if (index > 0 && index < this.transform.parent.childCount - 2)
        {
            leftNeighbor = this.transform.parent.GetChild(index - 1).GetComponent<Character>();
            rightNeighbor = this.transform.parent.GetChild(index + 2).GetComponent<Character>();

        }
        else if (index == 0)
        {
            leftNeighbor = this.transform.parent.parent.GetComponentInChildren<Character>();
            rightNeighbor = this.transform.parent.GetChild(index + 2).GetComponent<Character>();
        }
        else if (index >= this.transform.parent.childCount - 2)
        {
            leftNeighbor = this.transform.parent.GetChild(index - 1).GetComponent<Character>();
            rightNeighbor = this.transform.parent.parent.GetComponentInChildren<Character>();

        }



        if (leftNeighbor.trueOrder == trueLeftNeighbor)
        {
            Debug.Log(gameObject.name + "Jest levo");
        }
        if (leftNeighbor.trueOrder == trueRightNeighbor)
        {
            Debug.Log(gameObject.name + "Jest polu levo");
        }
        if (rightNeighbor.trueOrder == trueRightNeighbor)
        {
            Debug.Log(gameObject.name + "Jest pravo");
        }
        if (rightNeighbor.trueOrder == trueLeftNeighbor)
        {
            Debug.Log(gameObject.name + "Jest polu pravo");
        }

        Debug.Log(gameObject.name + " " + leftNeighbor.naming);
        Debug.Log(gameObject.name + " " + rightNeighbor.naming);

    }

    private void Update()
    {
        transform.localScale = Vector3.MoveTowards
            (transform.localScale,
            new Vector3(Mathf.Abs(Screen.width / 2 - transform.position.x) * 4 / Screen.width + 1f, Mathf.Abs(Screen.width / 2 - transform.position.x) * 4 / Screen.width + 1f),
            1000 * Time.deltaTime);


        CheckNeighbor();
    }
}