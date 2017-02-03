using NUnit.Framework;
using TeamTools.Logic.Data.Models;

namespace TeamTools.Logic.Tests.Data.Models.ProjectTests
{
    [TestFixture]
    public class IsPersonal_Should
    {
        [TestCase(true)]
        [TestCase(false)]
        public void SetCorrect_IsPersonal(bool isPersonal)
        {
            var project = new Project();

            project.IsPersonal = isPersonal;

            Assert.AreEqual(isPersonal, project.IsPersonal);
        }
    }
}
