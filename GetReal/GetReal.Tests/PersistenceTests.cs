using System;
using System.Threading.Tasks;
using GetReal.Core.Models;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using GetReal.Mobile.Services;

namespace GetReal.Tests
{
    [TestFixture]
    public class PersistenceTests
    {
        private static string TestUser1Id = "655b8f24-be21-4366-96fa-bf039b34d9b0";
        private static string TestUser2Id = "9b53a1a2-2a8d-4569-8fca-94211c7a0907";
        private static string TestRoomId = "9474e545-ea87-4950-bc53-9bef751a3819";

        [OneTimeTearDown]
        public async Task CleanUp()
        {
            RealtimeDataService service = new RealtimeDataService();
            //await service.DeleteChatRoom(TestRoomId);
            //await service.DeleteUser(TestUser1Id);
            //await service.DeleteUser(TestUser2Id);
        }

        [Test]
        public async Task CanCreateChatRoom()
        {
            RealtimeDataService service = new RealtimeDataService();
            ChatRoom room = new ChatRoom() { Name = "testRoom", Id = TestRoomId };
            await service.CreateChatRoom(room);
            ChatRoom roomFromDb = await service.GetChatRoom(TestRoomId);
            Assert.AreEqual(room.Name, roomFromDb.Name);
        }

        [Test]
        public async Task CanCreateUser()
        {
            RealtimeDataService service = new RealtimeDataService();
            User person = new User() { Name = "testUser", Id = TestUser1Id };
            await service.Register(person);
            await service.Register(person);
            User personFromDb = await service.GetUser(TestUser1Id);
            Assert.AreEqual(person.Name, personFromDb.Name);
        }

        [Test]
        public async Task CanJoinChatRoom()
        {
            RealtimeDataService service = new RealtimeDataService();

            ChatRoom room = new ChatRoom() { Name = "testRoom", Id = TestRoomId };
            await service.CreateChatRoom(room);
            User testUser = new User() { Name = "testUser1", Id = TestUser1Id };
            await service.Register(testUser);
            User testUser2 = new User() { Name = "testUser2", Id = TestUser2Id };
            await service.Register(testUser2);

            List<User> peopleFromDb = await service.GetAllUsers();
            ChatRoom roomFromDb = await service.GetChatRoom(TestRoomId);

            foreach (var person in peopleFromDb)
            {
                await service.JoinChatRoom(person.Id, roomFromDb.Id);
            }
        }
    }
}
