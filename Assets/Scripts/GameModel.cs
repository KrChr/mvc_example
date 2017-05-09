using System;
using UnityEngine;
using UnityEngine.UI;

// Dispatched when the enemy's position changes
public class GamePositionChangedEventArgs : EventArgs
{
}

public class GameColorChangedEventArgs : EventArgs
{
}

public class GameColorArrayChangedEventArgs : EventArgs
{
}

public class GamePointsChangedEventArgs : EventArgs
{
}

public class GameLivesChangedEventArgs : EventArgs
{
}

public class GameTimerChangedEventArgs : EventArgs
{
}

// Interface for the model
public interface IGameModel
{
	// Dispatched when the position changes
	event EventHandler<GamePositionChangedEventArgs> OnPositionChanged;

	// Dispatched when the position changes
	event EventHandler<GameColorChangedEventArgs> OnColorChanged;
	event EventHandler<GameColorArrayChangedEventArgs> OnColorArrayChanged;

	event EventHandler<GamePointsChangedEventArgs> OnPointsChanged;
	event EventHandler<GameLivesChangedEventArgs> OnLivesChanged;
	event EventHandler<GameTimerChangedEventArgs> OnTimerChanged;

	// Position of the enemy
	Vector3 Position 
	{
		get;
		set; 
	}

	Color ObjColor
	{
		get;
		set; 
	}

	Color[] ButtonColor
	{
		get;
		set; 
	}

	int Points
	{
		get;
		set;
	}

	int Lives
	{
		get;
		set;
	}

	int LivesMin
	{
		get;
		set;
	}

	bool GameOver
	{
		get;
		set;
	}


	float Timer
	{
		get;
		set;
	}
}



// Implementation of the enemy model interface
public class GameModel : IGameModel
{
	// Backing field for the enemy's position
	private Vector3 position;
	private Color objColor;
	private Color objColor02;

	private Color[] buttonColor = new Color[4];

	private int points;
	private int lives;
	private int livesMin = 0;
	private float timer;

	private bool gameOver = false;


	public event EventHandler<GamePositionChangedEventArgs> OnPositionChanged = (sender, e) => {};
	public event EventHandler<GameColorChangedEventArgs> OnColorChanged = (sender, e) => {};
	public event EventHandler<GameColorArrayChangedEventArgs> OnColorArrayChanged = (sender, e) => {};
	public event EventHandler<GamePointsChangedEventArgs> OnPointsChanged = (sender, e) => {};
	public event EventHandler<GameLivesChangedEventArgs> OnLivesChanged = (sender, e) => {};
	public event EventHandler<GameTimerChangedEventArgs> OnTimerChanged = (sender, e) => {};

	public Vector3 Position
	{
		get 
		{
			return position; 
		}

		set
		{
			// Only if the value changes
			if (position != value)
			{
				// Set new value
				position = value;

				// Dispatch the 'value changed' event
				var eventArgs = new GamePositionChangedEventArgs();
				OnPositionChanged(this, eventArgs);
			}
		}
	}


	public Color ObjColor
	{
		get 
		{
			return objColor; 
		}

		set
		{
			// Only if the value changes
			if (objColor != value)
			{
				// Set new value
				objColor = value;

				// Dispatch the 'value changed' event
				var eventArgs = new GameColorChangedEventArgs();
				OnColorChanged(this, eventArgs);
			}
		}
	}



	public Color[] ButtonColor
	{
		get 
		{
			return buttonColor;
		}

		set
		{
			// Only if the value changes
			if (buttonColor != value)
			{
				// Set new value
				buttonColor = value;

				// Dispatch the 'ButtonColor changed' event
				var eventArgs = new GameColorArrayChangedEventArgs();
				OnColorArrayChanged(this, eventArgs);
			}
		}
	}


	public int Points
	{
		get 
		{
			return points;
		}

		set
		{
			// Only if the value changes
			if (points != value)
			{
				// Set new value
				points = value;

				// Dispatch the 'Points changed' event
				var eventArgs = new GamePointsChangedEventArgs();
				OnPointsChanged(this, eventArgs);
			}
		}
	}


	public int Lives
	{
		get 
		{
			return lives;
		}

		set
		{
			// Only if the value changes
			if (lives != value)
			{
				// Set new value
				lives = value;

				// Dispatch the 'Lives changed' event
				var eventArgs = new GameLivesChangedEventArgs();
				OnLivesChanged(this, eventArgs);
			}
		}
	}

	public int LivesMin
	{
		get 
		{
			return livesMin;
		}

		set
		{
			// Only if the value changes
			if (livesMin != value)
			{
				// Set new value
				livesMin = value;
			}
		}
	}

	public float Timer
	{
		get 
		{
			return timer;
		}

		set
		{
			// Only if the value changes
			if (timer != value)
			{
				// Set new value
				timer = value;

				// Dispatch the 'Timer changed' event
				var eventArgs = new GameTimerChangedEventArgs();
				OnTimerChanged(this, eventArgs);
			}
		}
	}

	public bool GameOver
	{
		get 
		{
			return gameOver;
		}

		set
		{
			// Only if the value changes
			if (gameOver != value)
			{
				// Set new value
				gameOver = value;
			}
		}
	}

}