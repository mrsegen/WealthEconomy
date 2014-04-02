//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BusinessObjects
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using BusinessObjects.Metadata;
    
    [MetadataType(typeof(UserLicenseRatingMetadata))]
    public partial class UserLicenseRating : IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public short LicenseId { get; set; }
        public decimal Rating { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public System.DateTime ModifiedOn { get; set; }
        public Nullable<System.DateTime> DeletedOn { get; set; }
    
        public virtual License License { get; set; }
        public virtual User User { get; set; }
    }
}
