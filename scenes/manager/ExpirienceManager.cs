using Godot;

public partial class ExpirienceManager : Node
{
	private float _currentExp;

	public override void _Ready()
	{
		var gameEvents = GetNode<GameEvents>("/root/GameEvents");
		gameEvents.Connect("ExpirienceVialCollected", new Callable(this, nameof(OnExpirienceVialCollected)));
	}

	public void IncrementExpirience(float amount)
	{
		_currentExp += amount;
		GD.Print(_currentExp);
	}

	public void OnExpirienceVialCollected(float amount)
	{
		IncrementExpirience(amount);
	}
}
