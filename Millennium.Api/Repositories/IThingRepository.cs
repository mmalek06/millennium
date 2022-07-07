using Millennium.Api.Models;

namespace Millennium.Api.Repositories;

public interface IThingRepository
{
    void Create(Thing thing);

    Thing Get(Guid id);

    void Update(Thing thing);

    void Delete(Guid id);
}
