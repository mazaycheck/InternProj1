using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Models;

namespace WebApplication2.Data.Configurations
{
    public class MessageConfiguration : IEntityTypeConfiguration<Message>
    {
        public void Configure(EntityTypeBuilder<Message> builder)
        {


            builder
                .HasOne(m => m.UserSent)
                .WithMany(m => m.MessagesSent)
                .HasForeignKey(m => m.UserSentId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(m => m.UserRecieved)
                .WithMany(m => m.MessagesRecieved)
                .HasForeignKey(m => m.UserRecievedId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
