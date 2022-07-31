namespace PetStore.Data.Models.Common
{
    public static class CardInfoValidationConstants
    {
        public const int CardNumberMaxLength = 19;
        //MM/YY
        public const int ExpirationDateMaxLength = 5;
        public const int CardHolderMaxLength = 100;
        public const int CVCMaxLength = 4;
    }
}
