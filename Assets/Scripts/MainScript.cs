using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainScript : MonoBehaviour
{
	void Awake()
	{				
		// Create the model
		var modelFactory = new GameModelFactory();
		var model = modelFactory.Model;

		// Set some initial state
		//model.Position = new Vector3(2, 2, 3);
		//model.ObjColor = Color.green;

		model.ButtonColor [0] = Color.green;
		model.ButtonColor [1] = Color.green;
		model.ButtonColor [2] = Color.red;
		model.ButtonColor [3] = Color.green;

		model.Lives = 5;

		// Create the view
		var viewFactory = new GameViewFactory();
		var view = viewFactory.View;

		// Create the controller
		var controllerFactory = new GameControllerFactory(model, view);
		var controller = controllerFactory.Controller;
	}
}