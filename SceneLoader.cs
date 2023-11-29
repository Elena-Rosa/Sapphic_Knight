using Godot;
using System;

public partial class SceneLoader : Node
{
	// Called when the node enters the scene tree for the first time.

	public void ChangeToScene(string sceneName)
	{
		GetTree().ChangeSceneToFile($"res://../Scenes/{sceneName}.tscn");
	}

}
