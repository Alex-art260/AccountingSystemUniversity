using AccountAuditory.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AccountAuditory.Data.Configurations
{
    public class RoomItemConfiguration : IEntityTypeConfiguration<TypeRoom>
    {
        public void Configure(EntityTypeBuilder<TypeRoom> builder)
        {
            builder.HasData(
             GetAllTypeRoom()
              );
        }

        public static TypeRoom[] GetAllTypeRoom()
        {
            return new[] {
                new TypeRoom{Id = 1, Name = "лекционное"},
                new TypeRoom{Id = 2, Name = "для практических занятий" },
                new TypeRoom{Id = 3, Name = "спортзал" },
                new TypeRoom{Id = 4, Name = "пр." }
            };
        }
    }
}
