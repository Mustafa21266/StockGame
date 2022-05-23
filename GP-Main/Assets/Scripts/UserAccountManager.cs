using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserAccountManager : MonoBehaviour
{

    public GameObject logInPanel;
    public GameObject registerPanel;
    //public GameObject userAccountPanel;
    // Start is called before the first frame update
    public void onClickLogin()
    {
        logInPanel.SetActive(true);
        registerPanel.SetActive(false);
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    public void onClickRegister()
    {
        logInPanel.SetActive(false);
        registerPanel.SetActive(true);
        gameObject.SetActive(false);
    }
}
