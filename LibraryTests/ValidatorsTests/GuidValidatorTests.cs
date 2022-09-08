using LibrarryCrudOps.Validators;

namespace LibraryTests.ValidatorsTests
{
    internal class GuidValidatorTests
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void GuidValidator_passingemptyGuid_ReturnFalse()
        {
            // arrange
            var attrib = new NonEmptyGuidAttribute(string.Empty);

            // act
            var result = attrib.IsValid(Guid.Empty);

            // assert
            Assert.That(result, Is.False);
        }
    }
}
