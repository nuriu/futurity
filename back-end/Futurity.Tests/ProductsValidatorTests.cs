using Futurity.Application.Commands.Products;
using Futurity.Application.Queries.Products;
using FluentValidation.TestHelper;
using Xunit;

namespace Futurity.Tests.Application.ValidatorTests
{
    public class ProductsValidatorTests
    {
        private readonly ListQueryValidator _listQueryValidator;
        private readonly AddCommandValidator _addCommandValidator;

        public ProductsValidatorTests()
        {
            _listQueryValidator = new ListQueryValidator();
            _addCommandValidator = new AddCommandValidator();
        }

        [Theory]
        [InlineData(0, -1)]
        [InlineData(-1, 0)]
        public void ListQuery_ShouldHave_ValidationErrors(int pageValue, int pageSizeValue)
        {
            _listQueryValidator.ShouldHaveValidationErrorFor(x => x.Page, pageValue);
            _listQueryValidator.ShouldHaveValidationErrorFor(x => x.PageSize, pageSizeValue);
        }

        [Theory]
        [InlineData(5, 50)]
        [InlineData(50, 5)]
        public void ListQuery_ShouldNotHave_ValidationErrors(int pageValue, int pageSizeValue)
        {
            _listQueryValidator.ShouldNotHaveValidationErrorFor(x => x.Page, pageValue);
            _listQueryValidator.ShouldNotHaveValidationErrorFor(x => x.PageSize, pageSizeValue);
        }

        [Fact]
        public void AddCommand_ShouldHave_ValidationErrors()
        {
            _addCommandValidator.ShouldHaveValidationErrorFor(x => x.Name, "");
            _addCommandValidator.ShouldHaveValidationErrorFor(x => x.Name, "Lorem ipsum dolor sit amet.");
            _addCommandValidator.ShouldHaveValidationErrorFor(x => x.Description, "");
            _addCommandValidator.ShouldHaveValidationErrorFor(x => x.UnitPrice, 0);
            _addCommandValidator.ShouldHaveValidationErrorFor(x => x.UnitPrice, -1);
            _addCommandValidator.ShouldHaveValidationErrorFor(x => x.UnitsInStock, -1);
            _addCommandValidator.ShouldHaveValidationErrorFor(
                x => x.Description,
                @"Lorem ipsum dolor sit amet, consectetur adipiscing elit. Donec ac augue vel diam iaculis commodo.
                        Curabitur finibus enim eget sagittis vestibulum. Suspendisse vulputate ultrices posuere.
                        Praesent at elit lacus. Etiam eget lectus elementum, interdum leo et, congue arcu. Vivamus bibendum convallis
                        libero sit amet fringilla. Proin at nulla lorem. Donec euismod quis ex non faucibus.
                        Nulla velit ligula, egestas vel enim eu, auctor dignissim quam.
                        Curabitur vel mattis nisi.Aliquam a pharetra nisl.Proin non justo tortor.Praesent in urna eu neque
                        elementum blandit.Nam pellentesque purus at eleifend vulputate.Maecenas pharetra rutrum auctor.Maecenas
                        ut auctor tortor, id egestas velit.In placerat augue vel libero placerat, vel posuere ex tincidunt.Fusce
                        pellentesque iaculis ex, vestibulum sollicitudin enim lobortis pretium.
                        Maecenas iaculis lectus sit amet vehicula pretium.In hac habitasse platea dictumst.Nullam
                        molestie dictum dolor, dapibus commodo ligula.Integer nec diam dictum, cursus nunc
                        quis, blandit leo.Quisque arcu tortor, aliquam quis urna id, efficitur hendrerit nunc.Maecenas
                        quis justo et ex congue ultricies.Curabitur posuere, nibh consequat lobortis
                        faucibus, massa mauris faucibus lacus, vitae pellentesque sem sapien et purus.
                        Quisque nec tincidunt nunc, non pharetra magna.Donec vulputate ligula in augue feugiat congue.Mauris
                        gravida feugiat ornare.Maecenas rutrum, lectus in ultrices accumsan, dui nulla pretium
                        quam, vel tincidunt sem urna quis risus.Nunc libero neque, porta et blandit
                        vel, finibus a purus.Suspendisse ornare, tortor sodales tempus luctus, enim neque eleifend
                        neque, non efficitur mauris sem ac elit.");
        }

        [Fact]
        public void AddCommand_ShouldNotHave_ValidationErrors()
        {
            _addCommandValidator.ShouldNotHaveValidationErrorFor(x => x.Name, "Lorem ipsum.");
            _addCommandValidator.ShouldNotHaveValidationErrorFor(x => x.Description, "Lorem ipsum.");
            _addCommandValidator.ShouldNotHaveValidationErrorFor(x => x.UnitPrice, 1);
            _addCommandValidator.ShouldNotHaveValidationErrorFor(x => x.UnitsInStock, 0);
            _addCommandValidator.ShouldNotHaveValidationErrorFor(x => x.UnitsInStock, 1);
            _addCommandValidator.ShouldNotHaveValidationErrorFor(
                x => x.Description,
                @"Lorem ipsum dolor sit amet, consectetur adipiscing elit. Donec ac augue vel diam iaculis commodo.
                        Curabitur finibus enim eget sagittis vestibulum.");
        }
    }
}
