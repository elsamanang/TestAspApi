﻿namespace TestAspApi.DTOs
{
#nullable disable
    public class OperationDTO
    {
        public int Id { get; set; }
        public int Prix { get; set; }
        public int Quantite { get; set;}
        public DateTime Day { get; set; }
        public int TypeOperationId { get; set; }
        public string OperationName { get; set; }

    }
}
