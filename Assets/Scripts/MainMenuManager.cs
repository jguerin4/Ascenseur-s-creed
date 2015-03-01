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
		loadedFromLevelSelection = false;
		Application.LoadLevel ("LevelSelection");
	}

	public void Quit()
	{
		Application.Quit ();
	}
	// Update is called once per frame
	void Update () {
	
	}
}
