using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class gameManager : MonoBehaviour {
    [SerializeField]
    Button[] buttons;
    [SerializeField]
    question[] questions;
    List<string[]> questionData = new List<string[]>();
    [SerializeField]
        Text prompt, score;
    // Use this for initialization
    void Start()
    {
        loadQuestions();
        Persisants.scoreMax = questionData.Count;
        
        //Debug.Log("Max Score: "+ Persisants.scoreMax);
        //questionData.Remove(questionData[1]);
        //Debug.Log("After Remove: " + questionData.Count);
        setupQuestion();

    }
    void setupQuestion()
    {
        //skips the header row
        int ranNum = Random.Range(1, questionData.Count);
        string[] data = questionData[ranNum];
        //removes question from list
        questionData.Remove(data);
        //skips the num column
        ranNum = Random.Range(1, data.Length);
        
        getAns(ranNum, data);

        for (int x = 0; x < buttons.Length; x++)
        {
            buttons[x].onClick.AddListener(delegate { btnClick(questions[x].isCorrect); });
        }
    }
    void btnClick(bool istrue)
    {
        if (istrue)
        {
            increaseScore();
        }
        setupQuestion();
    }
    void getAns (int index, string [] d)
    {        
        for (int x =0; x < questions.Length; x++)
        {
            if (index <= 5)
            {
                if (x == 0) {
                    questions[x].text.text = d[index + 6 - x];
                    questions[x].isCorrect = true;
                }
                else
                { 
                    questions[x].text.text = d[index + 6 - x];
                    questions[x].isCorrect = false;
                }
            }
            else
            {
                if (x == 0)
                {
                    questions[x].text.text = d[index - 6 + x];
                    questions[x].isCorrect = true;
                }
                else
                {
                    questions[x].text.text = d[index - 6 + x];
                    questions[x].isCorrect = false;
                }
            }
        }
        
    }
    void loadQuestions()
    {
        Debug.Log("started");
        StreamReader sr = new StreamReader(Persisants.file);
        string line = sr.ReadLine();
        do
        {
            questionData.Add(formatedLine(line));
            //Debug.Log(line);
            line = sr.ReadLine();
        } while (line != null);
    }
    string[] formatedLine(string line)
    {
        //Debug.Log(line);
        
        List<string>formated = new List<string>();
        for (int x=0; x < line.Length; x++)
        {            
            string quotedData = "";
            if (line[x] == '"')
            {
                x++;
                while (line[x] != '"')
                {
                    quotedData += (line[x].ToString());
                    x++;
                }
            }
           
            if (quotedData != "" || quotedData != "," || quotedData != " ")
            {
                //Debug.Log(quotedData);
                formated.Add(quotedData);
            }
        }
        string [] complete = new string[(formated.Count/2)+1];
        int y = 0, yy = 0;
        foreach (string item in formated)
        {
            if (yy %2 ==0)
            {
                complete[y] = item;
               // Debug.Log(y + ": " + complete[y]);
                y++;
            }
            yy++;
        }
        return complete;
    }
    void increaseScore ()
    {
        string [] txt = score.text.Split();
        score.text = (txt[0] + (Persisants.scoreCurrent += 1).ToString());
    }
	
}
