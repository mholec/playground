namespace EFCoreDemo.Data.Models
{
    public class Price
    {
        public Price(decimal basePrice, decimal vatRate)
        {
            BasePrice = basePrice;
            VatRate = vatRate;
        }
        
        public decimal BasePrice { get; set; }
        public decimal VatRate { get; set; }

        public decimal PriceWithVat => BasePrice + (BasePrice * VatRate);
        public decimal Vat => BasePrice * VatRate;

        public static Price From(decimal basePrice, decimal vatRate)
        {
            return new Price(basePrice, vatRate);
        }
    }
}