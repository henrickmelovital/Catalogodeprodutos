using AutoMapper;
using ProVarejista.Application.DTOs;
using ProVarejista.Application.Interfaces;
using ProVarejista.Domain.Entities;
using ProVarejista.Domain.Interfaces;

namespace ProVarejista.Application.Services
{
    public class CategoriaService : ICategoriaService
    {
        private ICategoriaRepository _categoryRepository;
        private readonly IMapper _mapper;
        public CategoriaService(ICategoriaRepository categoryRepository,
            IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CategoriaDTO>> GetCategorias()
        {
            try
            {
                var categoriesEntity = await _categoryRepository.GetCategoriasAsync();
                var categoriasDto = _mapper.Map<IEnumerable<CategoriaDTO>>(categoriesEntity);
                return categoriasDto;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<CategoriaDTO> GetById(int? id)
        {
            var categoryEntity = await _categoryRepository.GetByIdAsync(id);
            return _mapper.Map<CategoriaDTO>(categoryEntity);
        }

        public async Task Add(CategoriaDTO categoryDto)
        {
            var categoryEntity = _mapper.Map<Categoria>(categoryDto);
            await _categoryRepository.CreateAsync(categoryEntity);
        }

        public async Task Update(CategoriaDTO categoryDto)
        {
            var categoryEntity = _mapper.Map<Categoria>(categoryDto);
            await _categoryRepository.UpdateAsync(categoryEntity);
        }

        public async Task Remove(int? id)
        {
            var categoryEntity = _categoryRepository.GetByIdAsync(id).Result;
            await _categoryRepository.RemoveAsync(categoryEntity);
        }
    }
}
