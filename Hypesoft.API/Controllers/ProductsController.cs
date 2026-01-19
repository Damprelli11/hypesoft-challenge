using MediatR;
using Microsoft.AspNetCore.Mvc;
using Hypesoft.Application.Products.Commands.CreateProduct;
using Hypesoft.Application.Products.Queries.GetProductById;
using Hypesoft.Application.Products.Queries.GetAllProducts;

namespace Hypesoft.API.Controllers;

[ApiController]
[Route("api/products")]
public class ProductsController : ControllerBase
{
    private readonly IMediator _mediator;

    public ProductsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Create(
        [FromBody] CreateProductCommand command,
        CancellationToken cancellationToken)
    {
        var id = await _mediator.Send(command, cancellationToken);
        return CreatedAtAction(nameof(GetById), new { id }, null);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var products = await _mediator.Send(
            new GetAllProductsQuery(),
            cancellationToken);

        return Ok(products);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id, CancellationToken cancellationToken)
    {
        var product = await _mediator.Send(
            new GetProductByIdQuery(id),
            cancellationToken);

        if (product is null)
            return NotFound();

        return Ok(product);
    }
}
