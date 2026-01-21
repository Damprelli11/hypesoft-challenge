using MediatR;
using Microsoft.AspNetCore.Mvc;
using Hypesoft.Application.Products.Commands.CreateProduct;
using Hypesoft.Application.Products.Commands.UpdateProduct;
using Hypesoft.Application.Products.Commands.DeleteProduct;
using Hypesoft.Application.Products.Queries.GetProductById;
using Hypesoft.Application.Products.Queries.GetAllProducts;

namespace Hypesoft.API.Controllers;

/// <summary>
/// Controller for managing products in the application.
/// Provides endpoints for CRUD operations on products.
/// </summary>
[ApiController]
[Route("api/products")]
public class ProductsController : ControllerBase
{
    private readonly IMediator _mediator;

    /// <summary>
    /// Initializes a new instance of the <see cref="ProductsController"/> class.
    /// </summary>
    /// <param name="mediator">The mediator for handling commands and queries.</param>
    public ProductsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Creates a new product.
    /// </summary>
    /// <param name="command">The command containing product details.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The ID of the created product.</returns>
    [HttpPost]
    public async Task<IActionResult> Create(
        [FromBody] CreateProductCommand command,
        CancellationToken cancellationToken)
    {
        var id = await _mediator.Send(command, cancellationToken);
        return CreatedAtAction(nameof(GetById), new { id }, null);
    }

    /// <summary>
    /// Retrieves all products.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A list of products.</returns>
    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var products = await _mediator.Send(
            new GetAllProductsQuery(),
            cancellationToken);

        return Ok(products);
    }

    /// <summary>
    /// Retrieves a product by its ID.
    /// </summary>
    /// <param name="id">The ID of the product.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The product if found, otherwise NotFound.</returns>
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

    /// <summary>
    /// Updates an existing product.
    /// </summary>
    /// <param name="id">The ID of the product to update.</param>
    /// <param name="command">The command containing updated product details.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>No content if successful.</returns>
    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(
        Guid id,
        [FromBody] UpdateProductCommand command,
        CancellationToken cancellationToken)
    {
        var commandWithId = command with { Id = id };

        await _mediator.Send(commandWithId, cancellationToken);

        return NoContent();
    }

    /// <summary>
    /// Deletes a product by ID.
    /// </summary>
    /// <param name="id">The ID of the product to delete.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>No content if successful.</returns>
    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(
        Guid id,
        CancellationToken cancellationToken)
    {
        await _mediator.Send(
            new DeleteProductCommand(id),
            cancellationToken);

        return NoContent();
    }
}
