//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BusinessObjects.Dto
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class UserSectorRatingDto
    {
        public UserSectorRatingDto()
        {
        }

        public UserSectorRatingDto(UserSectorRating userSectorRating)
        {
            this.Id = userSectorRating.Id;
            this.UserId = userSectorRating.UserId;
            this.SectorId = userSectorRating.SectorId;
            this.Rating = userSectorRating.Rating;
            this.CreatedOn = userSectorRating.CreatedOn;
            this.ModifiedOn = userSectorRating.ModifiedOn;
            this.DeletedOn = userSectorRating.DeletedOn;
            this.RowVersion = userSectorRating.RowVersion;
        }

        [Required]
        public int Id { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public short SectorId { get; set; }

        [Required]
        public decimal Rating { get; set; }

        [Required]
        public System.DateTime CreatedOn { get; set; }

        [Required]
        public System.DateTime ModifiedOn { get; set; }

        public Nullable<System.DateTime> DeletedOn { get; set; }

        [Required]
        public byte[] RowVersion { get; set; }

        public UserSectorRating ToBusinessObject()
        {
            return new UserSectorRating()
            {
                Id = Id,
                UserId = UserId,
                SectorId = SectorId,
                Rating = Rating,
                CreatedOn = CreatedOn,
                ModifiedOn = ModifiedOn,
                DeletedOn = DeletedOn,
                RowVersion = RowVersion
            };
        }
    }
}