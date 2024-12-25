using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using APILayer.DTOs;
using DataLayer;
using BuisnessLogic.Interfaces;

namespace APILayer.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly IProductService _productService;
    private readonly IMapper _mapper;

    public ProductsController(IProductService productService, IMapper mapper)
    {
        _productService = productService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProductDTO>>> GetProducts()
    {
        var products = await _productService.GetAllProductsAsync();
        return Ok(_mapper.Map<IEnumerable<ProductDTO>>(products));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ProductDTO>> GetProduct(int id)
    {
        var product = await _productService.GetProductByIdAsync(id);
        if (product == null)
            return NotFound();

        return Ok(_mapper.Map<ProductDTO>(product));
    }

    [HttpPost]
    public async Task<ActionResult<ProductDTO>> CreateProduct([FromBody] CreateProductDTO createProductDto)
    {
        var product = _mapper.Map<Product>(createProductDto);
        var createdProduct = await _productService.CreateProductAsync(product);

        return CreatedAtAction(
            nameof(GetProduct),
            new { id = createdProduct.Id },
            _mapper.Map<ProductDTO>(createdProduct));
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateProduct(int id, [FromBody] UpdateProductDTO updateProductDto)
    {
        var product = await _productService.GetProductByIdAsync(id);
        if (product == null)
            return NotFound();

        _mapper.Map(updateProductDto, product);
        await _productService.UpdateProductAsync(product);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProduct(int id)
    {
        var product = await _productService.GetProductByIdAsync(id);
        if (product == null)
            return NotFound();

        await _productService.DeleteProductAsync(id);
        return NoContent();
    }
}