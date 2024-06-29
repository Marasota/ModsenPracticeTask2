
namespace OnlineStore.BLL.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        private readonly IValidator<ProductDTO> _validator;

        public ProductService(IProductRepository productRepository, IMapper mapper, IValidator<ProductDTO> validator)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _validator = validator;
        }

        public async Task<IEnumerable<ProductDTO>> GetAllAsync()
        {
            var products = await _productRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<ProductDTO>>(products);
        }

        public async Task<ProductDTO> GetByIdAsync(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            return _mapper.Map<ProductDTO>(product);
        }

        public async Task AddAsync(ProductDTO productDto)
        {
            await _validator.ValidateAndThrowAsync(productDto);
            var product = _mapper.Map<Product>(productDto);
            await _productRepository.AddAsync(product);
        }

        public async Task UpdateAsync(ProductDTO productDto)
        {
            await _validator.ValidateAndThrowAsync(productDto);
            var product = _mapper.Map<Product>(productDto);
            await _productRepository.UpdateAsync(product);
        }

        public async Task DeleteAsync(int id)
        {
            await _productRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<ProductDTO>> GetProductsByCategoryAsync(int categoryId)
        {
            var products = await _productRepository.GetProductsByCategoryAsync(categoryId);
            return _mapper.Map<IEnumerable<ProductDTO>>(products);
        }
    }
}
