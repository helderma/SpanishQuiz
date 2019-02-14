using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class OpeningSceneManager : MonoBehaviour {
    string root = "./Assets/csv/";
    [SerializeField]
    Button[] btns;
    [SerializeField]
    Text[] texts;
    string[] info;
    void Start ()
    {
       // string path = "./csv/Conditional.csv";
        /*
        string [] files = System.IO.Directory.GetFiles(path);
        for (int x=0; x < files.Length; x++)
        {
            Debug.Log(files[x]);
        }*/
        readFile();
	}
    void readFile()
    {       
        string [] files = Directory.GetFiles(root,"*.csv");
        /*
        StreamReader sr = new StreamReader("./Assets/csv/Conditional.csv");
        string line;
        do
        {
            line = sr.ReadLine();
            Debug.Log(line);
        } while (line != null);       
        */
        
        for (int x=0; x < files.Length; x++)
        {
            info = files[x].Split('/');
            string name = info[info.Length - 1].Split('.')[0];
            Debug.Log(name);
            texts[x].text = name;
            string filePath = files[x];
            btns[x].onClick.AddListener(delegate { BtnClick(filePath); });
        }
        
    }
    public void BtnClick(string s)
    {
        Persisants.file = s;
        UnityEngine.SceneManagement.SceneManager.LoadScene("QuizGame") ;
    }
    /*
    public class myButton : Button
    {
        public myButton(string name)
        {
            this.name = name;

        }
    }*/

    // Update is called once per frame
    void Update () {
		
	}
}
