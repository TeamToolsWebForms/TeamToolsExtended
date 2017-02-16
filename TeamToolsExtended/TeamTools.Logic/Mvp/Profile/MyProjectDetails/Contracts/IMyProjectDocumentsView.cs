using System;
using WebFormsMvp;

namespace TeamTools.Logic.Mvp.Profile.MyProjectDetails.Contracts
{
    public interface IMyProjectDocumentsView : IView<ProjectDetailsViewModel>
    {
        event EventHandler<ProjectDetailsEventArgs> GetDocuments;
        event EventHandler<ProjectDetailsEventArgs> GetDocumentInfo;
        event EventHandler<ProjectDocumentsEventArgs> FindDocuments;
    }
}
