﻿using Bytes2you.Validation;
using TeamTools.Logic.Mvp.Profile.MyProjectDetails.Contracts;
using TeamTools.Logic.Services.Contracts;
using WebFormsMvp;

namespace TeamTools.Logic.Mvp.Profile.MyProjectDetails
{
    public class ProjectDocumentsPresenter : Presenter<IMyProjectDocumentsView>
    {
        private readonly IProjectService projectService;
        private readonly IFileService fileService;

        public ProjectDocumentsPresenter(IMyProjectDocumentsView view, IProjectService projectService, IFileService fileService)
            : base(view)
        {
            Guard.WhenArgument(projectService, "Project Service").IsNull().Throw();
            Guard.WhenArgument(fileService, "File Service").IsNull().Throw();

            this.View.GetDocuments += this.View_GetDocuments;
            this.View.GetDocumentInfo += this.View_GetDocumentInfo;
            this.View.FindDocuments += this.View_FindDocuments;

            this.projectService = projectService;
            this.fileService = fileService;
        }

        private void View_FindDocuments(object sender, ProjectDocumentsEventArgs e)
        {
            this.View.Model.Project = this.projectService.GetByIdSearchedDocuments(e.ProjectId, e.Pattern);
        }

        private void View_GetDocumentInfo(object sender, ProjectDetailsEventArgs e)
        {
            this.View.Model.DocumentInfo = this.fileService.DownloadFile(e.Id);
        }

        private void View_GetDocuments(object sender, ProjectDetailsEventArgs e)
        {
            this.View.Model.Project = this.projectService.GetById(e.Id);
        }
    }
}
