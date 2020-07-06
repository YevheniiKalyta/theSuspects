using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonClick : MonoBehaviour
{
    public Sprite[] sprites;
    public int state = 0, position, childOf;
   
    public string imageName;
    // Start is called before the first frame update
    void Start()
    {
        ChangeImage();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeImage()
    {
        state++;
        if (state > 3) state = 0;
        if (state == 3) this.GetComponent<Image>().color = Color.yellow;
        if (state == 2) this.GetComponent<Image>().color = Color.green;
        if (state == 1) this.GetComponent<Image>().color = Color.white;
        if (state == 0) this.GetComponent<Image>().color = Color.red;

    }

    public void MakeArray(Sprite[] inputSprites)
    {
        sprites = inputSprites;
    }


}
