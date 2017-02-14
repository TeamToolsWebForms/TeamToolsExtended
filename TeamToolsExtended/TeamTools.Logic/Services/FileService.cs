using Bytes2you.Validation;
using TeamTools.Logic.Data.Contracts;
using TeamTools.Logic.Data.Models;
using TeamTools.Logic.Mvp.Profile.MyProjectDetails.Contracts;
using TeamTools.Logic.Services.Contracts;

namespace TeamTools.Logic.Services
{
    public class FileService : IFileService
    {
        private readonly IRepository<ProjectDocument> projectDocumentRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapperService mapperService;
        private readonly IProjectDocumentFactory projectDocumentFactory;

        public FileService(
            IRepository<ProjectDocument> projectDocumentRepository,
            IUnitOfWork unitOfWork,
            IMapperService mapperService,
            IProjectDocumentFactory projectDocumentFactory)
        {
            Guard.WhenArgument(projectDocumentRepository, "ProjectDocument Repository").IsNull().Throw();
            Guard.WhenArgument(unitOfWork, "Unit of work").IsNull().Throw();
            Guard.WhenArgument(mapperService, "Mapper Service").IsNull().Throw();
            Guard.WhenArgument(projectDocumentFactory, "ProjectDocument Factory").IsNull().Throw();

            this.projectDocumentRepository = projectDocumentRepository;
            this.unitOfWork = unitOfWork;
            this.mapperService = mapperService;
            this.projectDocumentFactory = projectDocumentFactory;
        }

        public void SaveDocument(string filename, string fileExtension, byte[] fileContent, int projectId)
        {
            var createdDocument = this.projectDocumentFactory.CreateProjectDocument(filename, fileExtension, fileContent, projectId);
            var mappedProjectDocument = this.mapperService.MapObject<ProjectDocument>(createdDocument);
            this.projectDocumentRepository.Add(mappedProjectDocument);
            this.unitOfWork.Commit();
        }
    }
}
