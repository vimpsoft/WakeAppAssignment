using System;

[Serializable, Flags]
public enum Faction
{
    Player = 1,
    Enemies = 2,
    Everything = 3
}