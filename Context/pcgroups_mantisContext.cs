using System;
using System.Collections.Generic;
using DashboardApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DashboardApi.Context
{
    public partial class pcgroups_mantisContext : DbContext
    {
        public pcgroups_mantisContext()
        {
        }

        public pcgroups_mantisContext(DbContextOptions<pcgroups_mantisContext> options)
            : base(options)
        {
        }

        public virtual DbSet<MantisApiTokenTable> MantisApiTokenTables { get; set; } = null!;
        public virtual DbSet<MantisBugFileTable> MantisBugFileTables { get; set; } = null!;
        public virtual DbSet<MantisBugHistoryTable> MantisBugHistoryTables { get; set; } = null!;
        public virtual DbSet<MantisBugMonitorTable> MantisBugMonitorTables { get; set; } = null!;
        public virtual DbSet<MantisBugRelationshipTable> MantisBugRelationshipTables { get; set; } = null!;
        public virtual DbSet<MantisBugRevisionTable> MantisBugRevisionTables { get; set; } = null!;
        public virtual DbSet<MantisBugTable> MantisBugTables { get; set; } = null!;
        public virtual DbSet<MantisBugTagTable> MantisBugTagTables { get; set; } = null!;
        public virtual DbSet<MantisBugTextTable> MantisBugTextTables { get; set; } = null!;
        public virtual DbSet<MantisBugnoteTable> MantisBugnoteTables { get; set; } = null!;
        public virtual DbSet<MantisBugnoteTextTable> MantisBugnoteTextTables { get; set; } = null!;
        public virtual DbSet<MantisCategoryTable> MantisCategoryTables { get; set; } = null!;
        public virtual DbSet<MantisConfigTable> MantisConfigTables { get; set; } = null!;
        public virtual DbSet<MantisCustomFieldProjectTable> MantisCustomFieldProjectTables { get; set; } = null!;
        public virtual DbSet<MantisCustomFieldStringTable> MantisCustomFieldStringTables { get; set; } = null!;
        public virtual DbSet<MantisCustomFieldTable> MantisCustomFieldTables { get; set; } = null!;
        public virtual DbSet<MantisEmailTable> MantisEmailTables { get; set; } = null!;
        public virtual DbSet<MantisFiltersTable> MantisFiltersTables { get; set; } = null!;
        public virtual DbSet<MantisNewsTable> MantisNewsTables { get; set; } = null!;
        public virtual DbSet<MantisPluginTable> MantisPluginTables { get; set; } = null!;
        public virtual DbSet<MantisProjectFileTable> MantisProjectFileTables { get; set; } = null!;
        public virtual DbSet<MantisProjectHierarchyTable> MantisProjectHierarchyTables { get; set; } = null!;
        public virtual DbSet<MantisProjectTable> MantisProjectTables { get; set; } = null!;
        public virtual DbSet<MantisProjectUserListTable> MantisProjectUserListTables { get; set; } = null!;
        public virtual DbSet<MantisProjectVersionTable> MantisProjectVersionTables { get; set; } = null!;
        public virtual DbSet<MantisSponsorshipTable> MantisSponsorshipTables { get; set; } = null!;
        public virtual DbSet<MantisTagTable> MantisTagTables { get; set; } = null!;
        public virtual DbSet<MantisTokensTable> MantisTokensTables { get; set; } = null!;
        public virtual DbSet<MantisUserPrefTable> MantisUserPrefTables { get; set; } = null!;
        public virtual DbSet<MantisUserPrintPrefTable> MantisUserPrintPrefTables { get; set; } = null!;
        public virtual DbSet<MantisUserProfileTable> MantisUserProfileTables { get; set; } = null!;
        public virtual DbSet<MantisUserTable> MantisUserTables { get; set; } = null!;
        public virtual DbSet<ViewNoGestionado> ViewNoGestionados { get; set; } = null!;
        public virtual DbSet<ViewNoResuelto> ViewNoResueltos { get; set; } = null!;
        public virtual DbSet<ViewNotAcepted> ViewNotAcepteds { get; set; } = null!;
        public virtual DbSet<ViewNotresolved> ViewNotresolveds { get; set; } = null!;
        public virtual DbSet<ViewUnmanaged> ViewUnmanageds { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySQL("Server=www.pcgroupsa.com; Port=3306; Database=pcgroups_mantis; Uid=pcgroups_helpdeskAxel; Pwd=helpdeskAxel2023**;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MantisApiTokenTable>(entity =>
            {
                entity.ToTable("mantis_api_token_table");

                entity.HasIndex(e => new { e.UserId, e.Name }, "idx_user_id_name")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.DateCreated)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("date_created")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.DateUsed)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("date_used")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Hash)
                    .HasMaxLength(128)
                    .HasColumnName("hash");

                entity.Property(e => e.Name)
                    .HasMaxLength(128)
                    .HasColumnName("name");

                entity.Property(e => e.UserId)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("user_id");
            });

            modelBuilder.Entity<MantisBugFileTable>(entity =>
            {
                entity.ToTable("mantis_bug_file_table");

                entity.HasIndex(e => e.BugId, "idx_bug_file_bug_id");

                entity.HasIndex(e => e.Diskfile, "idx_diskfile");

                entity.Property(e => e.Id)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.BugId)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("bug_id");

                entity.Property(e => e.Content).HasColumnName("content");

                entity.Property(e => e.DateAdded)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("date_added")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Description)
                    .HasMaxLength(250)
                    .HasColumnName("description")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Diskfile)
                    .HasMaxLength(250)
                    .HasColumnName("diskfile")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.FileType)
                    .HasMaxLength(250)
                    .HasColumnName("file_type")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Filename)
                    .HasMaxLength(250)
                    .HasColumnName("filename")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Filesize)
                    .HasColumnType("int(11)")
                    .HasColumnName("filesize");

                entity.Property(e => e.Folder)
                    .HasMaxLength(250)
                    .HasColumnName("folder")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Title)
                    .HasMaxLength(250)
                    .HasColumnName("title")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.UserId)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("user_id");
            });

            modelBuilder.Entity<MantisBugHistoryTable>(entity =>
            {
                entity.ToTable("mantis_bug_history_table");

                entity.HasIndex(e => e.BugId, "idx_bug_history_bug_id");

                entity.HasIndex(e => e.DateModified, "idx_bug_history_date_modified");

                entity.HasIndex(e => e.UserId, "idx_history_user_id");

                entity.Property(e => e.Id)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.BugId)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("bug_id");

                entity.Property(e => e.DateModified)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("date_modified")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.FieldName)
                    .HasMaxLength(64)
                    .HasColumnName("field_name");

                entity.Property(e => e.NewValue)
                    .HasMaxLength(255)
                    .HasColumnName("new_value");

                entity.Property(e => e.OldValue)
                    .HasMaxLength(255)
                    .HasColumnName("old_value");

                entity.Property(e => e.Type)
                    .HasColumnType("smallint(6)")
                    .HasColumnName("type");

                entity.Property(e => e.UserId)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("user_id");
            });

            modelBuilder.Entity<MantisBugMonitorTable>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.BugId })
                    .HasName("PRIMARY");

                entity.ToTable("mantis_bug_monitor_table");

                entity.HasIndex(e => e.BugId, "idx_bug_id");

                entity.Property(e => e.UserId)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("user_id");

                entity.Property(e => e.BugId)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("bug_id");
            });

            modelBuilder.Entity<MantisBugRelationshipTable>(entity =>
            {
                entity.ToTable("mantis_bug_relationship_table");

                entity.HasIndex(e => e.DestinationBugId, "idx_relationship_destination");

                entity.HasIndex(e => e.SourceBugId, "idx_relationship_source");

                entity.Property(e => e.Id)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.DestinationBugId)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("destination_bug_id");

                entity.Property(e => e.RelationshipType)
                    .HasColumnType("smallint(6)")
                    .HasColumnName("relationship_type");

                entity.Property(e => e.SourceBugId)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("source_bug_id");
            });

            modelBuilder.Entity<MantisBugRevisionTable>(entity =>
            {
                entity.ToTable("mantis_bug_revision_table");

                entity.HasIndex(e => new { e.BugId, e.Timestamp }, "idx_bug_rev_id_time");

                entity.HasIndex(e => e.Type, "idx_bug_rev_type");

                entity.Property(e => e.Id)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.BugId)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("bug_id");

                entity.Property(e => e.BugnoteId)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("bugnote_id");

                entity.Property(e => e.Timestamp)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("timestamp")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Type)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("type");

                entity.Property(e => e.UserId)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("user_id");

                entity.Property(e => e.Value).HasColumnName("value");
            });

            modelBuilder.Entity<MantisBugTable>(entity =>
            {
                entity.ToTable("mantis_bug_table");

                entity.HasIndex(e => e.FixedInVersion, "idx_bug_fixed_in_version");

                entity.HasIndex(e => e.SponsorshipTotal, "idx_bug_sponsorship_total");

                entity.HasIndex(e => e.Status, "idx_bug_status");

                entity.HasIndex(e => e.ProjectId, "idx_project");

                entity.Property(e => e.Id)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.BugTextId)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("bug_text_id");

                entity.Property(e => e.Build)
                    .HasMaxLength(32)
                    .HasColumnName("build")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.CategoryId)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("category_id")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.DateSubmitted)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("date_submitted")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.DueDate)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("due_date")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.DuplicateId)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("duplicate_id");

                entity.Property(e => e.Eta)
                    .HasColumnType("smallint(6)")
                    .HasColumnName("eta")
                    .HasDefaultValueSql("'10'");

                entity.Property(e => e.FixedInVersion)
                    .HasMaxLength(64)
                    .HasColumnName("fixed_in_version")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.HandlerId)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("handler_id");

                entity.Property(e => e.LastUpdated)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("last_updated")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Os)
                    .HasMaxLength(32)
                    .HasColumnName("os")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.OsBuild)
                    .HasMaxLength(32)
                    .HasColumnName("os_build")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Platform)
                    .HasMaxLength(32)
                    .HasColumnName("platform")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Priority)
                    .HasColumnType("smallint(6)")
                    .HasColumnName("priority")
                    .HasDefaultValueSql("'30'");

                entity.Property(e => e.ProfileId)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("profile_id");

                entity.Property(e => e.ProjectId)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("project_id");

                entity.Property(e => e.Projection)
                    .HasColumnType("smallint(6)")
                    .HasColumnName("projection")
                    .HasDefaultValueSql("'10'");

                entity.Property(e => e.ReporterId)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("reporter_id");

                entity.Property(e => e.Reproducibility)
                    .HasColumnType("smallint(6)")
                    .HasColumnName("reproducibility")
                    .HasDefaultValueSql("'10'");

                entity.Property(e => e.Resolution)
                    .HasColumnType("smallint(6)")
                    .HasColumnName("resolution")
                    .HasDefaultValueSql("'10'");

                entity.Property(e => e.Severity)
                    .HasColumnType("smallint(6)")
                    .HasColumnName("severity")
                    .HasDefaultValueSql("'50'");

                entity.Property(e => e.SponsorshipTotal)
                    .HasColumnType("int(11)")
                    .HasColumnName("sponsorship_total");

                entity.Property(e => e.Status)
                    .HasColumnType("smallint(6)")
                    .HasColumnName("status")
                    .HasDefaultValueSql("'10'");

                entity.Property(e => e.Sticky)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("sticky");

                entity.Property(e => e.Summary)
                    .HasMaxLength(128)
                    .HasColumnName("summary")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.TargetVersion)
                    .HasMaxLength(64)
                    .HasColumnName("target_version")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Version)
                    .HasMaxLength(64)
                    .HasColumnName("version")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.ViewState)
                    .HasColumnType("smallint(6)")
                    .HasColumnName("view_state")
                    .HasDefaultValueSql("'10'");
            });

            modelBuilder.Entity<MantisBugTagTable>(entity =>
            {
                entity.HasKey(e => new { e.BugId, e.TagId })
                    .HasName("PRIMARY");

                entity.ToTable("mantis_bug_tag_table");

                entity.HasIndex(e => e.TagId, "idx_bug_tag_tag_id");

                entity.Property(e => e.BugId)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("bug_id");

                entity.Property(e => e.TagId)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("tag_id");

                entity.Property(e => e.DateAttached)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("date_attached")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.UserId)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("user_id");
            });

            modelBuilder.Entity<MantisBugTextTable>(entity =>
            {
                entity.ToTable("mantis_bug_text_table");

                entity.Property(e => e.Id)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.AdditionalInformation).HasColumnName("additional_information");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.StepsToReproduce).HasColumnName("steps_to_reproduce");
            });

            modelBuilder.Entity<MantisBugnoteTable>(entity =>
            {
                entity.ToTable("mantis_bugnote_table");

                entity.HasIndex(e => e.BugId, "idx_bug");

                entity.HasIndex(e => e.LastModified, "idx_last_mod");

                entity.Property(e => e.Id)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.BugId)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("bug_id");

                entity.Property(e => e.BugnoteTextId)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("bugnote_text_id");

                entity.Property(e => e.DateSubmitted)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("date_submitted")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.LastModified)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("last_modified")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.NoteAttr)
                    .HasMaxLength(250)
                    .HasColumnName("note_attr")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.NoteType)
                    .HasColumnType("int(11)")
                    .HasColumnName("note_type")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.ReporterId)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("reporter_id");

                entity.Property(e => e.TimeTracking)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("time_tracking");

                entity.Property(e => e.ViewState)
                    .HasColumnType("smallint(6)")
                    .HasColumnName("view_state")
                    .HasDefaultValueSql("'10'");
            });

            modelBuilder.Entity<MantisBugnoteTextTable>(entity =>
            {
                entity.ToTable("mantis_bugnote_text_table");

                entity.Property(e => e.Id)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.Note).HasColumnName("note");
            });

            modelBuilder.Entity<MantisCategoryTable>(entity =>
            {
                entity.ToTable("mantis_category_table");

                entity.HasIndex(e => new { e.ProjectId, e.Name }, "idx_category_project_name")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(128)
                    .HasColumnName("name")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.ProjectId)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("project_id");

                entity.Property(e => e.Status)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("status");

                entity.Property(e => e.UserId)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("user_id");
            });

            modelBuilder.Entity<MantisConfigTable>(entity =>
            {
                entity.HasKey(e => new { e.ConfigId, e.ProjectId, e.UserId })
                    .HasName("PRIMARY");

                entity.ToTable("mantis_config_table");

                entity.Property(e => e.ConfigId)
                    .HasMaxLength(64)
                    .HasColumnName("config_id");

                entity.Property(e => e.ProjectId)
                    .HasColumnType("int(11)")
                    .HasColumnName("project_id");

                entity.Property(e => e.UserId)
                    .HasColumnType("int(11)")
                    .HasColumnName("user_id");

                entity.Property(e => e.AccessReqd)
                    .HasColumnType("int(11)")
                    .HasColumnName("access_reqd")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Type)
                    .HasColumnType("int(11)")
                    .HasColumnName("type")
                    .HasDefaultValueSql("'90'");

                entity.Property(e => e.Value).HasColumnName("value");
            });

            modelBuilder.Entity<MantisCustomFieldProjectTable>(entity =>
            {
                entity.HasKey(e => new { e.FieldId, e.ProjectId })
                    .HasName("PRIMARY");

                entity.ToTable("mantis_custom_field_project_table");

                entity.Property(e => e.FieldId)
                    .HasColumnType("int(11)")
                    .HasColumnName("field_id");

                entity.Property(e => e.ProjectId)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("project_id");

                entity.Property(e => e.Sequence)
                    .HasColumnType("smallint(6)")
                    .HasColumnName("sequence");
            });

            modelBuilder.Entity<MantisCustomFieldStringTable>(entity =>
            {
                entity.HasKey(e => new { e.FieldId, e.BugId })
                    .HasName("PRIMARY");

                entity.ToTable("mantis_custom_field_string_table");

                entity.HasIndex(e => e.BugId, "idx_custom_field_bug");

                entity.Property(e => e.FieldId)
                    .HasColumnType("int(11)")
                    .HasColumnName("field_id");

                entity.Property(e => e.BugId)
                    .HasColumnType("int(11)")
                    .HasColumnName("bug_id");

                entity.Property(e => e.Text).HasColumnName("text");

                entity.Property(e => e.Value)
                    .HasMaxLength(255)
                    .HasColumnName("value")
                    .HasDefaultValueSql("''");
            });

            modelBuilder.Entity<MantisCustomFieldTable>(entity =>
            {
                entity.ToTable("mantis_custom_field_table");

                entity.HasIndex(e => e.Name, "idx_custom_field_name");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.AccessLevelR)
                    .HasColumnType("smallint(6)")
                    .HasColumnName("access_level_r");

                entity.Property(e => e.AccessLevelRw)
                    .HasColumnType("smallint(6)")
                    .HasColumnName("access_level_rw");

                entity.Property(e => e.DefaultValue)
                    .HasMaxLength(255)
                    .HasColumnName("default_value")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.DisplayClosed)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("display_closed");

                entity.Property(e => e.DisplayReport)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("display_report");

                entity.Property(e => e.DisplayResolved)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("display_resolved");

                entity.Property(e => e.DisplayUpdate)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("display_update")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.FilterBy)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("filter_by")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.LengthMax)
                    .HasColumnType("int(11)")
                    .HasColumnName("length_max");

                entity.Property(e => e.LengthMin)
                    .HasColumnType("int(11)")
                    .HasColumnName("length_min");

                entity.Property(e => e.Name)
                    .HasMaxLength(64)
                    .HasColumnName("name")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.PossibleValues)
                    .HasColumnType("text")
                    .HasColumnName("possible_values");

                entity.Property(e => e.RequireClosed)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("require_closed");

                entity.Property(e => e.RequireReport)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("require_report");

                entity.Property(e => e.RequireResolved)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("require_resolved");

                entity.Property(e => e.RequireUpdate)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("require_update");

                entity.Property(e => e.Type)
                    .HasColumnType("smallint(6)")
                    .HasColumnName("type");

                entity.Property(e => e.ValidRegexp)
                    .HasMaxLength(255)
                    .HasColumnName("valid_regexp")
                    .HasDefaultValueSql("''");
            });

            modelBuilder.Entity<MantisEmailTable>(entity =>
            {
                entity.HasKey(e => e.EmailId)
                    .HasName("PRIMARY");

                entity.ToTable("mantis_email_table");

                entity.Property(e => e.EmailId)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("email_id");

                entity.Property(e => e.Body).HasColumnName("body");

                entity.Property(e => e.Email)
                    .HasMaxLength(64)
                    .HasColumnName("email")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Metadata).HasColumnName("metadata");

                entity.Property(e => e.Subject)
                    .HasMaxLength(250)
                    .HasColumnName("subject")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Submitted)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("submitted")
                    .HasDefaultValueSql("'1'");
            });

            modelBuilder.Entity<MantisFiltersTable>(entity =>
            {
                entity.ToTable("mantis_filters_table");

                entity.Property(e => e.Id)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.FilterString).HasColumnName("filter_string");

                entity.Property(e => e.IsPublic)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("is_public");

                entity.Property(e => e.Name)
                    .HasMaxLength(64)
                    .HasColumnName("name")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.ProjectId)
                    .HasColumnType("int(11)")
                    .HasColumnName("project_id");

                entity.Property(e => e.UserId)
                    .HasColumnType("int(11)")
                    .HasColumnName("user_id");
            });

            modelBuilder.Entity<MantisNewsTable>(entity =>
            {
                entity.ToTable("mantis_news_table");

                entity.Property(e => e.Id)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.Announcement)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("announcement");

                entity.Property(e => e.Body).HasColumnName("body");

                entity.Property(e => e.DatePosted)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("date_posted")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Headline)
                    .HasMaxLength(64)
                    .HasColumnName("headline")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.LastModified)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("last_modified")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.PosterId)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("poster_id");

                entity.Property(e => e.ProjectId)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("project_id");

                entity.Property(e => e.ViewState)
                    .HasColumnType("smallint(6)")
                    .HasColumnName("view_state")
                    .HasDefaultValueSql("'10'");
            });

            modelBuilder.Entity<MantisPluginTable>(entity =>
            {
                entity.HasKey(e => e.Basename)
                    .HasName("PRIMARY");

                entity.ToTable("mantis_plugin_table");

                entity.Property(e => e.Basename)
                    .HasMaxLength(40)
                    .HasColumnName("basename");

                entity.Property(e => e.Enabled)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("enabled");

                entity.Property(e => e.Priority)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("priority")
                    .HasDefaultValueSql("'3'");

                entity.Property(e => e.Protected)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("protected");
            });

            modelBuilder.Entity<MantisProjectFileTable>(entity =>
            {
                entity.ToTable("mantis_project_file_table");

                entity.Property(e => e.Id)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.Content).HasColumnName("content");

                entity.Property(e => e.DateAdded)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("date_added")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Description)
                    .HasMaxLength(250)
                    .HasColumnName("description")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Diskfile)
                    .HasMaxLength(250)
                    .HasColumnName("diskfile")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.FileType)
                    .HasMaxLength(250)
                    .HasColumnName("file_type")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Filename)
                    .HasMaxLength(250)
                    .HasColumnName("filename")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Filesize)
                    .HasColumnType("int(11)")
                    .HasColumnName("filesize");

                entity.Property(e => e.Folder)
                    .HasMaxLength(250)
                    .HasColumnName("folder")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.ProjectId)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("project_id");

                entity.Property(e => e.Title)
                    .HasMaxLength(250)
                    .HasColumnName("title")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.UserId)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("user_id");
            });

            modelBuilder.Entity<MantisProjectHierarchyTable>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("mantis_project_hierarchy_table");

                entity.HasIndex(e => new { e.ChildId, e.ParentId }, "idx_project_hierarchy")
                    .IsUnique();

                entity.HasIndex(e => e.ChildId, "idx_project_hierarchy_child_id");

                entity.HasIndex(e => e.ParentId, "idx_project_hierarchy_parent_id");

                entity.Property(e => e.ChildId)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("child_id");

                entity.Property(e => e.InheritParent)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("inherit_parent");

                entity.Property(e => e.ParentId)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("parent_id");
            });

            modelBuilder.Entity<MantisProjectTable>(entity =>
            {
                entity.ToTable("mantis_project_table");

                entity.HasIndex(e => e.Name, "idx_project_name")
                    .IsUnique();

                entity.HasIndex(e => e.ViewState, "idx_project_view");

                entity.Property(e => e.Id)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.AccessMin)
                    .HasColumnType("smallint(6)")
                    .HasColumnName("access_min")
                    .HasDefaultValueSql("'10'");

                entity.Property(e => e.CategoryId)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("category_id")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.Enabled)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("enabled")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.FilePath)
                    .HasMaxLength(250)
                    .HasColumnName("file_path")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.InheritGlobal)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("inherit_global");

                entity.Property(e => e.Name)
                    .HasMaxLength(128)
                    .HasColumnName("name")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Status)
                    .HasColumnType("smallint(6)")
                    .HasColumnName("status")
                    .HasDefaultValueSql("'10'");

                entity.Property(e => e.ViewState)
                    .HasColumnType("smallint(6)")
                    .HasColumnName("view_state")
                    .HasDefaultValueSql("'10'");
            });

            modelBuilder.Entity<MantisProjectUserListTable>(entity =>
            {
                entity.HasKey(e => new { e.ProjectId, e.UserId })
                    .HasName("PRIMARY");

                entity.ToTable("mantis_project_user_list_table");

                entity.HasIndex(e => e.UserId, "idx_project_user");

                entity.Property(e => e.ProjectId)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("project_id");

                entity.Property(e => e.UserId)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("user_id");

                entity.Property(e => e.AccessLevel)
                    .HasColumnType("smallint(6)")
                    .HasColumnName("access_level")
                    .HasDefaultValueSql("'10'");
            });

            modelBuilder.Entity<MantisProjectVersionTable>(entity =>
            {
                entity.ToTable("mantis_project_version_table");

                entity.HasIndex(e => new { e.ProjectId, e.Version }, "idx_project_version")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.DateOrder)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("date_order")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.Obsolete)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("obsolete");

                entity.Property(e => e.ProjectId)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("project_id");

                entity.Property(e => e.Released)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("released")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Version)
                    .HasMaxLength(64)
                    .HasColumnName("version")
                    .HasDefaultValueSql("''");
            });

            modelBuilder.Entity<MantisSponsorshipTable>(entity =>
            {
                entity.ToTable("mantis_sponsorship_table");

                entity.HasIndex(e => e.BugId, "idx_sponsorship_bug_id");

                entity.HasIndex(e => e.UserId, "idx_sponsorship_user_id");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Amount)
                    .HasColumnType("int(11)")
                    .HasColumnName("amount");

                entity.Property(e => e.BugId)
                    .HasColumnType("int(11)")
                    .HasColumnName("bug_id");

                entity.Property(e => e.DateSubmitted)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("date_submitted")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.LastUpdated)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("last_updated")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Logo)
                    .HasMaxLength(128)
                    .HasColumnName("logo")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Paid)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("paid");

                entity.Property(e => e.Url)
                    .HasMaxLength(128)
                    .HasColumnName("url")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.UserId)
                    .HasColumnType("int(11)")
                    .HasColumnName("user_id");
            });

            modelBuilder.Entity<MantisTagTable>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.Name })
                    .HasName("PRIMARY");

                entity.ToTable("mantis_tag_table");

                entity.HasIndex(e => e.Name, "idx_tag_name");

                entity.Property(e => e.Id)
                    .HasColumnType("int(10) unsigned")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .HasColumnName("name")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.DateCreated)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("date_created")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.DateUpdated)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("date_updated")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.UserId)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("user_id");
            });

            modelBuilder.Entity<MantisTokensTable>(entity =>
            {
                entity.ToTable("mantis_tokens_table");

                entity.HasIndex(e => new { e.Type, e.Owner }, "idx_typeowner");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Expiry)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("expiry")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Owner)
                    .HasColumnType("int(11)")
                    .HasColumnName("owner");

                entity.Property(e => e.Timestamp)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("timestamp")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Type)
                    .HasColumnType("int(11)")
                    .HasColumnName("type");

                entity.Property(e => e.Value).HasColumnName("value");
            });

            modelBuilder.Entity<MantisUserPrefTable>(entity =>
            {
                entity.ToTable("mantis_user_pref_table");

                entity.Property(e => e.Id)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.BugnoteOrder)
                    .HasMaxLength(4)
                    .HasColumnName("bugnote_order")
                    .HasDefaultValueSql("'ASC'");

                entity.Property(e => e.DefaultProfile)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("default_profile");

                entity.Property(e => e.DefaultProject)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("default_project");

                entity.Property(e => e.EmailBugnoteLimit)
                    .HasColumnType("smallint(6)")
                    .HasColumnName("email_bugnote_limit");

                entity.Property(e => e.EmailOnAssigned)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("email_on_assigned");

                entity.Property(e => e.EmailOnAssignedMinSeverity)
                    .HasColumnType("smallint(6)")
                    .HasColumnName("email_on_assigned_min_severity")
                    .HasDefaultValueSql("'10'");

                entity.Property(e => e.EmailOnBugnote)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("email_on_bugnote");

                entity.Property(e => e.EmailOnBugnoteMinSeverity)
                    .HasColumnType("smallint(6)")
                    .HasColumnName("email_on_bugnote_min_severity")
                    .HasDefaultValueSql("'10'");

                entity.Property(e => e.EmailOnClosed)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("email_on_closed");

                entity.Property(e => e.EmailOnClosedMinSeverity)
                    .HasColumnType("smallint(6)")
                    .HasColumnName("email_on_closed_min_severity")
                    .HasDefaultValueSql("'10'");

                entity.Property(e => e.EmailOnFeedback)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("email_on_feedback");

                entity.Property(e => e.EmailOnFeedbackMinSeverity)
                    .HasColumnType("smallint(6)")
                    .HasColumnName("email_on_feedback_min_severity")
                    .HasDefaultValueSql("'10'");

                entity.Property(e => e.EmailOnNew)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("email_on_new");

                entity.Property(e => e.EmailOnNewMinSeverity)
                    .HasColumnType("smallint(6)")
                    .HasColumnName("email_on_new_min_severity")
                    .HasDefaultValueSql("'10'");

                entity.Property(e => e.EmailOnPriority)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("email_on_priority");

                entity.Property(e => e.EmailOnPriorityMinSeverity)
                    .HasColumnType("smallint(6)")
                    .HasColumnName("email_on_priority_min_severity")
                    .HasDefaultValueSql("'10'");

                entity.Property(e => e.EmailOnReopened)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("email_on_reopened");

                entity.Property(e => e.EmailOnReopenedMinSeverity)
                    .HasColumnType("smallint(6)")
                    .HasColumnName("email_on_reopened_min_severity")
                    .HasDefaultValueSql("'10'");

                entity.Property(e => e.EmailOnResolved)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("email_on_resolved");

                entity.Property(e => e.EmailOnResolvedMinSeverity)
                    .HasColumnType("smallint(6)")
                    .HasColumnName("email_on_resolved_min_severity")
                    .HasDefaultValueSql("'10'");

                entity.Property(e => e.EmailOnStatus)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("email_on_status");

                entity.Property(e => e.EmailOnStatusMinSeverity)
                    .HasColumnType("smallint(6)")
                    .HasColumnName("email_on_status_min_severity")
                    .HasDefaultValueSql("'10'");

                entity.Property(e => e.Language)
                    .HasMaxLength(32)
                    .HasColumnName("language")
                    .HasDefaultValueSql("'english'");

                entity.Property(e => e.ProjectId)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("project_id");

                entity.Property(e => e.RedirectDelay)
                    .HasColumnType("int(11)")
                    .HasColumnName("redirect_delay");

                entity.Property(e => e.RefreshDelay)
                    .HasColumnType("int(11)")
                    .HasColumnName("refresh_delay");

                entity.Property(e => e.Timezone)
                    .HasMaxLength(32)
                    .HasColumnName("timezone")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.UserId)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("user_id");
            });

            modelBuilder.Entity<MantisUserPrintPrefTable>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PRIMARY");

                entity.ToTable("mantis_user_print_pref_table");

                entity.Property(e => e.UserId)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("user_id");

                entity.Property(e => e.PrintPref)
                    .HasMaxLength(64)
                    .HasColumnName("print_pref");
            });

            modelBuilder.Entity<MantisUserProfileTable>(entity =>
            {
                entity.ToTable("mantis_user_profile_table");

                entity.Property(e => e.Id)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.Os)
                    .HasMaxLength(32)
                    .HasColumnName("os")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.OsBuild)
                    .HasMaxLength(32)
                    .HasColumnName("os_build")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Platform)
                    .HasMaxLength(32)
                    .HasColumnName("platform")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.UserId)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("user_id");
            });

            modelBuilder.Entity<MantisUserTable>(entity =>
            {
                entity.ToTable("mantis_user_table");

                entity.HasIndex(e => e.AccessLevel, "idx_access");

                entity.HasIndex(e => e.Email, "idx_email");

                entity.HasIndex(e => e.Enabled, "idx_enable");

                entity.HasIndex(e => e.CookieString, "idx_user_cookie_string")
                    .IsUnique();

                entity.HasIndex(e => e.Username, "idx_user_username")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.AccessLevel)
                    .HasColumnType("smallint(6)")
                    .HasColumnName("access_level")
                    .HasDefaultValueSql("'10'");

                entity.Property(e => e.CookieString)
                    .HasMaxLength(64)
                    .HasColumnName("cookie_string")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.DateCreated)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("date_created")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Email)
                    .HasMaxLength(191)
                    .HasColumnName("email")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Enabled)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("enabled")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.FailedLoginCount)
                    .HasColumnType("smallint(6)")
                    .HasColumnName("failed_login_count");

                entity.Property(e => e.LastVisit)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("last_visit")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.LoginCount)
                    .HasColumnType("int(11)")
                    .HasColumnName("login_count");

                entity.Property(e => e.LostPasswordRequestCount)
                    .HasColumnType("smallint(6)")
                    .HasColumnName("lost_password_request_count");

                entity.Property(e => e.Password)
                    .HasMaxLength(64)
                    .HasColumnName("password")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Protected)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("protected");

                entity.Property(e => e.Realname)
                    .HasMaxLength(191)
                    .HasColumnName("realname")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Username)
                    .HasMaxLength(191)
                    .HasColumnName("username")
                    .HasDefaultValueSql("''");
            });

            modelBuilder.Entity<ViewNoGestionado>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("view_NoGestionados");

                entity.Property(e => e.C)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("c");

                entity.Property(e => e.C0)
                    .HasColumnType("int(1)")
                    .HasColumnName("c0");

                entity.Property(e => e.DateSubmitted)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("date_submitted")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Summary)
                    .HasMaxLength(128)
                    .HasColumnName("summary")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Username)
                    .HasMaxLength(191)
                    .HasColumnName("username")
                    .HasDefaultValueSql("''");
            });

            modelBuilder.Entity<ViewNoResuelto>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("view_NoResueltos");

                entity.Property(e => e.C)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("c");

                entity.Property(e => e.C0)
                    .HasColumnType("int(1)")
                    .HasColumnName("c0");

                entity.Property(e => e.DateSubmitted)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("date_submitted")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Summary)
                    .HasMaxLength(128)
                    .HasColumnName("summary")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Username)
                    .HasMaxLength(191)
                    .HasColumnName("username")
                    .HasDefaultValueSql("''");
            });

            modelBuilder.Entity<ViewNotAcepted>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("view_notAcepted");

                entity.Property(e => e.C)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("c");

                entity.Property(e => e.C0)
                    .HasColumnType("int(1)")
                    .HasColumnName("c0");

                entity.Property(e => e.DateSubmitted)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("date_submitted")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Summary)
                    .HasMaxLength(128)
                    .HasColumnName("summary")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Username)
                    .HasMaxLength(191)
                    .HasColumnName("username")
                    .HasDefaultValueSql("''");
            });

            modelBuilder.Entity<ViewNotresolved>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("view_notresolved");

                entity.Property(e => e.C)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("c");

                entity.Property(e => e.C0)
                    .HasColumnType("int(1)")
                    .HasColumnName("c0");

                entity.Property(e => e.DateSubmitted)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("date_submitted")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Summary)
                    .HasMaxLength(128)
                    .HasColumnName("summary")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Username)
                    .HasMaxLength(191)
                    .HasColumnName("username")
                    .HasDefaultValueSql("''");
            });

            modelBuilder.Entity<ViewUnmanaged>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("view_unmanaged");

                entity.Property(e => e.C)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("c");

                entity.Property(e => e.C0)
                    .HasColumnType("int(1)")
                    .HasColumnName("c0");

                entity.Property(e => e.DateSubmitted)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("date_submitted")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Summary)
                    .HasMaxLength(128)
                    .HasColumnName("summary")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Username)
                    .HasMaxLength(191)
                    .HasColumnName("username")
                    .HasDefaultValueSql("''");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
