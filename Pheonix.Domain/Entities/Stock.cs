using System;

namespace Pheonix.Domain.Entities
{
    public class Stock : BaseEntity
    {
        public int ClientId { get; set; }
        public virtual Client Client { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
        public decimal Amount { get; set; }

        public void AddAmount(decimal amount)
        {
            ValidateAmount(amount);
            VerifyActive();
            Amount += amount;
        }        

        public void SubtractAmount(decimal amount)
        {
            ValidateAmount(amount);
            VerifyActive();

            var amountCalculated = Amount - amount;
            if (amountCalculated < decimal.Zero)
                throw new Exception("Estoque insuficiênte");

            Amount = amountCalculated;
        }

        private void VerifyActive()
        {
            if (!Actived)
                throw new Exception("Estoque desativado");
        }

        private static void ValidateAmount(decimal amount)
        {
            if (amount <= decimal.Zero)
                throw new Exception("A quantidade deve ser maior que zero");
        }
    }
}
