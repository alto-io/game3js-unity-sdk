// 
// THIS FILE HAS BEEN GENERATED AUTOMATICALLY
// DO NOT CHANGE IT MANUALLY UNLESS YOU KNOW WHAT YOU'RE DOING
// 
// GENERATED USING @colyseus/schema 0.5.41
// 

using Colyseus.Schema;

public class Player : Entity {
	[Type(2, "boolean")]
	public bool connected = false;

	[Type(3, "number")]
	public float score = 0;
}

