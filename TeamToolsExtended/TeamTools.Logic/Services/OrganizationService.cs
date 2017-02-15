using Bytes2you.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamTools.Logic.Data.Contracts;
using TeamTools.Logic.Data.Models;
using TeamTools.Logic.DTO;
using TeamTools.Logic.Services.Contracts;
using TeamTools.Logic.Services.Helpers.Contracts;

namespace TeamTools.Logic.Services
{
    public class OrganizationService : IOrganizationService
    {
        private readonly IRepository<Organization> organizationRepository;
        private readonly IRepository<User> userRepository;
        private readonly IMapperService mapperService;
        private readonly IImageHelper imageHelper;

        public OrganizationService(
            IRepository<Organization> organizationRepository,
            IRepository<User> userRepository,
            IMapperService mapperService,
            IImageHelper imageHelper)
        {
            Guard.WhenArgument(organizationRepository, "Organization Repository").IsNull().Throw();
            Guard.WhenArgument(userRepository, "User Repository").IsNull().Throw();
            Guard.WhenArgument(mapperService, "Mapper Service").IsNull().Throw();
            Guard.WhenArgument(imageHelper, "Image Helper").IsNull().Throw();

            this.organizationRepository = organizationRepository;
            this.userRepository = userRepository;
            this.mapperService = mapperService;
            this.imageHelper = imageHelper;
        }

        public IEnumerable<OrganizationDTO> GetUserOrganizations(string id)
        {
            var user = this.userRepository.GetById(id);
            var userOrganizations = user.Organizations.Select(x => this.mapperService.MapObject<OrganizationDTO>(x));

            return userOrganizations;
        }
    }
}
