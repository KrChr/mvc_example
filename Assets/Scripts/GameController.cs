using UnityEngine;

// Interface for the enemy controller
public interface IGameController
{
}



// Implementation of the enemy controller
public class GameController : IGameController
{
	// Keep references to the model and view
	private readonly IGameModel model;
	private readonly IGameView view;

	// Controller depends on interfaces for the model and view
	public GameController(IGameModel model, IGameView view)
	{
		this.model = model;
		this.view = view;

		// Listen to input from the view
		view.OnClicked += HandleClicked;

		view.OnClicked01 += HandleClicked01;

		view.OnClicked02 += HandleClicked02;

		view.OnClicked03 += HandleClicked03;

		view.OnClickedReset += HandleClickedReset;

		view.OnTimerRefresh += HandleTimer;


		// Listen to changes in the model
		model.OnPositionChanged += HandlePositionChanged;

		model.OnColorChanged += HandleColorChanged;

		model.OnColorArrayChanged += HandleColorArrayChanged;

		model.OnPointsChanged += HandlePointsChanged;

		model.OnLivesChanged += HandleLivesChanged;

		model.OnTimerChanged += HandleTimerChanged;


		// Set the view's initial state by synching with the model
		SyncPosition();

		SyncColor();

		SyncColorArray();

		SyncPoints();

		SyncLives();

		SyncGameOver();
	}



	// Called when the view is clicked
	private void HandleClicked(object sender, GameClickedEventArgs e)
	{
//		Debug.Log ("Game Controller.cs, Handle Clicked, model.ObjColor = " + model.ObjColor);
		// Do something to the model
		// This example just moves the model +1 along the X axis

//		Debug.Log("GameController.cs, before, ButtonColor[0] = " + model.ButtonColor [0]);
		model.ButtonColor [1] = Color.green;
//		Debug.Log("GameController.cs, after, ButtonColor[0] = " + model.ButtonColor [0]);

		if (!model.GameOver) {
			if (model.ButtonColor [0] == Color.green) {
				model.Points += 1;
			}

			if (model.ButtonColor [0] != Color.green) {
				RemoveLive ();
			}

			SetNewColor ();
			SyncColorArray ();
			SyncGameOver ();
		}
	}



	private void HandleClicked01(object sender, GameClickedEventArgs e)
	{
//		Debug.Log ("Game Controller.cs, Handle Clicked01, model.ObjColor = " + model.ObjColor);
		// Do something to the model
		// This example just moves the model +1 along the X axis

		if (!model.GameOver) {
			if (model.ButtonColor [1] == Color.green) {
				//model.ButtonColor [1] = Color.green;
				model.Points += 1;
			}

			if (model.ButtonColor [1] != Color.green) {
				RemoveLive ();
			}

			SetNewColor ();
			SyncColorArray ();
			SyncGameOver ();
		}
	}


	private void HandleClicked02(object sender, GameClickedEventArgs e)
	{
//		Debug.Log ("Game Controller.cs, Handle Clicked02, model.ObjColor = " + model.ObjColor);
		// Do something to the model
		// This example just moves the model +1 along the X axis

		if (!model.GameOver) {
			if (model.ButtonColor [2] == Color.green) {
				//model.ButtonColor [1] = Color.green;
				model.Points += 1;
			}

			if (model.ButtonColor [2] != Color.green) {
				RemoveLive ();
			}

			SetNewColor ();
			SyncColorArray ();
			SyncGameOver ();
		}
	}


	private void HandleClicked03(object sender, GameClickedEventArgs e)
	{
//		Debug.Log ("Game Controller.cs, Handle Clicked03, model.ObjColor = " + model.ObjColor);
		// Do something to the model
		// This example just moves the model +1 along the X axis

		if (!model.GameOver) {
			if (model.ButtonColor [3] == Color.green) {
				//model.ButtonColor [1] = Color.green;
				model.Points += 1;
			}

			if (model.ButtonColor [3] != Color.green) {
				RemoveLive ();
			}

			SetNewColor ();
			SyncColorArray ();
			SyncGameOver ();
		}
	}

	private void HandleClickedReset(object sender, GameClickedEventArgs e)
	{
//		Debug.Log ("GameController.cs, reset");
		// Do something to the model
		// This example just moves the model +1 along the X axis

		Application.LoadLevel (0);

	}

	private void HandleTimer(object sender, GameClickedEventArgs e)
	{
		//Debug.Log ("GameController.cs, reset");
		// Do something to the model
		// This example just moves the model +1 along the X axis

		if (model.Timer <= 30f) 
		{
			model.Timer += 0.02f;
			SyncTimer ();
		}
		else// (model.Timer > 30f) 
		{
			model.GameOver = true;
			SyncGameOver ();
		}

	}


	private void RemoveLive()
	{
		model.Lives -= 1;

		if (model.Lives == model.LivesMin) 
		{
			model.GameOver = true;
		}
	}

	private void SetNewColor()
	{
		int randomColor = Random.Range (0, 4);

		for (int i = 0; i < 4; i++) 
		{
			if (randomColor == i) 
			{
				model.ButtonColor [i] = Color.red;
			}
			else
			{
				model.ButtonColor [i] = Color.green;
			}

		}
	}


	// Called when the model's position changes
	private void HandlePositionChanged(object sender, GamePositionChangedEventArgs e)
	{
		// Update the view with the new position
		SyncPosition();
	}



	// Called when the model's position changes
	private void HandleColorChanged(object sender, GameColorChangedEventArgs e)
	{
		// Update the view with the new color
		SyncColor();
	}


	// Called when the model's position changes
	private void HandleColorArrayChanged(object sender, GameColorArrayChangedEventArgs e)
	{
		// Update the view with the new color
		SyncColorArray();
	}


	// Called when the model's points changes
	private void HandlePointsChanged(object sender, GamePointsChangedEventArgs e)
	{
		// Update the view with the new color
		SyncPoints();
	}

	// Called when the model's points changes
	private void HandleLivesChanged(object sender, GameLivesChangedEventArgs e)
	{
		// Update the view with the new color
		SyncLives();
	}

	// Called when the model's points changes
	private void HandleTimerChanged(object sender, GameTimerChangedEventArgs e)
	{
		// Update the view with the new color
		SyncTimer();
	}




	// Sync the view's position with the model's position
	private void SyncPosition()
	{
		view.Position = model.Position;
	}

	private void SyncColor()
	{
		view.ObjColor = model.ObjColor;
	}

	private void SyncColorArray()
	{
		view.ButtonColor = model.ButtonColor;
	}


	private void SyncPoints()
	{
		view.Points = model.Points;
	}


	private void SyncLives()
	{
		view.Lives = model.Lives;
	}


	private void SyncGameOver()
	{
		view.GameOver = model.GameOver;
	}

	private void SyncTimer()
	{
		view.Timer = model.Timer;
	}
}