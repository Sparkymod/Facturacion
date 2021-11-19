using Microsoft.EntityFrameworkCore;
using Serilog;

namespace Facturacion.Data.Database
{
    public class DatabaseRequest<TEntity> : FacturaDbContext, IModel<TEntity> where TEntity : class
    {
        /// <summary>
        /// Add <typeparamref name="TEntity"/> to Database.
        /// </summary>
        /// <param name="entity">The object.</param>
        /// <returns>Save into DB</returns>
        /// 
        public async Task<TEntity> Add(TEntity entity)
        {
            using FacturaDbContext Context = new();
            Context.Set<TEntity>().Add(entity);
            await Commit(Context);
            return entity;
        }

        /// <summary>
        /// Delete <typeparamref name="TEntity"/> from Database.
        /// </summary>
        /// <param name="id">Id of the object.</param>
        /// <returns>Remove from DB</returns>
        public async Task<TEntity> Delete(int id)
        {
            using FacturaDbContext Context = new();
            TEntity entity = await Context.Set<TEntity>().FindAsync(id);
            if (entity == null)
            {
                return entity;
            }

            Context.Set<TEntity>().Remove(entity);
            await Commit(Context);

            return entity;
        }

        /// <summary>
        /// Get entity by ID.
        /// </summary>
        /// <param name="id">Id of the object.</param>
        /// <returns>An object typeof <typeparamref name="TEntity"/></returns>
        public async Task<TEntity> Get(int id)
        {
            using FacturaDbContext Context = new();
            return await Context.Set<TEntity>().FindAsync(id);
        }

        /// <summary>
        /// Get all entities.
        /// </summary>
        /// <returns>A list of object typeof <typeparamref name="TEntity"/></returns>
        public async Task<List<TEntity>> GetAll()
        {
            using FacturaDbContext Context = new();
            return await Context.Set<TEntity>().ToListAsync();
        }

        /// <summary>
        /// Skip as many <paramref name="skip"/> is specify and Take as many <paramref name="take"/> is specify.
        /// </summary>
        /// <param name="skip">Numbers of objects to skip in the list.</param>
        /// <param name="take">Numbers of objects to take in the list.</param>
        /// <returns>A list of objects typeof <typeparamref name="TEntity"/> with the size of <paramref name="take"/></returns>
        public async Task<List<TEntity>> GetMany(int skip, int take)
        {
            using FacturaDbContext Context = new();
            return await Context.Set<TEntity>().Skip(skip).Take(take).ToListAsync();
        }

        /// <summary>
        /// Update an <typeparamref name="TEntity"/> into the Database.
        /// </summary>
        /// <param name="entity">The object.</param>
        /// <returns>Update into DB</returns>
        public async Task<TEntity> Update(TEntity entity)
        {
            using FacturaDbContext Context = new();
            Context.Entry(entity).State = EntityState.Modified;
            await Commit(Context);
            return entity;
        }

        /// <summary>
        /// Check if the entity exist in the Database.
        /// </summary>
        /// <param name="entity">The object.</param>
        /// <returns><see langword="true"/> if the object exist; otherwise <see langword="false"/>.</returns>
        public async Task<bool> Exist(TEntity entity)
        {
            using FacturaDbContext Context = new();
            return await Context.Set<TEntity>().ContainsAsync(entity);
        }

        public async Task<bool> Commit(FacturaDbContext Context)
        {
            try
            {
                await Context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateException ex)
            {
                Log.Logger.Error($"Error saving changes => {ex.InnerException.Message}");
                return false;
            }
            catch (Exception ex)
            {
                Log.Logger.Error($"Error saving changes => {ex}");
                return false;
            }
        }
    }
}
