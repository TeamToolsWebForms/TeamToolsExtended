using Bytes2you.Validation;
using TeamTools.Logic.Data.Contracts;
using TeamTools.Logic.Data.Models;
using TeamTools.Logic.DTO;
using TeamTools.Logic.Services.Contracts;

namespace TeamTools.Logic.Services
{
    public class FileService : IFileService
    {
        private readonly IRepository<ProjectDocument> projectDocumentRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapperService mapperService;

        public FileService(
            IRepository<ProjectDocument> projectDocumentRepository,
            IUnitOfWork unitOfWork,
            IMapperService mapperService)
        {
            Guard.WhenArgument(projectDocumentRepository, "ProjectDocument Repository").IsNull().Throw();
            Guard.WhenArgument(unitOfWork, "Unit of work").IsNull().Throw();
            Guard.WhenArgument(mapperService, "Mapper Service").IsNull().Throw();

            this.projectDocumentRepository = projectDocumentRepository;
            this.unitOfWork = unitOfWork;
            this.mapperService = mapperService;
        }

        public void SaveDocument(ProjectDocumentDTO projectDocument)
        {
            var mappedProjectDocument = this.mapperService.MapObject<ProjectDocument>(projectDocument);
            this.projectDocumentRepository.Add(mappedProjectDocument);
            this.unitOfWork.Commit();
        }
    }
}
