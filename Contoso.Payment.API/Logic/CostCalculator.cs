namespace Contoso.Payment.API.Logic
{
    public enum Region
    {
        NorthAmerica,
        SouthAmerica,
        Africa,
        WestEurope,
        Caribe
    }

    /// <summary>
    /// Class responsable to calculate the cost for a payment process.
    /// </summary>
    public class CostCalculator
    {
        public const float TAX_NORTHAMERICA = 1.1f;
        public const float TAX_SOUTHAMERICA = 2.0f;
        public const float TAX_AFRICA = 1.4f;
        public const float TAX_WESTEUROPE = 3.2f;
        public const float TAX_CARIBE = .5f;

        public float GetTaxFromRegion(Region region)
        {
            return region switch
            {
                Region.NorthAmerica => TAX_NORTHAMERICA,
                Region.SouthAmerica => TAX_SOUTHAMERICA,
                Region.Africa => TAX_AFRICA,
                Region.WestEurope => TAX_WESTEUROPE,
                Region.Caribe => TAX_CARIBE,
                _ => throw new InvalidOperationException(),
            };
        }

        public float CalculatePayment(float initialAmount, Region region)
        {
            float tax = GetTaxFromRegion(region);
            return (tax * initialAmount) + initialAmount;
        }
    }
}
