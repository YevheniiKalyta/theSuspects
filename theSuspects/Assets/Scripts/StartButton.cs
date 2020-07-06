using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartButton : MonoBehaviour
{

    public GameObject tutorial;
    public SpriteRenderer background;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator Starting()
    {
        Color alpha;

        this.GetComponent<Button>().interactable = false;

        for (float i = 1; i > 0 ; i-=0.01f)
        {
            
            alpha = background.color;
            alpha.a = i;
            background.color = alpha;
            this.GetComponent<Image>().enabled = false ;
            this.GetComponentInChildren<Text>().color = alpha;
            yield return new WaitForSeconds(0.01f);
            
            
        }


        tutorial.SetActive(true);
        this.gameObject.transform.parent.parent.gameObject.SetActive(false);


    }

    public void StartClick()
    {
        StartCoroutine(Starting());
    }
}
