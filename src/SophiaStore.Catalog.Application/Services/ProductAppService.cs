using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using SophiaStore.Catalog.Application.Dtos;
using SophiaStore.Catalog.Domain;
using SophiaStore.Catalog.Domain.Aggregate;
using SophiaStore.Catalog.Domain.Services;
using SophiaStore.Core.DomainObjects;

namespace SophiaStore.Catalog.Application.Services
{
    public class ProductAppService : IProductAppService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        private readonly IStockService _iStockService;

        public ProductAppService(IProductRepository productRepository, IMapper mapper, IStockService iStockService)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _iStockService = iStockService;
        }

        public async Task<IEnumerable<ProductDto>> GetAll()
        {
            return _mapper.Map<IEnumerable<ProductDto>>(await _productRepository.GetAll());
        }

        public async Task<ProductDto> GetById(Guid id)
        {
            return _mapper.Map<ProductDto>(await _productRepository.GetById(id));
        }

        public async Task<IEnumerable<ProductDto>> GetByCategoryCode(int code)
        {
            return _mapper.Map<IEnumerable<ProductDto>>(await _productRepository.GetByCategoryCode(code));
        }

        public async Task<IEnumerable<CategoryDto>> GetAllCategories()
        {
            return _mapper.Map<IEnumerable<CategoryDto>>(await _productRepository.GetAllCategories());
        }

        public async Task Add(ProductDto productDto)
        {
            var product = _mapper.Map<Product>(productDto);
            _productRepository.Add(product);

            await _productRepository.UnitOfWork.Commit();
        }

        public async Task Update(ProductDto productDto)
        {
            var product = _mapper.Map<Product>(productDto);
            _productRepository.Update(product);

            await _productRepository.UnitOfWork.Commit();
        }

        public async Task AddCategory(CategoryDto categoryDto)
        {
            var category = _mapper.Map<Category>(categoryDto);
            _productRepository.Add(category);

            await _productRepository.UnitOfWork.Commit();
        }

        public async Task UpdateCategory(CategoryDto categoryDto)
        {
            var category = _mapper.Map<Category>(categoryDto);
            _productRepository.Update(category);

            await _productRepository.UnitOfWork.Commit();
        }

        public async Task<ProductDto> Debit(Guid productId, int quantity)
        {
            if (!_iStockService.Debit(productId, quantity).Result)
                throw new DomainException("Fail to Debit stock");

            return _mapper.Map<ProductDto>(await _productRepository.GetById(productId));
        }

        public async Task<ProductDto> Replace(Guid productId, int quantity)
        {
            if (!_iStockService.Replace(productId, quantity).Result)
                throw new DomainException("Fail to Debit stock");

            return _mapper.Map<ProductDto>(await _productRepository.GetById(productId));
        }

        public void Dispose()
        {
            _productRepository?.Dispose();
            _iStockService?.Dispose();
        }

    }
}
