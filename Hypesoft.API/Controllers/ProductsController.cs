using MediatR;
using Microsoft.AspNetCore.Mvc;
using Hypesoft.Application.Products.Commands.CreateProduct;
using Hypesoft.Application.Products.Queries.GetProductById;

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
        return CreatedAtAction(
            nameof(GetById),
            new { id },
            new { id }
        );
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var product = await _mediator.Send(new GetProductByIdQuery(id));

        if (product is null)
            return NotFound();

        return Ok(product);
    }
}
