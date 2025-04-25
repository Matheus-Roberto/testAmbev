using Ambev.DeveloperEvaluation.Application.Sales.CreateSale;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentAssertions;
using NSubstitute;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Application;

/// <summary>
/// Contains unit tests for the <see cref="CreateSaleHandler"/> class.
/// </summary>
public class CreateSaleHandlerTests
{
    private readonly ISaleRepository _saleRepository;
    private readonly IMapper _mapper;
    private readonly CreateSaleHandler _handler;

    public CreateSaleHandlerTests()
    {
        _saleRepository = Substitute.For<ISaleRepository>();
        _mapper = Substitute.For<IMapper>();
        _handler = new CreateSaleHandler(_saleRepository, _mapper);
    }

    [Fact(DisplayName = "Given valid sale data When creating sale Then returns success response")]
    public async Task Handle_ValidRequest_ReturnsSuccessResponse()
    {
        // Given
        var command = CreateSaleHandlerTestData.GenerateValidCommand();
        var sale = new Sale(
            command.SaleNumber,
            command.Customer,
            command.Branch
        );

        foreach (var item in command.Items)
        {
            sale.AddItem(item.ProductName, item.Quantity, item.UnitPrice);
        }

        var result = new CreateSaleResult { SaleId = sale.Id };

        _mapper.Map<Sale>(command).Returns(sale);
        _mapper.Map<CreateSaleResult>(sale).Returns(result);
        _saleRepository.AddAsync(Arg.Any<Sale>(), Arg.Any<CancellationToken>())
            .Returns(Task.FromResult(sale));

        // When
        var createSaleResult = await _handler.Handle(command, CancellationToken.None);

        // Then
        createSaleResult.Should().NotBeNull();
        createSaleResult.SaleId.Should().Be(sale.Id);
        await _saleRepository.Received(1).AddAsync(Arg.Any<Sale>(), Arg.Any<CancellationToken>());
    }

    [Fact(DisplayName = "Given invalid sale data When creating sale Then throws validation exception")]
    public async Task Handle_InvalidRequest_ThrowsValidationException()
    {
        // Given
        var command = new CreateSaleCommand(); // Empty, should fail validation

        // When
        var act = () => _handler.Handle(command, CancellationToken.None);

        // Then
        await act.Should().ThrowAsync<FluentValidation.ValidationException>();
    }

    [Fact(DisplayName = "Given valid sale request When handling Then sale items obey business rules")]
    public async Task Handle_ValidRequest_AppliesDiscountsCorrectly()
    {
        // Given
        var command = CreateSaleHandlerTestData.GenerateValidCommandWithDiscounts();

        var sale = new Sale(command.SaleNumber, command.Customer, command.Branch);
        foreach (var item in command.Items)
        {
            sale.AddItem(item.ProductName, item.Quantity, item.UnitPrice);
        }

        _mapper.Map<Sale>(command).Returns(sale);
        _saleRepository.AddAsync(Arg.Any<Sale>(), Arg.Any<CancellationToken>())
            .Returns(Task.FromResult(sale));

        // When
        var result = await _handler.Handle(command, CancellationToken.None);

        // Then
        result.Should().NotBeNull();
        sale.Items.Should().OnlyContain(i =>
            (i.Quantity >= 10 && i.Discount == 0.2m) ||
            (i.Quantity >= 4 && i.Quantity < 10 && i.Discount == 0.1m) ||
            (i.Quantity < 4 && i.Discount == 0));
    }

    [Fact(DisplayName = "Given valid command When handling Then maps command to sale entity")]
    public async Task Handle_ValidRequest_MapsCommandToSale()
    {
        // Given
        var command = CreateSaleHandlerTestData.GenerateValidCommand();
        var sale = new Sale(command.SaleNumber, command.Customer, command.Branch);

        _mapper.Map<Sale>(command).Returns(sale);
        _saleRepository.AddAsync(Arg.Any<Sale>(), Arg.Any<CancellationToken>())
            .Returns(Task.FromResult(sale));

        // When
        await _handler.Handle(command, CancellationToken.None);

        // Then
        _mapper.Received(1).Map<Sale>(Arg.Is<CreateSaleCommand>(c =>
            
            c.Customer == command.Customer &&
            c.Branch == command.Branch &&
            c.Items.Count == command.Items.Count
        ));
    }
}
