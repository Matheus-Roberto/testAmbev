using Ambev.DeveloperEvaluation.Application.Sales.CreateSale;

public static class CreateSaleHandlerTestData
{
    public static CreateSaleCommand GenerateValidCommand()
    {
        return new CreateSaleCommand
        {
            Customer = "Cliente Exemplo",
            Branch = "Filial Central",
            Items = new List<CreateSaleItemCommand>
            {
                new() { ProductName = "Produto A", Quantity = 5, UnitPrice = 10.0m },
                new() { ProductName = "Produto B", Quantity = 12, UnitPrice = 5.0m }
            }
        };
    }

    public static CreateSaleCommand GenerateValidCommandWithDiscounts()
    {
        return new CreateSaleCommand
        {
            Customer = "Cliente Teste",
            Branch = "Filial Norte",
            Items = new List<CreateSaleItemCommand>
            {
                new() { ProductName = "Produto X", Quantity = 4, UnitPrice = 15.0m },
                new() { ProductName = "Produto Y", Quantity = 10, UnitPrice = 8.0m },
                new() { ProductName = "Produto Z", Quantity = 2, UnitPrice = 20.0m }
            }
        };
    }
}
