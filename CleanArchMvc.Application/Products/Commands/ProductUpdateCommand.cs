namespace CleanArchMvc.Application.Products.Commands
{
    public abstract class ProductUpdateCommand : ProductCommand
    {
        public int Id { get; set; }
    }
}
