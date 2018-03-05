using System;

namespace DH.Media.Infrastructure.Media.Mappings
{
    public class PresentationFullRepresentation : PresentationCardRepresentation
    {
        #region Properties

        public string RootId { get; set; }
        public string PlayerId { get; set; }
        public string PresentationTemplateId { get; set; }
        public string AlternateName { get; set; }
        public string CopyrightNotice { get; set; }
        public int MaximumConnections { get; set; }
        public string PublishingPointName { get; set; }
        public bool IsUploadAutomatic { get; set; }
        public string TimeZone { get; set; }
        public bool PollsEnabled { get; set; }
        public bool ForumsEnabled { get; set; }
        public bool SharingEnabled { get; set; }
        public bool PlayerLocked { get; set; }
        public bool PollsInternal { get; set; }
        public bool Private { get; set; }
        public bool NotifyOnMetadataChanged { get; set; }
        public string ApprovalState { get; set; }
        public string ApprovalRequiredChangeTypes { get; set; }
        public int ContentRevision { get; set; }
        public string PollLink { get; set; }
        public string ParentFolderName { get; set; }
        public string ParentFolderId { get; set; }
        public DateTime? DisplayRecordDate { get; set; }

        #endregion
    }
}
