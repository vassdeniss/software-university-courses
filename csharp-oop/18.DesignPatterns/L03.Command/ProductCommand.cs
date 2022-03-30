namespace L03.Command
{
    public class ProductCommand : ICommand
    {
        private readonly Product product;
        private readonly PriceAction action;
        private readonly decimal amount;

        public ProductCommand(Product product, PriceAction action, decimal amount)
        {
            this.product = product;
            this.action = action;
            this.amount = amount;
        }

        public void Execute()
        {
            if (action == PriceAction.Increase)
            {
                product.IncreasePrice(amount);
            }
            else if (action == PriceAction.Decrease)
            {
                product.DecreasePrice(amount);
            }
        }
    }
}
