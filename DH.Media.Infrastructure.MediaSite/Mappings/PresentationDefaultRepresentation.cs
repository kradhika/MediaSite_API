namespace DH.Media.Infrastructure.Media.Mappings
{
    public class PresentationDefaultRepresentation
    {
        #region Properties
        public string Id { get; set; }
        public string Title { get; set; }
        public string Status { get; set; }

        #endregion

        #region Constructors
        public PresentationDefaultRepresentation() { }

        public PresentationDefaultRepresentation(PresentationDefaultRepresentation obj)
        {
            Id = obj.Id;
            Title = obj.Title;
            Status = obj.Status;
        }

        #endregion
    }
}
