using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

public class Post : MonoBehaviour
{
    // Start is called before the first frame update
    public Sprite avatar;
    public string name;
    public DateTime dateOfPost;
    public string content;
    void Start()
    {
        dateOfPost = new DateTime(2020, 01, 15);
    }

    // Update is called once per frame
    void Update()
    {
        if (avatar !=  null ) {
            gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).GetComponent<Image>().sprite = avatar;
        }
        if (name != null)
        {
            gameObject.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = name;
        }
        if (content != null)
        {
            gameObject.transform.GetChild(3).transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = content;
        }


        gameObject.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = dateOfPost.Day + "/" + dateOfPost.Month + "/" + dateOfPost.Year + " at : " + dateOfPost.ToShortTimeString();

    }
}
