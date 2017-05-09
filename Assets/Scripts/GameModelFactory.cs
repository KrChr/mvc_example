using UnityEngine;
using UnityEngine.UI;

// Interface for the model factory
public interface IGameModelFactory
{
	// Get the created model
	IGameModel Model 
	{ 
		get; 
	}
}



// Implementation of the model factory
public class GameModelFactory : IGameModelFactory
{
	public IGameModel Model 
	{ 
		get; 
		private set; 
	}

	// Create the model
	public GameModelFactory()
	{
		Model = new GameModel();
	}
}



// Interface for the view factory
public interface IGameViewFactory
{
	// Get the created view
	IGameView View 
	{ 
		get;
	}
}



// Implementation of the view factory
public class GameViewFactory : IGameViewFactory
{
	public IGameView View 
	{ 
		get;
		private set; 
	}

	// Create the view
	public GameViewFactory()
	{
		var prefab = Resources.Load<GameObject>("GUI"); //Game
		var instance = UnityEngine.Object.Instantiate(prefab);
		View = instance.GetComponent<IGameView>(); 
	}
}



// Interface of the view factory
public interface IGameControllerFactory
{
	// Get the created controller
	IGameController Controller 
	{ 
		get; 
	}
}



// Implementation of the controller factory
public class GameControllerFactory : IGameControllerFactory
{
	public IGameController Controller 
	{ 
		get; 
		private set; 
	}

	// Create just the controller
	public GameControllerFactory(IGameModel model, IGameView view)
	{
		Controller = new GameController(model, view);
	}

	// Create the model, view, and controller
	public GameControllerFactory()	: this(new GameModel(), new GameView())
	{
	}
}