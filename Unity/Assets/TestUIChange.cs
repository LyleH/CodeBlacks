using UnityEngine;
using UnityEngine.UI;
using System.Collections;

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
}
