using CepediFullStack.Domain.Common;

namespace CepediFullStack.Domain.Interfaces
{
    public interface IService<T> where T : BaseEntity
    {
        Task CreateAsync(T entity);
        Task <TResponse> CreateAsync<TDto, TResponse>(TDto dto) 
            where TDto : BaseDto
            where TResponse : BaseDto
        ;
        Task UpdateAsync(T entity);
        Task UpdateAsync<TDto>(Guid id, TDto newValueDto) where TDto : BaseDto;
        Task DeleteAsync(T entity);
        Task<T?> GetByIdAsync(Guid id);
        Task<TDto?> GetByIdAsync<TDto>(Guid id) where TDto : BaseDto;
        Task<IEnumerable<T>?> GetAllAsync();
        Task<IEnumerable<TDto>?> GetAllAsync<TDto>() where TDto : BaseDto;
    }
}