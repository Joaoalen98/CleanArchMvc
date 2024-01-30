using CleanArch.Domain.Entities;
using FluentAssertions;

namespace CleanArch.Domain.Tests
{
    public class CategoryUnitTest1
    {
        [Fact(DisplayName = "Create category with valid state")]
        public void CreateCategory_WithValidParameters_ResultObjectValidState()
        {
            Action action = () => new Category(1, "Category Name");
            action.Should()
                .NotThrow<Validation.DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Try to create  a category with a negative id value")]
        public void CreateCategory_NegativeIdValue_ResultObjectValidState()
        {
            Action action = () => new Category(-1, "Category Name");
            action.Should()
                .Throw<Validation.DomainExceptionValidation>()
                .WithMessage("Invalid Id value.");
        }

        [Fact(DisplayName = "Try to create a category with null name")]
        public void CreateCategory_WithNullname_ResultObjectValidState()
        {
            Action action = () => new Category(1, null);
            action.Should()
                .Throw<Validation.DomainExceptionValidation>()
                .WithMessage("Name is required.");
        }

        [Fact(DisplayName = "Try to create a category with short name")]
        public void CreateCategory_WithShortName_ResultObjectValidState()
        {
            Action action = () => new Category(1, "Ca");
            action.Should()
                .Throw<Validation.DomainExceptionValidation>()
                .WithMessage("Name is too short, minimum 3 characters.");
        }
    }
}