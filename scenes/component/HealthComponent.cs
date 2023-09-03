using Godot;

public partial class HealthComponent : Node
{
	[Export]
	public float MaxHealth { get; set; } = 10;

	[Signal]
	public delegate void DiedEventHandler();

	private float _currentHealth;

	public override void _Ready()
	{
		_currentHealth = MaxHealth;
	}

	private void CheckDeath()
	{
		if (_currentHealth == 0)
		{
			EmitSignal("Died");
			Owner.QueueFree();
		}
	}

	public void Damage(float damage)
	{
		_currentHealth = Mathf.Max(_currentHealth - damage, 0);

		CallDeferred(nameof(CheckDeath));
	}
}
