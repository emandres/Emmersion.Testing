# EL.Testing

A library for making testing easier.


# Tips for adding EL.Testing to a codebase
- Get EL.Testing from Nuget
    - you may need to add a nuget.config to get the Emmersion feed
    - add a nuget restore step in the yaml if there isn't one
- Search for Moq to find files that are using mocks
- Extend the class with With_an_automocked
- Replace the mocks in the file with GetMocks
- Replace the instances of the class under test with ClassUnderTest
- Utilize helpers
    - It.IsAny -> IsAny
    - Guid.NewGuid() -> NewGuid()
    - Guid.NetGuid().ToString() -> RandomString()
    - Verifies with Times.Never -> VerifyNever(...)
- Remove Moq

# Version History
- 1.0 - Initial release
- 2.0 - Target `netstandard2.1` instead of `netstandard2.0`