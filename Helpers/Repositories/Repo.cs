using Bmerketo_WebApp.Contexts;
using Bmerketo_WebApp.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Linq.Expressions;

namespace Bmerketo_WebApp.Helpers.Repositories;

public abstract class Repo<TEntity> where TEntity : class
{
	private readonly DataContext _dataContext;
	private readonly IdentityContext _identityContext;

	protected Repo(DataContext dataContext, IdentityContext identityContext)
	{
		_dataContext = dataContext;
		_identityContext = identityContext;
	}
    public virtual async Task<TEntity> AddProductAsync(TEntity entity)
    {
        _dataContext.Set<TEntity>().Add(entity);
        await _dataContext.SaveChangesAsync();
        return entity;
    }

	public virtual async Task<TEntity?> GetByIdAsync(int id)
	{
		return await _dataContext.Set<TEntity>().FindAsync(id);
	}

    public virtual async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> expression)
    {
        try
        {
            
            
                var entity = await _identityContext.Set<TEntity>().FirstOrDefaultAsync(expression);
                if (entity != null)
                    return entity;
            
           
            
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }
        return null!;
    }

    public virtual async Task<IEnumerable<TEntity>> GetAsync()
    {
        try
        {
            if (typeof(TEntity).IsAssignableFrom(typeof(IdentityUser)))
            {
                var entities = await _identityContext.Set<TEntity>().ToListAsync();
                if (entities != null)
                    return entities;
            }
            else
            {
                var entities = await _dataContext.Set<TEntity>().ToListAsync();
                if (entities != null)
                    return entities;
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }
        return null!;
    }
    public virtual async Task<TEntity?> GetLatestAsync()
    {
        try
        {
            if (typeof(TEntity) == typeof(UserEntity))
            {
                var latestEntity = await _identityContext.Set<UserEntity>().OrderByDescending(e => e.Id).FirstOrDefaultAsync();
                return latestEntity as TEntity;
            }
            else
            {
                var latestEntity = await _dataContext.Set<ProductEntity>().OrderByDescending(e => e.Id).FirstOrDefaultAsync();
                return latestEntity as TEntity;
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }
        return null!;
    }

    public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
	{
		try
		{
			var entities = await _dataContext.Set<TEntity>().ToListAsync();
			if(entities != null)
				return entities;
		}
		catch (Exception ex)
		{
			Debug.WriteLine(ex.Message);
			
		}
		return null!;
	}

	public virtual async Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate)
	{
		try
		{
			return await _dataContext.Set<TEntity>().Where(predicate).ToListAsync();
		}
		catch (Exception ex)
		{
			Debug.WriteLine(ex.Message);
			return Enumerable.Empty<TEntity>();
		}
	}
    public virtual async Task<IEnumerable<TEntity>> FindImageAsync(Expression<Func<TEntity, bool>> predicate)
    {
        try
        {
            return await _dataContext.Set<TEntity>().Where(predicate).ToListAsync();
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return Enumerable.Empty<TEntity>();
        }
    }

    public virtual async Task<TEntity> AddAsync(TEntity entity)
	{
		try
		{
			if (typeof(TEntity).IsAssignableFrom(typeof(UserEntity)))
			{
				_identityContext.Set<TEntity>().Add(entity);
				await _identityContext.SaveChangesAsync();
			}
			else
			{
				_dataContext.Set<TEntity>().Add(entity);
				await _dataContext.SaveChangesAsync();
			}
			return entity;
		}
		catch (Exception ex)
		{
			Debug.WriteLine(ex.Message);
			return null!;
		}
	}
    public virtual async Task<TEntity> AddAddressAsync(TEntity entity)
    {
        try
        {
            
                _identityContext.Set<TEntity>().Add(entity);
                await _identityContext.SaveChangesAsync();
            
            return entity;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return null!;
        }
    }
    public virtual async Task<bool> DeleteAsync<TKey>(TKey id)
	{
		try
		{
			var entity = await _dataContext.Set<TEntity>().FindAsync(id);
			if (entity == null)
				return false;

			_dataContext.Set<TEntity>().Remove(entity);
			await _dataContext.SaveChangesAsync();
			return true;
		}
		catch (Exception ex)
		{
			Debug.WriteLine(ex.Message);
			return false;
		}
	}

	public virtual async Task<bool> UpdateAsync(TEntity entity)
	{
		try
		{
			_dataContext.Entry(entity).State = EntityState.Modified;
			await _dataContext.SaveChangesAsync();
			return true;
		}
		catch (Exception ex)
		{
			Debug.WriteLine(ex.Message);
			return false;
		}
	}


}

