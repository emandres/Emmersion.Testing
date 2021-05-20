# Emmersion.Testing

A library for making Moq-based ("London style") unit-testing with NUnit easier.


## Usage

Add this project to your unit testing project, then have your test class extend `With_an_automocked<T>`.
Then in a test, `ClassUnderTest` will be an instance of `T` with all dependencies automatically mocked.

Here is an example:

```csharp
public class ExampleWorkflowTests : With_an_automocked<ExampleWorkflow>
{
    [Test]
    public void When_a_record_already_exists()
    {
        var recordId = NewGuid();
        var existingRecord = new Record { Name = "Test Record" };
        GetMock<IExampleRepository>().Setup(x => x.Load(recordId)).Returns(existingRecord);

        var result = ClassUnderTest.GetName(recordId);
        
        Assert.That(result, Is.EqualTo(existingRecord.Name));
    }
}
```


## Tips for adding Emmersion.Testing to a codebase
- Get Emmersion.Testing from Nuget
    - add a nuget restore step in the yaml if there isn't one
- Search for Moq to find files that are using mocks
- Extend the class with `With_an_automocked`
- Replace the mocks in the file with GetMocks
- Replace the instances of the class under test with ClassUnderTest
- Utilize helpers
    - It.IsAny -> IsAny
    - Guid.NewGuid() -> NewGuid()
    - Guid.NetGuid().ToString() -> RandomString()
    - Verifies with Times.Never -> VerifyNever(...)
- Remove Moq

# Version History
- 3.0 - Change namespace from `EL.` to `Emmersion.`
- 2.0 - Target `netstandard2.1` instead of `netstandard2.0`
- 1.0 - Initial release
