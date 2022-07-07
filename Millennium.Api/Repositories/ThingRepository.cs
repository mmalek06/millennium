using Millennium.Api.Models;

namespace Millennium.Api.Repositories;

public class ThingRepository : IThingRepository
{
    private static readonly List<Thing> _things = new();

    public void Create(Thing thing)
    {
        var existingThing = _things.SingleOrDefault(t => t == thing);

        if (existingThing is not null)
            throw new InvalidOperationException(
                $"Can't create a Thing with id {thing.Id}.");

        _things.Add(thing);
    }

    public void Delete(Guid id) 
    {
        var thing = _things.SingleOrDefault(t => t.Id == id);

        if (thing is null)
            throw new InvalidOperationException(
                $"Can't remove a Thing with id {id}.");

        _things.Remove(thing);
    }

    public Thing Get(Guid id)
    {
        var thing = _things.SingleOrDefault(t => t.Id == id);

        if (thing is null)
            throw new InvalidOperationException(
                $"There's no Thing with id {id}.");

        return thing;
    }

    public void Update(Thing thing)
    {
        var index = _things.FindIndex(t => t.Id == thing.Id);

        if (index < 0)
            throw new InvalidOperationException(
                $"Can't update a Thing with id {thing.Id}.");

        _things[index] = thing;
    }
}
