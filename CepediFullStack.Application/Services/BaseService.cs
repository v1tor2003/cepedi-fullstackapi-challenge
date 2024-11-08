using AutoMapper;
using CepediFullStack.Domain.Common;
using CepediFullStack.Domain.Interfaces;

namespace CepediFullStack.Application.Services
{
    public class BaseService<T> : IService<T> where T : BaseEntity
    {
        protected readonly IRepository<T> _repository;
        protected readonly IMapper _mapper;
        public BaseService(IRepository<T> repository, IMapper mapper) 
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task CreateAsync(T entity)
        {
            await _repository.CreateAsync(entity);
            await _repository.SaveAsync();
        }

        public async Task<TResponse> CreateAsync<TDto, TResponse>(TDto dto) 
            where TDto : BaseDto
            where TResponse : BaseDto
        {
            var entity = _mapper.Map<T>(dto);
            await _repository.CreateAsync(entity);
            await _repository.SaveAsync();
            //reload if needed
            var response = _mapper.Map<TResponse>(entity);
            return response;
        }

        public async Task UpdateAsync(T entity)
        {
            await _repository.UpdateAsync(entity);
            await _repository.SaveAsync();
        }

        public async Task UpdateAsync<TDto>(Guid id, TDto newValueDto) where TDto : BaseDto
        {
            var entity = await _repository.GetByIdAsync(id);
            await _repository.UpdateAsync(entity!, _mapper.Map<T>(newValueDto));
            await _repository.SaveAsync();
        }
        public async Task DeleteAsync(T entity)
        {
            await _repository.DeleteAsync(entity);
            await _repository.SaveAsync();
        }

        public async Task<IEnumerable<T>?> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<TDto?> GetByIdAsync<TDto>(Guid id) where TDto : BaseDto
        {
            var entity = await GetByIdAsync(id);
            return _mapper.Map<TDto>(entity);
        }
        public async Task<T?> GetByIdAsync(Guid id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<TDto>?> GetAllAsync<TDto>() where TDto : BaseDto
        {
            var customers = await _repository.GetAllAsync();
            if (customers is null) return [];

            return customers.Select(_mapper.Map<TDto>);
        }
    }
}