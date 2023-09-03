using Godot;

public partial class GameEvents : Node
{
	[Signal]
	public delegate void ExpirienceVialCollectedEventHandler(float amount);

	public void EmitExpirienceVialCollected(float amount)
	{
		EmitSignal("ExpirienceVialCollected", amount);
	}
}
