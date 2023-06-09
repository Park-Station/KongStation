﻿using Content.Shared.Atmos;

namespace Content.Server.Xenoarchaeology.XenoArtifacts.Effects.Components;

/// <summary>
///     Change atmospherics temperature until it reach target.
/// </summary>
[RegisterComponent]
public sealed class TemperatureArtifactComponent : Component
{
    public override string Name => "TemperatureArtifact";

    [DataField("targetTemp")]
    public float TargetTemperature = Atmospherics.T0C;

    [DataField("spawnTemp")]
    public float SpawnTemperature = 100;

    [DataField("maxTempDif")]
    public float MaxTemperatureDifference = 1;

    /// <summary>
    ///     If true, artifact will heat/cool not only its current tile, but surrounding tiles too.
    ///     This will change room temperature much faster.
    /// </summary>
    [DataField("effectAdjacent")]
    public bool EffectAdjacentTiles = true;
}
