using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Score : MonoBehaviour {
    public Text text;
    private int score = 0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void AddScore()
    {
        score++;
        text.text = score.ToString();
    }
}
