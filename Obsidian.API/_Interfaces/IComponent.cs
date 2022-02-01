namespace Obsidian.API;

/// <summary>
/// The component is the main part of the entity component system (ecs). The component describes one part of code
/// which can be assigned to a specific entity. The component can handle specific parts and can be retrieved later
/// to use it as some kind of API.
/// </summary>
public interface IComponent
{
    /// <summary>
    /// Gets called when the component gets assigned. 
    /// </summary>
    /// <param name="entity">The <see cref="IEntity"/> which will own the component.</param>
    public Task OnAssign(IEntity entity);

    /// <summary>
    /// Gets called when the component gets removed from the entity.
    /// </summary>
    /// <param name="entity">The <see cref="IEntity"/> which owned the component.</param>
    public Task OnRemove(IEntity entity) => Task.CompletedTask;
}
