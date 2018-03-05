using System.Collections.Generic;
using DH.Media.Core.Integration.Media.ViewModels;

namespace DH.Media.Core.Application.UnitTest
{
    /// <summary>
    /// Application Test Data Builder
    /// </summary>
    public static class TestDataBuilder
    {
        public const string TenantIdTest1 = "90C641E8-E12F-406A-BB31-9557CE7D9F66";

        #region MediaApplicationTest Test data

        public static readonly string SearchCriteria = "SomeCriteria";
        public static readonly string PresentationId = "12127";
        public static readonly int MinutesToLive = 2;
        public static readonly string Query = "presentationId=12127&minutesToLive=2";
        public static List<Presentation> PresentationLst { get; } = new List<Presentation> {
            new Presentation{ Id="1",Name="Media",Description="Desc",PrimaryPresenter="PrimaryPresenter"},
            new Presentation{ Id="2",Name="Media",Description="Desc",PrimaryPresenter="PrimaryPresenter"} };
        public static List<Presentation> PresentationsObj { get; } = new List<Presentation> {
            new Presentation{ Id="1",Name="Media",Description="Desc",PrimaryPresenter="PrimaryPresenter"},
            new Presentation{ Id="2",Name="Media",Description="Desc",PrimaryPresenter="PrimaryPresenter"} };
        
        #endregion
    }
}
