using Robust.Shared.Timing;
using Robust.Server.Player;
using Content.Server.Chat.Systems;
using Content.Shared._NF.Trade.Components;
using Content.Shared.Cargo.Components;

namespace Content.Server.Corvax.AutoDeleteItems;

public sealed class InflationCargoCrateSystem : EntitySystem
{
    [Dependency] private readonly IGameTiming _gameTiming = default!;
    [Dependency] private readonly ChatSystem _chatSystem = default!;
    [Dependency] private readonly IEntityManager _entManager = default!;

    private TimeSpan? Timer = TimeSpan.FromSeconds(10);
    private TimeSpan? NextTimeToCheck = TimeSpan.FromSeconds(5);

    StaticPriceComponent? staticPriceComponent = null;

    public override void Initialize()
    {
        base.Initialize();
    }

    public override void Update(float frameTime)
    {
        base.Update(frameTime);

        double modifier = 0;

        if (NextTimeToCheck < _gameTiming.CurTime)
        {
            numberCrates = _entManager.Count<TradeCrateComponent>();

            var query = EntityQueryEnumerator<InflationCargoCrateComponent>();
            while (query.MoveNext(out var uid, out var inflationCargoCrateComponent))
            {
                var xformQuery = GetEntityQuery<StaticPriceComponent>();
                if (!xformQuery.TryGetComponent(uid, out var xform))
                {
                    return;
                }

                if (numberCrates == 1)
                    modifier = 1;
                else if (numberCrates >= 2 && numberCrates <= 5)
                    modifier = 0.5;
                else if (numberCrates >= 6 && numberCrates <= 10)
                    modifier = 0.3;

                foreach (var iterator in _entManager.EntityQuery<TradeCrateComponent>(true))
                {

                    if (TryComp(uid, out inflationCargoCrateComponent))
                    {
                        if (inflationCargoCrateComponent.IsInflated)
                            continue;

                        if (TryComp(uid, out staticPriceComponent))
                        {
                            staticPriceComponent.Price *= modifier;
                            inflationCargoCrateComponent.IsInflated = true;
                        }

                        if (iterator.Owner == uid)
                        continue;
                    }
                }
            }
            NextTimeToCheck = NextTimeToCheck + Timer;
        }
    }
}
