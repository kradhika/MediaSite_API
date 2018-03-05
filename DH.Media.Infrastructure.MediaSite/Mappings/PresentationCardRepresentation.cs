using System;

namespace DH.Media.Infrastructure.Media.Mappings
{
    public class PresentationCardRepresentation : PresentationDefaultRepresentation
    {
        #region Properties
        public string Description { get; set; }

        public DateTime? RecordDate { get; set; }

        public DateTime? RecordDateLocal { get; set; }

        public int Duration { get; set; }

        public int NumberOfViews { get; set; }

        public string Owner { get; set; }

        public string PrimaryPresenter { get; set; }

        public string ThumbnailUrl { get; set; }

        public bool IsLive { get; set; }

        public DateTime? CreationDate { get; set; }
        
        public PresentationCardRepresentation()
        { }

        #endregion

        #region Constructor
        public PresentationCardRepresentation(PresentationCardRepresentation obj)
            : base(obj)
        {
            Description = obj.Description;
            Status = obj.Status;
            PrimaryPresenter = obj.PrimaryPresenter;
            ThumbnailUrl = obj.ThumbnailUrl;
            RecordDate = obj.RecordDate;
            RecordDateLocal = obj.RecordDateLocal;
            Duration = obj.Duration;
            NumberOfViews = obj.NumberOfViews;
            Owner = obj.Owner;
            CreationDate = obj.CreationDate;
            IsLive = obj.IsLive;
        }

        #endregion
    }
}
