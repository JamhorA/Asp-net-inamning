using Bmerketo_WebApp.Contexts;
using Bmerketo_WebApp.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Diagnostics;
using System.Linq.Expressions;

namespace Bmerketo_WebApp.Helpers.Repositories;

public class AddressRepository : Repo<AddressEntity>
{
    private readonly IdentityContext _identityContext;


    public AddressRepository(DataContext dataContext, IdentityContext identityContext) : base(dataContext, identityContext)
    {
        _identityContext = identityContext;
    }

    public override Task<IEnumerable<AddressEntity>> GetAllAsync()
    {
        return base.GetAllAsync();
    }

    public override Task<AddressEntity> GetAsync(Expression<Func<AddressEntity, bool>> expression)
    {
        return base.GetAsync(expression);
    }
    public override async Task<AddressEntity> AddAsync(AddressEntity entity)
    {
        try
        {

            _identityContext.Addresses.Add(entity);
            await _identityContext.SaveChangesAsync();

            return entity;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return null!;
        }
    }

}
