using CleanArchMvc.Domain.Entities;
using FluentAssertions;

namespace CleanArchMvc.Domain.Tests
{
    public class ProductUnitTest1
    {
        [Fact(DisplayName = "Create a valid product")]

        public void CreateProduct_WithValidParameters_ResultObjectValidState()
        {

            Action action = () => new Product(1, "Product Name", "Product Description", 9.99m,
            99, "product image");
            action.Should()
                .NotThrow<Validation.DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Try to create a product with negative id")]
        public void CreateProduct_NegativeIdValue_DomainExceptionInvalidId()
        {

            Action action = () => new Product(-1, "Product Name", "Product Description", 9.99m,
            99, "product image");

            action.Should().Throw<Validation.DomainExceptionValidation>()
                .WithMessage("Invalid Id value.");
        }

        [Fact(DisplayName = "Try to create a product with a short name")]
        public void CreateProduct_ShortNameValue_DomainExceptionShortName()
        {

            Action action = () => new Product(1, "Pr", "Product Description", 9.99m, 99,
                "product image");
            action.Should()
                .Throw<Validation.DomainExceptionValidation>()
                .WithMessage("Invalid name, too short, minimum 3 characters.");
        }

        [Fact(DisplayName = "Try to create a product with long image name")]
        public void CreateProduct_LongImageName_DomainExceptionLongImageName()
        {

            Action action = () => new Product(1, "Product Name", "Product Description", 9.99m,
                99, "product image tooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooo looooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooong");

            action.Should()
            .Throw<Validation.DomainExceptionValidation>()
            .WithMessage("Invalid image name, too long, maximum 250 characters.");
        }

        [Fact(DisplayName = "Try to create a product with null image name")]
        public void CreateProduct_WithNullImageName_NoDomainException()
        {

            Action action = () => new Product(1, "Product Name", "Product Description", 9.99m, 99, null);
            action.Should().NotThrow<Validation.DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Try to create a product with empty image name")]
        public void CreateProduct_WithEmptyImageName_NoDomainException()
        {

            Action action = () => new Product(1, "Product Name", "Product Description", 9.99m, 99, "");
            action.Should().NotThrow<Validation.DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Try to create a product with invalid price")]
        public void CreateProduct_WithInvalidPrice_DomainException()
        {

            Action action = () => new Product(1, "Product Name", "Product Description", -9.99m, 99, "");
            action.Should().Throw<Validation.DomainExceptionValidation>();
        }

        [Theory(DisplayName = "Try to create a product with invalid stock value")]
        [InlineData(-5)]
        public void CreateProduct_InvalidStockValue_ExceptionDomainNegativeValue(int value)
        {
            Action action = () => new Product(1, "Pro", "Product Description", 9.99m, value,
                "product image");
            action.Should().Throw<Validation.DomainExceptionValidation>()
            .WithMessage("Invalid stock value.");
        }
    }
}
