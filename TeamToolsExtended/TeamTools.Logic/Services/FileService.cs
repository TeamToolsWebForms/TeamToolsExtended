using Bytes2you.Validation;
using TeamTools.Logic.Data.Contracts;
using TeamTools.Logic.Data.Models;
using TeamTools.Logic.DTO;
using TeamTools.Logic.Mvp.Profile.MyProjectDetails.Contracts;
using TeamTools.Logic.Services.Contracts;
using TeamTools.Logic.Services.Helpers.Contracts;

namespace TeamTools.Logic.Services
{
    public class FileService : IFileService
    {
        private readonly IRepository<ProjectDocument> projectDocumentRepository;
        private readonly IRepository<Organization> organizationRepository;
        private readonly IRepository<OrganizationLogo> organizationLogoRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapperService mapperService;
        private readonly IProjectDocumentFactory projectDocumentFactory;
        private readonly IImageHelper imageHelper;

        public FileService(
            IRepository<ProjectDocument> projectDocumentRepository,
            IRepository<Organization> organizationRepository,
            IRepository<OrganizationLogo> organizationLogoRepository,
            IUnitOfWork unitOfWork,
            IMapperService mapperService,
            IProjectDocumentFactory projectDocumentFactory,
            IImageHelper imageHelper)
        {
            Guard.WhenArgument(projectDocumentRepository, "ProjectDocument Repository").IsNull().Throw();
            Guard.WhenArgument(organizationRepository, "Organization Repository").IsNull().Throw();
            Guard.WhenArgument(organizationLogoRepository, "OrganizationLogo Repository").IsNull().Throw();
            Guard.WhenArgument(unitOfWork, "Unit of work").IsNull().Throw();
            Guard.WhenArgument(mapperService, "Mapper Service").IsNull().Throw();
            Guard.WhenArgument(projectDocumentFactory, "ProjectDocument Factory").IsNull().Throw();
            Guard.WhenArgument(imageHelper, "Image Helper").IsNull().Throw();

            this.projectDocumentRepository = projectDocumentRepository;
            this.organizationRepository = organizationRepository;
            this.organizationLogoRepository = organizationLogoRepository;
            this.unitOfWork = unitOfWork;
            this.mapperService = mapperService;
            this.projectDocumentFactory = projectDocumentFactory;
            this.imageHelper = imageHelper;
        }

        public void SaveDocument(string filename, string fileExtension, byte[] fileContent, int projectId)
        {
            var createdDocument = this.projectDocumentFactory.CreateProjectDocument(filename, fileExtension, fileContent, projectId);
            var mappedProjectDocument = this.mapperService.MapObject<ProjectDocument>(createdDocument);
            this.projectDocumentRepository.Add(mappedProjectDocument);
            this.unitOfWork.Commit();
        }

        public ProjectDocumentDTO DownloadFile(int id)
        {
            var projectDocument = this.projectDocumentRepository.GetById(id);
            var mappedProjectDocument = this.mapperService.MapObject<ProjectDocumentDTO>(projectDocument);
            return mappedProjectDocument;
        }

        public void UpdateDocument(byte[] content, int organizationId)
        {
            var organization = this.organizationRepository.GetById(organizationId);
            var organizationLogo = this.organizationLogoRepository.GetById(organization.OrganizationLogoId);
            organizationLogo.Image = content;
            organization.OrganizationLogoUrl = this.imageHelper.ByteArrayToImageUrl(organizationLogo.Image);
            this.organizationLogoRepository.Update(organizationLogo);
            this.unitOfWork.Commit();
        }
    }
}
