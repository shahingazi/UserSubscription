using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using VoiceoverIP.DataAccess.Entities;

namespace VoiceOverIp.DataAccess.Mapping
{
    public class UserMapping: EntityTypeConfiguration<User>
    {
        public UserMapping()
        {
            ToTable("User");
            HasKey(x => x.Id);
            Property(x => x.Id).HasDatabaseGeneratedOption(
              DatabaseGeneratedOption.Identity);
            Property(x => x.Email).HasMaxLength(50).IsRequired()
                .HasColumnAnnotation(IndexAnnotation.AnnotationName,
                new IndexAnnotation(
                new IndexAttribute("IX_Email") { IsUnique = true }));
            Property(x => x.FirstName).HasMaxLength(50).IsRequired();
            Property(x => x.LastName).HasMaxLength(50).IsRequired();
           

        }
    }
}