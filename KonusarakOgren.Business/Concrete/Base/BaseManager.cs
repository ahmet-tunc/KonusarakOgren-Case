using Core.DataAccess;
using Core.Entities.Concrete;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using KonusarakOgren.Business.Abstract.Base;
using KonusarakOgren.Business.Constants;
using System.Linq.Expressions;

namespace KonusarakOgren.Business.Concrete.Base
{
    public class BaseManager<T> : IBaseService<T> where T : Entity, new()
    {
        private readonly IEntityRepository<T> _entityRepository;

        public BaseManager(IEntityRepository<T> entityRepository)
        {
            _entityRepository = entityRepository;
        }

        public async Task<IResult> AddAsync(T entity)
        {
            var result = await _entityRepository.AddAsync(entity);
            if (result.Success)
                return new SuccessResult(Message.Added);

            return new ErrorResult(Message.AddedFailed);
        }

        public async Task<IResult> AddListAsync(List<T> entity)
        {
            var result = await _entityRepository.AddListAsync(entity);
            if (result.Success)
                return new SuccessResult(Message.AddedList);

            return new ErrorResult(Message.AddedListFailed);
        }

        public async Task<IResult> UpdateAsync(T entity)
        {
            var result = await _entityRepository.UpdateAsync(entity);
            if (result.Success)
                return new SuccessResult(Message.Updated);

            return new ErrorResult(Message.UpdatedFailed);
        }


        public async Task<IResult> UpdateListAsync(List<T> entity)
        {
            var result = await _entityRepository.UpdateListAsync(entity);
            if (result.Success)
                return new SuccessResult(Message.UpdatedList);

            return new ErrorResult(Message.UpdatedListFailed);
        }


        public async Task<IDataResult<List<T>>> GetAllAsync(Expression<Func<T, bool>> filter = null)
        {
            var result = await _entityRepository.GetAllAsync(filter ?? null);
            if (result.Success)
                return new SuccessDataResult<List<T>>(result.Data, result.Message);

            return new ErrorDataResult<List<T>>(Message.GetAllFailed);
        }

        public async Task<IDataResult<T>> GetByIdAsync(int id)
        {
            var result = await _entityRepository.GetAsync(x => x.Id == id);
            if (result.Success)
                return new SuccessDataResult<T>(result.Data, result.Message);

            return new ErrorDataResult<T>(Message.GetFailed);
        }
    }
}
