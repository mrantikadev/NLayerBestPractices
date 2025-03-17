﻿namespace App.Services.Products
{
    public record ProductDto(int Id, string Name, decimal Price, int Stock);

    //public record ProductDto
    //{
    //    public int Id { get; init; }
    //    public string Name { get; init; }
    //    public decimal Price { get; init; }
    //    public int Stock { get; init; }
    //}
}
