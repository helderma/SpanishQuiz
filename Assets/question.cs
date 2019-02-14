using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
using UnityEngine.UI;

[Serializable]
public class question : MonoBehaviour{
    public Text text;
    public bool isCorrect;
    public question(string txt, bool tf)
    {
        text.text = txt;
        isCorrect = tf;
    }
    
    

}
