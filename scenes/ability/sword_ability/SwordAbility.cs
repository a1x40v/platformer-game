using Godot;

public partial class SwordAbility : Node2D
{
	[Export]
	public HitboxComponent HitboxComponent { get; set; }
}

/* 
NOTE. Свойство HitboxComponent должно было инициализироваться on-ready в коде, чтобы использоваться в SwordAbilityController.
В SwordAbilityController свойство было null, поэтому инициализировал в редакторе.
*/