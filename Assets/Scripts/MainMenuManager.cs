using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MainMenuManager : MonoBehaviour {

	// Use this for initialization
	static public bool loadedFromLevelSelection;

	public GameObject mainMenu;

	void Start () {
		loadedFromLevelSelection = false;
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
	public void NewGame()
	{
		PlayerPrefs.DeleteAll ();
		loadSelection ();
	}
	// Update is called once per frame
	void Update () {
	
	}
}
