using Bytes2you.Validation;
using TeamTools.Logic.Mvp.Profile.MyProjectDetails.Contracts;
using TeamTools.Logic.Services.Contracts;
using WebFormsMvp;

namespace TeamTools.Logic.Mvp.Profile.MyProjectDetails
{
    public class MyProjectDetailsPresenter : Presenter<IMyProjectDetailsView>
    {
        private readonly IProjectService projectService;
        private readonly IProjectDocumentFactory projectDocumentFactory;
        private readonly IFileService fileService;

        public MyProjectDetailsPresenter(
            IMyProjectDetailsView view,
            IProjectService projectService,
            IProjectDocumentFactory projectDocumentFactory,
            IFileService fileService)
            : base(view)
        {
            Guard.WhenArgument(view, "View").IsNull().Throw();
            Guard.WhenArgument(projectService, "Project service").IsNull().Throw();
            Guard.WhenArgument(projectDocumentFactory, "ProjectDocument Factory").IsNull().Throw();
            Guard.WhenArgument(fileService, "File Service").IsNull().Throw();

            this.View.DeleteProject += View_DeleteProject;
            this.View.SaveDocument += View_SaveDocument;

            this.projectService = projectService;
            this.projectDocumentFactory = projectDocumentFactory;
            this.fileService = fileService;
        }

        private void View_SaveDocument(object sender, ProjectDetailsEventArgs e)
        {
            var projectDocument = this.projectDocumentFactory.CreateProjectDocument(e.FileName, e.FileExtension, e.FileContent, e.Id);
            this.fileService.SaveDocument(projectDocument);
        }

        private void View_DeleteProject(object sender, ProjectDetailsEventArgs e)
        {
            this.projectService.Delete(e.Id);
        }
    }
}
