﻿using Obsidian.API.AI;

namespace Obsidian.API;

public interface IEntity
{
    public IServer Server { get; }

    public IWorld WorldLocation { get; }
    public INavigator Navigator { get; set; }

    public IGoalController GoalController { get; set; }
    
    /// <summary>
    /// A list containing all <see cref="IComponent"/>s assigned to this entity.
    /// </summary>
    public IReadOnlyList<IComponent> Components { get; }

    public Guid Uuid { get; set; }

    public VectorF Position { get; set; }
    public Angle Pitch { get; set; }
    public Angle Yaw { get; set; }
    public int EntityId { get; }

    public Pose Pose { get; set; }
    public EntityType Type { get; }

    public int Air { get; set; }

    public float Health { get; set; }

    public ChatMessage CustomName { get; set; }

    public bool CustomNameVisible { get; }
    public bool Silent { get; }
    public bool NoGravity { get; }
    public bool OnGround { get; }
    public bool Sneaking { get; }
    public bool Sprinting { get; }
    public bool Glowing { get; }
    public bool Invisible { get; }
    public bool Burning { get; }
    public bool Swimming { get; }
    public bool FlyingWithElytra { get; }

    public Task RemoveAsync();
    public Task TickAsync();
    public Task DamageAsync(IEntity source, float amount = 1.0f);

    public Task KillAsync(IEntity source);
    public Task KillAsync(IEntity source, ChatMessage message);

    public Task TeleportAsync(IWorld world);
    public Task TeleportAsync(IEntity to);
    public Task TeleportAsync(VectorF pos);

    /// <summary>
    /// Checks if the <see cref="IComponent"/> of the given type is currently assigned to this entity.
    /// </summary>
    /// <typeparam name="T">The type of the <see cref="IComponent"/>.</typeparam>
    /// <returns>True, if the wanted <see cref="IComponent"/> is assigned.</returns>
    public bool HasComponent<T>() where T : IComponent;

    /// <summary>
    /// Returns the <see cref="IComponent"/> of the given type which is currently assigned to this entity or,
    /// if the <see cref="IComponent"/> does not exist, a new <see cref="IComponent"/> will be added to this entity
    /// and then returned.
    /// </summary>
    /// <typeparam name="T">The type of the <see cref="IComponent"/>.</typeparam>
    /// <returns>The <see cref="IComponent"/></returns>
    public Task<T?> GetComponentAsync<T>() where T : IComponent;

    /// <summary>
    /// Removes the <see cref="IComponent"/> of the given type from this entity. If the component does not exist
    /// nothing will happen.
    /// </summary>
    /// <typeparam name="T">The type of the <see cref="IComponent"/> which will be removed.</typeparam>
    public Task RemoveComponentAsync<T>() where T : IComponent;

    public IEnumerable<IEntity> GetEntitiesNear(float distance);

    public VectorF GetLookDirection();
}
