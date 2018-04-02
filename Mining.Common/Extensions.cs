using System;
using System.Collections.Generic;
using System.Linq;
using Mining.Domain;

namespace Mining.Common
{
   public static class Extenstions
    {
        public static int TotalSize(this IEnumerable<Transaction> owner) => owner.Sum(x => x.Size);
        public static double TotalFees(this IEnumerable<Transaction> owner) => owner.Sum(x => x.Fee);
        public static Tuple<List<Transaction>, List<Transaction>> Spilt(this IEnumerable<Transaction> owner)
        {
            int total = owner.Count();
            var left = owner.Take(total / 2).ToList();
            var right = owner.Skip(left.Count()).ToList();
            return Tuple.Create(left, right);

        }

    }
}
