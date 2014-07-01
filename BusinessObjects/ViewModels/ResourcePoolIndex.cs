﻿
namespace BusinessObjects.ViewModels
{
    public class ResourcePoolIndex
    {
        public ResourcePoolIndex() { }

        public ResourcePoolIndex(BusinessObjects.ResourcePoolIndex resourcePoolIndex)
        {
            Id = resourcePoolIndex.Id;
            Name = resourcePoolIndex.Name;
            IndexRatingCount = resourcePoolIndex.IndexRatingCount;
            IndexRatingAverage = resourcePoolIndex.IndexRatingAverage;
            IndexRatingPercentage = resourcePoolIndex.IndexRatingPercentage;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public decimal IndexRatingCount { get; set; }
        public decimal IndexRatingAverage { get; set; }
        public decimal IndexRatingPercentage { get; set; }
    }
}
