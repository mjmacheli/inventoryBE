using System.Collections.Generic;
using InventoryApp.Models;
using MongoDB.Driver;

namespace InventoryApp.Services
{
    public class UserService
    {
        private readonly IMongoCollection<User> _users;

        public UserService(IinventoryAppDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _users = database.GetCollection<User>(settings.InventoryAppCollectionName);
        }

        public List<User> Get() =>
            _users.Find(user => true).ToList();

        public User Get(string id) =>
           _users.Find<User>(user => user.Id == id).FirstOrDefault();

        public User Login(string email, string password) =>
           _users.Find<User>(user => user.email == email && user.password == password).FirstOrDefault();

        public User Create(User user)
        {
            _users.InsertOne(user);
            return user;
        }

        public void Update(string id, User userIn) =>
           _users.ReplaceOne(user => user.Id == id, userIn);

        public void Remove(User userIn) =>
            _users.DeleteOne(user => user.Id == userIn.Id);

        public void Remove(string id) =>
            _users.DeleteOne(user => user.Id == id);

    }
}
