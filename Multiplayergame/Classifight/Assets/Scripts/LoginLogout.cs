using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using System.Security.Cryptography;
using System.Text;
using System;

public class LoginLogout : MonoBehaviour
{
    public InputField AccountUserName;
    public InputField AccountPassword;

    public string baseUrl = "http://localhost:8080/ZooGo/";


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AccountRegister()
    {
        string uName = AccountUserName.text;
        string pWord = AccountPassword.text;
        StartCoroutine(RegisterNewAccount(uName, pWord));
    }
    public void AccountLogin()
    {
        string uName = AccountUserName.text;
        string pWord = AccountPassword.text;
        StartCoroutine(LoginAccount(uName, pWord));
    }

    IEnumerator RegisterNewAccount(string uName, string pWord)
    {
        WWWForm form = new WWWForm();
        form.AddField("newAccountUsername", uName);
        form.AddField("newAccountPassword", pWord);
        using (UnityWebRequest www = UnityWebRequest.Post(baseUrl, form))
        {
            www.downloadHandler = new DownloadHandlerBuffer();
            yield return www.SendWebRequest();

            if (www.isNetworkError)
            {
                Debug.Log(www.error);
            }
            else
            {
                string responseText = www.downloadHandler.text;
                Debug.Log("Response = " + responseText);
              //  info.Text= "Response = " + responseText;
            }
        }
    }
    IEnumerator LoginAccount(string uName, string pWord)
    {
        //pWord = HashPassword(pWord);
        WWWForm form = new WWWForm();
        form.AddField("loginUsername", uName);
        form.AddField("loginPassword", pWord);
        using (UnityWebRequest www = UnityWebRequest.Post(baseUrl, form))
        {
            www.downloadHandler = new DownloadHandlerBuffer();
            yield return www.SendWebRequest();

            if (www.isNetworkError)
            {
                Debug.Log(www.error);
            }
            else
            {
                string responseText = www.downloadHandler.text;
                Debug.Log("Response = " + responseText);

                /// if (responseText == "200") SceneManager.LoadScene("MainScenes");
                // else info.text = responseText;
            }
        }
    }

}
