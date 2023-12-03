using Godot;
using System;

public partial class SplashPage : ColorRect
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		GetNode<Timer>("Timer").Timeout +=
			() => GetNode<SceneLoader>("/root/SceneLoader").ChangeToScene("MainMenu.tscn");
	}
}

