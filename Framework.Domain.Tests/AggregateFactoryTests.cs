using FluentAssertions;
using Framework.Core;

namespace Framework.Domain.Tests
{
    public class AggregateFactoryTests
    {
        [SetUp]
        public void Setup()
        {
        }
        [Test]
        public void creates_aggregate_by_applying_events()
        {
            var userId = Guid.NewGuid();

            var events = new List<DomainEvent>
            {
                new UserRegistered(userId,"admin","john","doe"),
                new UserActivated(userId),
                new UserPersonalInfoUpdated("mike","cohn")
            };

            var factory = new AggregateFactory();

            var user = factory.Create<User>(events);

            user.Id.Should().Be(userId);
            user.Username.Should().Be("admin");
            user.FirstName.Should().Be("mike");
            user.LastName.Should().Be("cohn");
            user.IsActive.Should().BeTrue();
        }

    }

    public class User : AggregateRoot
    {
        public User(string username, string firstName, string lastName, bool isActive)
        {
            Username = username;
            FirstName = firstName;
            LastName = lastName;
            IsActive = isActive;
        }
        private User() { }
        public string Username { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public bool IsActive { get; private set; }
        public void Activate()
        {
            Causes(new UserActivated(Id));
        }
        public void UpdatePersonalInfo(string firstname, string lastname)
        {
            if (!IsActive)
            {
                throw new Exception("Can not update personal information of inactive user");
            }
            Causes(new UserPersonalInfoUpdated(firstname, lastname));
        }
        public override void Apply(DomainEvent @event)
        {
            When((dynamic)@event);
        }

        private void When(UserRegistered @event)
        {
            Id = @event.Id;
            FirstName = @event.FirstName;
            LastName = @event.LastName;
            Username = @event.Username;
            IsActive = false;
        }
        private void When(UserActivated @event)
        {
            IsActive = true;
        }
        private void When(UserPersonalInfoUpdated @event)
        {
            FirstName = @event.Firstname;
            LastName = @event.Lastname;
        }
    }
    public class UserRegistered : DomainEvent
    {
        public UserRegistered(Guid id, string username, string firstName, string lastName)
        {
            Id = id;
            Username = username;
            FirstName = firstName;
            LastName = lastName;
        }

        public Guid Id { get; private set; }
        public string Username { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
    }
    public class UserPersonalInfoUpdated : DomainEvent
    {
        public UserPersonalInfoUpdated(string firstname, string lastname)
        {
            Firstname = firstname;
            Lastname = lastname;
        }

        public string Firstname { get; private set; }
        public string Lastname { get; private set; }
    }
    public class UserActivated : DomainEvent
    {
        public UserActivated(Guid userId)
        {
            UserId = userId;
        }

        public Guid UserId { get; private set; }
    }
}