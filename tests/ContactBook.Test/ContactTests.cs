using Xunit;
using ContactBook;

namespace ContactBook.Tests
{
    public class ContactTests
    {
        [Fact]
        public void Constructor_DefaultValues_ShouldInitializeEmptyStrings()
        {
            var contact = new Contact();

            Assert.Equal("", contact.GetFname());
            Assert.Equal("", contact.GetLname());
            Assert.Equal("", contact.GetPhone());
            Assert.Equal("", contact.GetEmail());
        }

        [Fact]
        public void Constructor_WithValues_ShouldInitializeCorrectly()
        {
            var contact = new Contact("John", "Doe", "1234567890", "john@example.com");

            Assert.Equal("John", contact.GetFname());
            Assert.Equal("Doe", contact.GetLname());
            Assert.Equal("1234567890", contact.GetPhone());
            Assert.Equal("john@example.com", contact.GetEmail());
        }

        [Fact]
        public void Setters_ShouldUpdateValuesCorrectly()
        {
            var contact = new Contact();

            contact.SetFname("Jane");
            contact.SetLname("Smith");
            contact.SetPhone("9999999999");
            contact.SetEmail("jane@example.com");

            Assert.Equal("Jane", contact.GetFname());
            Assert.Equal("Smith", contact.GetLname());
            Assert.Equal("9999999999", contact.GetPhone());
            Assert.Equal("jane@example.com", contact.GetEmail());
        }

        [Fact]
        public void ToString_ShouldReturnCorrectFormat()
        {
            var contact = new Contact("John", "Doe", "123", "john@mail.com");

            var result = contact.ToString();

            Assert.Equal("Contact[fname=John, lname=Doe, phone=123, email=john@mail.com]", result);
        }

        [Fact]
        public void Equals_SameReference_ShouldReturnTrue()
        {
            var contact = new Contact("A", "B", "1", "a@mail.com");

            Assert.True(contact.Equals(contact));
        }

        [Fact]
        public void Equals_Null_ShouldReturnFalse()
        {
            var contact = new Contact();

            Assert.False(contact.Equals(null));
        }

        [Fact]
        public void Equals_SameValues_ShouldReturnTrue()
        {
            var c1 = new Contact("John", "Doe", "123", "john@mail.com");
            var c2 = new Contact("John", "Doe", "123", "john@mail.com");

            Assert.True(c1.Equals(c2));
        }

        [Fact]
        public void Equals_DifferentValues_ShouldReturnFalse()
        {
            var c1 = new Contact("John", "Doe", "123", "john@mail.com");
            var c2 = new Contact("Jane", "Doe", "123", "john@mail.com");

            Assert.False(c1.Equals(c2));
        }

        [Fact]
        public void Equals_ObjectOverride_WithSameValues_ShouldReturnTrue()
        {
            var c1 = new Contact("John", "Doe", "123", "john@mail.com");
            object c2 = new Contact("John", "Doe", "123", "john@mail.com");

            Assert.True(c1.Equals(c2));
        }

        [Fact]
        public void Operator_Equality_SameValues_ShouldReturnTrue()
        {
            var c1 = new Contact("John", "Doe", "123", "john@mail.com");
            var c2 = new Contact("John", "Doe", "123", "john@mail.com");

            Assert.True(c1 == c2);
        }

        [Fact]
        public void Operator_Equality_BothNull_ShouldReturnTrue()
        {
            Contact? c1 = null;
            Contact? c2 = null;

            Assert.True(c1 == c2);
        }

        [Fact]
        public void Operator_Equality_OneNull_ShouldReturnFalse()
        {
            var c1 = new Contact();
            Contact? c2 = null;

            Assert.False(c1 == c2);
        }

        [Fact]
        public void Operator_Inequality_DifferentValues_ShouldReturnTrue()
        {
            var c1 = new Contact("John", "Doe", "123", "john@mail.com");
            var c2 = new Contact("Jane", "Doe", "123", "john@mail.com");

            Assert.True(c1 != c2);
        }

        [Fact]
        public void GetHashCode_SameValues_ShouldBeEqual()
        {
            var c1 = new Contact("John", "Doe", "123", "john@mail.com");
            var c2 = new Contact("John", "Doe", "123", "john@mail.com");

            Assert.Equal(c1.GetHashCode(), c2.GetHashCode());
        }

        [Fact]
        public void GetHashCode_DifferentValues_ShouldBeDifferent()
        {
            var c1 = new Contact("John", "Doe", "123", "john@mail.com");
            var c2 = new Contact("Jane", "Doe", "123", "john@mail.com");

            Assert.NotEqual(c1.GetHashCode(), c2.GetHashCode());
        }
    }
}