using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PostApplication.Core.Enums;
using PostApplication.Data.Repository;
using PostApplication.DataContext.PostApplication;
using System;
using System.Linq;

namespace PostApplication.Repository.Test
{
    [TestClass]
    public class RepositoryTest
    {
        private PostRepository _postRepository;
        private PostApplicationContext _context;
        private UserRepository _userRepository;
        private readonly string username = "felipe1";

        [TestInitialize]
        public void Init()
        {
            var builder = new DbContextOptionsBuilder<PostApplicationContext>();
            builder.UseInMemoryDatabase("PostsDB");
            _context = new PostApplicationContext(builder.Options);
            _postRepository = new PostRepository(_context);
            _userRepository = new UserRepository(_context);
            

        }

        [TestMethod]
        public void InsertPostTest()
        {
            var _roleMock = new Role
            {
                RoleId = 1,
                RoleName = "Test Role",
                RoleDescription = "Test"
            };

            var _userMock = new User
            {
                Role = _roleMock,
                Username = "user"
            };

            //Arrange
            var _blockMock = new Blog
            {
                BlogCreatedBy = _userMock,
                BlogCreationDate = DateTime.Now,

            };
            var _postStateMock = new PostState
            {
                PostStateId = 1,
                PostStateName = "Test"
            };

            var _postMock = new Post()
            {
                PostId = 0,
                Blog = _blockMock,
                PostPublicationDate = DateTime.Now,
                PostState = _postStateMock,
                PostText = "Unit Test Content",
                PostTitle = "Unit Test Title",
                PostUser = _userMock
            };

            //Act
            _postRepository.Insert(_postMock);
            var response = _postRepository.Save();

            //Asserts
            Assert.IsNotNull(response);
            Assert.IsTrue(response > 0);
        }
    }
}
