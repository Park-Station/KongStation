using Content.Shared.Light.Component;
using Robust.Shared.GameObjects;
using Robust.Shared.GameStates;
using System.Collections.Generic;

namespace Content.Shared.Light;

public abstract class SharedRgbLightControllerSystem : EntitySystem
{
    public override void Initialize()
    {
        base.Initialize();

        SubscribeLocalEvent<RgbLightControllerComponent, ComponentGetState>(OnGetState);
    }

    private void OnGetState(EntityUid uid, RgbLightControllerComponent component, ref ComponentGetState args)
    {
        args.State = new RgbLightControllerState(component.CycleRate, component.Layers);
    }

    public void SetLayers(EntityUid uid, List<int>? layers,  RgbLightControllerComponent? rgb = null)
    {
        if (!Resolve(uid, ref rgb))
            return;

        rgb.Layers = layers;
        rgb.Dirty();
    }

    public void SetCycleRate(EntityUid uid, float rate, RgbLightControllerComponent? rgb = null)
    {
        if (!Resolve(uid, ref rgb))
            return;

        rgb.CycleRate = rate;
        rgb.Dirty();
    }
}
