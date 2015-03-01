using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MainMenuManager : MonoBehaviour {

	// Use this for initialization

	public GameObject mainMenu;

	void Start () {
	
	}

	public void loadSelection()
	{
		Application.LoadLevel ("LevelSelection");
	}

	public void Quit()
	{
		Application.Quit ();
	}
	public void Instruc()
	{
		Application.LoadLevel ("Instruction");
	}
	// Update is called once per frame
	void Update () {
	
	}
}
