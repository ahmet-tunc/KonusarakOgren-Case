using Core.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Core.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
        where TEntity : Entity, new()
        where TContext : DbContext, new()
    {
        public async Task<IResult> AddAsync(TEntity entity)
        {
            using var context = new TContext();
            var addedEntity = context.Entry(entity);
            addedEntity.State = EntityState.Added;
            await context.SaveChangesAsync();
            return new SuccessResult();
        }

        public async Task<IResult> AddListAsync(List<TEntity> entity)
        {
            using var context = new TContext();
            var addedEntity = context.Entry(entity);
            addedEntity.State = EntityState.Added;
            await context.SaveChangesAsync();
            return new SuccessResult();
        }

        public async Task<IResult> UpdateAsync(TEntity entity)
        {
            using var context = new TContext();
            var updatedEntity = context.Entry(entity);
            updatedEntity.State = EntityState.Added;
            await context.SaveChangesAsync();
            return new SuccessResult();
        }

        public async Task<IResult> UpdateListAsync(List<TEntity> entity)
        {
            using var context = new TContext();
            var updatedEntity = context.Entry(entity);
            updatedEntity.State = EntityState.Added;
            await context.SaveChangesAsync();
            return new SuccessResult();
        }


        public async Task<IResult> DeleteByIdAsync(Expression<Func<TEntity, bool>> filter)
        {
            using var context = new TContext();
            var entity = context.Set<TEntity>().FirstOrDefault(filter);

            if (entity == null)
                return new ErrorResult(Message.NotFoundRecord);

            var deletedEntity = context.Entry(entity);
            deletedEntity.State = EntityState.Deleted;
            await context.SaveChangesAsync();
            return new SuccessResult();
        }

        public async Task<IResult> DeleteByIdsAsync(Expression<Func<TEntity, bool>> filter)
        {
            using var context = new TContext();
            var entity = context.Set<TEntity>().Where(filter).ToList();

            if (entity.Count == 0)
                return new ErrorResult(Message.NotFoundRecord);

            var deletedEntity = context.Entry(entity);
            deletedEntity.State = EntityState.Deleted;
            await context.SaveChangesAsync();
            return new SuccessResult();
        }

        public async Task<IResult> DeleteListAsync(TEntity entity)
        {
            using var context = new TContext();
            var deletedEntity = context.Entry(entity);
            deletedEntity.State = EntityState.Deleted;
            await context.SaveChangesAsync();
            return new SuccessResult();
        }


        public async Task<IDataResult<TEntity>> GetAsync(Expression<Func<TEntity, bool>> filter)
        {
            using var context = new TContext();
            var entity = await context.Set<TEntity>().FirstOrDefaultAsync(filter);
            if (entity != null)
                return new SuccessDataResult<TEntity>(entity, Message.ListedRecord);

            return new ErrorDataResult<TEntity>(Message.NotFoundRecord);
        }

        public async Task<IDataResult<List<TEntity>>> GetAllAsync(Expression<Func<TEntity, bool>> filter = null)
        {
            using var context = new TContext();
            var entity = filter != null ? await context.Set<TEntity>().Where(filter).ToListAsync() : await context.Set<TEntity>().ToListAsync();
            if (entity.Count > 0)
                return new SuccessDataResult<List<TEntity>>(entity, Message.ListedRecord);
            else if(entity.Count == 0)
                return new SuccessDataResult<List<TEntity>>(Message.NotFoundRecord);

            return new ErrorDataResult<List<TEntity>>(Message.GetAllFailed);
        }
    }
}
