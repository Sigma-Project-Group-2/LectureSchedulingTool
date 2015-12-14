using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using LectureSchedulingTool.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LectureSchedulingTool.Tests.Models.Tests
{
    [TestClass]
    public class IdentityModelTest
    {
        [TestMethod]
        public void IdentityModel_AppDBContextTest_CreateContext_IsNotNull()
        {
            //arrange
            ApplicationDbContext context = new ApplicationDbContext();
            //act
            object result = ApplicationDbContext.Create();
            //assert
            Assert.IsNotNull(result);
        }
    }
}
