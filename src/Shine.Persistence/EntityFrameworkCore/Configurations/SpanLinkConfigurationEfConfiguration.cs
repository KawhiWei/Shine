using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shine.Domain.AggregateRoots.Trace;

namespace Shine.Persistence.EntityFrameworkCore.Configurations;

public class SpanLinkConfigurationEfConfiguration : IEntityTypeConfiguration<SpanLink>
{
    public void Configure(EntityTypeBuilder<SpanLink> builder)
    {
        builder.ToTable("span_link");
        builder.HasKey(e => e.Id);
        builder.Property(x => x.Id).HasColumnName("id");
        builder.Property(x => x.TraceId).HasColumnName("trace_id").IsRequired();
        builder.Property(x => x.SpanId).HasColumnName("span_id").IsRequired();
        builder.Property(x => x.Index).HasColumnName("index").IsRequired();
        builder.Property(x => x.LinkedTraceId).HasColumnName("linked_trace_id").IsRequired();
        builder.Property(x => x.LinkedSpanId).HasColumnName("linked_span_id").IsRequired();
        builder.Property(x => x.LinkedTraceState).HasColumnName("linked_trace_state").IsRequired();
        builder.Property(x => x.LinkedTraceFlags).HasColumnName("linked_trace_flags").IsRequired();
        builder.Property(x => x.CreationTime).HasColumnName("creation_time");
        builder.Property(x => x.LastModificationTime).HasColumnName("last_modification_time");
        builder.Property(x => x.DeletionTime).HasColumnName("deletion_time");
        builder.HasMany(x => x.SpanLinkAttributes).WithOne()
            .HasForeignKey(x => x.SpanId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}