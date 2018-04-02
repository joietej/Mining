using System;

namespace Mining.Domain
{
   public class Transaction
    {
        public int Id { get; set; }
        public int Size { get; set; }
        public double Fee { get; set; }

        public override string ToString() => $"#{Id}, Size : {Size} , Fee : {Fee}";
    }
}
