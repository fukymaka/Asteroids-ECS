﻿using System;

namespace AsteroidsECS.Services.Enums
{
    [Flags]
    public enum PossibleCollisions
    {
        None = 0,
        Asteroid = 1,
        Ufo = 2,
        Player = 4,
        UfoProjectile = 8,
        PlayerProjectile = 16
    }
}