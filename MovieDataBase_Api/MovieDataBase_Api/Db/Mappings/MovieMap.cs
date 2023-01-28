//using Microsoft.EntityFrameworkCore.Metadata.Builders;
//using Microsoft.EntityFrameworkCore;
//using MovieDataBase_Api.Db.Entities;

//namespace MovieDataBase_Api.Db.Mappings
//{
//    public class MovieMap : IEntityTypeConfiguration<MovieEntity>
//    {
//        public void Configure(EntityTypeBuilder<MovieEntity> builder)
//        {
//            builder.HasKey(t => t.Id);
//            builder.Property(t => t.Name).HasMaxLength(200).IsRequired();
//            builder.Property(t => t.ShortDescription).HasMaxLength(2000).IsRequired();
//            builder.Property(t => t.Year ).IsRequired();
//            builder.Property(t => t.Status).IsRequired();
//            builder.Property(t => t.CreateYear).IsRequired();
//        }
//    }

//}
