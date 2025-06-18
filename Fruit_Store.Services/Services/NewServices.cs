using AutoMapper;
using Fruit_Store.Core.DTOs;
using Fruit_Store.Core.Interfaces.Repository;
using Fruit_Store.Core.Interfaces.Services;
using FruitStore.Core.Models;
using System.Runtime.CompilerServices;

namespace Fruit_Store.Services.Services
{
    public class NewServices : INewServices
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public NewServices(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<bool> AddAsync(NewDTO NewDTO)
        {
            var New = _mapper.Map<New>(NewDTO);
            return await _unitOfWork.New.AddAsync(New);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var New = await _unitOfWork.New.Get(x => x.Id == id);
            if (New is null)
                return false;

            return await _unitOfWork.New.DeleteAsync(New);
        }

        public async Task<NewDTO?> GetByIDAsync(int id)
        {
            var New = await _unitOfWork.New.Get(x => x.Id == id);
            if (New is null)
                return null;

            return await Task.FromResult(_mapper.Map<NewDTO>(New));
        }

        public async Task<IEnumerable<NewDTO>> GetLastAsync()
        {
            var newsList = await _unitOfWork.New.GetAllAsync();
           

            var lastTen = newsList
                .OrderByDescending(n => n.Id) // Assuming higher Id means newer
                .Take(10);

            return _mapper.Map<IEnumerable<NewDTO>>(lastTen);
        }

        public async Task<bool> UpdateAsync(NewDTO NewDTO)
        {
            var exsitingNew = await _unitOfWork.New.Get(x => x.Id == NewDTO.Id);
            if (exsitingNew is null) return false;

            var updatedEntity = _mapper.Map<New>(NewDTO);
            return await _unitOfWork.New.UpdateAsync(exsitingNew.Id, updatedEntity);
        }
    }
}
