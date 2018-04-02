using System.ComponentModel.DataAnnotations;
using Mining.Domain;

namespace Mining.Presentation.Models
{
    public class TransationsRequestModel
    {
        [Required]
        public Transaction[] Transactions {get;set;}
     
        [Required]
        public int MaxBlockSize {get;set;}
        public double BockFee {get;set;}
    }
}