using System;
using UnityEngine;
using UnityEngine.UI;

// Dispatched when the button is clicked
public class GameClickedEventArgs : EventArgs
{
}



// Interface for the enemy view
public interface IGameView
{
	// Dispatched when the button is clicked
	event EventHandler<GameClickedEventArgs> OnClicked;
	event EventHandler<GameClickedEventArgs> OnClicked01;
	event EventHandler<GameClickedEventArgs> OnClicked02;
	event EventHandler<GameClickedEventArgs> OnClicked03;
	event EventHandler<GameClickedEventArgs> OnClickedReset;
	event EventHandler<GameClickedEventArgs> OnTimerRefresh;

	// Set the enemy's position
	Vector3 Position 
	{ 
		set;
	}

	Color ObjColor 
	{
		set;
	}

	Color[] ButtonColor
	{
		set;
	}

	float Timer
	{
		set;
	}

	int Points 
	{
		set;
	}

	int Lives
	{
		set;
	}

	bool GameOver
	{
		set;
	}
}



// Implementation of the enemy view
public class GameView : MainScript, IGameView
{
	private string hearts;
	private float timerView;

	public Text timer;
	public Text pointsGUI;
	public Text livesGUI;

	public Image button00;
	public Image button01;
	public Image button02;
	public Image button03;

	public GameObject popup;
	public Text popupText;
	public Image buttonReset;

	public MainScript mainScript;


	// Dispatched when the button is clicked
	public event EventHandler<GameClickedEventArgs> OnClicked = (sender, e) => {};
	public event EventHandler<GameClickedEventArgs> OnClicked01 = (sender, e) => {};
	public event EventHandler<GameClickedEventArgs> OnClicked02 = (sender, e) => {};
	public event EventHandler<GameClickedEventArgs> OnClicked03 = (sender, e) => {};
	public event EventHandler<GameClickedEventArgs> OnClickedReset = (sender, e) => {};
	public event EventHandler<GameClickedEventArgs> OnTimerRefresh = (sender, e) => {};

	void Awake()
	{
		PrepareReferences();
		popup.SetActive (false);
	}

	public void Start ()
	{

	}


	// Set the enemy's position
	public Vector3 Position
	{
		set 
		{
			transform.position = value;
		} 
	}

	// Set the enemy's color
	public Color ObjColor
	{
		set 
		{
//			Debug.Log ("GameView.cs / rend.material.color = " + value);

			GetComponent<Renderer>().material.color = value;
		} 
	}


	// Set the enemy's color
	public Color[] ButtonColor
	{
		set 
		{
//			Debug.Log ("! GameView.cs / Color[] ButtonColor.value[0] = " + value[0]);

			button00.color = value[0];
			button01.color = value[1];
			button02.color = value[2];
			button03.color = value[3];
		} 
	}

	// Set the enemy's points
	public int Points
	{
		set 
		{
//			Debug.Log ("GameView.cs / pointsGUI.text");

			pointsGUI.text = "Score: " + value; //problem: w chwili wywołania nie ma referencji
			popupText.text = "Score: " + value;
		} 
	}

	public float Timer
	{
		set 
		{
			timer.text = "Timer: " + value.ToString("F2") + "s";
		}
	}

	public int Lives
	{
		set 
		{
//			Debug.Log ("GameView.cs / livesGUI.text = " + value);


			hearts = "";

			for (int i = 0; i < value; i++) 
			{
				hearts = hearts + "❤";
			}


			livesGUI.text = hearts + " ";

		} 
	}


	// Set the enemy's position
	public bool GameOver
	{
		set 
		{
			if (value == true) 
			{
				popup.SetActive (true);
			}
		} 
	}



	public void AddPoints()
	{
		var eventArgs = new GameClickedEventArgs(); //event w GameController.cs
		OnClicked(this, eventArgs);
	}





	public void Button00Clicked()
	{
		var eventArgs = new GameClickedEventArgs(); //event w GameController.cs
		OnClicked(this, eventArgs);
	}


	public void Button01Clicked()
	{
		var eventArgs = new GameClickedEventArgs(); //event w GameController.cs
		OnClicked01(this, eventArgs);
	}


	public void Button02Clicked()
	{
		var eventArgs = new GameClickedEventArgs(); //event w GameController.cs
		OnClicked02(this, eventArgs);
	}


	public void Button03Clicked()
	{
		var eventArgs = new GameClickedEventArgs(); //event w GameController.cs
		OnClicked03(this, eventArgs);
	}

	public void ButtonReset()
	{
		Debug.Log ("GameView.cs, Reset");
		var eventArgs = new GameClickedEventArgs(); //event w GameController.cs
		OnClickedReset(this, eventArgs);
	}


	public void TimerRefresh()
	{
		if (!popup.activeSelf) 
		{
			var eventArgs = new GameClickedEventArgs (); //event w GameController.cs
			OnTimerRefresh (this, eventArgs);
		}
	}

	void PrepareReferences()
	{
		mainScript = GameObject.Find ("Main Camera").GetComponent<MainScript>();

		timer = GameObject.Find("GUI(Clone)/Texts/Timer").GetComponent<Text>();
		pointsGUI = GameObject.Find("GUI(Clone)/Texts/Points").GetComponent<Text>();
		livesGUI = GameObject.Find("GUI(Clone)/Texts/Lives").GetComponent<Text>();

		button00 = GameObject.Find("GUI(Clone)/Buttons/Button00").GetComponent<Image>();
		button01 = GameObject.Find("GUI(Clone)/Buttons/Button01").GetComponent<Image>();
		button02 = GameObject.Find("GUI(Clone)/Buttons/Button02").GetComponent<Image>();
		button03 = GameObject.Find("GUI(Clone)/Buttons/Button03").GetComponent<Image>();

		popup = GameObject.Find ("GUI(Clone)/Popup");
		popupText = GameObject.Find("GUI(Clone)/Popup/Panel/Text").GetComponent<Text>();
		buttonReset = GameObject.Find("GUI(Clone)/Popup/Panel/ButtonReset").GetComponent<Image>();
	}


	void FixedUpdate()
	{
		TimerRefresh ();
	}


}