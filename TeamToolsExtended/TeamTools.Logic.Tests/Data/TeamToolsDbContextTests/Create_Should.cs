using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using TeamTools.Logic.Data;

namespace TeamTools.Logic.Tests.Data.TeamToolsDbContextTests
{
    [TestFixture]
    public class Create_Should
    {
        [Test]
        public void ReturnInstanceOf_TeamToolsDbContext()
        {
            var result = TeamToolsDbContext.Create();

            Assert.IsInstanceOf<TeamToolsDbContext>(result);
        }

        [Test]
        public void ReturnNotNull_TeamToolsDbContext()
        {
            var result = TeamToolsDbContext.Create();

            Assert.IsNotNull(result);
        }
    }
}
