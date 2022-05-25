using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChatAppContact : MonoBehaviour
{
    // Start is called before the first frame update
    public Sprite avatar;

    public string name;
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (this.avatar != null) {
            gameObject.transform.GetChild(2).transform.GetChild(0).GetComponent<Image>().sprite = this.avatar;
        }
        if (this.name != null) {
            gameObject.transform.GetChild(0).GetComponent<Text>().text = this.name;
        }
    }
}
