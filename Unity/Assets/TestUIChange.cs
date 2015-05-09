using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.IO;

public class TestUIChange : MonoBehaviour {

	
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void MEnter()
	{
		
		Image myImage = GetComponent<Image>();
		Color color = myImage.color;
		
		myImage.color = new Color(color.r - 0.1f, color.g - 0.1f, color.b - 0.1f); ;


	}

	void MExit()
	{
		Image myImage = GetComponent<Image>();
		Color color = myImage.color;
		myImage.color = new Color(color.r + 0.1f, color.g + 0.1f, color.b + 0.1f);
	}

	void MClick()
	{
		string file = Application.dataPath;
		file = file.Replace("Unity/Assets","");
		Debug.Log(file);
		var sr = new StreamReader(file + "restsharp.json");
		var fileContents = sr.ReadToEnd();
		sr.Close();

		var lines = fileContents.Split("\n"[0]);
		Debug.Log(lines[20]);
	}
}
